﻿namespace HospAPI.DTOs
{
    public class PaginacionDTO
    {
        public int Pagina { get; set; } = 1;
        private int recordsPorPagina = 10;
        private readonly int cantidadMaximaPorPagina = 20;

        public int RecorsPorPagina
        {
            get
            {
                return recordsPorPagina;
            }
            set
            {
                recordsPorPagina = (value > cantidadMaximaPorPagina) ? cantidadMaximaPorPagina: value;
            }
        }
    }
}
