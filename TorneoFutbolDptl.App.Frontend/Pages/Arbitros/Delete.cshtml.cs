using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbolDptl.App.Dominio;
using TorneoFutbolDptl.App.Persistencia;

namespace TorneoFutbolDptl.App.Frontend.Pages.Arbitros
{
    public class DeleteModel : PageModel
    {
        private readonly IRepositorioArbitro _repoArbitro;
        public Arbitro arbitro {get; set;}
        public DeleteModel(IRepositorioArbitro repoArbitro)
        {
            _repoArbitro = repoArbitro;
        }

        public IActionResult OnGet(int id)
        {
            arbitro = _repoArbitro.GetArbitro(id);
            if(arbitro == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(Arbitro arbitro)
        {
            _repoArbitro.DeleteArbitro(arbitro.Id);
            return RedirectToPage("Index");
        }
    }
}