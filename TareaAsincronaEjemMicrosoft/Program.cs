/**
 * En este ejemplo se muestra tareas asincrónicas y conseguir datos de una web
 * 
 */

using System.Diagnostics;

//HttpClient expone la capacidad de enviar solicitudes HTTP
//y de recibir respuestas HTTP. 
HttpClient s_client = new()
{
    MaxResponseContentBufferSize = 1_000_000
};

//s_urlList contiene todas
//las direcciones URL que planea procesar la aplicación.
IEnumerable<string> s_urlList = new string[]
{
    "https://learn.microsoft.com",
    "https://learn.microsoft.com/aspnet/core",
    "https://learn.microsoft.com/azure",
    "https://learn.microsoft.com/azure/devops",
    "https://learn.microsoft.com/dotnet",
    "https://learn.microsoft.com/dynamics365",
    "https://learn.microsoft.com/education",
    "https://learn.microsoft.com/enterprise-mobility-security",
    "https://learn.microsoft.com/gaming",
    "https://learn.microsoft.com/graph",
    "https://learn.microsoft.com/microsoft-365",
    "https://learn.microsoft.com/office",
    "https://learn.microsoft.com/powershell",
    "https://learn.microsoft.com/sql",
    "https://learn.microsoft.com/surface",
    "https://learn.microsoft.com/system-center",
    "https://learn.microsoft.com/visualstudio",
    "https://learn.microsoft.com/windows",
    "https://learn.microsoft.com/xamarin"
};


//Método que Suma los bytes de cada página
async Task SumPageSizesAsync()
{
    //crono para ver cuanto tarda
    var stopwatch = Stopwatch.StartNew();

    //Crea una colección de tareas, LINQ nos ayuda
    //pasa la URL y la capacidad de solicitudes HTTP.
    //Devuleve un entero
    IEnumerable<Task<int>> downloadTasksQuery =
        from url in s_urlList
        select ProcessUrlAsync(url, s_client);

    //Por la ejecución diferida con LINQ, se llama a Enumerable.ToList
    //para iniciar cada tarea.
    List<Task<int>> downloadTasks = downloadTasksQuery.ToList();

    int total = 0;
    while (downloadTasks.Any())
    {
        //Espera una llamada a WhenAny para identificar la "primera" tarea
        //de la colección que ha finalizado su descarga.
        Task<int> finishedTask = await Task.WhenAny(downloadTasks);

        //quitar tarea de la colección
        downloadTasks.Remove(finishedTask);

        // La variable finishedTask es un Task<TResult> donde TResult
        // es un entero. La tarea ya está completa, pero la espera
        // para recuperar la longitud del sitio web descargado
        // Si se produce un error en la tarea, await iniciará
        // la primera excepción secundaria almacenada en AggregateException.
        // Si todo bien, se guarda el num de bytes
        total += await finishedTask;
    }

    stopwatch.Stop();

    //Finalizado todo los cálculos muestra el tiempo y capacidad
    Console.WriteLine($"\nTotal bytes returned:    {total:#,#}");
    Console.WriteLine($"Elapsed time:              {stopwatch.Elapsed}\n");
}


static async Task<int> ProcessUrlAsync(string url, HttpClient client)
{
    //Para cualquier dirección URL, el método usará la instancia de client
    //proporcionada para obtener la respuesta como byte[].
    //La longitud se devuelve después de que la dirección URL
    //y la longitud se escriban en la consola.
    byte[] content = await client.GetByteArrayAsync(url);
    Console.WriteLine($"{url,-60} {content.Length,10:#,#}");

    return content.Length;
}

//Ejecutamos la aplicación de forma asíncrona
await SumPageSizesAsync();


// Example output:
// https://learn.microsoft.com                                      132,517
// https://learn.microsoft.com/powershell                            57,375
// https://learn.microsoft.com/gaming                                33,549
// https://learn.microsoft.com/aspnet/core                           88,714
// https://learn.microsoft.com/surface                               39,840
// https://learn.microsoft.com/enterprise-mobility-security          30,903
// https://learn.microsoft.com/microsoft-365                         67,867
// https://learn.microsoft.com/windows                               26,816
// https://learn.microsoft.com/xamarin                               57,958
// https://learn.microsoft.com/dotnet                                78,706
// https://learn.microsoft.com/graph                                 48,277
// https://learn.microsoft.com/dynamics365                           49,042
// https://learn.microsoft.com/office                                67,867
// https://learn.microsoft.com/system-center                         42,887
// https://learn.microsoft.com/education                             38,636
// https://learn.microsoft.com/azure                                421,663
// https://learn.microsoft.com/visualstudio                          30,925
// https://learn.microsoft.com/sql                                   54,608
// https://learn.microsoft.com/azure/devops                          86,034

// Total bytes returned:    1,454,184
// Elapsed time:            00:00:01.1290403