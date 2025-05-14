using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

internal sealed class Server_CDN : Server_Base
{
	public Server_CDN(int p0, string p1)
	{
		this.Set_port(p0);
		this.Set_server_name(p1);
		this.Set_delay(100);
	}

    public override int Get_port()
    {
        return this.port;
    }

    public override void Set_port(int p0)
    {
        this.port = p0;
    }

    public override string Get_server_name()
    {
        return this.server_name;
    }

    public override void Set_server_name(string p0)
    {
        this.server_name = p0;
    }

    public override int get_delay()
    {
        return this.delay;
    }

    public override void Set_delay(int p0)
    {
        this.delay = p0;
    }

    public override byte[] Get_data_from_route(string p0, HttpListenerRequest p1)
    {
        Console.WriteLine("[CDN] Requested file " + p0);
        byte[] array = new byte[0];
        try
        {
            WebClient webClient = new WebClient();
            try
            {
                array = webClient.DownloadData("https://github.com/nito9999/RecBox/raw/main/CDN/data" + p0.Substring(1));
            }
            finally
            {
                ((IDisposable)webClient).Dispose();
            }
        }
        catch
        {
            string text = "";//Paths.GetRoomsFolder() + c000041.f000043.Room.Name + p0.Substring(1);
            bool flag = File.Exists(text);
            if (flag)
            {
                Console.WriteLine("[DEBUG][CDN] File Exists " + text);
                array = File.ReadAllBytes(text);
            }
        }
        return array;
    }

    private int port;

	private string server_name;

	private int delay;
}
