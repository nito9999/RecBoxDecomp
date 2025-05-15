using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

public sealed class c000057
{
	public static List<c000057.UserGift> m000009()
	{
		bool flag = c000057.m000035() == null;
		if (flag)
		{
			c000057.m000024();
		}
		using (WebClient webClient = new WebClient())
		{
			c000057.c00005c c00005c = new c000057.c00005c();
			c00005c = JsonConvert.DeserializeObject<c000057.c00005c>(webClient.DownloadString("https://raw.githubusercontent.com/nito9999/RecBox/main/PlayerGifts.json"));
			bool flag2 = c000057.f00000a == null;
			if (flag2)
			{
				c000057.f00000a = string.Empty;
			}
			bool flag3 = c000057.f00000a != c00005c.LastUpdated;
			if (flag3)
			{
				bool flag4 = c00005c.UserGifts.ContainsKey(c000079.m000009()[0].Id);
				if (flag4)
				{
					foreach (c000057.UserGift c00005b in c00005c.UserGifts[c000079.m000009()[0].Id])
					{
						c000057.m000035().Add(c00005b);
					}
				}
				bool flag5 = c00005c.UserGifts.ContainsKey(69420UL);
				if (flag5)
				{
					foreach (c000057.UserGift c00005b2 in c00005c.UserGifts[69420UL])
					{
						c000057.m000035().Add(c00005b2);
					}
				}
				c000057.f00000a = c00005c.LastUpdated;
				c000057.m000033();
			}
		}
		return c000057.m000035();
	}

	private static List<c000057.UserGift> m000035()
	{
		return c000057.f000034;
	}

	private static void m000036(List<c000057.UserGift> p0)
	{
		c000057.f000034 = p0;
	}

	public static UserGift m000037(c000075.GiftDrop p0)
	{
		UserGift c00005b = new UserGift
		{
			Id = (long)p0.GiftDropId,
			AvatarItemDesc = p0.AvatarItemDesc,
			ConsumableItemDesc = p0.ConsumableItemDesc,
			EquipmentPrefabName = p0.EquipmentPrefabName,
			EquipmentModificationGuid = p0.EquipmentModificationGuid,
			CurrencyType = StoreFronts.Currency.Invalid,
			Currency = 0,
			Xp = 0,
			Level = 0,
			GiftRarity = p0.Rarity,
			Message = "Thank you for your purchase!",
			Context = p0.Context
		};
		m000009().Add(c00005b);
		m000033();
		return c00005b;
	}

