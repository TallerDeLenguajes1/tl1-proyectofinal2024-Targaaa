namespace Features
{
    public static class Utilidades
    {
        public static void EscribirLento(string texto)
        {
            foreach (char c in texto)
            { 
                Console.Write(c);
                Thread.Sleep(30);
            }
        }
    }
}