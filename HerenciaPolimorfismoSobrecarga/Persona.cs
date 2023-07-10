using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaPolimorfismoSobrecarga
{
    public class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int DNI { get; set;}

        //este método es virtual, lo puede modificar la clase hija, Polimorfismo
        public virtual void Info() 
        {
            Console.WriteLine($"Soy {Nombre} tengo {Edad} años, con DNI {DNI}");
        }
    }
}
