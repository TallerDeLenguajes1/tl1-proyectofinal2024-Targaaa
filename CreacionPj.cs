namespace CreacionPj;
    public enum Clases{ //es un listado que usare aleatoriamente para las clases de los personajes
        Saber,
        Archer,
        Lancer,
        Caster,
        Assasin,
        Berserker,
        Rider,
        Ruler
    }

    public class Personaje { 
        private int velocidad;
        private int hp; //vida
        private int mp; //maná
        private int nivel; //el nivel ira aumentando conforme vaya avanzando de ronda en el torneo
        private int sacred; //tesoro sagrado de los servants
        private string clase;
        private string nombre;
        private string nacimiento;

        public int Velocidad { get => velocidad;  set => velocidad = value; }
        public int Hp { get => hp; set => hp = value; }       
        public int Mp { get=> mp; set => mp = value; }
        public int Nivel { get => nivel; set => nivel = value;}
        public int Sacred { get=> sacred; set => sacred = value;}
        public string Clase { get => clase; set => clase = value; }
        public string Nombre { get => nombre; set => nombre = value;}
        public string Nacimiento { get => nacimiento; set => nacimiento = value;}
        
} 
