using Personajes;

namespace Combate
{
    public class Batalla
    {
        public static Personaje Pelea(Personaje usuario,Personaje bot)
        {
            int turno = 0;
            while(usuario.Caracteristicas.HpBase > 0 && bot.Caracteristicas.HpBase > 0)
            {
                if(turno == 0)
                {
                    do{
                        Console.Clear();
                        string[] opciones = { "Ataque Normal", "Ataque Especial", "Huir" };
                        opcionSeleccionada = 0;
                        for (int i = 0; i < opciones.lenght; i++)
                        { 
                            if (i == opcionSeleccionada)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(" " + opciones[i]);
                                Console.ResetColor();
                            }
                            else{
                                Console.WriteLine(" " + opciones[i]);
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
                    }while(key != ConsoleKey.Enter);
                    switch(opcionSeleccionada){
                        case 1: // case 1 o 0?
                            ataqueNormal(usuario, bot);
                            turno = 1; //cambio turno
                            break;
                        case 2: 
                            ataqueEspecial(usuario,bot);
                            turno = 1; //cambio turno
                            break;
                        case 3:
                            huir(usuario);
                            usuario.Caracteristicas.HpBase = 0;
                            break;
                    }
                }
                else
                {
                    int aux = rand.Next(0, 1);
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
            Console.WriteLine("\n" + atacante.Datos.Name + " usó ataque normal y causó " + atacante.Caracteristicas.Atk + "de daño\n");
            Console.WriteLine("\n Salud restante:" + defensor.Caracteristicas.Hp);
            }
        

        private static void ataqueEspecial(Personaje atacante, Personaje defensor)
        {
            int numeroRandom = rand.Next(1, 11);
            if(numeroRandom > 3)
            {
                Console.WriteLine("\n" + atacante.Datos.Name + " usó ataque especial pero falló");
            }
            else{
                defensor.Caracteristicas.Hp = defensor.Caracteristicas.Hp - (atacante.Caracteristicas.Atk)*2;
                Console.WriteLine("\n" + atacante.Datos.Name + " usó ataque normal y causó " + (atacante.Caracteristicas.Atk)*2 + "de daño\n");
                Console.WriteLine("\nSalud restante:" + defensor.Caracteristicas.Hp);
            }
        }
        private static void huir(Personaje usuario){ //buscar nombre de usuraio y agg musica
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
        }
    }
}