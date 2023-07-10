//Trabajar con fechas


using System.Globalization;

DateTime fecha = new DateTime(2020, 12, 14);//14/12/2020 0:00:00

DateTime fechaLarga = new DateTime(2020, 12, 14, 20, 45, 10);//14/12/2020 20:45:10

DateTime hoy = DateTime.Today;//04/07/2023 0:00:00

DateTime ahora = DateTime.Now;//04/07/2023 12:32:22
Console.WriteLine(ahora.TimeOfDay);//12:32:22

Console.WriteLine(ahora.ToString("  yyyy  MMMM  " +
    " ddd  dddd   HH  dd   f"));
//2023  julio   mar.  martes   12  04   6 -> mirar formato de cadenas

DateTime tresDiasDespues = hoy.AddDays(3);// 07/07/2023 0:00:00

DayOfWeek hoyDiaSemana = hoy.DayOfWeek;//Tuesday

bool esHorarioVerano = hoy.IsDaylightSavingTime();//True
bool esHorarioVerano2 = fecha.IsDaylightSavingTime();//False


//TimeSpan, representa un intervalo de tiempo, (mirar formato de cadenas)
TimeSpan duration = new TimeSpan(1, 12, 23, 62);
Console.WriteLine( duration);//1.12:24:02
Console.WriteLine("Tiempo en dias: {0:%d} dias", duration);//Tiempo en dias: 1 dias
Console.WriteLine("Tiempo en dias: "+ duration.ToString("%d") + " dias");//Tiempo en dias: 1 dias
Console.WriteLine("Tiempo total: {0:dd\\.hh\\:mm\\:ss} dias", duration);//Tiempo total: 01.12:24:02 dias
Console.WriteLine("Tiempo total: " + duration.ToString(@"dd\.hh\:mm\:ss"));//Tiempo total: 01.12:24:02

//Mostrar fecha según paises
DateTime localDate = DateTime.Now;
String[] cultureNames = { "en-US", "en-GB", "fr-FR",
                                "de-DE", "ru-RU", "es-ES" };

foreach (var cultureName in cultureNames)
{
    var culture = new CultureInfo(cultureName);
    Console.WriteLine("{0}: {1}", cultureName,
                      localDate.ToString(culture));
}
//en-US: 7/4/2023 1:10:26 PM
//en-GB: 04/07/2023 13:10:26
//fr-FR: 04/07/2023 13:10:26
//de-DE: 04.07.2023 13:10:26
//ru-RU: 04.07.2023 13:10:26
//es-ES: 04/07/2023 13:10:26