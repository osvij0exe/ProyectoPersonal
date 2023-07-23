using HospAPI.DTOs;
using HospAPI.DTOs.MedcosDTOs;
using Microsoft.AspNetCore.Mvc;

namespace HospAPI.Servicios.interfaces
{
    public interface IMedicosServices
    {
            Task<IEnumerable<GetMedicoDTO>> getMedicoListAsync(int pagina = 1, CancellationToken cancellationToken = default);
            Task<ActionResult> PostMedicoAsync(InsertarMedicoDTO insertarMedicoDTO, CancellationToken cancellationToken = default);
            Task<ActionResult<List<GetMedicoDTO>>> getMedicoListConDTOAsync([FromQuery] PaginacionDTO paginacionDTO, CancellationToken cancellationToken = default);
            Task<ActionResult<GetMedicoDTO>> GetMedicoAsync(int id, CancellationToken cancellationToken = default);
            Task<ActionResult<List<GetMedicoDTO>>> GetByNameAsync(string nombre, CancellationToken cancellationToken = default);
            Task<ActionResult<GetMedicoDTO>> GetByMatriculaAsync(int matriucla, CancellationToken cancellationToken = default);
            Task<ActionResult<GetMedicoDTO>> GetByCedulaAsync(int cedula, CancellationToken cancellationToken = default);
            Task<ActionResult<List<GetMedicoDTO>>> FiltrarParametroAsync([FromQuery] MedicoFiltroDTO medicoFiltroDTO, CancellationToken cancellationToken = default);
            Task<ActionResult> PutActualizacionAsync(InsertarMedicoDTO insertarMedicoDTO, int id, CancellationToken cancellationToken = default);
            Task<ActionResult> DeleteAsync(int id, CancellationToken cancellationToken);
            Task<ActionResult> RestaurarAsync(int id, CancellationToken cancellationToken = default);
    }

}
