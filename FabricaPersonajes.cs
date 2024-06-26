
using Api;
using Personajes;

namespace Creaciones{
        public class Fabrica{
            private static Random random = new Random();
            public static List<Personaje> cargarDatos(List<Personaje> listaPersonajes, List<PjApi> personajesApi){
                foreach(var personaje in personajesApi){
                    Personaje nuevoPersonaje = new Personaje();
                    
                    nuevoPersonaje.Datos.Name = personaje.name;
                    nuevoPersonaje.Datos.Endurance = personaje.endurance;
                    nuevoPersonaje.Datos.Agility = personaje.agility;
                    nuevoPersonaje.Datos.ClassName = personaje.className;
                    nuevoPersonaje.Datos.Luck = personaje.luck;
                    nuevoPersonaje.Datos.Magic = personaje.magic;
                    nuevoPersonaje.Datos.NoblePhantasms = personaje.noblePhantasms;
                    nuevoPersonaje.Datos.Story  = personaje.story;

                    switch (personaje.luck){
                        case "A++":
                        case "A+":
                        case "A":
                            nuevoPersonaje.Caracteristicas.AtkBase = random.Next(10,41)*2.0;
                        break;
                        case "A-":
                        case "A--":
                            nuevoPersonaje.Caracteristicas.AtkBase = random.Next(10,41)*1.8;
                        break;
                        case "B++":
                        case "B+":
                        case "B":
                            nuevoPersonaje.Caracteristicas.AtkBase = random.Next(10,41)*1.6;
                        break;
                        case "B-":
                        case "B--":
                            nuevoPersonaje.Caracteristicas.AtkBase = random.Next(10,41)*1.4;
                        break;
                        case "C++":
                        case "C+":
                        case "C":
                            nuevoPersonaje.Caracteristicas.AtkBase = random.Next(10,41)*1.2;
                        break;
                        case "C-":
                        case "C--":
                            nuevoPersonaje.Caracteristicas.AtkBase = random.Next(10,41);
                        break;
                        case "D++":
                        case "D+":
                        case "D":
                        case "D-":
                        case "D--":
                            nuevoPersonaje.Caracteristicas.AtkBase = random.Next(10,41)*0.8;
                        break;
                        case "E++":
                        case "E+":
                        case "E":
                        case "E-":
                        case "E--":
                            nuevoPersonaje.Caracteristicas.AtkBase = random.Next(10,41)*0.6;
                        break;
                    }
                    switch (personaje.agility){
                        case "A++":
                        case "A+":
                        case "A":
                            nuevoPersonaje.Caracteristicas.Defensa = random.Next(10,41)*2.0;
                        break;
                        case "A-":
                        case "A--":
                            nuevoPersonaje.Caracteristicas.Defensa = random.Next(10,41)*1.8;
                        break;
                        case "B++":
                        case "B+":
                        case "B":
                            nuevoPersonaje.Caracteristicas.Defensa = random.Next(10,41)*1.6;
                        break;
                        case "B-":
                        case "B--":
                            nuevoPersonaje.Caracteristicas.Defensa = random.Next(10,41)*1.4;
                        break;
                        case "C++":
                        case "C+":
                        case "C":
                            nuevoPersonaje.Caracteristicas.Defensa = random.Next(10,41)*1.2;
                        break;
                        case "C-":
                        case "C--":
                            nuevoPersonaje.Caracteristicas.Defensa = random.Next(10,41);
                        break;
                        case "D++":
                        case "D+":
                        case "D":
                        case "D-":
                        case "D--":
                            nuevoPersonaje.Caracteristicas.Defensa = random.Next(10,41)*0.8;
                        break;
                        case "E++":
                        case "E+":
                        case "E":
                        case "E-":
                        case "E--":
                            nuevoPersonaje.Caracteristicas.Defensa = random.Next(10,41)*0.6;
                        break;
                    }
                    nuevoPersonaje.Caracteristicas.Nivel = 1;
                    
                    listaPersonajes.Add(nuevoPersonaje);
                }
                return listaPersonajes;
            }
        }
    }
