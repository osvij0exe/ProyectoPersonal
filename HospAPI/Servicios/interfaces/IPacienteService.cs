using HospAPI.DTOs;
using HospAPI.DTOs.PacientesDTOs;
using Microsoft.AspNetCore.Mvc;

namespace HospAPI.Servicios.interfaces
{
    public interface IPacienteService
    {
        Task<ActionResult> PostPacienteAsync(InsertarPacienteDTO insertarPacienteDTO,CancellationToken cancellationToken = default );
        Task<ActionResult<List<GetPacienteDTO>>> GetListaPacienteAsync([FromQuery] PaginacionDTO paginacionDTO, CancellationToken cancellationToken = default);
        Task<ActionResult<GetPacienteDTO>> GetPacienteIdAsync(int id, CancellationToken cancellationToken = default);
        Task<ActionResult<GetPacienteDTO>> GetPacienteNssAsync(int nss, CancellationToken cancellationToken = default);
        Task<ActionResult<List<GetPacienteDTO>>> GetPacientePorNombreAsync(string nombre, CancellationToken cancellationToken = default);
        Task<ActionResult<List<GetPacienteDTO>>> GetfiltroAsync([FromQuery] PacienteFiltro pacienteFiltro, CancellationToken cancellationToken = default);
        Task<ActionResult> PutPacienteAsync(ActualizarPacienteDTO actualizarPacienteDTO, int id, CancellationToken cancellationToken = default);
        Task<ActionResult> DeletePacienteAsync(int id, CancellationToken cancellationToken = default);
        Task<ActionResult> RestaurarPacienteAsync(int id, CancellationToken cancellationToken = default);
    }
}
