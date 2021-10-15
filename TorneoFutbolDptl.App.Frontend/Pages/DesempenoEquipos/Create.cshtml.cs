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
    public class CreateModel : PageModel
    {
        private readonly IRepositorioDesempenoEquipo _repoDesempenoEquipo;
        public DesempenoEquipo desempenoEquipo {get; set;}
        public CreateModel(IRepositorioDesempenoEquipo repoDesempenoEquipo)
        {
            _repoDesempenoEquipo = repoDesempenoEquipo;
        }
        public void OnGet()
        {
            desempenoEquipo = new DesempenoEquipo();
        }

        public IActionResult OnPost(DesempenoEquipo desempenoEquipo)
        {
            if (ModelState.IsValid)
            {
                _repoDesempenoEquipo.AddDesempenoEquipo(desempenoEquipo);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
