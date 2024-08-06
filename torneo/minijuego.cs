using Features;
using Personajes;
using System.Media;

namespace Minijuego
{
    public class Wordle
    {
        private static List<string> palabras = new List<string>
        {
            "abeto", "actor", "agudo", "alzar", "amigo", "andar", "animo", "apoyo", "aroma", "banco",
        "barro", "bicho", "bomba", "poste", "cabra", "cerca", "chico","cielo", "cobra", "corte",
        "cuero", "dados", "denso", "diana", "dudas", "techo",
        "entre", "estar", "vamos", "ficha", "freno", "fruta", "gafas", "gente", "grito",
        "guapo", "hacha", "huevo", "ideal", "joven", "lagos", "lente", "lucha", "malas",
        "manta", "mujer", "nieve", "nunca", "oruga", "padre", "panal", "patas", "pegar", "perro",
        "plata", "poder", "quema", "raton", "rojos", "ruido", "sello", "silla", "somos", "susto",
        "tarde", "tinta", "torta", "traje", "trigo", "unico", "viene", "vocal", "jugar",
        "zebra", "zorro", "cacao", "capaz", "cinta", "clima", "porte", "muere", "datos", "libra",
        "doble", "flama", "globo", "comer", "nariz", "jarra", "lucha", "llave", "marco", "marca",
        "mojar", "noble", "pasto", "piano", "plaza", "mover", "robar", "saber", "tonto", "valer",
        "viene", "vocal", "zumba"
        };

        private string palabraElegida;
        private int intentos = 6;

        public void juego(Personaje personajeUsuario)
        {
            Utilidades.EscribirLento("\n¿Qué es esto?...");
            Utilidades.EscribirLento("\nParece un código, pero nose si tengo tiempo de descifrarlo.");
            Utilidades.EscribirLento("\nAdivinar la palabra te traerá benificios, pero quien sabe que te pasara si te equivocas...");
            Thread.Sleep(2000);
            string[] opciones = new string[]
            {
                "si","no",
            };
            int opcionSeleccionada = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine("╭────────────────────────────────────────────────╮");
                Console.WriteLine("│                  Minijuego Wordle              │");
                Console.WriteLine("├────────────────────────────────────────────────┤");
                for (int i = 0; i < opciones.Length; i++)
                {
                    if (i == opcionSeleccionada)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"│ » {opciones[i].PadRight(44)} │");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"│ » {opciones[i].PadRight(44)} │");
                    }
                }
                Console.WriteLine("╰────────────────────────────────────────────────╯");
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow)
                {
                    opcionSeleccionada = (opcionSeleccionada == 0) ? opciones.Length - 1 : opcionSeleccionada - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    opcionSeleccionada = (opcionSeleccionada == opciones.Length - 1) ? 0 : opcionSeleccionada + 1;
                }
            }while(key != ConsoleKey.Enter);
            
            string respuesta = opciones[opcionSeleccionada];
            if(respuesta == "si")
            {
            #if WINDOWS
            SoundPlayer mariotema = new SoundPlayer(Rutas.menuSongs[2]);
            mariotema.PlayLooping();
            #endif
            Utilidades.EscribirLento("\nInstrucciones:");
            Console.WriteLine(@"El código es una palabra de 5 letras, en caso de que una letra de la palabra que ingresaste se encuentra en el codigo,
esta será una coincidencia. Y en el caso de que coincida en el lugar exacto, se pondrá en mayúsculas. Buena suerte");
            Console.WriteLine("\n  Ingrese una tecla para continuar\n");
            Console.ReadKey(true);

            Random random = new Random();
            palabraElegida = palabras[random.Next(palabras.Count)];
            
            Console.Clear();
            for (int intento = 0; intento < intentos; intento++)
            {
                Console.WriteLine("╭─────────────────────────────────────────────╮");
                Console.Write($"│ Intento {intento + 1} de {intentos}: ");
                string prueba = Console.ReadLine();
                Console.WriteLine("╰─────────────────────────────────────────────╯");
                if (prueba.Length != 5)
                {
                    Console.WriteLine("Por favor, introduce una palabra válida de 5 letras.");
                    continue;
                }

                if (Verificar(prueba))
                {
                    Console.Clear();
                    Console.WriteLine("╭────────────────────────────────────────────────────╮");
                    Console.WriteLine("│ Descubriste el código, ¡tus estadísticas aumentan! │");
                    Console.WriteLine("╰────────────────────────────────────────────────────╯");
                    personajeUsuario = cambiarEstadisticas(personajeUsuario);
                    Thread.Sleep(3000);
                    return;
                }
                else
                {
                    Coincidencias(prueba);
                }
            }
            Console.WriteLine($"Lo siento, no adivinaste la palabra. La palabra era: {palabraElegida}");
            Thread.Sleep(3000);
            }

        }
        public static Personaje cambiarEstadisticas(Personaje personajeUsuario)
        {

            personajeUsuario.Caracteristicas.Atk += 5;
            return personajeUsuario;
        }
        private bool Verificar(string prueba)
        {
            return prueba.Equals(palabraElegida, StringComparison.OrdinalIgnoreCase);
        }

        
        private void Coincidencias(string prueba)
        {
            char[] coincide = new char[5];
            Dictionary<char, int> cuentaPalabraElegida = new Dictionary<char, int>();
            Dictionary<char, int> cuentaProcesadas = new Dictionary<char, int>();

            // Contar apariciones de cada letra en palabraElegida
            foreach (char c in palabraElegida)
            {
                if (cuentaPalabraElegida.ContainsKey(c))
                {
                    cuentaPalabraElegida[c]++;
                }
                else
                {
                    cuentaPalabraElegida[c] = 1;
                }
            }

            // Primer bucle para letras en la posición correcta
            for (int i = 0; i < 5; i++)
            {
                if (prueba[i] == palabraElegida[i])
                {
                    coincide[i] = Char.ToUpper(prueba[i]);
                    if (!cuentaProcesadas.ContainsKey(prueba[i]))
                    {
                        cuentaProcesadas[prueba[i]] = 0;
                    }
                    cuentaProcesadas[prueba[i]]++;
                }
                else
                {
                    coincide[i] = '_';
                }
            }

            // Segundo bucle para letras correctas en posición incorrecta
            for (int i = 0; i < 5; i++)
            {
                if (coincide[i] == '_') // Solo procesar posiciones que no han sido identificadas como correctas
                {
                    if (palabraElegida.Contains(prueba[i]))
                    {
                        if (!cuentaProcesadas.ContainsKey(prueba[i]))
                        {
                            cuentaProcesadas[prueba[i]] = 0;
                        }

                        if (cuentaProcesadas[prueba[i]] < cuentaPalabraElegida[prueba[i]])
                        {
                            coincide[i] = Char.ToLower(prueba[i]);
                            cuentaProcesadas[prueba[i]]++;
                        }
                        else
                        {
                            coincide[i] = '_';
                        }
                    }
                    else
                    {
                        coincide[i] = '_';
                    }
                }
            }

            Console.WriteLine($"Coinciden: {new string(coincide)}");
        }
    }
}