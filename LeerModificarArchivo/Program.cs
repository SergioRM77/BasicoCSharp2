/**
 * Crear archivos puede ser útil, tanto para crear registros, configuraciones,
 * crear con otras librerías pdf, html... es algo complejo pero posible.
 * 
 * Una de las mayores utilidades pueden ser para registrar los loggs de errores
 * en caso de no disponer de base de datos, podemos guardarlo en archivos txt.
 * 
 * Si son archivos muy grandes, para modificarlos es poco eficiente, quizás una
 * solución más acertada es convertirlo a lista y modificar por posición.
 */
using System.IO;
using System.Text;
//1º Comprobar si existe un archivo File
string path = @"archivo.txt";
    //Esto es para poder pasar por todos los procesos
    if (File.Exists("archivo.txt")) File.Delete("archivo.txt");

if (!File.Exists(path))
{
    //En caso de no existir lo creamos
    using (StreamWriter sw = File.CreateText(path))
    {
        sw.WriteLine("Hola");
        sw.WriteLine("Esto es ");
        sw.WriteLine("Un archivo");

        //Se debe cerrar el archivo una vez deje de modificarse
        sw.Close();
    }
}


// 2º Para leer el archivo se usa StreamReader
using (StreamReader sr = File.OpenText(path))
{
    string s = "";
    while ((s = sr.ReadLine()) != null)
    {
        Console.WriteLine(s);
    }
}


/**
 * 3º Para modificar un archivo, debemos duplicar el archivo en 
 * otro temporal, línea por línea lo copiamos en el temporal y 
 * la coincidencia que queremos cambiar la saltamos o metemos
 * otra cosa. Despues cambiamos el nombre del archivo
 * No es muy eficiente si es un texto largo
 * */
using (StreamWriter nuevo = new StreamWriter("temp.txt"))
{
    using (StreamReader existene = File.OpenText("archivo.txt"))
    {
        string s = "";
        while ((s = existene.ReadLine()) != null)
        {
            if (s.Contains("archivo"))
            {
                nuevo.WriteLine("Un archivo modificado");
            }
            else
            {
                nuevo.WriteLine(s);
            }
        }
    }
}
Console.WriteLine("Ahora hay 2 archivos, archivo.txt y temp.txt. Si quieres mantener los 2 Pon 'si'" +
    " (se cambiará temp.txt por archivoModificado.txt) en caso de que no, se borrará el original " +
    "y se cambiará el temp.txt por archivo.txt");
var resp = Console.ReadLine();

if (resp == "si")
{
    //Comprueba si existe para borrarlo, no puede moverlo  si existe de antes
    if (File.Exists("archivoModificado.txt")) File.Delete("archivoModificado.txt");
    File.Move("temp.txt", "archivoModificado.txt");
    File.Delete("temp.txt");
}
else
{
    //Comprueba si existe para borrarlo, no puede moverlo  si existe de antes
    if (File.Exists("archivoModificado.txt")) File.Delete("archivoModificado.txt");

    //Debemos borrarlo porque existe por ser el original
    File.Delete(path);
    File.Move("temp.txt", "archivo.txt");
    File.Delete("temp.txt");
    
}

