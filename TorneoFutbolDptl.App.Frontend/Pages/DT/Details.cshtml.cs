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
    public class DetailsModel : PageModel

    {
        private readonly IRepositorioDirectorTecnico _repoDT;
        public DirectorTecnico directorTecnico {get; set;}        

         public DetailsModel (IRepositorioDirectorTecnico repoDT)
        {
        _repoDT= repoDT;

        }
        public IActionResult OnGet(int id)
        {
            directorTecnico = _repoDT.GetDirectorTecnico(id);
            if (directorTecnico == null)
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
