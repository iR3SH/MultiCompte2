using System;
using MultiCompte2.Sound;

namespace MultiCompte2.Sound
{
    class Client
    {
		public class DisconnectedArgs : EventArgs
		{
			public Client Host { get; set; }

			public DisconnectedArgs(Client host)
			{
				Host = host;
			}
		}

		private SimpleClient m_client;

		public event EventHandler<DisconnectedArgs> Disconnected;

		public Client(SimpleClient client)
		{
			m_client = client;
			if (client != null)
			{
				m_client.DataReceived += ClientDataReceive;
				m_client.Disconnected += ClientDisconnected;
			}
		}

		public void Dipose()
		{
			m_client.DataReceived -= ClientDataReceive;
			m_client.Disconnected -= ClientDisconnected;
			m_client.Stop();
		}

		private void ClientDataReceive(object sender, SimpleClient.DataReceivedEventArgs e)
		{
		}

		private void ClientDisconnected(object sender, SimpleClient.DisconnectedEventArgs e)
		{
			OnDisconnected(new DisconnectedArgs(this));
		}

		private void OnDisconnected(DisconnectedArgs e)
		{
			if (this.Disconnected != null)
			{
				this.Disconnected?.Invoke(this, e);
			}
		}

		public void Send(byte[] data)
		{
			if (m_client.Runing)
			{
				m_client.Send(data);
			}
		}
	}
}
