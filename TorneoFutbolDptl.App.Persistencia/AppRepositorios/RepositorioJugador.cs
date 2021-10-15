using System.Collections.Generic;
using System.Linq;
using TorneoFutbolDptl.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace TorneoFutbolDptl.App.Persistencia
{
    public class RepositorioJugador : IRepositorioJugador
    {
        private readonly AppContext _appContext = new AppContext();

        Jugador IRepositorioJugador.AddJugador(Jugador jugador)        
        {
            var JugadorAdicionado = _appContext.Jugadores.Add(jugador);
            _appContext.SaveChanges();
            return JugadorAdicionado.Entity;

        }
       
        Jugador IRepositorioJugador.GetJugador(int idJugador)
        {
            var jugador = _appContext.Jugadores
                .Where(p => p.Id == idJugador)
                .Include(p => p.Equipo)
                .Include(p => p.Posicion)
                .FirstOrDefault();
        return jugador;
        }

        void IRepositorioJugador.DeleteJugador(int idJugador)
        {
            var jugadorEncontrado = _appContext.Jugadores.Find(idJugador);
            if (jugadorEncontrado == null)
                return;
            _appContext.Jugadores.Remove(jugadorEncontrado);
            _appContext.SaveChanges();
        } 
        
        IEnumerable<Jugador> IRepositorioJugador.GetAllJugadores()
        {
            return _appContext.Jugadores
            .Include(p => p.Equipo)
            .Include(p => p.Posicion);
        }

        public Jugador UpdateJugador(Jugador jugador)
        {
            var jugadorEncontrado= _appContext.Jugadores.FirstOrDefault(p => p.Id==jugador.Id);
            if (jugadorEncontrado !=null)
            {
                jugadorEncontrado.Nombre=jugador.Nombre;
                jugadorEncontrado.Numero=jugador.Numero;
                jugadorEncontrado.Posicion=jugador.Posicion;
                jugadorEncontrado.Equipo=jugador.Equipo;
                _appContext.SaveChanges();
            }
            return jugadorEncontrado; 
        }           

        // Código ya implementado
        Equipo IRepositorioJugador.AsignarEquipoJugador(int idJugador, int idEquipo)
        { var jugadorEncontrado = _appContext.Jugadores.Find(idJugador); 
        if ( jugadorEncontrado != null)
            { 
                var equipoEncontrado = _appContext.Equipos.Find(idEquipo);
                if ( equipoEncontrado != null)
               {
                    jugadorEncontrado.Equipo = equipoEncontrado;
                   _appContext.SaveChanges();
                }
                return equipoEncontrado;
            }
        return null;
        }

        // Código ya implementado
        Posicion IRepositorioJugador.AsignarPosicionJugador(int idJugador, int idPosicion)
        { var jugadorEncontrado = _appContext.Jugadores.FirstOrDefault(p => p.Id == idJugador);
        if ( jugadorEncontrado != null)
            { 
                var posicionEncontrado = _appContext.Posiciones.FirstOrDefault(m => m.Id == idPosicion);
                if ( posicionEncontrado != null)
               {
                    jugadorEncontrado.Posicion = posicionEncontrado;
                   _appContext.SaveChanges();
                }
                return  posicionEncontrado;
            }
        return null;
        }  

        IEnumerable<Jugador> IRepositorioJugador.SearchJugadores(string nombre)
        {
            return _appContext.Jugadores
                .Where(p => p.Nombre.Contains(nombre));
        }

        

    }
}