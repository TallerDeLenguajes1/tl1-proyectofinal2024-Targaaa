using Personajes;

namespace Combate
{
    public class Batalla
    {
        public static Personaje Pelea(Personaje usuario,Personaje bot)
        {
            int turno = 0;
            while(usuario.Caracteristicas.Hp > 0 && bot.Caracteristicas.Hp > 0)
            {
                if(turno == 0)
                {
                    int opcionSeleccionada = 0;
                    ConsoleKey key;
                    string[] opciones = { "Ataque Normal", "Ataque Especial", "Huir" };
                    do{
                        Console.Clear();
                        Console.WriteLine("╭────────────────────────────────────────────────╮");
                        Console.WriteLine("│                  MENÚ DE ATAQUE                │");
                        Console.WriteLine("├────────────────────────────────────────────────┤");
                        for (int i = 0; i < opciones.Length; i++)
                        { 
                            if (i == opcionSeleccionada)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"│ » {opciones[i].PadRight(44)} │");
                                Console.ResetColor();
                            }
                            else{
                                Console.WriteLine($"│ » {opciones[i].PadRight(44)} │");
                            }
                        }
                        Console.WriteLine("╰────────────────────────────────────────────────╯");

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
                    switch(opcionSeleccionada){
                        case 0: 
                            ataqueNormal(usuario, bot);
                            turno = 1; //cambio turno
                            break;
                        case 1: 
                            ataqueEspecial(usuario,bot);
                            turno = 1; //cambio turno
                            break;
                        case 2:
                            huir(usuario);
                            usuario.Caracteristicas.Hp = 0;
                            break;
                    }
                }
                else
                {
                    int aux = rand.Next(0, 2);
                    if(aux == 1)
                    {
                        ataqueNormal(bot,usuario);
                    }
                    else
                    {
                        ataqueEspecial(bot,usuario);
                    }
                    turno = 0; //cambio turno
                }
            }
            if(usuario.Caracteristicas.Hp <= 0)
            {
                bot.Caracteristicas.Hp = 100;
                return bot;
            }
            else
            {
                usuario.Caracteristicas.Hp = 100;
                return usuario;
            }
        }

        private static void ataqueNormal(Personaje atacante, Personaje defensor) //2 funcioems?
        {
            defensor.Caracteristicas.Hp = defensor.Caracteristicas.Hp - atacante.Caracteristicas.Atk;
            
            Console.WriteLine("\n" + atacante.Datos.Name + " usó ataque normal y causó " + atacante.Caracteristicas.Atk + " de daño\n");
            if(defensor.Caracteristicas.Hp < 0)
                {
                    Console.WriteLine(@"Salud restante de "+defensor.Datos.Name+": 0");
                }
                else
                {
                    Console.WriteLine(@"Salud restante de "+defensor.Datos.Name+": " + defensor.Caracteristicas.Hp);
                }
            Thread.Sleep(3000);
        }
        

        private static void ataqueEspecial(Personaje atacante, Personaje defensor)
        {
            int numeroRandom = rand.Next(1, 11);
            if(numeroRandom > 3)
            {   
                Console.Clear();
                Console.WriteLine("\n" + atacante.Datos.Name + " usó ataque especial pero falló");
                Thread.Sleep(2000);
            }
            else{
                defensor.Caracteristicas.Hp = defensor.Caracteristicas.Hp - (atacante.Caracteristicas.Atk)*2;
                Console.Clear();
                Console.WriteLine("\n" + atacante.Datos.Name + " usó ataque especial y causó " + (atacante.Caracteristicas.Atk)*2 + " de daño\n");
                if(defensor.Caracteristicas.Hp < 0)
                {
                    Console.WriteLine(@"Salud restante de "+defensor.Datos.Name+": 0");
                }
                else
                {
                    Console.WriteLine(@"Salud restante de "+defensor.Datos.Name+": " + defensor.Caracteristicas.Hp);
                }
                Thread.Sleep(2000);
            }
        }
        private static void huir(Personaje usuario){ 
            Console.Clear();
            string textColor = "\u001b[31m";
            string resetColor = "\u001b[0m";
            Console.WriteLine(textColor + @"
                         _______  _______  _        _       _________ _        _______ 
                        (  ____ \(  ___  )( \      ( \      \__   __/( (    /|(  ___  )
                        | (    \/| (   ) || (      | (         ) (   |  \  ( || (   ) |
                        | |      | (___) || |      | |         | |   |   \ | || (___) |
                        | | ____ |  ___  || |      | |         | |   | (\ \) ||  ___  |
                        | | \_  )| (   ) || |      | |         | |   | | \   || (   ) |
                        | (___) || )   ( || (____/\| (____/\___) (___| )  \  || )   ( |
                        (_______)|/     \|(_______/(_______/\_______/|/    )_)|/     \|
                    " + resetColor);
            Thread.Sleep(2000);
            Console.WriteLine("\n " + usuario.Datos.Name + " está decepcionado de ti...");
        }
        private static Random rand = new Random();
    }
}