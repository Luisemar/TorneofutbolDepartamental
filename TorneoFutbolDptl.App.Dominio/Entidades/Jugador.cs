using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
namespace TorneoFutbolDptl.App.Dominio
{
    public class Jugador
    {
        // Identificador único de cada Jugador
        public int Id { get; set; }


        [Required(ErrorMessage = "Debe agregar el nombre completo del jugador")]
        [StringLength(60, ErrorMessage = "Máximo 60 caracteres")]
        [MinLength(8, ErrorMessage = "Mínimo 8 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre {get;set;}
        [StringLength(2, ErrorMessage = "Máximo 2 cifras")]
        [Display(Name = "Número del jugador")]
        public string Numero {get;set;}
        // Relacion entre el Jugador y equipo FK
        public Equipo Equipo { get; set; }
        // Relacion entre el Jugador y la posion FK        
        [Display(Name = "Posición")]
        public Posicion Posicion { get; set; }
        //jdjjd
    }
}
