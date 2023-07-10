using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiposDeObjetos;

namespace ClasesAbstractas
{
    
    public class Avion : Vehiculo
    //una clase solo puede extender de una clase Abstracta, pero puede tener muchas Interfaces
    //a su vez una clase abstracta puede heredar de otra clase abstracta y tener interfaces
    {

        //new sobreescribe propiedades o métodos ocultado el de la clase base
        protected new int NumConductores { get; set; } = 2; 

        //podemos sobrescribir propiedades, pero el tipo y acceso debe ser el mismo
        protected override int NumRuedas { get; set; } = 3;

        /**La mayor diferencia entre new y override, override espera que 
         * en la clase base la propiedad o método tenga un virtual para poder sobrescribirlo
         * pero con new oculta el original de la clase base, de tal forma que con new el elemento
         * de la clase base sigue siendo accesible pero con override lo sobreescribe para siempre**/

        

        //Aquí nos obliga a usar el método abastracto y a implementarlo
        public override string Licencia(int valor)
        {
            if (valor > 1 && valor < 5)
                return "A"+valor;
            return "B"+valor;
        }

        //override nos permite ampliar, modificar o implementar métodos, propiedades
        //o eventos heredados de la clase padre
        public override void Encender() 
        {
            Console.WriteLine("Encender Avión");
        }

        public override void InfoVehiculo()
        {
            Console.WriteLine($"Marca: {Marca} Color: {Color} NumRuedas: {NumRuedas}" +
                $" VelocidadMax: {VelocidadMax}km/h Velocidad Actual: {VelocidadActual}km/h " +
                $"con NumPilotos: {NumConductores}");
        }

        public void InfoVevhiculoBase()
        {
            //Así podemos ver el método de la clase base, si hemos usado un 
            //override sobreescribe la clase base, modificado definitivo
            //new lo oculta, sigue existiendo el valor original en clase base
            base.InfoVehiculo();
        }

    }
}
