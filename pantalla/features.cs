

namespace Features
{
    public static class Utilidades
    {
        public static void EscribirLento(string texto)
        {
            foreach (char c in texto)
            { 
                Console.Write(c);
                Thread.Sleep(5);
            }
            
        }
    public static void LimpiarBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
    }
    public class Rutas()
    {
        public static string[] menuSongs = { @"recursos\audio\cancion1.wav", @"recursos\audio\historial.wav", @"recursos\audio\minijuego.wav", @"recursos\audio\pelea.wav", @"recursos\audio\huir.wav" };
    }

}