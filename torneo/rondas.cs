using Personajes;
using Combate;
using Minijuego;
using Features;
using Historial;
using MenuInicial;
using System.Media;
using System.ComponentModel;

namespace Rondas
{
    public class Formato
    {
        public static void armadoCombates(List<Personaje> lista, List<HistorialGanadores> listado)
        {
            Personaje personajeUsuario = lista[0];
            primerEncuentro(lista);
            List<Personaje> ganadoresPrimerEncuentro = peleacion(lista, personajeUsuario); 
            if(ganadoresPrimerEncuentro.Contains(personajeUsuario))
            {
                Wordle wordlejuego = new Wordle();
                wordlejuego.juego(personajeUsuario);
                segundoEncuentro(ganadoresPrimerEncuentro);
                List<Personaje> ganadoresSegundoEncuentro = peleacion(ganadoresPrimerEncuentro, personajeUsuario);
                if(ganadoresSegundoEncuentro.Contains(personajeUsuario))
                {
                    wordlejuego.juego(personajeUsuario);
                    tercerEncuentro(ganadoresSegundoEncuentro);
                    List<Personaje> ganadoresTercerEncuentro = peleacion(ganadoresSegundoEncuentro, personajeUsuario);
                    if(ganadoresSegundoEncuentro.Contains(personajeUsuario))
                    {
                        wordlejuego.juego(personajeUsuario);
                        cuartoEncuentro(ganadoresTercerEncuentro);
                        List<Personaje> ganadoresCuartoEncuentro = peleacion(ganadoresTercerEncuentro, personajeUsuario);
                        if(ganadoresCuartoEncuentro.Contains(personajeUsuario))
                        {
                            Console.Clear();
                            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                            Utilidades.EscribirLento("\nFelicidades!! Has ganado el ultimo combate, eres el Master que ha conseguido dominar al servant más fuerte");
                            Utilidades.EscribirLento("\nAhora tu nombre pasará a la historia, eres libre de usar el santo grial en todo su esplendor y cumplir tu deseo");
                            Utilidades.EscribirLento("\nComo? Que este juego te gustó tanto que tu deseo es volver a jugarlo?");
                            Utilidades.EscribirLento("\nDeseo cumplido!!");
                            Console.WriteLine("\n╚═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                            Thread.Sleep(5000);
                            Menu.empezar();
                            HistorialGanadores.CargarHistorial(personajeUsuario, listado);
                        }
                        else
                        {
                            mensajeDerrota();
                        }
                    }
                    else
                    {
                        mensajeDerrota();
                    }
                }
                else
                {
                    mensajeDerrota();
                }
            }
            else
            {
                mensajeDerrota();
            }
        }
        private static void primerEncuentro(List<Personaje> listaPersonajes)
        {

            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Utilidades.EscribirLento(@"             Despues de pasar horas obteniendo información sobre esta guerra y tus oponentes,
            decides tomarte un descanso para prepararte correctamente. Fue justo durante en ese momento que 
            sientes que te observan, te giras para investigar y antes de darte cuenta te intentaron rebanar el cuello.
            Con el alma encendida por la determinación y la adrenalina corriendo por tus venas, te preparas para enfrentar a tu oponente.
            La guerra no esperará, y tampoco lo hará tu enemigo."+ "\n");
            Console.WriteLine("\n╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Utilidades.EscribirLento(@"Te enfrantas a " + listaPersonajes[1].Datos.Name+ "\n");
            Utilidades.EscribirLento(@"Que comience la batalla!!"+ "\n");
            Utilidades.EscribirLento(@"-----------PRIMER COMBATE-----------"+ "\n");
            Thread.Sleep(3000);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nIngrese una tecla para continuar\n");
            Console.ReadKey(true);
        }
        private static void segundoEncuentro(List<Personaje> listaPersonajes)
        {

            SoundPlayer Opening = new SoundPlayer(Rutas.menuSongs[0]);
            Opening.PlayLooping();

            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Utilidades.EscribirLento(@"*Cof cof, tose sangre*.Ese bastardo era mas fuerte de lo que pensaba, no lo crees "
            + listaPersonajes[0].Datos.Name +"?");
            Utilidades.EscribirLento("\n"+ listaPersonajes[0].Datos.Name + ": Tranquilízate... Mientras yo este de tu lado solo habrá un ganador y ese seras tú."+"\n");
            Utilidades.EscribirLento(@"Haha..., es reconfortante tener un compañero tan seguro de sí mismo, y sí... tienes razón, es mejor estar tranquilo."+ "\n"+" Vamos, esto recien comienza.");
            Thread.Sleep(3000);
            Utilidades.EscribirLento("\nNo puede ser... es "+ listaPersonajes[1].Datos.Name + "! Tenemos que huir "+listaPersonajes[0].Datos.Name+ "!!\n");
            Utilidades.EscribirLento(@""+listaPersonajes[1].Datos.Name + ": Por lo que veo me conocen, eso me facilitará las cosas."+ "\n");
            Utilidades.EscribirLento(@""+listaPersonajes[1].Datos.Name + ": Asique... haganme el favor de morir."+ "\n");
            Utilidades.EscribirLento(@"Rayos, nose que hacer en esta situación, ni siquiera se si podríamos llegar a escapar."+ "\n");
            Utilidades.EscribirLento(""+listaPersonajes[0].Datos.Name+": Acaso no escuchaste lo que te dije recien? Sea quien sea el rival, no perderemos."+ "\n");
            Console.WriteLine("\n╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
        
            Utilidades.EscribirLento("-----------SEGUNDO COMBATE-----------"+ "\n");
            Thread.Sleep(5000);
            Console.ForegroundColor = ConsoleColor.Green;

            Opening.Stop();

            Console.WriteLine("\nIngrese una tecla para continuar\n");
            Console.ReadKey(true);
        }

        private static void tercerEncuentro(List<Personaje> listaPersonajes)
        {

            SoundPlayer Opening = new SoundPlayer(Rutas.menuSongs[0]);
            Opening.PlayLooping();

            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Utilidades.EscribirLento(@"*Despues de descansar de la ultima batalla decides salir a buscar a tu proximo rival."+ "\n");
            Utilidades.EscribirLento(@"Escuchas a dos guerreros pelear a lo lejos y decides ir a ver quienes son*"+ "\n");
            Utilidades.EscribirLento(@"Al llegar ves como se deshicieron de su rival facilmente, pero crees que es una oportunidad que hay que aprovechar."+ "\n");
            Utilidades.EscribirLento(@" "+listaPersonajes[0].Datos.Name + ",vamos."+ "\n");
            Console.WriteLine("\n╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Utilidades.EscribirLento("-----------TERCER COMBATE-----------"+ "\n");
            Thread.Sleep(3000);
            Console.ForegroundColor = ConsoleColor.Green;
            Opening.Stop();
            Console.WriteLine("\nIngrese una tecla para continuar\n");
            Console.ReadKey(true);


        }
        private static void cuartoEncuentro(List<Personaje> listaPersonajes)
        {
            SoundPlayer Opening = new SoundPlayer(Rutas.menuSongs[0]);
            Opening.PlayLooping();
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Utilidades.EscribirLento(@"Al quedar solo dos masters en la disputa por el santo grial, éste ultimo activa su poder y teletransporta a ambos magos hacia 
la iglesia en donde tendrán un duelo a muerte para determinar quien obtendrá su poder y se cumplirá su deseo."+ "\n");
            Utilidades.EscribirLento(""+listaPersonajes[0].Datos.Name+": Pues no me sorprende la verdad, sabia que si iba a tener que enfrentar a alguien en la final, serías tú"+ "\n");
            Utilidades.EscribirLento(""+listaPersonajes[1].Datos.Name+": No me alabes tanto, me estas dando asco, pero tengo que admitir que será un duelo divertido"+ "\n");
            Utilidades.EscribirLento(""+listaPersonajes[0].Datos.Name +": Bueno..."+ "\n");
            Console.WriteLine(""+listaPersonajes[0].Datos.Name+": Que gane el mejor!");
            Console.WriteLine(""+listaPersonajes[1].Datos.Name+": Que gane el mejor!");
            Console.WriteLine("\n╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Utilidades.EscribirLento("\n"+"-----------FINAL-----------"+ "\n");
            Thread.Sleep(3000);
            Console.ForegroundColor = ConsoleColor.Green;
            Opening.Stop();
            Console.WriteLine("\nIngrese una tecla para continuar\n");
            Console.ReadKey(true);
        }
        private static void mensajeDerrota()
        {
            Utilidades.EscribirLento("\n Pensaste que sería tan fácil?");
            Utilidades.EscribirLento("\n Vuelve cuando seas un verdadero master.");
        }
        private static List<Personaje> peleacion(List<Personaje> lista, Personaje personajeUsuario)
        {

            SoundPlayer pelea = new SoundPlayer(Rutas.menuSongs[3]);
            pelea.PlayLooping();

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
            pelea.Stop();
            return ganadores;
        }
    }
}