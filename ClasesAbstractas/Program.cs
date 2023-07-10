using ClasesAbstractas;
using TiposDeObjetos;
/**
* La palabra clave abstract permite crear clases y miembros class que están incompletos 
* y se deben implementar en una clase derivada.
* Siempre se pueden dejar la mayor parte de funcionalidades hechas y después ampliar o 
* sobrescribir.
* 
* En otros proyectos hemos usado la clase vehiculo, esta es más genérica ya que un coche,
* un avión, una moto... todos son vehiculos, pero cambian cosas, en este ejemplo usamos
* la clase Avión, que sobreescribe funcionalidades y a la vez  implementa nuevas.
*/
Avion av = new Avion();
av.InfoVehiculo();
av.Marca = "Rayanair";
av.Color = "Blanco";
av.VelocidadMax = 400;
av.InfoVehiculo();
//Marca: Rayanair Color: Blanco NumRuedas: 3 VelocidadMax: 400km/h Velocidad Actual: 0km/h
//con NumPilotos: 2 

av.InfoVevhiculoBase();
//Marca: Rayanair Color: Blanco NumRuedas: 3 VelocidadMax: 400km/h Velocidad Actual: 0km/h
//con NumPilotos: 1

/**NumRuedas se ha modificado en clase base por override, por eso tiene 3 ruedas
 * NumPilotos solo se oculta en clase base por eso sigue existiendo el valor original si
 *      se llama al método base
 **/


