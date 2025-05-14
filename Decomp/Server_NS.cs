using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

internal sealed class Server_NS : Server_Base
{
	public Server_NS(int p0, string p1)
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
        return Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(this.ns_data));
    }

    private int port;

	private string server_name;

	private int delay;

	private NS_Data ns_data = new NS_Data
	{
		API = string.Format("http://localhost:{0}/", Paths.APIPort),
		Images = string.Format("http://localhost:{0}/", Paths.ImagePort),
		Notifications = string.Format("ws://localhost:{0}/", Paths.NotificationPort)
	};
}
