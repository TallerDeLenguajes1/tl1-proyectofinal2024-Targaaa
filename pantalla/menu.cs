using Inicio;
using Personajes;
using Rondas;
using Historial;
using Features;

namespace MenuInicial{
    public class Menu
    {   
        public static void empezar()
        {
            List<HistorialGanadores> listado = HistorialGanadores.CargarHistorialDesdeArchivo();
            mostrarMenu(listado);
        }
        public static void mostrarMenu(List<HistorialGanadores> listado)
        {
            string[] opciones = {
                "Jugar",
                "Historial de Campeones",
                "Salir"
            };
            Console.CursorVisible = false;
            int opcionSeleccionada = 0;
            ConsoleKey key;
            Utilidades.LimpiarBuffer();
            do
            {
                
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════╗");
                Console.WriteLine("║                MENÚ PRINCIPAL                  ║");

                Console.WriteLine("╠════════════════════════════════════════════════╣");
                for (int i = 0; i < opciones.Length; i++)
                {
                    if (i == opcionSeleccionada)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"║ -> {opciones[i].PadRight(43)} ║");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"║    {opciones[i].PadRight(43)} ║");
                    }
                }
                Console.WriteLine("╚════════════════════════════════════════════════╝");
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

            switch(opcionSeleccionada)
            {
                case 0:
                    Presentacion.StartGame(); 
                    List<Personaje> listaPeleadores = Elegidos.Candidatos.ObtenerListaPeleadores();
                    Formato.armadoCombates(listaPeleadores, listado);
                break;
                case 1:
                    HistorialGanadores.MostrarListado(listado);
                break;
                default:
                    Utilidades.EscribirLento("Saliendo...");
                    Thread.Sleep(1000);
                    return;
            }
        }
    }
}