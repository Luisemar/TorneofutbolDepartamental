using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbolDptl.App.Dominio;
using TorneoFutbolDptl.App.Persistencia;

namespace TorneoFutbolDptl.App.Frontend.Pages.Estadios
{
    public class DeleteModel : PageModel
    {
        private readonly IRepositorioEstadio _repoEstadio;
        public Estadio estadio {get; set;}
        public DeleteModel(IRepositorioEstadio repoEstadio)
        {
            _repoEstadio = repoEstadio;
        }

       public IActionResult OnGet(int id)
        {
            estadio = _repoEstadio.GetEstadio(id);
            if (estadio == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(int id)
        {
            _repoEstadio.DeleteEstadio(id);
            return RedirectToPage("Index");
        }      

    }
}