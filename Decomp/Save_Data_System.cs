using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal class Save_Data_System
{
	public static bool check_if_slot_not_empty(slot p0)
	{
		bool flag = Slots == null;
		if (flag)
		{
			Load_file_to_slots();
		}
		return Slots[(int)p0] != string.Empty;
	}

	public static void Load_file_to_slots()
	{
		Slots = new List<string>();
		string text = Paths.BaseDirectory + "\\0";
		bool flag = File.Exists(text);
		if (flag)
		{
			foreach (string text2 in File.ReadAllLines(text))
			{
				Slots.Add(text2);
			}
		}
		while (Slots.Count<string>() != 13)
		{
			Slots.Add(string.Empty);
		}
	}

	public static void write_to_slot(slot p0, byte[] p1)
	{
		bool flag = Slots == null;
		if (flag)
		{
			Load_file_to_slots();
		}
		string text = Convert.ToBase64String(p1, 0, p1.Length, Base64FormattingOptions.None);
		Slots[(int)p0] = text;
		Write_slots_to_file();
	}

	public static byte[] read_from_slot(slot p0)
	{
		bool flag = Slots == null;
		if (flag)
		{
			Load_file_to_slots();
		}
		return Convert.FromBase64String(Slots[(int)p0]);
	}

	public static void Write_slots_to_file()
	{
		bool flag = Slots == null;
		if (flag)
		{
			Load_file_to_slots();
		}
		bool flag2 = !Directory.Exists(Paths.BaseDirectory);
		if (flag2)
		{
			Directory.CreateDirectory(Paths.BaseDirectory);
		}
		string text = Paths.BaseDirectory + "\\0";
		File.WriteAllLines(text, Slots);
	}

	public static List<string> Slots;

	public enum slot
	{
		none,
		unk_1,
		unk_2,
		unk_3,
		unk_4,
		unk_5,
		unk_6,
		unk_7,
	}
}
