using Features;

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

        public void juego()
        {
            Utilidades.EscribirLento("\n¿Qué es esto?...");
            Utilidades.EscribirLento("\nParece un código, pero nose si tengo tiempo de descifrarlo.");
            Thread.Sleep(2000);
            Console.WriteLine("\n**************************************************************************************");
            Utilidades.EscribirLento("\nAdivinar la palabra te traerá benificios, pero quien sabe que te pasara si te equivocas...");
            Console.WriteLine("\n**************************************************************************************");
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
            }while(key != ConsoleKey.Enter);
            
            string respuesta = opciones[opcionSeleccionada];
            if(respuesta == "si")
            {

            Random random = new Random();
            palabraElegida = palabras[random.Next(palabras.Count)];
            
            
            for (int intento = 0; intento < intentos; intento++)
            {
                Console.Write($"Intento {intento + 1} de {intentos}: ");
                string prueba = Console.ReadLine();

                if (prueba.Length != 5)
                {
                    Console.WriteLine("Por favor, introduce una palabra válida de 5 letras.");
                    continue;
                }

                if (Verificar(prueba))
                {
                    Console.Clear();
                    Console.WriteLine("Descubriste el código, tus estadisticas aumentan!!");
                    Thread.Sleep(2000);
                    return;
                }
                else
                {
                    Coincidencias(prueba);
                }
            }
            Console.WriteLine($"Lo siento, no adivinaste la palabra. La palabra era: {palabraElegida}");
            Thread.Sleep(2000);
            }

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