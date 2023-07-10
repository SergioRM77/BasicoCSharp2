using ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiposDeObjetos
{
    public abstract class Vehiculo : Maquina
    {
        public string Marca { get; set; }
        public string Color { get; set; }
        protected virtual int NumRuedas { get; set; } = 4;
        public int VelocidadMax { get; set; }
        protected int VelocidadActual { get; set; } = 0;

        protected virtual int NumConductores { get; set; } = 1;

        //Los métodos abstractos no tienen implementación
        //muy parecido a las interfaces pero podemos tener 
        //funciones ya esctritas para usar tal cual o sobrescribir
        public abstract string Licencia(int valor);

        public virtual void InfoVehiculo() 
        {
            Console.WriteLine($"Marca: {Marca} Color: {Color} NumRuedas: {NumRuedas}" +
                $" VelocidadMax: {VelocidadMax}km/h Velocidad Actual: {VelocidadActual}km/h " +
                $"con NumPilotos: {NumConductores}");
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

        public virtual void Encender() 
        {
            Console.WriteLine("Encender Vehículo");
        }

    }
}
