using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbolDptl.App.Dominio;
using TorneoFutbolDptl.App.Persistencia;

namespace TorneoFutbolDptl.App.Frontend.Pages.DesempenoEquipos
{
    public class DeleteModel : PageModel
    {
        private readonly IRepositorioDesempenoEquipo _repoDesempenoEquipo;
        public DesempenoEquipo desempenoEquipo {get; set;}
        public DeleteModel(IRepositorioDesempenoEquipo repoDesempenoEquipo)
        {
            _repoDesempenoEquipo = repoDesempenoEquipo;
        }

        public IActionResult OnGet(int id)
        {
            desempenoEquipo = _repoDesempenoEquipo.GetDesempenoEquipo(id);
            if(desempenoEquipo == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(DesempenoEquipo desempenoEquipo)
        {
            _repoDesempenoEquipo.DeleteDesempenoEquipo(desempenoEquipo.Id);
            return RedirectToPage("Index");
        }
    }
}