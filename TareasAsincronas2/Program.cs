/**Los métodos async se usan con Task o Task<T> y esperan un 
 * await para un proceso que puede demorarse. También existe 
 * Task.Run para procesos de la CPU a un segundo plano o subproceso
 */

//Esto es un método que consigue el contenido String de una página
//tiene un await porque tarda más en recopilar la información
async Task<int> GetUrlContentLengthAsync()
{
    var client = new HttpClient();

    Task<string> getStringTask =
        client.GetStringAsync("https://learn.microsoft.com/dotnet");

    DoIndependentWork();

    string contents = await getStringTask;

    return contents.Length;
}

//Función random, no sabemos cuándo puede parar
async Task<(int, int)> GetRandomAsync() 
{
    Console.WriteLine("Dame num divisible entre 74 y 31");
    Random rnd = new Random();
    int num = 2;
    int contador = 1;
    while ((num % 74 != 0 & num % 31 != 0))
    {
        num = rnd.Next(0, 1000);
        contador++;
    }
    return (num, contador);
}

void DoIndependentWork()
{
    Console.WriteLine("Working...");
}

//Aquí tambien debemos poner un await, aunque en la
//función tenga un await, fuera del método no sabe 
//que es asíncrono y debe esperarse
var valor = await GetUrlContentLengthAsync();

Console.WriteLine(valor);

Console.WriteLine("Si no ponemos await el código puede terminar sin conseguir lo esperado" +
    "\nEsto es una opción, pero no es recomendable, al poner un Console.Readline esperamos que consiga" +
    "el resultado y luego le damos enter para terminar");
var valor2 = GetUrlContentLengthAsync();
Console.WriteLine(valor);
Console.ReadLine();

//llamamos a método random
(int rnd, int contador) = await GetRandomAsync();
Console.WriteLine(rnd + ". Número de veces intentado: " + contador);

