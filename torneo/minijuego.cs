namespace Minijuego
{
    public class wordle
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
            Console.WriteLine("\n¿Qué es esto?...");
            Console.WriteLine("\nParece un código, pero nose si tengo tiempo de descifrarlo.");
            Thread.Sleep(2000);
            Console.WriteLine("\n¿Qué me dices?, te animas a encontrar la palabra escondida?");
            Console.WriteLine("\nAdivinarla te traerá benificios, pero quien sabe que te pasara si te equivocas...");
            string[] opciones = new string[]
            {
                "si","no"
            }
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
            }
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
                    Console.WriteLine("Descubriste el código, tus estadisticas aumentan!!");
                    return;
                }
                else
                {
                    Coincidencias(prueba);
                }
            }
            Console.WriteLine($"Lo siento, no adivinaste la palabra. La palabra era: {palabraElegida}");
            }

        }

        private bool Verificar(string prueba)
        {
            return prueba.Equals(palabraElegida, StringComparison.OrdinalIgnoreCase);
        }

        private void Coincidencias(string prueba)
        {
            char[] coincide = new char[5];
            for (int i = 0; i < 5; i++)
            {
                if (prueba[i] == palabraElegida[i])
                {
                    coincide[i] = Char.ToUpper(prueba[i]);
                }
                else if (palabraElegida.Contains(prueba[i]))
                {
                    coincide[i] = Char.ToLower(prueba[i]);
                }
                else
                {
                    coincide[i] = '_';
                }
            }
            Console.WriteLine($"Coinciden: {new string(coincide)}");
        }
    }
}