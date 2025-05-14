using System;
using System.IO;
using System.Net;
using System.Threading;

internal class Server_Listener_Base
{
	public Server_Listener_Base(Server_Base p0)
	{
		this.server_base = p0;
		try
		{
			Console.WriteLine(this.server_base.Get_server_name());
			new Thread(new ThreadStart(this.Server_start)).Start();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}
	}

	public void Server_start()
	{
		this.Listener.Prefixes.Add(string.Format("http://+:{0}/", this.server_base.Get_port()));
		for (;;)
		{
			this.Listener.Start();
			HttpListenerContext context = this.Listener.GetContext();
			HttpListenerRequest request = context.Request;
			HttpListenerResponse response = context.Response;
			string rawUrl = request.RawUrl;
			byte[] array = this.server_base.Get_data_from_route(rawUrl, request);
			response.ContentLength64 = (long)array.Length;
			Stream outputStream = response.OutputStream;
			outputStream.Write(array, 0, array.Length);
			Thread.Sleep(this.server_base.get_delay());
			outputStream.Close();
			this.Listener.Stop();
		}
	}

	private Server_Base server_base;

	private HttpListener Listener = new HttpListener();
}
