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
    public class IndexModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        public IEnumerable<Equipo> equipos { get; set; }
        public string bActual { get; set; }
        public IndexModel(IRepositorioEquipo repoEquipo)
        {
            _repoEquipo = repoEquipo;
        }
        public void OnGet(string b)

        {
            if (String.IsNullOrEmpty(b))
            {
                bActual = "";
                equipos = _repoEquipo.GetAllEquipos();
            }
            else
            {
                bActual = b;
                equipos = _repoEquipo.SearchEquipos(b);
            }

        }
    }
}

