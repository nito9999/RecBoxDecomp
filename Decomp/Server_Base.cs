using System;
using System.Net;

internal abstract class Server_Base
{
	public abstract int Get_port();

	public abstract void Set_port(int p0);

	public abstract string Get_server_name();

	public abstract void Set_server_name(string p0);

	public abstract byte[] Get_data_from_route(string p0, HttpListenerRequest p1);

	public abstract int get_delay();

	public abstract void Set_delay(int p0);
}
