using Api;
using Creaciones;
using Personajes;
using ManejoJson;
using System.Reflection;


namespace ArmarJsonPjsConApi
{
    public class CargadorDatos
    {
        public static async Task CargarDatosPersonajesAsync()
        {
            List<personajeApi> listaPersonajesApi = new List<personajeApi>();
            List<Personaje> listaPersonajes = new List<Personaje>();

            listaPersonajesApi = await InfoApi.TraerInformacionApi(listaPersonajesApi);
            listaPersonajes = Fabrica.CargarDatos(listaPersonajes, listaPersonajesApi);

            PersonajesJson.GuardarPersonajes(listaPersonajes, "Json/Personajes.json");
        }
    }
}