using System.Text.Json;
using Personajes;
namespace PersonajesElegidos
{
    public class Elegidos
    {
        public static List<Personaje> ObtenerListaElegidos()
        {
            /////Traigo las lista de personajes cargada del json
            string jsonData = File.ReadAllText("Json/Personajes.json");
            List<Personaje> personajes = JsonSerializer.Deserialize<List<Personaje>>(jsonData);

            //Seleccion de personaje del usuario
            Personaje personajeSeleccionado = Eleccion.SeleccionUsuario.SeleccionPersonaje(personajes);

            //Eleccion de resto de personajes del torneo
            List<Personaje> listaPersonajesSeleccionados = Eleccion.SeleccionUsuario.MostrarMenuContrincantes(personajes, personajeSeleccionado);

            //Agrego a la lista de peleadores obtenidos(manual o automaticamente) el personaje a usar por el usuario.
            List<Personaje> listaPersonajesElegidos = [];
            listaPersonajesElegidos.Add(personajeSeleccionado);
            foreach (var personaje in listaPersonajesSeleccionados)
            {
                listaPersonajesElegidos.Add(personaje);
            }

            return listaPersonajesElegidos;
        }
    }
}