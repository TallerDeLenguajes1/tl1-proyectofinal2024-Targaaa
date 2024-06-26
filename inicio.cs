using Personajes;
using ManejoJson;
using Creaciones;
public class Presentacion
{
    public static void Inicio()
    {
        Console.WriteLine(@"

 ______  __                  __              ___                                            ___      
/\__  _\/\ \                /\ \            /\_ \                                       __ /\_ \     
\/_/\ \/\ \ \___      __    \ \ \___     ___\//\ \    __  __         __   _ __    __   /\_\\//\ \    
   \ \ \ \ \  _ `\  /'__`\   \ \  _ `\  / __`\\ \ \  /\ \/\ \      /'_ `\/\`'__\/'__`\ \/\ \ \ \ \   
    \ \ \ \ \ \ \ \/\  __/    \ \ \ \ \/\ \L\ \\_\ \_\ \ \_\ \    /\ \L\ \ \ \//\ \L\.\_\ \ \ \_\ \_ 
     \ \_\ \ \_\ \_\ \____\    \ \_\ \_\ \____//\____\\/`____ \   \ \____ \ \_\\ \__/.\_\\ \_\/\____\
      \/_/  \/_/\/_/\/____/     \/_/\/_/\/___/ \/____/ `/___/> \   \/___L\ \/_/ \/__/\/_/ \/_/\/____/
                                                          /\___/     /\____/                         
                                                          \/__/      \_/__/                                                     
                ");
    }
}
public class PeleaCompleta{
    public async Task IniciarPeleaCompleta(){
        Fabrica fabricarPj = new Fabrica(); // Instancio FabricaDePersonajes

        List<Personaje> enemigos = await fabricarPj.(); // Creo los enemigos (método asincrónico)

        PersonajesJson enemigosJson = new PersonajesJson(); // Instancio PersonajesJson
        Fabrica caca = new Fabrica();
        List<Personaje> acas = caca.CargarDatos();



        string nombreArchivo;
        if (!Directory.Exists("./Json"))
        {
            Directory.CreateDirectory("./Json");
            nombreArchivo = "Json/listapersonajes.json";
            enemigosJson.GuardarPersonaje(enemigos, nombreArchivo);
        }
        nombreArchivo = "Json/enemigos.json";
    }
}