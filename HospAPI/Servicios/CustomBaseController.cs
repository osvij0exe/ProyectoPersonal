using AutoMapper;
using HospAPI.DTOs.MedcosDTOs;
using HospAPI.DTOs;
using HospAPI.Servicios.interfaces;
using HospAPI.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using HospAPI.Models;

namespace HospAPI.Servicios
{
    public class CustomBaseController : ControllerBase, ICutomBaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomBaseController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        /*********************************************************************/
        /*                       METODO POST                                 */
        /*                    INSERTAR REGISTROS                             */
        /*********************************************************************/
        public Task<ActionResult> PostMedicoAsync<TInsertar, TEntidad>(TInsertar insertarDTO, TEntidad tentidad, CancellationToken cancellationToken = default) where TEntidad : class
        {
            throw new NotImplementedException();
        }


        /*********************************************************************/
        /*                       METODO GET                                 */
        /*                  CONSULTAR REGISTROS                             */
        /*********************************************************************/



        /*********************************************************************/
        /*                           METODO PUT                              */
        /*                     ACTUALIZAR REGISTROS                          */
        /*********************************************************************/

        public Task<ActionResult> PutActualizacionAsync(InsertarMedicoDTO insertarMedicoDTO, int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }



        /*********************************************************************/
        /*                       METODO DELETE/POST                           */
        /*                    BORRAR REGISTROS LOGICO                        */
        /*********************************************************************/

        public Task<ActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }



        public Task<ActionResult> RestaurarAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }


    }
}