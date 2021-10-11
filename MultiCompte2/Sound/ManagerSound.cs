namespace MultiCompte2.Sound
{
    class ManagerSound
    {
		public static GameServer gameServer = new GameServer();

		public static RegServer regServer = new RegServer();

		public static void Init()
		{
			gameServer.StartAuthentificate();
			regServer.StartAuthentificate();
		}
	}
}
