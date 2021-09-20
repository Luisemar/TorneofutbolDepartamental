
using System;
namespace TorneoFutbolDptl.App.Dominio
{
    public class Partido
    {
        // Identificador único de cada Partido
        public int Id { get; set; }
        public int EquipoLocal {get;set;}
        public int EquipoVisita {get;set;}
        public int EquipoLocalMarca {get;set;}
        public int EquipoVisitaMarca {get;set;}
        public DateTime FechaHora  { get; set; }                        
        // Relacion entre Partido y el Arbitro Fk
        public Arbitro Arbitro { get; set; } 
        // Relacion entre Partido y el Estadio Fk
        public Estadio Estadio { get; set; } 
        // Relacion entre la Partido y la Novedad Fk
        public Novedad Novedad { get; set; }                 
    }
}