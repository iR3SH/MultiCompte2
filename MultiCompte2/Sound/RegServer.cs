using System.Net.Sockets;

namespace MultiCompte2.Sound
{
    class RegServer
    {
		private SimpleServer m_server;

		private RegClient m_client;

		public RegClient Client => m_client;

		public RegServer()
		{
			m_server = new SimpleServer();
		}

		public void StartAuthentificate()
		{
			m_server.Start(8080);
            m_server.ConnectionAccepted += AccepteClient;
		}

		private void AccepteClient(Socket client)
		{
			SimpleClient client2 = new SimpleClient(client);
			m_client = new RegClient(client2);
		}

		private void ClientDisconnected(object sender, RegClient.DisconnectedArgs e)
		{
			m_client = null;
		}
	}
}
