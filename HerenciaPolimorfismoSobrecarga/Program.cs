

using HerenciaPolimorfismoSobrecarga;
/**
* La Herencia se puede ver también en ClasesAbstractas, consiste en una clase Padre que hereda a 
* su Hija una serie de propiedades y métodos.
* 
* Polimorfismo también en ClasesAbstractas, se usa para sobrescribir métodos o propiedades de una
* clase Padre a través de virtual-override, o también con new
* 
* Sobrecarga de Métodos: un método puede tener diferentes comportamientos en función de los parámetros
* que se le pasen
*/
Persona persona = new Persona();
persona.Nombre = "Pepe";
persona.Edad = 20;
persona.DNI = 20254715;
persona.Info();
//Soy Pepe tengo 20 años, con DNI 20254715

Adulto adulto = new Adulto();//Herencia
adulto.Nombre = persona.Nombre;
adulto.Edad = persona.Edad;
adulto.DNI = persona.DNI;
adulto.IsTrabajadorActivo = true;
adulto.NumHijos = 3;
adulto.Info();//Polimorfismo
//Soy Pepe tengo 20 años, con DNI 20254715, Estoy Trabajando? True y actualmente tengo 3 hijos

//Sobrecarga
adulto.Saludo();//Hola soy Pepe
adulto.Saludo("Hola este es un saludo personalizado");//Hola este es un saludo personalizado