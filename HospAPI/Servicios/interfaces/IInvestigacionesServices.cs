using HospAPI.DTOs;
using HospAPI.DTOs.InvetigacionDTOs;
using Microsoft.AspNetCore.Mvc;

namespace HospAPI.Servicios.interfaces
{
    public interface IInvestigacionesServices
    {
        Task<ActionResult> PostArticulo([FromForm] InsertarInvestigacionDTO insertarInvestigacionDTO, CancellationToken cancellationToken = default);
        Task<ActionResult<List<GetInvestigacionDTO>>> GetListaArticulos([FromQuery] PaginacionDTO paginacionDTO, CancellationToken cancellationToken = default);
        Task<ActionResult<List<GetInvestigacionDTO>>> GetInvestigacionPorNombre(string nombre, CancellationToken cancellationToken = default);
        Task<ActionResult<GetInvestigacionDTO>> Get(int id, CancellationToken cancellationToken = default);
        Task<ActionResult<List<GetMedicosFiltroDTO>>> GetInvestigacionPorDatosMedico([FromQuery] MedicoInvestigacionDTO medicoInvestigacionDTO, int pagina = 1, CancellationToken cancellationToken = default);
        Task<ActionResult<List<GetInvestigacionDTO>>> GetInvestigacionPorDatos([FromQuery] InvestigacionFiltroDTO investigacionFiltroDTO,
            [FromQuery] PaginacionDTO paginacionDTO, CancellationToken cancellationToken = default);

    }
}
