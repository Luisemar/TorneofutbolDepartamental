using System;
using System.ComponentModel.DataAnnotations;
namespace TorneoFutbolDptl.App.Dominio
{
    public class Equipo
    {
        // Identificador único de cada Equipo
        public int Id { get; set; }

        [Display(Name = "Nombre del Equipo: ")]
    
        public string Nombre { get; set; }
        // Relacion entre Equipo y el municipio Fk
        [Display(Name = "Municipio del Equipo: ")]
        public Municipio Municipio {get; set;}
        // Relacion entre Equipo y DT  Fk
        [Display(Name = "DT del equipo")]
        public DirectorTecnico DirectorTecnico { get; set; }
    }
}