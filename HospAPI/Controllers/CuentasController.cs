using AutoMapper;
using HospAPI.DTOs;
using HospAPI.DTOs.CuentasDTOs;
using HospAPI.Utilidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HospAPI.Controllers
{
    [ApiController]
    [Route("api/cuentas")]
    public class CuentasController: ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CuentasController(
            UserManager<IdentityUser> userManager,
            IConfiguration configuration,
            SignInManager<IdentityUser> signInManager,
            ApplicationDbContext context,
            IMapper mapper)
        {
            _userManager   = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _context = context;
            _mapper = mapper;
        }


        /*********************************************************************/
        /*                       METODO POST                                 */
        /*                      CREAR USUARIO                                */
        /*********************************************************************/


        [HttpPost("registrar")]
        public async Task<ActionResult<UerToken>> Registrar(CredencialesUsuario credencialesUsuario)
        {
            var usuario = new IdentityUser
            {
                UserName = credencialesUsuario.Email,
                Email = credencialesUsuario.Email
            };
            var resultado = await _userManager.CreateAsync(usuario, credencialesUsuario.Password);

            if(resultado.Succeeded)
            {
                return await ConstruirToken(credencialesUsuario);
            }
            else
            {
                return BadRequest(resultado.Errors);
            }




        }
        [HttpPost("login")]
        public async Task<ActionResult<UerToken>> login(CredencialesUsuario credencialesUsuario)
        {
            var resultado = await _signInManager.PasswordSignInAsync(credencialesUsuario.Email,
                credencialesUsuario.Password, isPersistent: false, lockoutOnFailure: false);

            if(resultado.Succeeded)
            {
                return await ConstruirToken(credencialesUsuario);
            }
            else
            {
                return BadRequest("login incorrecto");
            }
        }

        [HttpPost("AsignarRol")]
        public async Task<ActionResult> AsignarRol(EditarRoleDTO editarRoleDTO)
        {
            var usuario = await _userManager.FindByIdAsync(editarRoleDTO.UsuarioId);
            if (usuario == null)
            {
                return NotFound();
            }

            await _userManager.AddClaimAsync(usuario, new Claim(ClaimTypes.Role, editarRoleDTO.NombreRol));
            return NoContent();
        }
        [HttpPost("RemoverRol")]
        public async Task<ActionResult> RemoverRol(EditarRoleDTO editarRole)
        {
            var usuario = await _userManager.FindByIdAsync(editarRole.UsuarioId);

            if (usuario == null)
            {
                return NotFound();
            }


            await _userManager.RemoveClaimAsync(usuario, new Claim(ClaimTypes.Role, editarRole.NombreRol));
            return NoContent();
        }



        /*********************************************************************/
        /*                       METODO GET                                 */
        /*                  CONSULTAR REGISTROS                             */
        /*********************************************************************/

        [HttpGet("ObtenerUsuario")]
        public async Task<ActionResult<List<UsuarioDTO>>> GetUusario([FromQuery] PaginacionDTO paginacionDTO, CancellationToken cancellationToken)
        {
            var queryableUser = _context.Users.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryableUser);

            var Usuarios = await queryableUser.OrderBy(UsuariosDB => UsuariosDB.Email).Paginar(paginacionDTO).ToListAsync(cancellationToken);

            return _mapper.Map<List<UsuarioDTO>>(Usuarios);
        }


        [HttpGet("Rol")]
        public async Task<ActionResult<List<string>>> GetRols()
        {
            return await _context.Roles.Select(x => x.Name).ToListAsync();
        }



        /*************************************************************************/

        [HttpGet("RenovarToken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<UerToken>> Renovar()
        {
            var emailClaim =  HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim.Value;
            var credencialesUsuario = new CredencialesUsuario()
            {
                Email = email,
            };

            return await ConstruirToken(credencialesUsuario);
        }
        /***************************************************************************/
        /**********                       métodos                         **********/
        /***************************************************************************/

        private async Task<UerToken> ConstruirToken(CredencialesUsuario credencialesUsuario)
        {
            var claims = new List<Claim>()
            {
                new Claim("email", credencialesUsuario.Email),
            };
            var usuario   = await _userManager.FindByEmailAsync(credencialesUsuario.Email);

            claims.Add(new Claim(ClaimTypes.NameIdentifier,usuario.Id ));

            var claimsDB = await _userManager.GetClaimsAsync(usuario);

            claims.AddRange(claimsDB);

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["llavejwt"]));
            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);
            //tiempo de duracion del token
            var expiracion = DateTime.UtcNow.AddDays(1);

            var sercurityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
                expires: expiracion, signingCredentials: creds);

            return new UerToken()
            {
                // devuelve el string del token
                Token = new JwtSecurityTokenHandler().WriteToken(sercurityToken),
                Expiracion = expiracion,
            };
        }



    }
}
