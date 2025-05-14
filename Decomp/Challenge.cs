using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public sealed class Challenge
{
	public sealed class c000024
	{
	}

	public sealed class ChallengeData
	{
		public int ChallengeId { get; set; }

		public string Name { get; set; }

        public string Config { get; set; }

        public string Description { get; set; }

        public string Tooltip { get; set; }

        public bool Complete { get; set; }
	}

	public enum enum026
	{

	}

	public sealed class WeeklyData
	{
		public WeeklyData()
		{
			this.ChallengeMapId = 3;
			this.CompleteAll = true;
			this.StartAt = DateTime.Now;
			this.EndAt = StoreFronts.Get_Next_Week_day(DateTime.Now, DayOfWeek.Wednesday);
			this.ServerTime = DateTime.Now;
			this.Challenges = new List<ChallengeData>
			{
				new ChallengeData
				{
					ChallengeId = 142,
					Name = "CompleteCCC",
					Config = "{\"ct\":0,\"ipc\":false,\"wc\":[{\"ct\":6,\"vs\":[2]},{\"ct\":9,\"vs\":[true],\"v\":\"won\"},{\"ct\":7,\"vs\":[{\"l\":\"949fa41f-4347-45c0-b7ac-489129174045\"}]}]}",
					Description = "Complete the ^CrimsonCauldron quest",
					Tooltip = "Vanquish the Witch in ^CrimsonCauldron!",
					Complete = false
				},
				new ChallengeData
				{
					ChallengeId = 142,
					Name = "CompleteCCC",
					Config = "{\"ct\":0,\"ipc\":false,\"wc\":[{\"ct\":6,\"vs\":[2]},{\"ct\":9,\"vs\":[true],\"v\":\"won\"},{\"ct\":7,\"vs\":[{\"l\":\"949fa41f-4347-45c0-b7ac-489129174045\"}]}]}",
					Description = "Complete the ^CrimsonCauldron quest",
					Tooltip = "Vanquish the Witch in ^CrimsonCauldron!",
					Complete = true
				},
				new ChallengeData
				{
					ChallengeId = 142,
					Name = "CompleteCCC",
					Config = "{\"ct\":0,\"ipc\":false,\"wc\":[{\"ct\":6,\"vs\":[2]},{\"ct\":9,\"vs\":[true],\"v\":\"won\"},{\"ct\":7,\"vs\":[{\"l\":\"949fa41f-4347-45c0-b7ac-489129174045\"}]}]}",
					Description = "Complete the ^CrimsonCauldron quest",
					Tooltip = "Vanquish the Witch in ^CrimsonCauldron!",
					Complete = false
				}
			};
			this.Gifts = new List<c000075.GiftDrop>
			{
				new c000075.GiftDrop
				{
					GiftDropId = 35465,
					FriendlyName = string.Empty,
					Tooltip = string.Empty,
					AvatarItemDesc = string.Empty,
					ConsumableItemDesc = string.Empty,
					EquipmentPrefabName = "[MakerPen]",
					EquipmentModificationGuid = "79090a4b-e191-4788-9210-88a7bdf6d828",
					Rarity = (c000057.GiftRarity)50,
					IsQuery = false,
					Unique = false,
					Level = 1,
					Context = c000057.Context_type.All_Weekly_Challenge_Complete
				}
			};
			this.ChallengeThemeString = "Maker Pen";
			this.ChallengeThemeId = new int?(3);
		}

		public int ChallengeMapId { get; set; }

        public bool CompleteAll { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime EndAt { get; set; }

        public DateTime ServerTime { get; set; }

        public List<ChallengeData> Challenges { get; set; }

		public List<c000075.GiftDrop> Gifts { get; set; }

        public string ChallengeThemeString { get; set; }

        public int? ChallengeThemeId { get; set; }
	}

	public enum enum028
	{

	}
}
