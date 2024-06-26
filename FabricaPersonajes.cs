using System.Diagnostics;
using Api;
using CreacionPj;

namespace Creaciones;
    public class CreacionPj{
        public class Fabrica{
            private static Random random = new Random();
            public static List<Personaje> cargarDatos(List<Personaje> listaPersonajes, List<PersonajesApi> personajesApi){
                foreach(var personaje in personajesApi){
                    Personaje nuevoPersonaje = new Personaje();

                    nuevoPersonaje.Datos.Name = personaje.Name;
                    nuevoPersonaje.Datos.Endurance = personaje.Endurance;
                    nuevoPersonaje.Datos.Agility = personaje.Agility;
                    nuevoPersonaje.Datos.ClassName = personaje.ClassName;
                    nuevoPersonaje.Datos.Luck = personaje.Luck;
                    nuevoPersonaje.Datos.Magic = personaje.Magic;
                    nuevoPersonaje.Datos.NoblePhantasms = personaje.NoblePhantasms;
                    nuevoPersonaje.Datos.Story  = personaje.Story;

                    switch (personaje.Luck){
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
                    switch (personaje.Agility){
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
                    nuevoPersonaje.Caracteristicas.Nivel= 1;
                    
                    listaPersonajes.Add(nuevoPersonaje);
                }
                return listaPersonajes;
            }
        }
    }