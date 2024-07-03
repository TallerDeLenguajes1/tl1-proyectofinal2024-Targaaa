using System.Text.Json;
using Personajes;

namespace Elegidos{
    public class Candidatos{
        public static void personajePrincipal(){ 

            string jsonData = File.ReadAllText("Json/Personajes.json");
            List<Personaje> personajes = JsonSerializer.Deserialize<List<Personaje>>(jsonData);

            Console.WriteLine("Selecciona a tu Servant. Ten en cuenta que será tu unico aliado en esta aventura, elige con sabiduria.\n");
            Console.WriteLine(@"Escribe el numero para seleccionar la clase 
            1. Saber: Espíritu Heroico de la Espada. Un guerrero de todos los oficios. Ágil y poderoso en el combate cercano.
            2. Archer: Espíritu Heroico del Arco. Excelentes exploradores que se destacan por poseer poderosos Noble Phantasms.
            3. Lancer: Espíritu Heroico de la Lanza. Dotado de una agilidad extrema y competente en tácticas de golpe y fuga.
            4. Caster: Espíritus heroicos de hechicería. Siendo uno de los pocos capaces de utilizar hechizos del más alto calibre.
            5. Assassin: Espíritu heroico de asesinatos. Extremadamente hábil en operaciones encubiertas, sigilosas y silenciosas.
            6. Berserker: Espíritu heroico de la furia frenética. Guerreros enloquecidos que han perdido casi todo rastro de cordura a cambio de un gran poder.
            7. Rider: Espíritu heroico de la montura. Expertos de la montura capaces de domesticar cualquier bestia, ya sea mítica o mecánica.
            8. Avenger: Espíritu Heróico de la venganza. Guerreros vengativos que han tenido un gran odio en el pasado, la personificación del odio en sí.
            9. Shielder: Maestro de la defensa y sirviente del escudo. Guerrero único con una defensa casi inexpugnable.");
            string claseEleccion = Console.ReadLine();
            switch (claseEleccion)
            {
                case "1":
                    claseEleccion = "servant";
                break;
                case "2":
                    claseEleccion = "archer";
                break;
                case "3":
                    claseEleccion = "lancer";
                break;
                case "4":
                    claseEleccion = "caster";
                break;
                case "5":
                    claseEleccion = "assassin";
                break;
                case "6":
                    claseEleccion = "berserker";
                break;
                case "7":
                    claseEleccion = "rider";
                break;
                case "8":
                    claseEleccion = "avenger";
                break;
                case "9":
                    claseEleccion = "shielder";
                break;
                default:
                    Console.WriteLine("Ingrese un numero valido\n");
                break;
            }
            Console.WriteLine("\nLista de personajes posibles:");
            var personajesFiltrados = personajes.Where(p => p.Datos.className == claseEleccion);
            foreach (var personaje in personajesFiltrados)
        {
            Console.WriteLine(personaje.Datos.name + " Rareza:" + personaje.Datos.rarity + "*");
        }
        }
            public static List<Personaje> SeleccionarContrincantesAleatoriamente(List<Personaje> listaPersonajes, Personaje personajePrincipal)
        {
            Random random = new Random();
            List<Personaje> contrincantes = listaPersonajes.OrderBy(p => random.Next()).Take(15).ToList();
            //.Where(p => p != personajePrincipal): crea una colección de personajes que contiene todos los elementos de listaPersonajes excepto aquel que es igual a personajePrincipal
            //.OrderBy(p => random.Next()): ordena la colección resultante del filtro anterior en un orden aleatorio
            //.Take(15): selecciona los primeros 15 elementos de la colección ordenada aleatoriamente.
            //.ToList(): convierte la colección de los 15 personajes seleccionados en una lista de tipo List<Personaje>.
            return contrincantes;
        }
            
        public static List<Personaje> ObtenerListaPeleadores(){
            
            List<Personaje> listaPersonajesElegidos = [];
            foreach (var personaje in listaPersonajesElegidos)
            {
                listaPersonajesElegidos.Add(personaje);
            }
            return listaPersonajesElegidos;
        }
    }
}