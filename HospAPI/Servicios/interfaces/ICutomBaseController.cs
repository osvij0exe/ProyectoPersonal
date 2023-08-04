using HospAPI.DTOs;
using HospAPI.DTOs.MedcosDTOs;
using HospAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospAPI.Servicios.interfaces
{
    public interface ICutomBaseController
    {
        Task<ActionResult> PostMedicoAsync<TInsertar,TEntidad>(TInsertar insertarDTO,TEntidad tentidad, CancellationToken cancellationToken = default) where TEntidad : class;
        Task<ActionResult> PutActualizacionAsync(InsertarMedicoDTO insertarMedicoDTO, int id, CancellationToken cancellationToken = default);
        Task<ActionResult> DeleteAsync(int id, CancellationToken cancellationToken);
        Task<ActionResult> RestaurarAsync(int id, CancellationToken cancellationToken = default);
    }
}
