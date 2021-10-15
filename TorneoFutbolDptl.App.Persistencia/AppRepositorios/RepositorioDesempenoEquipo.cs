using System.Collections.Generic;
using System.Linq;
using TorneoFutbolDptl.App.Dominio;
using Microsoft.EntityFrameworkCore;
using System;

namespace TorneoFutbolDptl.App.Persistencia
{
    public class RepositorioDesempenoEquipo : IRepositorioDesempenoEquipo
    {
        private readonly AppContext _appContext = new AppContext();

        DesempenoEquipo IRepositorioDesempenoEquipo.AddDesempenoEquipo(DesempenoEquipo desempenoEquipo)        
        {
            var DesempenoEquipoAdicionado = _appContext.DesempenoEquipos.Add(desempenoEquipo);
            _appContext.SaveChanges();
            return DesempenoEquipoAdicionado.Entity;

        }
       
        DesempenoEquipo IRepositorioDesempenoEquipo.GetDesempenoEquipo(int idDesempenoEquipo)
        {
            var desempenoEquipo = _appContext.DesempenoEquipos
                .Where(p => p.Id == idDesempenoEquipo)
                .Include(p => p.Equipo)
                .FirstOrDefault();
        return desempenoEquipo;
        }

        void IRepositorioDesempenoEquipo.DeleteDesempenoEquipo(int idDesempenoEquipo)
        {
            var desempenoEquipoEncontrada = _appContext.DesempenoEquipos.Find(idDesempenoEquipo);
            if (desempenoEquipoEncontrada == null)
                return;
            _appContext.DesempenoEquipos.Remove(desempenoEquipoEncontrada);
            _appContext.SaveChanges();
        } 
        
       IEnumerable<DesempenoEquipo> IRepositorioDesempenoEquipo.GetAllDesempenoEquipos()
        {
           
           List<DesempenoEquipo> temporal = _appContext.DesempenoEquipos.OrderByDescending(o => o.PuntosAcumulados).ToList();
            
        return temporal;
        }
        
        public DesempenoEquipo UpdateDesempenoEquipo(DesempenoEquipo desempenoEquipo)
        {
            var desempenoEquipoEncontrada= _appContext.DesempenoEquipos.FirstOrDefault(p => p.Id==desempenoEquipo.Id);
            if (desempenoEquipoEncontrada !=null)
            {
                desempenoEquipoEncontrada.Id=desempenoEquipo.Id;
                _appContext.SaveChanges();
            }
            return desempenoEquipoEncontrada; 
        }         

        // Código ya implementado
        Equipo IRepositorioDesempenoEquipo.AsignarEquipo(int idDesempenoEquipo, int idEquipo)
        { var desempenoEquiposEncontrado = _appContext.DesempenoEquipos.FirstOrDefault(p => p.Id == idDesempenoEquipo);
        if ( desempenoEquiposEncontrado != null)
            { var equipoEncontrado = _appContext.Equipos.FirstOrDefault(m => m.Id == idEquipo);
        if ( equipoEncontrado != null)
            { desempenoEquiposEncontrado.Equipo = equipoEncontrado;
           _appContext.SaveChanges();
             }
          return equipoEncontrado;
          }
        return null;
        }
    }
}