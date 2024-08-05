using Personajes;
using Combate;
using Minijuego;
using Features;

namespace Rondas
{
    public class Formato
    {
        public static void armadoCombates(List<Personaje> lista)
        {
            Personaje personajeUsuario = lista[0];
            primerEncuentro(lista);
            List<Personaje> ganadoresPrimerEncuentro = peleacion(lista, personajeUsuario); 
            if(ganadoresPrimerEncuentro.Contains(personajeUsuario))
            {
                Wordle wordlejuego = new Wordle();
                wordlejuego.juego();
                segundoEncuentro(ganadoresPrimerEncuentro);
                List<Personaje> ganadoresSegundoEncuentro = peleacion(ganadoresPrimerEncuentro, personajeUsuario);
                if(ganadoresSegundoEncuentro.Contains(personajeUsuario))
                {
                    wordlejuego.juego();
                    tercerEncuentro(ganadoresSegundoEncuentro);
                    List<Personaje> ganadoresTercerEncuentro = peleacion(ganadoresSegundoEncuentro, personajeUsuario);
                    if(ganadoresSegundoEncuentro.Contains(personajeUsuario))
                    {
                        wordlejuego.juego();
                        cuartoEncuentro(ganadoresTercerEncuentro);
                        List<Personaje> ganadoresCuartoEncuentro = peleacion(ganadoresTercerEncuentro, personajeUsuario);
                        if(ganadoresCuartoEncuentro.Contains(personajeUsuario))
                        {
                            Console.WriteLine("\n ganaste");
                        }
                    }
                }
            }
        }
        private static void primerEncuentro(List<Personaje> listaPersonajes)
        {
            Console.Clear(); 
            Utilidades.EscribirLento(@"Despues de pasar horas obteniendo información sobre esta guerra y tus openentes,
            decides tomarte un descanso para prepararte correctamente. Fue justamente durante ese descanso que 
            sientes que te observan, te giras para investigar y antes de darte cuenta te intentaron rebanar el cuello.");
            Utilidades.EscribirLento(@"Con el alma encendida por la determinación y la adrenalina corriendo por tus venas,
            te preparas para enfrentar a tu oponente. La guerra no esperará, y tampoco lo hará tu enemigo.");
            Utilidades.EscribirLento("\nTe enfrantas a " + listaPersonajes[1].Datos.Name);
            Utilidades.EscribirLento("\nQue comience la batalla!!");
            Utilidades.EscribirLento("\nIngrese una tecla para continuar\n");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("-----------PRIMER COMBATE-----------");
        }
        private static void segundoEncuentro(List<Personaje> listaPersonajes)
        {
            Console.Clear();
            Console.WriteLine(@"*cof cof, tose sangre*, ese bastardo era mas fuerte de lo que pensaba, no lo crees"
            + listaPersonajes[0].Datos.Name +"? Tranquilízate... Mientras yo este de tu lado solo habrá un ganador y ese seras tú");
            Console.WriteLine(@"Haha..., es reconfortante tener un compañero tan seguro de sí mismo,
            aunque tienes razón, es mejor estar tranquilo. Vamos, esto recien comienza.");
            Utilidades.EscribirLento(".            .            .");
            Console.WriteLine(@"No puede ser, es "+ listaPersonajes[1].Datos.Name + " tenemos que huir");
            Console.WriteLine(@" "+listaPersonajes[1].Datos.Name + ":Por lo que veo me conocen, eso facilitará las cosas.");
            Console.WriteLine("Bien, haganme el favor de dejarme asesinarlos");
            Console.WriteLine(" "+listaPersonajes[0]+":Acaso no escuchaste lo que te dije recien? Sea quien sea el rival, no perderemos");
            Utilidades.EscribirLento("\nIngrese una tecla para continuar\n");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("-----------SEGUNDO COMBATE-----------");
        }

        private static void tercerEncuentro(List<Personaje> listaPersonajes)
        {
            Console.WriteLine("@*Despues de descansar de la ultima batalla decides salir a buscar a tu proximo rival");
            Console.WriteLine("Escuchas a dos rivales pelear a lo lejos y decides ir a opinar*");
            Console.WriteLine(@"Al llegar ves como se deshicieron de su rival facilmente, pero crees que estan
            cansados y es una oportunidad que aprovechar");
            Console.WriteLine(@" "+listaPersonajes[0].Datos.Name + ",vamos.");
            Utilidades.EscribirLento("\nIngrese una tecla para continuar\n");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("-----------TERCER COMBATE-----------");

        }
        private static void cuartoEncuentro(List<Personaje> listaPersonajes)
        {
            Console.WriteLine(@"Al quedar solo dos masters en la disputa por el santo grial, éste ultimo activa su poder
            y teletransporta a ambos magos hacia la iglesia en donde tendrán un duelo a muerte para determinar quien obtendrá su
            poder y se cumplirá su deseo");
            Console.WriteLine(""+listaPersonajes[0].Datos.Name+":Pues no me sorprende la verdad, sabia que si iba a tener que enfrentar a alguien en la final, serías tú");
            Console.WriteLine(""+listaPersonajes[1].Datos.Name+":No me alabes tanto, me estas dando asco, pero tengo que admitir que será un duelo divertido");
            Console.WriteLine(""+listaPersonajes[0].Datos.Name +":Bueno...");
            Console.WriteLine(""+listaPersonajes[0].Datos.Name+":Que gane el mejor!");
            Console.WriteLine(""+listaPersonajes[1].Datos.Name+":Que gane el mejor!");
            Utilidades.EscribirLento("\nIngrese una tecla para continuar\n");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("-----------FINAL-----------");
        }
        private static List<Personaje> peleacion(List<Personaje> lista, Personaje personajeUsuario)
        {
            List<Personaje> ganadores = new List<Personaje>();
            Random random = new Random();
            for(int i = 0;i<lista.Count; i+=2)
            {   
                Personaje ganador;
                if(i == 0)
                {
                    ganador = Batalla.Pelea(personajeUsuario, lista[1]);
                }
                else
                {
                    ganador = random.Next(2) == 0 ? lista[i] : lista[i+1];
                }
                ganadores.Add(ganador);
            }
            return ganadores;
        }
    }
}