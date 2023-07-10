using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiposDeObjetos
{
    public class Vehiculo : IVehiculo //, IVolar, IPlanear ... Podemos tener todas las interfaces que queramos
    {
        public string Marca { get; set; }
        public string Color { get; set; }
        protected int NumRuedas { get; set; } = 4;
        public int VelocidadMax { get; set; }
        public int VelocidadActual { get; set; } = 0;

        public void InfoVehiculo() 
        {
            Console.WriteLine($"Marca: {Marca} Color: {Color} NumRuedas: {NumRuedas}" +
                $" VelocidadMax: {VelocidadMax}km/h Velocidad Actual: {VelocidadActual}km/h");
        }

        public string Acelerar(int velocidad)
        {
            VelocidadActual = velocidad;
            return $"El coche circula a {VelocidadActual}km/h actualmente";
        }

        public string Frenar(int velocidad)
        {
            VelocidadActual = velocidad >= VelocidadActual ? 0 : VelocidadActual - velocidad;
            return VelocidadActual == 0 ? $"El coche está parado" : $"El coche circula a {VelocidadActual}km/h";
        }


    }
}
