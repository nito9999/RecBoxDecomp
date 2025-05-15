using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

public class Equipment
{
	public static string getUnlocked()
	{
		Equipment.localEquipment = JsonConvert.DeserializeObject<List<Equipment>>(new WebClient().DownloadString("https://raw.githubusercontent.com/nito9999/RecBox/main/Equipment.json"));
		return JsonConvert.SerializeObject(Equipment.localEquipment);
	}

	public string PrefabName { get; set; }

	public string ModificationGuid { get; set; }

	public int UnlockedLevel { get; set; }

	public bool Favorited { get; set; }

	public static List<Equipment> localEquipment;
}
