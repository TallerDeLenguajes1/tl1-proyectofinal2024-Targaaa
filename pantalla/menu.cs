using Inicio;
using Personajes;
using Rondas;

namespace MenuInicial{
    public class Menu
    {   
        public static void mostrarMenu()
        {
            string[] opciones = {
                "Jugar",
                "Historial de Campeones",
                "Salir"
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
            } while (key != ConsoleKey.Enter);

            switch(opcionSeleccionada)
            {
                case 0:
                    Presentacion.StartGame(); 
                    List<Personaje> listaPeleadores = Elegidos.Candidatos.ObtenerListaPeleadores();
                    Formato.armadoCombates(listaPeleadores);
                break;
                case 1:
                    //Historial.historialGanadores();
                break;
            }
        }
    }
}