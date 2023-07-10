using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaPolimorfismoSobrecarga
{
    public class Adulto : Persona // Persona es clase Padre, hace Herencia a clase Adulto
    {
        public bool IsTrabajadorActivo { get; set; }
        public int NumHijos { get; set; } = 0;

        //Polimorfismo, Info en Persona y en Adulto tienen comportamientos comportamientos diferentes
        public override void Info()
        {
            //base.Info(); -> esto llama al método de clase padre
            Console.WriteLine($"Soy {Nombre} tengo {Edad} años, con DNI {DNI}, " +
                $"Estoy Trabajando? {IsTrabajadorActivo} y actualmente tengo {NumHijos} hijos");
        }


        //Sobrecarga, función con mismo nombre se comporta diferente según parámetros
        public void Saludo() 
        {
            Console.WriteLine("Hola soy " + Nombre);
        }
        public void Saludo(string saludo) 
        {
            Console.WriteLine(saludo);
        }
    }
}
