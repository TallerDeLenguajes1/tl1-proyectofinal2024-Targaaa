using Api;
using Creaciones;
using Personajes;
using ManejoJson;


namespace ArmarJsonPjsConApi
{
    public class CargadorDatos
    {
        public static async Task CargarDatosPersonajesAsync()
        {
            List<PjApi> listaPersonajesApi = new List<PjApi>();
            List<Personaje> listaPersonajes = new List<Personaje>();

            listaPersonajesApi = await InfoApi.traerInformacionApi(listaPersonajesApi);
            listaPersonajes = Fabrica.cargarDatos(listaPersonajes, listaPersonajesApi);

            // Guarda los personajes en un archivo JSON en el directorio "Json"
            PersonajesJson.GuardarPersonajes(listaPersonajes, "Json/Personajes.json");
        }
    }
}