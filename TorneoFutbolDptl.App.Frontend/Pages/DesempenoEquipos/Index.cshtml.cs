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
    public class IndexModel : PageModel
    {
        private readonly IRepositorioDesempenoEquipo _repoDesempenoEquipo;
        public IEnumerable<DesempenoEquipo> desempenoEquipos {get; set;}

        public IndexModel(IRepositorioDesempenoEquipo repoDesempenoEquipo)
        {
            _repoDesempenoEquipo = repoDesempenoEquipo;
        }

        public void OnGet()
        {
            desempenoEquipos = _repoDesempenoEquipo.GetAllDesempenoEquipos();
            
        }
    }
}