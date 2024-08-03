
using Api;
using Personajes;

namespace Creaciones{
        public class Fabrica{
            private static Random random = new Random();
            public static List<Personaje> CargarDatos(List<Personaje> listaPersonajes, List<personajeApi> personajesApi){
                foreach(var personaje in personajesApi){
                    Personaje nuevoPersonaje = new Personaje();
                    
                    nuevoPersonaje.Datos.Name = personaje.name;
                    nuevoPersonaje.Datos.ClassName = personaje.className;
                    nuevoPersonaje.Datos.Rarity = personaje.rarity;
                    nuevoPersonaje.Datos.Attribute = personaje.attribute;

                    switch (personaje.rarity){
                        case 5:
                            nuevoPersonaje.Caracteristicas.AtkBase = random.Next(35,40);
                        break;
                        case 4:
                            nuevoPersonaje.Caracteristicas.AtkBase = random.Next(30,35);
                        break;
                        case 3:
                            nuevoPersonaje.Caracteristicas.AtkBase = random.Next(25,30);
                        break;
                        case 2:
                            nuevoPersonaje.Caracteristicas.AtkBase = random.Next(20,25);
                        break;
                        case 1:
                            nuevoPersonaje.Caracteristicas.AtkBase = random.Next(15,20);
                        break;
                    }
                    nuevoPersonaje.Caracteristicas.Hp = 100;
                    nuevoPersonaje.Caracteristicas.Defensa = 100;

                    
                    listaPersonajes.Add(nuevoPersonaje);
                }
                return listaPersonajes;
            }
        }
    }
