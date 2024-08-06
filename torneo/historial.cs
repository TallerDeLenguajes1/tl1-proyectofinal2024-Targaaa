using System.Text.Json;
using Personajes;
using MenuInicial;
using System.Media;
using Features; 


namespace Historial
{
    public class HistorialGanadores
    {
        public Personaje Ganador { get; set; }
        private static string nombreArchivo = "Json/Historial.json";

        public static void CargarHistorial(Personaje ganador,List<HistorialGanadores> lista)
        {
            HistorialGanadores nombre = new HistorialGanadores(ganador);
            lista.Add(nombre);
            guardar(lista);
        }

        private static void guardar(List<HistorialGanadores> listaHistorial)
        {
            var opciones = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(listaHistorial, opciones);
            File.WriteAllText(nombreArchivo, json);
        }
        public static List<HistorialGanadores> CargarHistorialDesdeArchivo()
        {
            if (!File.Exists(nombreArchivo))
            {
                return new List<HistorialGanadores>();
            }

            string json = File.ReadAllText(nombreArchivo);
            return JsonSerializer.Deserialize<List<HistorialGanadores>>(json);
        }
        public static void MostrarListado(List<HistorialGanadores> listado)
        {
            
            SoundPlayer cancion = new SoundPlayer(Rutas.menuSongs[1]);
            cancion.PlayLooping();

            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║       Servants que fueron merecedores del Santo Grial              ║");
            Console.WriteLine("╠════════════════════════════════════════════════════════════════════╣");
            if (listado.Count == 0)
            {
                Console.WriteLine("║      Nadie fue merecedor aún                                       ║");
            }
            else
            {
                foreach (var ganador in listado)
                {
                    Console.WriteLine($"║  -> {ganador.Ganador.Datos.Name.PadRight(62)} ║");
                }
            }
            Utilidades.LimpiarBuffer();
            Console.WriteLine("╠════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║   Ingrese una tecla para regresar al menú                          ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("Ingrese una tecla para regresar al menu");
            Console.CursorVisible = false;
            Console.ReadKey(true);

            cancion.Stop();
            
            Menu.mostrarMenu(listado);
        }
        public HistorialGanadores(Personaje ganador)
        {
            Ganador = ganador;
        }
    }
}
