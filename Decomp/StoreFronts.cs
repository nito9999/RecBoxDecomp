using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

public sealed class StoreFronts
{
	public static long Get_Currency_Balance(Currency p0)
	{
		Dictionary<Currency, long> dictionary = new Dictionary<Currency, long>
		{
			{
                Currency.Invalid,
				0L
			},
			{
                Currency.LaserTagTickets,
				0L
			},
			{
                Currency.RecCenterTokens,
				0L
			},
			{
                Currency.LostSkullsGold,
				0L
			},
			{
                Currency.RecRoyale_Season1,
				0L
			}
		};
		if (Save_Data_System.check_if_slot_not_empty((Save_Data_System.slot)6))
		{
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(Save_Data_System.read_from_slot((Save_Data_System.slot)6)));
			try
			{
				while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
				{
					Currency @enum = (Currency)binaryReader.ReadInt32();
					long num = binaryReader.ReadInt64();
					dictionary[@enum] = num;
				}
			}
			finally
			{
				((IDisposable)binaryReader).Dispose();
			}
		}
		return dictionary[p0];
	}

	public static void Set_Currency_Balance(Currency currency_type, long p1)
	{
		Dictionary<Currency, long> dictionary = new Dictionary<Currency, long>();
		dictionary.Add(Currency.Invalid, Get_Currency_Balance(Currency.Invalid));
		dictionary.Add(Currency.LaserTagTickets, Get_Currency_Balance(Currency.LaserTagTickets));
		dictionary.Add(Currency.RecCenterTokens, Get_Currency_Balance(Currency.RecCenterTokens));
		dictionary.Add(Currency.LostSkullsGold, Get_Currency_Balance(Currency.LostSkullsGold));
		dictionary.Add(Currency.RecRoyale_Season1, Get_Currency_Balance(Currency.RecRoyale_Season1));
		dictionary[currency_type] = p1;
		MemoryStream memoryStream = new MemoryStream();
		byte[] array;
		try
		{
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			try
			{
				foreach (KeyValuePair<Currency, long> keyValuePair in dictionary)
				{
					binaryWriter.Write((int)keyValuePair.Key);
					binaryWriter.Write(keyValuePair.Value);
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
		Save_Data_System.write_to_slot((Save_Data_System.slot)6, array);
	}

	public static Storefront m00000e(Storefront_Type p0)
	{
		Storefront storefront = new Storefront
		{
			StorefrontType = p0,
			NextUpdate = Get_Next_Week_day(DateTime.Now, DayOfWeek.Wednesday),
			StoreItems = new List<StoreFronts.StoreItem>()
		};
		WebClient webClient = new WebClient();
		try
		{
			storefront = JsonConvert.DeserializeObject<StoreFronts.Storefront>(webClient.DownloadString(string.Format("https://raw.githubusercontent.com/nito9999/RecBox/main/StoreFront{0}.json", (int)p0)));
		}
		finally
		{
			((IDisposable)webClient).Dispose();
		}
		bool flag = StoreFronts_data.ContainsKey(p0);
		if (flag)
		{
			StoreFronts_data.Remove(p0);
		}
		StoreFronts_data.Add(p0, storefront);
		return storefront;
	}

	public static bool m00000f(string p0)
	{
		foreach (KeyValuePair<StoreFronts.Storefront_Type, StoreFronts.Storefront> keyValuePair in StoreFronts.StoreFronts_data)
		{
			using (List<StoreFronts.StoreItem>.Enumerator enumerator2 = keyValuePair.Value.StoreItems.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current.GiftDrops[0].AvatarItemDesc == p0)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public static c000075.GiftDrop Get_GiftDrop(string p0)
	{
		foreach (KeyValuePair<StoreFronts.Storefront_Type, StoreFronts.Storefront> keyValuePair in StoreFronts.StoreFronts_data)
		{
			foreach (StoreFronts.StoreItem c in keyValuePair.Value.StoreItems)
			{
				if (c.GiftDrops[0].FriendlyName == p0)
				{
					return c.GiftDrops[0];
				}
			}
		}
		return null;
	}

	public static c000075.GiftDrop Get_GiftDrop(long p0)
	{
		foreach (KeyValuePair<StoreFronts.Storefront_Type, StoreFronts.Storefront> keyValuePair in StoreFronts.StoreFronts_data)
		{
			foreach (StoreFronts.StoreItem c in keyValuePair.Value.StoreItems)
			{
				if (c.GiftDrops[0].GiftDropId == (int)p0)
				{
					return c.GiftDrops[0];
				}
			}
		}
		return null;
	}

	public static StoreFronts.BalanceUpdate_dto m000011(string p0)
	{
		Storefront_Purchasable_Item Purchasable_Item = JsonConvert.DeserializeObject<StoreFronts.Storefront_Purchasable_Item>(p0);
		c000075.GiftDrop GiftDrop = StoreFronts.StoreFronts_data[Purchasable_Item.StorefrontType].m000023((int)Purchasable_Item.PurchasableItemId);
		c000057.UserGift c00005b = c000057.m000037(GiftDrop);
		long num = StoreFronts.Get_Currency_Balance(Purchasable_Item.CurrencyType);
		long num2 = (long)StoreFronts.StoreFronts_data[Purchasable_Item.StorefrontType].m000022(GiftDrop.GiftDropId);
		if (c00005b.AvatarItemDesc != string.Empty)
		{
			if (c00008c.c00008e.m00000f(c00005b.AvatarItemDesc))
			{
				StoreFronts.BalanceUpdate_dto c00000e = new BalanceUpdate_dto(num, num, Purchasable_Item.CurrencyType);
				c00000e.BalanceUpdates[0].UpdateResponse = (StoreFronts.enum010)3;
				return c00000e;
			}
			if (!StoreFronts.m00000f(c00005b.AvatarItemDesc))
			{
				Environment.Exit(1);
			}
		}
		StoreFronts.BalanceUpdate_dto c00000e3;
		if (num >= num2)
		{
			num -= (long)StoreFronts.StoreFronts_data[Purchasable_Item.StorefrontType].m000022(GiftDrop.GiftDropId);
			if (num < 0L)
			{
				num = 0L;
			}
			BalanceUpdate_dto c00000e2 = new BalanceUpdate_dto(c00005b, num, Purchasable_Item.CurrencyType);
			Set_Currency_Balance(Purchasable_Item.CurrencyType, num);
			c00000e3 = c00000e2;
		}
		else
		{
			if (num < 0L)
			{
				num = 0L;
			}
			StoreFronts.BalanceUpdate_dto c00000e4 = new BalanceUpdate_dto(num, num, Purchasable_Item.CurrencyType);
			c00000e4.BalanceUpdates[0].UpdateResponse = enum010.NotEnoughCredit;
			c00000e3 = c00000e4;
		}
		return c00000e3;
	}

	public static void Add_Currency_Balance(Currency p0, int p1)
	{
		long num = StoreFronts.Get_Currency_Balance(p0);
		num += p1;
		StoreFronts.Set_Currency_Balance(p0, num);
	}

	public static DateTime Get_Next_Week_day(DateTime Date, DayOfWeek WeekDay)
	{
		int num = (WeekDay - Date.DayOfWeek + 7) % 7;
		return Date.AddDays((double)num);
	}

	public static Dictionary<StoreFronts.Storefront_Type, StoreFronts.Storefront> StoreFronts_data = new Dictionary<StoreFronts.Storefront_Type, StoreFronts.Storefront>();

	public enum enum0c
	{

	}

	public sealed class c00000d
	{
		public StoreFronts.enum0c m000014()
		{
			return this.f000025;
		}

		public void m000015(StoreFronts.enum0c p0)
		{
			this.f000025 = p0;
		}

		public int m000016()
		{
			return this.f00000b;
		}

		public void m000017(int p0)
		{
			this.f00000b = p0;
		}

		public int m000018()
		{
			return this.f000020;
		}

		public void m000019(int p0)
		{
			this.f000020 = p0;
		}

		public int m00001a()
		{
			return this.f000004;
		}

		public void m00001b(int p0)
		{
			this.f000004 = p0;
		}

		public int m00001c()
		{
			return this.f000005;
		}

		public void m00001d(int p0)
		{
			this.f000005 = p0;
		}

		public int m00001e()
		{
			return this.f000006;
		}

		public void m00001f(int p0)
		{
			this.f000006 = p0;
		}

		public bool m000002()
		{
			return this.f000016;
		}

		public void m000020(bool p0)
		{
			this.f000016 = p0;
		}

		public static StoreFronts.c00000d m000021(StoreFronts.enum0c p0, int p1)
		{
			StoreFronts.c00000d c00000d = new StoreFronts.c00000d();
			c00000d.m000015(p0);
			c00000d.m000017(p1);
			c00000d.m000019(0);
			c00000d.m00001b(0);
			c00000d.m00001d(0);
			c00000d.m00001f(p1);
			c00000d.m000020(true);
			return c00000d;
		}

		private StoreFronts.enum0c f000025;

		private int f00000b;

		private int f000020;

		private int f000004;

		private int f000005;

		private int f000006;

		private bool f000016;
	}

	public sealed class BalanceUpdate_dto
	{
		public BalanceUpdate_dto(object p0, long p1, Currency p2)
		{
			this.BalanceUpdates = new List<BalanceUpdate>
			{
				new BalanceUpdate
				{
					UpdateResponse = (enum010)0,
					Data = new List<object> { p0 }
				}
			};
			this.CurrencyType = p2;
			this.Balance = p1;
		}

		public List<BalanceUpdate> BalanceUpdates { get; set; }

		public Currency CurrencyType { get; set; }

        public long Balance { get; set; }
	}

	public enum Storefront_Type
	{
		None,
		LaserTag,
		RecCenter,
		Watch,
		Quest_LostSkulls = 100,
		RecRoyale = 200,
		Cafe = 300,
		Paintball = 400
	}

	public enum enum010
	{
        OK,
        TooManyRequests,
        NotEnoughCredit,
        AlreadyOwned,
        NoItemAvailable
    }

	public sealed class StoreItem
	{
		public int PurchasableItemId { get; set; }

        public c000057.enum05a Type { get; set; }

        public bool IsFeatured { get; set; }

        public List<StoreFront_price> Prices { get; set; }

        public List<c000075.GiftDrop> GiftDrops { get; set; }
	}

	public sealed class Storefront_Balance
	{
		public Storefront_Balance(Currency p0)
		{
			this.Balance = Get_Currency_Balance(p0);
			this.CurrencyType = p0;
		}

		public long Balance { get; set; }

        public Currency CurrencyType { get; set; }
    }

	public sealed class Storefront_Purchasable_Item
	{
		public Storefront_Type StorefrontType { get; set; }

        public long PurchasableItemId { get; set; }

        public Currency CurrencyType { get; set; }
	}

	public sealed class BalanceUpdate
	{
		public enum010 UpdateResponse { get; set; }

		public List<object> Data { get; set; }
	}

	public sealed class StoreFront_price
	{
		public StoreFront_price(Currency p0, long p1)
		{
			this.CurrencyType = p0;
			this.Price = p1;
		}

		public Currency CurrencyType { get; set; }

        public long Price { get; set; }
	}

	public enum Currency
	{
        Invalid,
        LaserTagTickets,
        RecCenterTokens,
        LostSkullsGold = 100,
        DraculaSilver,
        RecRoyale_Season1 = 200
    }

	public sealed class Storefront
	{
		public Storefront_Type StorefrontType { get; set; }

        public DateTime NextUpdate { get; set; }

        public List<StoreItem> StoreItems { get; set; }

		public int Get_PurchasableItem_Price(int p0)
		{
			int num = 10;
			foreach (StoreFronts.StoreItem c in this.StoreItems)
			{
				if (c.PurchasableItemId == p0)
				{
					num = (int)c.Prices[0].Price;
				}
			}
			return num;
		}

		public c000075.GiftDrop m000023(int p0)
		{
			c000075.GiftDrop c = new c000075.GiftDrop();
			foreach (StoreFronts.StoreItem c2 in this.StoreItems)
			{
				if (c2.PurchasableItemId == p0)
				{
					c = c2.GiftDrops[0];
				}
			}
			return c;
		}
	}
}
