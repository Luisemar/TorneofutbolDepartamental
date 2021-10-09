using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbolDptl.App.Dominio;
using TorneoFutbolDptl.App.Persistencia;

namespace TorneoFutbolDptl.App.Frontend.Pages.Equipos
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        public Equipo equipo {get; set;}
        public EditModel(IRepositorioJugador repoJugador)
        {
            _repoEquipo = repoEquipo;
        }

        public IActionResult OnGet(int id)
        {
            Equipo = _repoEquipo.GetEquipo(id);
            if(equipo == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(Equipo equipo)
        {
            _repoEquipo.UpdatEquipo(equipo);
            return RedirectToPage("Index");
        }
    }
}