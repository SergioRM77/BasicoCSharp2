using TiposDeObjetos;
/**
* Los objetos se crean a trabés de clases, dependiendo del tipo
* están las clases generales, las estructuras, los enumerables...
* entre otras cosas, como las interfaces o clases abstractas (en otro apartado) 
*/


//Objetos generales como por ejemplo un coche, tiene ruedas, color, marca y realiza acciones
//como acelerar, parar, etc...

Vehiculo veh =  new Vehiculo();
veh.Marca = "Seat";
veh.Color = "rojo";
veh.VelocidadMax = 120;
veh.InfoVehiculo();

string estado = veh.Acelerar(58);
Console.WriteLine(estado);

estado = veh.Frenar(40);
Console.WriteLine(estado);

estado = veh.Frenar(111);
Console.WriteLine(estado);
