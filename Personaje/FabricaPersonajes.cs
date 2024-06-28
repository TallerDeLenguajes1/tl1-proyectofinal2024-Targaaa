
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
                            nuevoPersonaje.Caracteristicas.AtkBase = random.Next(10,41)*1.5;
                        break;
                        case 4:
                            nuevoPersonaje.Caracteristicas.AtkBase = random.Next(10,41)*1.4;
                        break;
                        case 3:
                            nuevoPersonaje.Caracteristicas.AtkBase = random.Next(10,41)*1.3;
                        break;
                        case 2:
                            nuevoPersonaje.Caracteristicas.AtkBase = random.Next(10,41)*1.2;
                        break;
                        case 1:
                            nuevoPersonaje.Caracteristicas.AtkBase = random.Next(10,41)*1.1;
                        break;
                    }
                    nuevoPersonaje.Caracteristicas.Nivel = 1;
                    nuevoPersonaje.Caracteristicas.HpBase = 150;
                    nuevoPersonaje.Caracteristicas.Defensa = 100;

                    
                    listaPersonajes.Add(nuevoPersonaje);
                }
                return listaPersonajes;
            }
        }
    }
