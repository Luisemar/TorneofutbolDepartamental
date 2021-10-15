using System.Collections.Generic;
using System.Linq;
using TorneoFutbolDptl.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace TorneoFutbolDptl.App.Persistencia
{
    public class RepositorioPartido : IRepositorioPartido
    {
        private readonly AppContext _appContext = new AppContext();

        Partido IRepositorioPartido.AddPartido(Partido partido)        
        {
            var PartidoAdicionado = _appContext.Partidos.Add(partido);
            _appContext.SaveChanges();
            return PartidoAdicionado.Entity;

        }
        
        Partido IRepositorioPartido.GetPartido(int idPartido)
        {
            var partido = _appContext.Partidos
                .Where(p => p.Id == idPartido)
                .Include(p => p.Arbitro)
                .FirstOrDefault();
        return partido;
        }

        Partido IRepositorioPartido.GetPartidoEV(int idPartido)
        {
            var partido = _appContext.Partidos
                .Where(p => p.Id == idPartido)
                .Include(p => p.EquipoVisita)
                .FirstOrDefault();
        return partido;                
        }

        public Partido UpdatePartidoEVM(Partido partido)
        {
            var partidoEncontrado= _appContext.Partidos.FirstOrDefault(p => p.Id==partido.Id);
            if (partidoEncontrado !=null)
            {
                partidoEncontrado.Id=partido.Id;                
                partidoEncontrado.EquipoVisitaMarca=partido.EquipoVisitaMarca;                              
                _appContext.SaveChanges();
            }
            return partidoEncontrado; 
        }   
	
	public Partido UpdatePartidoELM(Partido partido)
        {
            var partidoEncontrado= _appContext.Partidos.FirstOrDefault(p => p.Id==partido.Id);
            if (partidoEncontrado !=null)
            {
                partidoEncontrado.Id=partido.Id;                
                partidoEncontrado.EquipoLocalMarca=partido.EquipoLocalMarca;                              
                _appContext.SaveChanges();
            }
            return partidoEncontrado; 
        } 

        void IRepositorioPartido.DeletePartido(int idPartido)
        {
            var partidoEncontrado = _appContext.Partidos.Find(idPartido);
            if (partidoEncontrado == null)
                return;
            _appContext.Partidos.Remove(partidoEncontrado);
            _appContext.SaveChanges();
        } 
        
        IEnumerable<Partido> IRepositorioPartido.GetAllPartidos()
        {
            return _appContext.Partidos;
        }

        public Partido UpdatePartido(Partido partido)
        {
            var partidoEncontrado= _appContext.Partidos.FirstOrDefault(p => p.Id==partido.Id);
            if (partidoEncontrado !=null)
            {
                partidoEncontrado.Id=partido.Id;
                partidoEncontrado.EquipoLocal=partido.EquipoLocal;
                partidoEncontrado.EquipoVisita=partido.EquipoVisita;
                partidoEncontrado.EquipoLocalMarca=partido.EquipoLocalMarca;
                partidoEncontrado.EquipoVisitaMarca=partido.EquipoVisitaMarca;
                partidoEncontrado.FechaHora=partido.FechaHora;
                partidoEncontrado.Arbitro=partido.Arbitro;
                partidoEncontrado.Estadio=partido.Estadio;
                partidoEncontrado.Novedad=partido.Novedad;


                _appContext.SaveChanges();
            }
            return partidoEncontrado; 
        }           

        // Código ya implementado
        Arbitro IRepositorioPartido.AsignarArbitroPartido(int idPartido, int idArbitro)
        { var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.Id == idPartido);
        if ( partidoEncontrado != null)
            { var arbitroEncontrado = _appContext.Arbitros.FirstOrDefault(m => m.Id == idArbitro);
        if ( arbitroEncontrado != null)
            { partidoEncontrado.Arbitro = arbitroEncontrado;
           _appContext.SaveChanges();
             }
          return arbitroEncontrado;
          }
        return null;
        }


        // Código ya implementado
       Estadio IRepositorioPartido.AsignarEstadioPartido(int idPartido, int idEstadio)
        { var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.Id == idPartido);
        if ( partidoEncontrado != null)
            { var estadioEncontrado = _appContext.Estadios.FirstOrDefault(m => m.Id == idEstadio);
        if ( estadioEncontrado != null)
            { partidoEncontrado.Estadio = estadioEncontrado;
           _appContext.SaveChanges();
             }
          return estadioEncontrado;
          }
        return null;
        }

       // Código ya implementado
        Novedad IRepositorioPartido.AsignarNovedadPartido(int idPartido, int idNovedad)
        { var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.Id == idPartido);
        if ( partidoEncontrado != null)
            { var novedadEncontrado = _appContext.Novedades.FirstOrDefault(m => m.Id == idNovedad);
        if ( novedadEncontrado != null)
            { partidoEncontrado.Novedad = novedadEncontrado;
           _appContext.SaveChanges();
             }
          return novedadEncontrado;
          }
        return null;
        }

        Equipo IRepositorioPartido.AsignarEquipoPartido(int idPartido, int idEquipo)
        { var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.Id == idPartido);
        if ( partidoEncontrado != null)
            { var equipoEncontrado = _appContext.Equipos.FirstOrDefault(m => m.Id == idEquipo);
        if ( equipoEncontrado != null)
        //Sale error porque Arbitro si es una entidad y EquipoVisita es un int
            { partidoEncontrado.EquipoVisita = equipoEncontrado.Id;
           _appContext.SaveChanges();
            }
          return equipoEncontrado;
          }
        return null;
        }
	
	 Equipo IRepositorioPartido.AsignarEquipoELPartido(int idPartido, int idEquipo)
        { var partidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.Id == idPartido);
        if ( partidoEncontrado != null)
            { var equipoEncontrado = _appContext.Equipos.FirstOrDefault(m => m.Id == idEquipo);
        if ( equipoEncontrado != null)
            { partidoEncontrado.EquipoLocal = equipoEncontrado.Id;
           _appContext.SaveChanges();
             }
          return equipoEncontrado;
          }
        return null;
        }

    }
}