	public static c000057.UserGift m000038(Dictionary<string, string> p0)
	{
		bool flag = c000057.f000050 == null;
		if (flag)
		{
			WebClient webClient = new WebClient();
			try
			{
				c000057.f000050 = JsonConvert.DeserializeObject<Dictionary<c000057.Context_type, List<c000057.UserGift>>>(webClient.DownloadString("https://raw.githubusercontent.com/nito9999/RecBox/main/ContextDrops.json"));
			}
			finally
			{
				((IDisposable)webClient).Dispose();
			}
		}
		bool flag2 = true;
		c000057.UserGift c00005b = new c000057.UserGift();
		c000057.Context_type @enum = (c000057.Context_type)int.Parse(p0["GiftContext"]);
		bool flag3 = c000057.f000050.ContainsKey(@enum);
		if (flag3)
		{
			using (List<c000057.UserGift>.Enumerator enumerator = c000057.f000050[@enum].GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					c000057.UserGift c00005b2 = enumerator.Current;
					bool flag4 = c00005b2.AvatarItemDesc != string.Empty;
					if (flag4)
					{
						bool flag5 = !c00008c.c00008e.m00000f(c00005b2.AvatarItemDesc);
						if (flag5)
						{
							flag2 = false;
							c00005b = c00005b2;
							break;
						}
					}
					else
					{
						bool flag6 = !(c00005b2.ConsumableItemDesc != string.Empty) && (!(c00005b2.EquipmentModificationGuid != string.Empty) || !(c00005b2.EquipmentPrefabName != string.Empty));
						if (flag6)
						{
							flag2 = false;
							new Random().Next(1, 9999);
							c00005b = c00005b2;
						}
					}
				}
				goto IL_0145;
			}
		}
		flag2 = true;
		IL_0145:
		bool flag7 = flag2;
		if (flag7)
		{
			int num = new Random().Next(1, 9999);
			int num2 = 90000 + num;
			c00005b = new c000057.UserGift
			{
				Id = (long)num2,
				AvatarItemDesc = string.Empty,
				ConsumableItemDesc = string.Empty,
				EquipmentPrefabName = string.Empty,
				EquipmentModificationGuid = string.Empty,
				CurrencyType = (c00000b.enum016)2,
				Currency = c000057.m000016(),
				Xp = 0,
				Level = 0,
				GiftRarity = (c000057.GiftRarity)0,
				Context = @enum
			};
		}
		bool flag8 = p0.ContainsKey("Message");
		if (flag8)
		{
			c00005b.Message = p0["Message"] ?? string.Empty;
		}
		else
		{
			c00005b.Message = string.Format("Context = {0}", @enum);
		}
		c000057.m000035().Add(c00005b);
		return c00005b;
	}

	public static void m000039(Dictionary<string, string> p0)
	{
		for (int i = 0; i < c000057.m000035().Count<c000057.UserGift>(); i++)
		{
			if (c000057.m000035()[i].Id == (long)int.Parse(p0["Id"]))
			{
				if (c000057.m000035()[i].AvatarItemDesc != string.Empty)
				{
					c00008c.c00008e.m00004f(c000057.m000035()[i].AvatarItemDesc, c000057.m000035()[i].Level);
				}
				else if (c000057.m000035()[i].ConsumableItemDesc != string.Empty)
				{
					c00009e.m00004f(c000057.m000035()[i].ConsumableItemDesc, 1);
				}
				else if ((!(c000057.m000035()[i].EquipmentModificationGuid != string.Empty) || !(c000057.m000035()[i].EquipmentPrefabName != string.Empty)) && c000057.m000035()[i].CurrencyType > (c00000b.enum016)0)
				{
					c00000b.m000012(c000057.m000035()[i].CurrencyType, c000057.m000035()[i].Currency);
				}
				c000057.m000035().Remove(c000057.m000035()[i]);
				break;
			}
		}
		c000057.m000033();
	}

	public static int m000016()
	{
		int num = 100;
		int num2 = new Random().Next(1, 1000);
		if (num2 == 700)
		{
			num = 2000;
		}
		else if (num2 > 100 && num2 < 400)
		{
			num = 200;
		}
		else if (num2 > 450 && num2 < 550)
		{
			num = 500;
		}
		else if (num2 > 400 && num2 < 420)
		{
			num = 1000;
		}
		return num;
	}

	public static void m000024()
	{
		c000057.m000036(new List<c000057.UserGift>());
		if (Save_Data_System.check_if_slot_not_empty((Save_Data_System.slot)2))
		{
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(Save_Data_System.read_from_slot((Save_Data_System.slot)2)));
			try
			{
				c000057.f00000a = binaryReader.ReadString();
				while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
				{
					UserGift userGift = new UserGift();
					userGift.Id = binaryReader.ReadInt64();
					userGift.AvatarItemDesc = binaryReader.ReadString();
					userGift.ConsumableItemDesc = binaryReader.ReadString();
					userGift.EquipmentPrefabName = binaryReader.ReadString();
					userGift.EquipmentModificationGuid = binaryReader.ReadString();
					userGift.CurrencyType = (StoreFronts.Currency)binaryReader.ReadInt32();
					userGift.Currency = binaryReader.ReadInt32();
					userGift.Xp = binaryReader.ReadInt32();
					userGift.Level = binaryReader.ReadInt32();
					userGift.GiftRarity = (c000057.GiftRarity)binaryReader.ReadInt32();
					userGift.Message = binaryReader.ReadString();
					userGift.Context = (c000057.Context_type)binaryReader.ReadInt32();
					m000035().Add(userGift);
				}
			}
			finally
			{
				((IDisposable)binaryReader).Dispose();
			}
		}
	}

	public static void m000033()
	{
		MemoryStream memoryStream = new MemoryStream();
		byte[] array;
		try
		{
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			try
			{
				binaryWriter.Write(c000057.f00000a);
				foreach (c000057.UserGift c00005b in c000057.m000009())
				{
					binaryWriter.Write(c00005b.Id);
					binaryWriter.Write(c00005b.AvatarItemDesc);
					binaryWriter.Write(c00005b.ConsumableItemDesc);
					binaryWriter.Write(c00005b.EquipmentPrefabName);
					binaryWriter.Write(c00005b.EquipmentModificationGuid);
					binaryWriter.Write((int)c00005b.CurrencyType);
					binaryWriter.Write(c00005b.Currency);
					binaryWriter.Write(c00005b.Xp);
					binaryWriter.Write(c00005b.Level);
					binaryWriter.Write((int)c00005b.GiftRarity);
					binaryWriter.Write(c00005b.Message);
					binaryWriter.Write((int)c00005b.Context);
				}
			}
			finally
			{
				((IDisposable)binaryWriter).Dispose();
			}
			array = memoryStream.ToArray();
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
		Save_Data_System.write_to_slot((Save_Data_System.slot)2, array);
	}

	public static string f00000a;

	public static Dictionary<c000057.Context_type, List<c000057.UserGift>> f000050;

	private static List<c000057.UserGift> f000034;

	public enum Context_type
	{
		None = -1,
		Default,
		First_Activity,
		Game_Drop,
		All_Daily_Challenges_Complete,
		All_Weekly_Challenge_Complete,
		Daily_Challenge_Complete,
		Weekly_Challenge_Complete,
		Unassigned_Equipment = 10,
		Unassigned_Avatar,
		Unassigned_Consumable,
		Reacquisition = 20,
		Membership,
		NUX_TokensAndDressUp = 30,
		NUX_Experiment1,
		NUX_Experiment2,
		NUX_Experiment3,
		NUX_Experiment4,
		NUX_Experiment5,
		LevelUp = 100,
        LevelUp_2 = 102,
        LevelUp_3,
        LevelUp_4,
        LevelUp_5,
        LevelUp_6,
        LevelUp_7,
        LevelUp_8,
        LevelUp_9,
        LevelUp_10,
        LevelUp_11,
        LevelUp_12,
        LevelUp_13,
        LevelUp_14,
        LevelUp_15,
        LevelUp_16,
        LevelUp_17,
        LevelUp_18,
        LevelUp_19,
        LevelUp_20,
        LevelUp_21,
        LevelUp_22,
        LevelUp_23,
        LevelUp_24,
        LevelUp_25,
        LevelUp_26,
        LevelUp_27,
        LevelUp_28,
        LevelUp_29,
        LevelUp_30,
        Event_RawData = 1000,
        SFVRCC_Promo,
        HelixxVR_Promo,
		Paintball_ClearCut = 2000,
		Paintball_Homestead,
		Paintball_Quarry,
		Paintball_River,
		Paintball_Dam,
		Discgolf_Propulsion = 3000,
		Discgolf_Lake,
		Discgolf_Mode_CoopCatch = 3500,
		Quest_Goblin_A = 4000,
		Quest_Goblin_B,
		Quest_Goblin_C,
		Quest_Goblin_S,
		Quest_Goblin_Consumable,
		Quest_Cauldron_A = 4010,
		Quest_Cauldron_B,
		Quest_Cauldron_C,
		Quest_Cauldron_S,
		Quest_Cauldron_Consumable,
		Quest_Pirate1_A = 4100,
		Quest_Pirate1_B,
		Quest_Pirate1_C,
		Quest_Pirate1_S,
		Quest_Pirate1_X,
		Quest_Pirate1_Consumable,
		Quest_SciFi_A = 4500,
		Quest_SciFi_B,
		Quest_SciFi_C,
		Quest_SciFi_S,
		Quest_scifi_Consumable,
		Charades = 5000,
		Soccer = 6000,
		Paddleball = 7000,
		Dodgeball = 8000,
		Lasertag = 9000,
		Store_LaserTag = 100000,
		Store_RecCenter = 100010,
		Consumable = 110000,
		Token = 110100,
		Punchcard_Challenge_Complete = 110200,
		All_Punchcard_Challenges_Complete
	}

	public enum GiftRarity
	{
        None = -1,
        Common,
        Uncommon = 10,
        Rare = 20,
        Epic = 30,
        Legendary = 50
    }

	public enum enum05a
	{

	}

	public sealed class UserGift
	{
		public long Id { get; set; }

        public string AvatarItemDesc { get; set; }

        public string ConsumableItemDesc { get; set; }

        public string EquipmentPrefabName { get; set; }

        public string EquipmentModificationGuid { get; set; }

        public StoreFronts.Currency CurrencyType { get; set; }

        public int Currency { get; set; }

        public int Xp { get; set; }

        public int Level { get; set; }

        public c000057.GiftRarity GiftRarity { get; set; }

        public string Message { get; set; }

        public c000057.Context_type Context { get; set; }
    }

	public sealed class c00005c
	{
		public string LastUpdated { get; set; }

        public Dictionary<ulong, List<c000057.UserGift>> UserGifts { get; set; }
	}
}
