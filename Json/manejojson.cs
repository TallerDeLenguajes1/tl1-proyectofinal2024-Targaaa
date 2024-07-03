using System.Text.Json;
using Personajes;
using System.Reflection;    

namespace ManejoJson{
    public class PersonajesJson{
        public static bool Existe(string nombreArchivo)
        {
            if(File.Exists(nombreArchivo))
            {
                return true;
            }else{
                return false;
            }
        }
        public static void GuardarPersonajes(List<Personaje> misPersonajes, string nombreArchivo)
        {
            
            if (!File.Exists(nombreArchivo))
            {
                string jsonString = JsonSerializer.Serialize(misPersonajes);

                File.WriteAllText(nombreArchivo, jsonString);
            }

        }

        public static List<Personaje> LeerPersonajes(string nombreArchivo)
        {
            string dev = File.ReadAllText(nombreArchivo);
            return JsonSerializer.Deserialize<List<Personaje>>(dev);
        }
    }
}