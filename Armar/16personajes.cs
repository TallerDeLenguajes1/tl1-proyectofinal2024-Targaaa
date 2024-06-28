using System.Text.Json;
using Personajes;

namespace Elegidos{
    public class Candidatos{
        
            public static List<Personaje> SeleccionarContrincantesAleatoriamente(List<Personaje> listaPersonajes, Personaje personajePrincipal)
        {
            Random random = new Random();
            List<Personaje> contrincantes = listaPersonajes.OrderBy(p => random.Next()).Take(16).ToList();
            //.Where(p => p != personajePrincipal): crea una colección de personajes que contiene todos los elementos de listaPersonajes excepto aquel que es igual a personajePrincipal
            //.OrderBy(p => random.Next()): ordena la colección resultante del filtro anterior en un orden aleatorio
            //.Take(15): selecciona los primeros 15 elementos de la colección ordenada aleatoriamente.
            //.ToList(): convierte la colección de los 15 personajes seleccionados en una lista de tipo List<Personaje>.
            return contrincantes;
        }
            
        public static List<Personaje> ObtenerListaPeleadores(){
            string jsonData = File.ReadAllText("Json/Personajes.json");
            List<Personaje> personajes = JsonSerializer.Deserialize<List<Personaje>>(jsonData);
            

            List<Personaje> listaPersonajesElegidos = [];
            foreach (var personaje in listaPersonajesElegidos)
            {
                listaPersonajesElegidos.Add(personaje);
            }
            return listaPersonajesElegidos;
        }
    }
}