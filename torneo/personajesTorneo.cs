using System.Text.Json;
using Personajes;

namespace Elegidos
{
    public class Candidatos
    {
        public static Personaje personajePrincipal(List<Personaje> listaPersonajes)
        {

            string jsonData = File.ReadAllText("Json/Personajes.json");
            List<Personaje> personajes = JsonSerializer.Deserialize<List<Personaje>>(jsonData);

            string[] opciones = new string[]
            {
                "1. Saber: Espíritu Heroico de la Espada. Un guerrero de todos los oficios. Ágil y poderoso en el combate cercano.",
                "2. Archer: Espíritu Heroico del Arco. Excelentes exploradores que se destacan por poseer poderosos Noble Phantasms.",
                "3. Lancer: Espíritu Heroico de la Lanza. Dotado de una agilidad extrema y competente en tácticas de golpe y fuga.",
                "4. Caster: Espíritus heroicos de hechicería. Siendo uno de los pocos capaces de utilizar hechizos del más alto calibre.",
                "5. Assassin: Espíritu heroico de asesinatos. Extremadamente hábil en operaciones encubiertas, sigilosas y silenciosas.",
                "6. Berserker: Espíritu heroico de la furia frenética. Guerreros enloquecidos que han perdido casi todo rastro de cordura a cambio de un gran poder.",
                "7. Rider: Espíritu heroico de la montura. Expertos de la montura capaces de domesticar cualquier bestia, ya sea mítica o mecánica.",
                "8. Avenger: Espíritu Heróico de la venganza. Guerreros vengativos que han tenido un gran odio en el pasado, la personificación del odio en sí.",
                "9. Shielder: Maestro de la defensa y sirviente del escudo. Guerrero único con una defensa casi inexpugnable."
            };
            int opcionSeleccionada = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine("Selecciona la clase de tu Servant para ver los Servants disponibles.");
                Console.WriteLine("Ten en cuenta que será tu unico aliado en esta aventura, elige con sabiduria.\n");

                for (int i = 0; i < opciones.Length; i++)
                {
                    if (i == opcionSeleccionada)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("-> " + opciones[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("   " + opciones[i]);
                    }
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    opcionSeleccionada = (opcionSeleccionada == 0) ? opciones.Length - 1 : opcionSeleccionada - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    opcionSeleccionada = (opcionSeleccionada == opciones.Length - 1) ? 0 : opcionSeleccionada + 1;
                }
            } while (key != ConsoleKey.Enter);

            string claseEleccion = opciones[opcionSeleccionada].Split(' ')[1].ToLower().Replace(":", "");

            Console.Clear();

            var personajesFiltrados = personajes.Where(p => p.Datos.ClassName.ToLower() == claseEleccion).ToList();
            opcionSeleccionada = 0;

            do
            {
                Console.Clear();
                Console.WriteLine($"Lista de personajes de la clase {claseEleccion}:\n");

                for (int i = 0; i < personajesFiltrados.Count; i++)
                {
                    if (i == opcionSeleccionada)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("-> " + personajesFiltrados[i].Datos.Name + " Rareza: " + personajesFiltrados[i].Datos.Rarity + "*");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("   " + personajesFiltrados[i].Datos.Name + " Rareza: " + personajesFiltrados[i].Datos.Rarity + "*");
                    }
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    opcionSeleccionada = (opcionSeleccionada == 0) ? personajesFiltrados.Count - 1 : opcionSeleccionada - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    opcionSeleccionada = (opcionSeleccionada == personajesFiltrados.Count - 1) ? 0 : opcionSeleccionada + 1;
                }

            } while (key != ConsoleKey.Enter);
            Personaje seleccionado = personajesFiltrados[opcionSeleccionada];
            string servantEleccion = personajesFiltrados[opcionSeleccionada].Datos.Name;
            Console.Clear();
            Console.WriteLine($"Has seleccionado:\n{servantEleccion}");
            Thread.Sleep(3000);
            return seleccionado;
        }
        public static List<Personaje> SeleccionarContrincantesAleatoriamente(List<Personaje> listaPersonajes, Personaje personajePrincipal)
        {
            Random random = new Random();
            List<Personaje> enemigos = listaPersonajes.Where(p => p != personajePrincipal).OrderBy(p => random.Next()).Take(15).ToList();
            return enemigos;
        }

        public static List<Personaje> ObtenerListaPeleadores()
        {
            string jsonData = File.ReadAllText("Json/Personajes.json");
            List<Personaje> personajes = JsonSerializer.Deserialize<List<Personaje>>(jsonData);

            
            Personaje personajeElegido = Candidatos.personajePrincipal(personajes);

            List<Personaje> listaPersonajesElegidos = [];
            listaPersonajesElegidos.Add(personajeElegido);

            List<Personaje> personajeElegidoAleatoriamente = Candidatos.SeleccionarContrincantesAleatoriamente(personajes, personajeElegido);
            foreach (var personaje in personajeElegidoAleatoriamente)
            {
                listaPersonajesElegidos.Add(personaje);
            }
            return listaPersonajesElegidos;
        }
    }
}

