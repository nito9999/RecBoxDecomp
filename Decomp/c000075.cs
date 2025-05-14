using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class c000075
{
	// Note: this type is marked as 'beforefieldinit'.
	static c000075()
	{
		Dictionary<string, Consumable> dictionary = new Dictionary<string, Consumable>();
		string text = "Glazed Donuts";
		Consumable consumable = new Consumable();
		consumable.Set_id(9001L);
		consumable.Set_guid("7OZ5AE3uuUyqa0P-2W1ptg");
		dictionary.Add(text, consumable);

		string text2 = "Hawaiian Pizza";
		Consumable consumable2 = new Consumable();
		consumable2.Set_id(9002L);
		consumable2.Set_guid("_jnjYGBcyEWY5Ub4OezXcA");
		dictionary.Add(text2, consumable2);

		string text3 = "Cheese Pizza";
		Consumable consumable3 = new Consumable();
		consumable3.Set_id(9003L);
		consumable3.Set_guid("5hIAZ9wg5EyG1cILf4FS2A");
		dictionary.Add(text3, consumable3);

		string text4 = "Supreme Pizza";
		Consumable consumable4 = new Consumable();
		consumable4.Set_id(9004L);
		consumable4.Set_guid("wUCIKdJSvEmiQHYMyx4X4w");
		dictionary.Add(text4, consumable4);

		string text5 = "Pepperoni Pizza";
		Consumable consumable5 = new Consumable();
		consumable5.Set_id(9005L);
		consumable5.Set_guid("mq23W-RSP0G8iGNLdrcpUw");
		dictionary.Add(text5, consumable5);

		string text6 = "Assorted Donuts";
		Consumable consumable6 = new Consumable();
		consumable6.Set_id(9006L);
		consumable6.Set_guid("ZuvkidodzkuOfGLDnTOFyg");
		dictionary.Add(text6, consumable6);

		string text7 = "Chocolate Frosted Donuts";
		Consumable consumable7 = new Consumable();
		consumable7.Set_id(9007L);
		consumable7.Set_guid("mMCGPgK3tki5S_15q2Z81A");
		dictionary.Add(text7, consumable7);

		string text8 = "Salted Pretzels";
		Consumable consumable8 = new Consumable();
		consumable8.Set_id(9008L);
		consumable8.Set_guid("InQ25wQMGkG_bvuD5rf2Ag");
		dictionary.Add(text8, consumable8);

		string text9 = "Root Beer";
		Consumable consumable9 = new Consumable();
		consumable9.Set_id(9009L);
		consumable9.Set_guid("JfnVXFmilU6ysv-VbTAe3A");
		dictionary.Add(text9, consumable9);

		c000075.Consumables = dictionary;
	}

	public static GiftDrop m000041(string p0, enum078 p1)
	{
		GiftDrop GiftDrop = new GiftDrop();
		GiftDrop.GiftDropId = 0;
		GiftDrop.FriendlyName = p0;
		GiftDrop.Tooltip = string.Empty;
		GiftDrop.AvatarItemDesc = string.Empty;
		GiftDrop.ConsumableItemDesc = string.Empty;
		GiftDrop.EquipmentPrefabName = string.Empty;
		GiftDrop.EquipmentModificationGuid = string.Empty;
		GiftDrop.Rarity = (c000057.GiftRarity)50;
		GiftDrop.IsQuery = false;
		GiftDrop.Unique = false;
		GiftDrop.Level = 1;
		GiftDrop.Context = c000057.Context_type.Store_RecCenter;
		GiftDrop GiftDrop2;
		if (p1 == (enum078)0)
		{
			GiftDrop2 = StoreFronts.Get_GiftDrop(p0);
		}
		else
		{
			GiftDrop2 = StoreFronts.Get_GiftDrop(p0);
		}
		return GiftDrop2;
	}

	public static GiftDrop m000042(long p0, enum078 p1)
	{
		GiftDrop GiftDrop = new GiftDrop
		{
			GiftDropId = 0,
			FriendlyName = string.Empty,
			Tooltip = string.Empty,
			AvatarItemDesc = string.Empty,
			ConsumableItemDesc = string.Empty,
			EquipmentPrefabName = string.Empty,
			EquipmentModificationGuid = string.Empty,
			Rarity = (c000057.GiftRarity)50,
			IsQuery = false,
			Unique = false,
			Level = 1,
			Context = c000057.Context_type.Store_RecCenter
		};
		GiftDrop = StoreFronts.Get_GiftDrop(p0);
		bool flag = GiftDrop == null;
		if (flag)
		{
			GiftDrop = new GiftDrop
			{
				GiftDropId = 0,
				FriendlyName = string.Empty,
				Tooltip = string.Empty,
				AvatarItemDesc = string.Empty,
				ConsumableItemDesc = string.Empty,
				EquipmentPrefabName = string.Empty,
				EquipmentModificationGuid = string.Empty,
				Rarity = (c000057.GiftRarity)50,
				IsQuery = false,
				Unique = false,
				Level = 1,
				Context = c000057.Context_type.Store_RecCenter
			};
			foreach (KeyValuePair<string, c000075.Consumable> keyValuePair in c000075.Consumables)
			{
				bool flag2 = keyValuePair.Value.Get_id() == p0;
				if (flag2)
				{
					GiftDrop.FriendlyName = keyValuePair.Key;
					GiftDrop.ConsumableItemDesc = keyValuePair.Value.Get_guid() ?? string.Empty;
					GiftDrop.GiftDropId = (int)keyValuePair.Value.Get_id();
				}
			}
		}
		return GiftDrop;
	}

	public static Dictionary<string, c000075.Consumable> Consumables;

	public sealed class Consumable
	{
		public long Get_id()
		{
			return this.id;
		}

		public void Set_id(long p0)
		{
			this.id = p0;
		}

		public string Get_guid()
		{
			return this.guid;
		}

		public void Set_guid(string p0)
		{
			this.guid = p0;
		}

		private long id;

		private string guid;
	}

	public sealed class GiftDrop
	{
		public int GiftDropId { get; set; }

		public string FriendlyName { get; set; }

        public string Tooltip { get; set; }

        public string AvatarItemDesc { get; set; }

        public string ConsumableItemDesc { get; set; }

        public string EquipmentPrefabName { get; set; }

        public string EquipmentModificationGuid { get; set; }

        public c000057.GiftRarity Rarity { get; set; }

        public bool IsQuery { get; set; }

        public bool Unique { get; set; }

        public int Level { get; set; }

        public c000057.Context_type Context { get; set; }
	}

	public enum enum078
	{

	}
}
