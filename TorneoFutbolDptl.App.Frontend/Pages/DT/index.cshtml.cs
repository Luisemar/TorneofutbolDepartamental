using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbolDptl.App.Dominio;
using TorneoFutbolDptl.App.Persistencia;

namespace TorneoFutbolDptl.App.Frontend.Pages.DT
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioDirectorTecnico _repoDT;
        public IEnumerable<DirectorTecnico> directorTecnicos {get; set;}
        public IndexModel(IRepositorioDirectorTecnico repoDT)
        {
            _repoDT = repoDT;
        }        
        public void OnGet()
        {
            directorTecnicos = _repoDT.GetAllDirectorTecnicos();            
        }
    }
}
