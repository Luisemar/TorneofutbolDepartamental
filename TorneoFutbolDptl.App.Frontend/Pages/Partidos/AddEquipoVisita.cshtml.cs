using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbolDptl.App.Dominio;
using TorneoFutbolDptl.App.Persistencia;

namespace TorneoFutbolDptl.App.Frontend.Pages.Partidos
{
    public class AddEquipoVisitaModel : PageModel
    {

        private readonly IRepositorioPartido _repoPartido;
        private readonly IRepositorioEquipo _repoEquipo;
        public Partido partido {get; set;}
        public IEnumerable<Equipo> equipos {get; set;}
        public AddEquipoVisitaModel(IRepositorioPartido repoPartido, IRepositorioEquipo repoEquipo)
        {
            _repoPartido = repoPartido;
            _repoEquipo = repoEquipo;
        }

        public void OnGet(int id)
        {
            partido = _repoPartido.GetPartido(id);
            equipos = _repoEquipo.GetAllEquipos();
        }

        public IActionResult OnPost(int idPartido, int idEquipo)
        {
            _repoPartido.AsignarEquipoPartido(idPartido, idEquipo);
            return RedirectToPage("Details", new{id = idPartido});
        }
    }
}