using System;
using System.Threading;

internal class Program
{
    private static void Main(string[] p0)
    {
        try
        {
            Paths.Region = p0[0];
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Launch arguments not found.");
            Console.ResetColor();
            Thread.Sleep(2000);
            Console.Clear();
        }
        Console.Title = "Rec Box";
        Console.WriteLine("Initializing Rec Box...");
        /*
        new c000051(new c00007b(Paths.NSPort, "NameServer"));
        new c000051(new c0000a5(Paths.APIPort, "API"));
        new c000051(new c00004f(Paths.ImagePort, "Image"));
        new c000051(new c000030(Paths.CDNPort, "CDN"));
        new c000090("Notification", Paths.NotificationPort);
        */
        Console.WriteLine("All servers started. Have fun!");
    }
}
