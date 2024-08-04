using Personajes;
using Combate;
using Minijuego;

namespace Rondas
{
    public class Formato
    {
        public static void armadoCombates(List<Personaje> lista)
        {
            Personaje personajeUsuario = lista[0];
            primerEncuentro(lista);
            List<Personaje> ganadoresPrimerEncuentro = peleacion(lista, personajeUsuario); 
            wordle wordlejuego = new wordle();
            wordle.juego();
        }
        private static void primerEncuentro(List<Personaje> listaPersonajes)
        {
            Console.WriteLine(@"\nDespues de pasar horas obteniendo información sobre esta guerra y tus openentes,
            decides tomarte un descanso para prepararte correctamente. Fue justamente durante ese descanso que 
            sientes que te observan, te giras para investigar y antes de darte cuenta te intentaron rebanar el cuello.");
            Console.WriteLine(@"\n Con el alma encendida por la determinación y la adrenalina corriendo por tus venas,
            te preparas para enfrentar a tu oponente. La guerra no esperará, y tampoco lo hará tu enemigo.");
            Console.WriteLine("\nTe enfrantas a " + listaPersonajes[1].Datos.Name);
            Console.WriteLine("\nQue comience la batalla!!");
            Console.Clear();
        }
        private static List<Personaje> peleacion(List<Personaje> lista, Personaje personajeUsuario)
        {
            List<Personajes> ganadores = new List<Personaje>();
            for(int i = 0;i<lista.Count; i+=2)
            {   
                if(i == 0)
                {
                    ganador = Batalla.Pelea(personajeUsuario, lista[1]);
                }
                else
                {
                    ganador = rng.Next(2) == 0 ? lista[i] : lista[i+1];
                }
                ganadores.Add(ganador);
            }
            return ganadores;
        }
    }
}