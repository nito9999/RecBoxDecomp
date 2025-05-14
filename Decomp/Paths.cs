using System;
using System.IO;

internal class Paths
{
    public static string GetServerDirectory()
    {
        return string.Format("{0}\\Servers\\{1}", BaseDirectory, ServerId);
    }

    public static string GetPicturesFolder()
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Rec Room\\";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        return path;
    }

    public static string GetDocumentsFolder()
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Rec Room\\";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        return path;
    }

    public static string GetRoomsFolder()
    {
        string path = GetDocumentsFolder() + "Rooms\\";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        return path;
    }

    public static string GetPlayersFolder()
    {
        return GetServerDirectory() + "Players\\";
    }

    public static ulong ServerId  = 0UL;
    public static string Region = "us";
    public static string Version = "1.3.0";
    public static int NSPort = 56;
    public static int APIPort = 56700;
    public static int NotificationPort = 56701;
    public static int ImagePort = 56702;
    public static int CDNPort = 56703;
    public static string BaseDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RecBoxData");

}
