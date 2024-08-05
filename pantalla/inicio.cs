using System.Reflection;
using Personajes;
using Elegidos;
using Features;

namespace Inicio
{
    public class Presentacion
    {
        public static void Titulo()
        {
            Console.Clear();
            string textColor = "\u001b[31m";
            string resetColor = "\u001b[0m";
            Console.WriteLine(textColor + @"

 ______  __                  __              ___                                             ___      
/\__  _\/\ \                /\ \            /\_ \                                        __ /\_ \     
\/_/\ \/\ \ \___      __    \ \ \___     ___\//\ \     __  __         __   _ __    __   /\_\\//\ \    
   \ \ \ \ \  _  \  /'__`\   \ \  _  \  / __ \\ \ \   /\ \/\ \      /'_ `\/\`'__\/'__`\ \/\ \ \ \ \   
    \ \ \ \ \ \ \ \/\  __/    \ \ \ \ \/\ \_\ \\_\ \_ \ \ \_\ \    /\ \_\ \ \ \//\ \_\.\_\ \ \ \_\ \_ 
     \ \_\ \ \_\ \_\ \____\    \ \_\ \_\ \____//\____\ \/`____ \   \ \____ \ \_\\ \__/.\_\\ \_\/\____\
      \/_/  \/_/\/_/\/____/     \/_/\/_/\/___/ \/____/  `/___/  \   \/___L\ \/_/ \/__/\/_/ \/_/\/____/
                                                           /\___/     /\____/                         
                                                           \/__/      \_/__/                                                                           
                    " + resetColor);

        }
        public static void StartGame()
        {
            Titulo();
            Thread.Sleep(3000);
            //Utilidades.EscribirLento();
            Console.WriteLine(@"        Bienvenido a Fate/stay night:

                En un mundo donde la magia y la realidad se entrelazan, te encuentras en la ciudad de Fuyuki, un lugar aparentemente tranquilo que 
        esconde un oscuro secreto. Cada pocas décadas, se celebra un misterioso evento conocido como la Guerra del Santo Grial, una feroz competencia
        en la que poderosos magos, conocidos como Masters, invocan espíritus heroicos del pasado llamados Servants para luchar por el legendario Santo Grial,
        un artefacto capaz de conceder cualquier deseo.");

        Console.Write("\n        Introduce tu nombre de Master: ");
        string playerName = Console.ReadLine();
        Console.WriteLine("\n        Bienvenido " + playerName + @" te encuentras participando en esta peligrosa guerra. Con la ayuda del Servant que elijas,
        debes enfrentarte a otros Masters y Servants en una serie de intensas batallas mágicas.
        Explora la ciudad de Fuyuki, descubre los secretos de tus enemigos y desentraña las intrigas que rodean la Guerra del Santo Grial.
        Cada decisión que tomes puede acercarte a la victoria... o a la destrucción.

        ¿Estás listo para asumir tu destino y luchar por tus sueños? La Guerra del Santo Grial te espera.");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n  Ingrese una tecla para continuar\n");
        Console.ReadKey(true);
        }
    }
}
