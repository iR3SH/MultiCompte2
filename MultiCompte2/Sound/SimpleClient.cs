using System;
using System.Net;
using System.Net.Sockets;

namespace MultiCompte2.Sound
{
    class SimpleClient
    {
		public class ConnectedEventArgs : EventArgs
		{
		}

		public class DisconnectedEventArgs : EventArgs
		{
			public SimpleClient Socket { get; set; }

			public DisconnectedEventArgs(SimpleClient socket)
			{
				Socket = socket;
			}
		}

		public class DataSendedEventArgs : EventArgs
		{
		}

		public class DataReceivedEventArgs : EventArgs
		{
			public byte[] Data { get; set; }

			public DataReceivedEventArgs(byte[] data)
			{
				Data = data;
			}
		}

		public class ErrorEventArgs : EventArgs
		{
			public Exception Ex { get; set; }

			public ErrorEventArgs(Exception ex)
			{
				Ex = ex;
			}
		}

		public Socket Socket;

		private byte[] sendBuffer;

		private byte[] receiveBuffer;

		private byte[] buffer;

		private const int bufferLength = 8192;

		public bool Normaly = false;

		public bool Runing { get; set; }

		public event EventHandler<ConnectedEventArgs> Connected;

		public event EventHandler<DisconnectedEventArgs> Disconnected;

		public event EventHandler<DataReceivedEventArgs> DataReceived;

		public event EventHandler<DataSendedEventArgs> DataSended;

		public event EventHandler<ErrorEventArgs> ErrorH;

		public SimpleClient(string ip, short port)
		{
			Init();
			Start(ip, port);
		}

		public SimpleClient(Socket socket)
		{
			Init();
			Start(socket);
		}

		public SimpleClient()
		{
			Init();
		}

		public void Start(Socket socket)
		{
			try
			{
				Runing = true;
				Socket = socket;
				Socket.BeginReceive(receiveBuffer, 0, 8192, SocketFlags.None, ReceiveCallBack, Socket);
			}
			catch (Exception ex)
			{
				OnError(new ErrorEventArgs(ex));
			}
		}

		public void Start(string ip, short port)
		{
			try
			{
				Socket.BeginConnect(new IPEndPoint(IPAddress.Parse(ip), Convert.ToInt32(port)), ConnectionCallBack, Socket);
			}
			catch (Exception ex)
			{
				OnError(new ErrorEventArgs(ex));
			}
		}

		public void Start(IPEndPoint endPoint)
		{
			try
			{
				Socket.BeginConnect(endPoint, ConnectionCallBack, Socket);
			}
			catch (Exception ex)
			{
				OnError(new ErrorEventArgs(ex));
			}
		}

		public void Stop()
		{
			try
			{
				if (Socket.Connected)
				{
					Socket.BeginDisconnect(reuseSocket: false, DisconectedCallBack, Socket);
				}
			}
			catch (Exception ex)
			{
				OnError(new ErrorEventArgs(ex));
			}
		}

		public void Send(byte[] data)
		{
			try
			{
				if (!Socket.Connected)
				{
					Runing = false;
				}
				if (Runing)
				{
					if (data.Length != 0)
					{
						sendBuffer = data;
						Socket.BeginSend(sendBuffer, 0, sendBuffer.Length, SocketFlags.None, SendCallBack, Socket);
					}
				}
				else
				{
					Console.WriteLine("Send " + data.Length + " bytes but not runing");
				}
			}
			catch (Exception ex)
			{
				OnError(new ErrorEventArgs(ex));
			}
		}

		public void Dispose()
		{
			if (Socket != null)
			{
				Socket.Dispose();
			}
			if (buffer != null)
			{
				buffer = null;
			}
			Socket = null;
			sendBuffer = null;
			receiveBuffer = null;
			buffer = null;
		}

		private void Init()
		{
			try
			{
				buffer = new byte[8192];
				receiveBuffer = new byte[8192];
				Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			}
			catch (Exception ex)
			{
				OnError(new ErrorEventArgs(ex));
			}
		}

		private void ConnectionCallBack(IAsyncResult asyncResult)
		{
			try
			{
				Runing = true;
				Socket socket = (Socket)asyncResult.AsyncState;
				socket.EndConnect(asyncResult);
				socket.BeginReceive(receiveBuffer, 0, 8192, SocketFlags.None, ReceiveCallBack, socket);
				OnConnected(new ConnectedEventArgs());
			}
			catch (Exception ex)
			{
				OnError(new ErrorEventArgs(ex));
			}
		}

		private void DisconectedCallBack(IAsyncResult asyncResult)
		{
			try
			{
				Runing = false;
				Socket socket = (Socket)asyncResult.AsyncState;
				socket.EndDisconnect(asyncResult);
				OnDisconnected(new DisconnectedEventArgs(this));
			}
			catch (Exception ex)
			{
				OnError(new ErrorEventArgs(ex));
			}
		}

		private void ReceiveCallBack(IAsyncResult asyncResult)
		{
			Socket socket = (Socket)asyncResult.AsyncState;
			if (!socket.Connected)
			{
				Runing = false;
			}
			else if (Runing)
			{
				int num = 0;
				try
				{
					num = socket.EndReceive(asyncResult);
				}
				catch (Exception ex)
				{
					OnError(new ErrorEventArgs(ex));
				}
				if (num == 0)
				{
					Runing = false;
					OnDisconnected(new DisconnectedEventArgs(this));
					return;
				}
				byte[] destinationArray = new byte[num - 1 + 1];
				Array.Copy(receiveBuffer, destinationArray, num);
				buffer = destinationArray;
				OnDataReceived(new DataReceivedEventArgs(buffer));
				try
				{
					socket.BeginReceive(receiveBuffer, 0, 8192, SocketFlags.None, ReceiveCallBack, socket);
				}
				catch (Exception ex2)
				{
					OnError(new ErrorEventArgs(ex2));
				}
			}
			else
			{
				Console.WriteLine("Receive data but not running");
			}
		}

		private void SendCallBack(IAsyncResult asyncResult)
		{
			try
			{
				if (Runing)
				{
					Socket socket = (Socket)asyncResult.AsyncState;
					socket.EndSend(asyncResult);
					OnDataSended(new DataSendedEventArgs());
				}
				else
				{
					Console.WriteLine("Send data but not runing !");
				}
			}
			catch (Exception ex)
			{
				OnError(new ErrorEventArgs(ex));
			}
		}

		private void OnConnected(ConnectedEventArgs e)
		{
			if (this.Connected != null)
			{
				this.Connected?.Invoke(this, e);
			}
		}

		private void OnDisconnected(DisconnectedEventArgs e)
		{
			if (this.Disconnected != null)
			{
				this.Disconnected?.Invoke(this, e);
			}
		}

		private void OnDataReceived(DataReceivedEventArgs e)
		{
			if (this.DataReceived != null)
			{
				this.DataReceived?.Invoke(this, e);
			}
		}

		private void OnDataSended(DataSendedEventArgs e)
		{
			if (this.DataSended != null)
			{
				this.DataSended?.Invoke(this, e);
			}
		}

		private void OnError(ErrorEventArgs e)
		{
			if (this.ErrorH != null)
			{
				this.ErrorH?.Invoke(this, e);
			}
		}
	}
}
