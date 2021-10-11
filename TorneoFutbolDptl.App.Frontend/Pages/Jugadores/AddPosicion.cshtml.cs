using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbolDptl.App.Dominio;
using TorneoFutbolDptl.App.Persistencia;

namespace TorneoFutbolDptl.App.Frontend.Pages.Jugadores
{
    public class AddPosicionModel : PageModel
    {

        private readonly IRepositorioJugador _repoJugador;
        private readonly IRepositorioPosicion _repoPosicion;
        public Jugador jugador {get; set;}
        public IEnumerable<Posicion> posiciones {get; set;}
        public AddPosicionModel(IRepositorioJugador repoJugador, IRepositorioPosicion repoPosicion)
        {
            _repoJugador = repoJugador;
            _repoPosicion = repoPosicion;
        }

        public void OnGet(int id)
        {
            jugador = _repoJugador.GetJugador(id);
            posiciones = _repoPosicion.GetAllPosiciones();
        }

        public IActionResult OnPost(int idJugador, int idPosicion)
        {
            _repoJugador.AsignarPosicionJugador(idJugador, idPosicion);
            return RedirectToPage("Details", new{id = idJugador});
        }
    }
}