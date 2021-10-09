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
    public class CreateModel : PageModel
    {
        private readonly IRepositorioDirectorTecnico _repoDT;
        public DirectorTecnico directorTecnico {get; set;}
        public CreateModel(IRepositorioDirectorTecnico repoDT)
        {
            _repoDT = repoDT;
        }
        public void OnGet()
        {
            directorTecnico = new DirectorTecnico();
        }

        public IActionResult OnPost(DirectorTecnico directorTecnico)
        {
            if (ModelState.IsValid)
            {
                _repoDT.AddDirectorTecnico(directorTecnico);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}