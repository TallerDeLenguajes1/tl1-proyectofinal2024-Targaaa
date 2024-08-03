using Personajes;

namespace Combate
{
    public class Batalla
    {
        public static Personaje Pelea(Personaje usuario,Personaje bot){

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
                            break;
                        case 2: 
                            ataqueEspecial(usuario,bot);
                            break;
                        case 3:
                            huir(usuario);
                            break;
                    }
                    turno = 1; //cambio turno
                }
                else{
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
            Console.WriteLine("\n" + atacante.Datos.Name + " usó ataque normal");
            defensor.Caracteristicas.Hp = defensor.Caracteristicas.Hp - atacante-Caracteristicas.Atk;
        }
        private static void ataqueEspecial(Personaje atacante, Personaje defensor)
        {
            Console.WriteLine("\n" + atacante.Datos.Name + " usó ataque especial");
            defensor.Caracteristicas.Hp = defensor.Caracteristicas.Hp - atacante-Caracteristicas.Atk;
        }
        private static void huir(Personaje usuario){ //buscar nombre de usuraio
            
        }
    }
}
