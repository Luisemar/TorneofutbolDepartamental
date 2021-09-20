using System;
namespace TorneoFutbolDptl.App.Dominio
{
    public class Novedad
    {
        // Identificador único de cada Novedad
        public int Id { get; set; }
        public int TarjetaAmarilla {get;set;}
        public DateTime FechaHoraTA  { get; set; }
        public int TarjetaRoja {get;set;}
        public DateTime FechaHoraTR  { get; set; }
        public int GolEquipoLocal {get;set;}
        public DateTime FechaGEl { get; set; }                              
        public int GolEquipoVisita {get;set;}
        public DateTime FechaGEV  { get; set; }         
        public int EquipoLocalMarca {get;set;}
        public int EquipoVisitaMarca {get;set;}
        public DateTime FechaHora  { get; set; }                        
        // Relacion entre la Novedad y el Jugador Fk
        public Jugador Jugador { get; set; } 
    }
}