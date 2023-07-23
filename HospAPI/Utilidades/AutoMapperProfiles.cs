using AutoMapper;
using HospAPI.DTOs.InvetigacionDTOs;
using HospAPI.DTOs.MedcosDTOs;
using HospAPI.DTOs.PacientesDTOs;
using HospAPI.Models;

namespace HospAPI.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //CreateMap<Fuente, Destino>()
            CreateMap<InsertarMedicoDTO, Medico>();
            CreateMap<Medico, GetMedicoDTO>();
            CreateMap<MedicoFiltroDTO, GetMedicoDTO>();

            CreateMap<InsertarPacienteDTO, Paciente>();
            CreateMap<Paciente, GetPacienteDTO>();
            CreateMap<PacienteFiltro, GetPacienteDTO>();
            CreateMap<ActualizarPacienteDTO, Paciente>();

            CreateMap<InsertarInvestigacionDTO, Investigacion>()
            //mapear los medicos NOTA: en el DTO la relacion de los medicos debe ser int 
            //para tener una coleccion de enteros
            .ForMember(modelDb => modelDb.Medicos,
                dto => dto.MapFrom(campo => campo.Medicos.Select(id => new Medico() { MedicoId = id })));
            CreateMap<Investigacion, GetInvestigacionDTO>();
            CreateMap<Investigacion,MedicoInvestigacionDTO>();
            CreateMap<MedicoInvestigacionDTO,Investigacion>();
            CreateMap<Medico,MedicoInvestigacionDTO>().ReverseMap();
            CreateMap<Medico,GetMedicosFiltroDTO>().ReverseMap();
            CreateMap<Investigacion, InvestigacionFiltroDTO>();

        }
    }
}
