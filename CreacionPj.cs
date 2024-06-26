namespace CreacionPj;
    public class Personaje { 
        private Datos datos;
        private Caracteristicas caracteristicas;
        public Personaje()
        {
            datos = new Datos();
            caracteristicas = new Caracteristicas();
        }
        public Datos Datos { get => datos; set => datos = value; }
        public Caracteristicas Caracteristicas { get => caracteristicas; set => caracteristicas = value; }
    }

    public class Datos
    {
        private string className;
        private string name;
        private string story; // VER EN PROCESOOOOOOOOOOOOOOOOOOO  
        private string noblePhantasms; //tesoro sagrado 
        private string luck; //suerte
        private string endurance;
        private string magic;
        private string agility;

        public string ClassName { get => className; set => className = value; }
        public string Name { get => name; set => name = value;}
        public string Story { get => story; set => story = value; }
        public string NoblePhantasms { get => noblePhantasms; set => noblePhantasms = value;}
        public string Luck { get => luck; set => luck = value; }
        public string Endurance { get => endurance; set => endurance = value; }
        public string Magic { get => magic; set => magic = value; }
        public string Agility { get => agility; set => agility = value; }
} 
public class Caracteristicas
    {   
        private double hpBase; //vida
        private double atkBase; //ataque
        private int mp; //maná
        private int nivel; //el nivel ira aumentando conforme vaya avanzando de ronda en el torneo
        private double defensa;
        public Caracteristicas()
        {
            hpBase = 0;
            atkBase = 0;
            mp = 0;
            nivel = 0;
            defensa = 0;
        }
        public int Mp { get=> mp; set => mp = value; }
        public int Nivel { get => nivel; set => nivel = value;}
        public double Defensa { get => defensa; set => defensa = value;}
        public double AtkBase { get => atkBase; set => atkBase = value;}
        public double HpBase{ get => hpBase; set => hpBase = value; }
}