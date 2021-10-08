namespace MultiCompte2.Composants
{
    class HotKey
    {
		public enum FsModifiers
		{
			None = 0,
			Alt = 1,
			Control = 2,
			Shift = 4,
			Windows = 8,
			Alt_Ctrl = 3,
			Alt_Shift = 5,
			Alt_Windows = 9,
			Ctrl_Shift = 6,
			Ctrl_Windows = 10,
			Shift_Windows = 12,
			No_Repeat = 0x4000
		}

		public const int WM_HOTKEY = 786;

		public const int HOTKEY = 444719;

		public static object Liste_Touche = new string[55, 1]
		{
		{ "A" },
		{ "B" },
		{ "C" },
		{ "D" },
		{ "E" },
		{ "F" },
		{ "G" },
		{ "H" },
		{ "I" },
		{ "J" },
		{ "K" },
		{ "L" },
		{ "M" },
		{ "N" },
		{ "O" },
		{ "P" },
		{ "Q" },
		{ "R" },
		{ "S" },
		{ "T" },
		{ "U" },
		{ "V" },
		{ "W" },
		{ "X" },
		{ "Y" },
		{ "Z" },
		{ "0" },
		{ "1" },
		{ "2" },
		{ "3" },
		{ "4" },
		{ "5" },
		{ "6" },
		{ "7" },
		{ "8" },
		{ "9" },
		{ "F1" },
		{ "F2" },
		{ "F3" },
		{ "F4" },
		{ "F5" },
		{ "F6" },
		{ "F7" },
		{ "F8" },
		{ "F9" },
		{ "F10" },
		{ "F11" },
		{ "F12" },
		{ "Echap" },
		{ "Inser" },
		{ "Fin" },
		{ "Fleche du Haut" },
		{ "Fleche du Bas" },
		{ "Fleche de Gauche" },
		{ "Fleche de Droite" }
		};
	}
}
