using System;
using System.Threading;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Paths.Region = args[0];
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
        //new Server_Listener_Base(new Server_NS(Paths.NSPort, "NameServer"));
        //new Server_Listener_Base(new c0000a5(Paths.APIPort, "API"));
        //new Server_Listener_Base(new c00004f(Paths.ImagePort, "Image"));
        //new Server_Listener_Base(new Server_CDN(Paths.CDNPort, "CDN"));
        //new c000090("Notification", Paths.NotificationPort);
        Console.WriteLine("All servers started. Have fun!");
    }
}
