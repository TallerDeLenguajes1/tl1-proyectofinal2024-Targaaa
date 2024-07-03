namespace Personajes{ 

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
        public int id { get; set; }
        public string name { get; set; }
        public string className { get; set; }
        public int rarity { get; set; }
        public string attribute{ get; set; }

        public string Attribute{ get => attribute; set => attribute = value; }
        public string ClassName { get => className; set => className = value; }
        public string Name { get => name; set => name = value;}
        public int Rarity { get => rarity; set => rarity = value;}



} 
public class Caracteristicas
    {   
        private double hpBase;
        private double atkBase; 
        private int nivel; 
        private double defensa;
        public Caracteristicas()
        {
            hpBase = 0;
            atkBase = 0;
            nivel = 0;
            defensa = 0;
        }
        public int Nivel { get => nivel; set => nivel = value;}
        public double Defensa { get => defensa; set => defensa = value;}
        public double AtkBase { get => atkBase; set => atkBase = value;}
        public double HpBase{ get => hpBase; set => hpBase = value; }
    }
}