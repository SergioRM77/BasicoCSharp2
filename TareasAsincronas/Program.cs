using System.Diagnostics;
/**
* Las tareas Asíncronas se usan para cosas como solicitar datos de una red, 
* acceder a una base de datos o leer y escribir un sistema de archivos, 
* cálculos complejos que pueden tardar...
* 
* La ejecución no espera a realizar las operaciones que pueden tardar o fallar,
* e incluso lo más probable es que falle porque a la hora de devolver unos datos
* no le ha dado tiempo a recopilarlos y lanza un error.
* 
* Los encargados de ello son los objetos Task y Task<T>, que tiene una estrecha
* relación con las palabras async y await:
*      * Código Enlazado E/S -> Task o Task<T>, dentro de un método async
*      * Código Enlazado CPU -> Task.Run subproceso en segundo plano 
*      
* async: para indicar que el método es asíncrono, al ejecutar el método, el 
*  programa sigue adelante.
* await: para indicarle al programa que pare hasta que finalice la tarea no
*  continúe
* 
*/

Stopwatch crono = Stopwatch.StartNew();// creamos un crono para ver cuanto tarda las tareas

double num = 0;
crono.Start();
for (int i = 0; i < 1000; i++)
      num += (i * 5.3654f - (i * i))/Math.PI;
crono.Stop();
//Console.WriteLine(crono.Elapsed);//00:00:00.0000036

var task1 = new Task(() => {
    Stopwatch stopwatch = Stopwatch.StartNew();
    stopwatch.Start();
    Thread.Sleep(1000);
    stopwatch.Stop();
    Console.WriteLine(stopwatch.Elapsed);
});

var task2 = new Task(() => {
    Stopwatch stopwatch = Stopwatch.StartNew();
    stopwatch.Start();
    Thread.Sleep(1000);
    stopwatch.Stop();
    Console.WriteLine(stopwatch.Elapsed);
});

var task3 = new Task(() => {
    Stopwatch stopwatch = Stopwatch.StartNew();
    stopwatch.Start();
    Thread.Sleep(1000);
    stopwatch.Stop();
    Console.WriteLine(stopwatch.Elapsed);
});

var task4 = new Task(() => {
    Stopwatch stopwatch = Stopwatch.StartNew();
    stopwatch.Start();
    Thread.Sleep(1000);
    stopwatch.Stop();
    Console.WriteLine(stopwatch.Elapsed);
});

var task5 = new Task(() => {
    Stopwatch stopwatch = Stopwatch.StartNew();
    stopwatch.Start();
    Thread.Sleep(1000);
    stopwatch.Stop();
    Console.WriteLine(stopwatch.Elapsed);
});


Console.WriteLine("Simulación de varias tareas, como consulta a base de datos");
Stopwatch stopwatch = Stopwatch.StartNew();
stopwatch.Start();

task1.Start();
task2.Start();
task3.Start();
task4.Start();
task5.Start();
//await task1;
//await task2;
//await task3;
//await task4;
//await task5;

//Esta es la versión corta
await  Task.WhenAll(task1, task2, task3, task4, task5);
stopwatch.Stop();

Console.WriteLine("5 tareas de 1 segundo cada una se han realizado en: " + stopwatch.Elapsed);
