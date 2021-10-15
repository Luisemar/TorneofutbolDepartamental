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
    public class DetailsModel : PageModel

    {
        private readonly IRepositorioDesempenoEquipo _repoDesempenoEquipo;
        public DesempenoEquipo desempenoEquipo {get; set;}        

         public DetailsModel (IRepositorioDesempenoEquipo repoDesempenoEquipo)
        {
        _repoDesempenoEquipo= repoDesempenoEquipo;

        }
        public IActionResult OnGet(int id)
        {
            desempenoEquipo = _repoDesempenoEquipo.GetDesempenoEquipo(id);
            if (desempenoEquipo == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
    }

}    