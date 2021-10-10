using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TorneoFutbolDptl.App.Frontend
{
    public class ListModel : PageModel
    {
        private string[]  Arbitros = { "Arbitro 1", "Arbitro 2", "Arbitro 3"};
public List<string> ListaArbitros {get; set;}


        public void OnGet()
        {
            ListaArbitros = new List<string>();
            ListaArbitros.AddRange(Arbitros);
        }
    }
}

