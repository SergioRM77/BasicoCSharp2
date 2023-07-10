

//Partiendo de la Clase Vehiculo, hacemos una interfaz de mínimos
//y la desarrollamos en esa clase
using Interfaces;
using TiposDeObjetos;
/**
* Las intefaces son una declaración de inteciones, un contrato
* en el que te comprometes a usar una serie de funciones. No se
* desarrollan, solo se definen y se encarga en la clase que la 
* implementa.
*/
Vehiculo v1 = new Vehiculo();
IVehiculo v2 = new Vehiculo();// las dos maneras son válidas

v1.Marca = "Audi";
v1.Color = "Rojo";
//v2.Marca = "Audi"; esto da error, porque IVehiculo no implementa eso

//***LA FUNCIONALIDAD ES IGUAL QUE EN TiposDeObjetos...
