using System.Net.Sockets;

namespace MultiCompte2.Sound
{
    class GameServer
    {
		private SimpleServer m_server;

		private GameClient m_client;

		public GameClient Client => m_client;

		public GameServer()
		{
			m_server = new SimpleServer();
		}

		public void StartAuthentificate()
		{
			m_server.Start(8081);
			m_server.ConnectionAccepted += AccepteClient;
		}

		private void AccepteClient(Socket client)
		{
			SimpleClient client2 = new SimpleClient(client);
			m_client = new GameClient(client2);
		}

		private void ClientDisconnected(object sender, GameClient.DisconnectedArgs e)
		{
			m_client = null;
		}
	}
}
