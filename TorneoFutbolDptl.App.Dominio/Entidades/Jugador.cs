namespace TorneoFutbolDptl.App.Dominio
{
    public class Jugador
    {
        // Identificador único de cada Jugador
        public int Id { get; set; }
        public string Nombre {get;set;}
        public string Numero {get;set;}
        // Relacion entre el Jugador y equipo FK
        public Equipo Equipo { get; set; }
        // Relacion entre el Jugador y la posion FK        
        public Posicion Posicion { get; set; }
    }
}
