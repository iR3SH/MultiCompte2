using System.Net.Sockets;

namespace MultiCompte2.Sound
{
    class Server
    {
		private SimpleServer m_server;

		private Client m_client;

		public Client Client => m_client;

		public bool IsStart => m_server.Connected;

		public Server()
		{
			m_server = new SimpleServer();
		}

		public void StartAuthentificate()
		{
			m_server.Start(4242);
			m_server.ConnectionAccepted += AccepteClient;
		}

		private void AccepteClient(Socket client)
		{
			SimpleClient client2 = new SimpleClient(client);
			m_client = new Client(client2);
		}

		private void ClientDisconnected(object sender, Client.DisconnectedArgs e)
		{
			m_client = null;
		}
	}
}
