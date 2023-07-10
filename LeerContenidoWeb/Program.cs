using System.Net;

String url = "https://www.bing.com";

string s;
using (WebClient client = new WebClient())
{
    s = client.DownloadString(url);
}

Console.WriteLine(s);