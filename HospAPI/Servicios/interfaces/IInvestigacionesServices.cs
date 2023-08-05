using HospAPI.DTOs;
using HospAPI.DTOs.InvetigacionDTOs;
using Microsoft.AspNetCore.Mvc;

namespace HospAPI.Servicios.interfaces
{
    public interface IInvestigacionesServices
    {
        Task<ActionResult> PostArticuloAsync([FromForm] InsertarInvestigacionDTO insertarInvestigacionDTO, CancellationToken cancellationToken = default);
        Task<ActionResult<List<GetInvestigacionDTO>>> GetListaArticulosAsync([FromQuery] PaginacionDTO paginacionDTO, CancellationToken cancellationToken = default);
        Task<ActionResult<List<GetInvestigacionDTO>>> GetInvestigacionPorNombreAsync(string nombre, CancellationToken cancellationToken = default);
        Task<ActionResult<GetInvestigacionDTO>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<ActionResult<List<GetMedicosFiltroDTO>>> GetInvestigacionPorDatosMedicoAsync([FromQuery] MedicoInvestigacionDTO medicoInvestigacionDTO, int pagina = 1, CancellationToken cancellationToken = default);
        Task<ActionResult<List<GetInvestigacionDTO>>> GetInvestigacionPorDatosAsync([FromQuery] InvestigacionFiltroDTO investigacionFiltroDTO,
            [FromQuery] PaginacionDTO paginacionDTO, CancellationToken cancellationToken = default);

    }
}
