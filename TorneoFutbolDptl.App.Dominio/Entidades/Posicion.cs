
namespace TorneoFutbolDptl.App.Dominio
{
    public class Posicion
    {
        // Identificador único de cada posicion
        public int Id { get; set; }
        public string Nombre {get;set;}
        
    }
    public enum Puesto
    {
        Arquero,
        Defensa,
        Centrocampista,
        Mediocampista,
        Volante,
        Mediapunta,
        Delantero,
        Puntero


    }
}