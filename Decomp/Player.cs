using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using Microsoft.Win32;
using Newtonsoft.Json;

public sealed class Player
{
    private static List<PlayerProfile> playerProfiles;

    public static List<string> RandomNames = new List<string> { "CrazyCow", "SmallFox", "BigDog" };

    public static List<PlayerProfile> GetProfiles()
    {
        return playerProfiles;
    }

    public static void SetProfiles(List<PlayerProfile> profiles)
    {
        playerProfiles = profiles;
    }

    public static void LoadProfile()
    {
        SetProfiles(new List<PlayerProfile>());

        var profile = new PlayerProfile();
        try
        {
            using (WebClient client = new WebClient())
            {
                profile.Id = GetMachineGuidAsUInt();
                string url = $"https://raw.githubusercontent.com/Dyno41/RecBox/main/Players/{profile.Id}.json";
                profile = JsonConvert.DeserializeObject<PlayerProfile>(client.DownloadString(url));
                GetProfiles().Add(profile);
            }
        }
        catch
        {
            profile.Id = GetMachineGuidAsUInt();
            profile.Username = profile.Id.ToString();
            profile.DisplayName = profile.Id.ToString();
            profile.Level = 1;
            profile.XP = 0;
            profile.Developer = false;
            profile.IsBooster = false;
            profile.BootMultiplier = 0;
            profile.IsSpecial = false;
            GetProfiles().Add(profile);
        }
    }

    public static void SendProfilePacket()
    {
        byte[] data;
        using (MemoryStream ms = new MemoryStream())
        {
            using (BinaryWriter writer = new BinaryWriter(ms))
            {
                var profile = GetProfiles()[0];
                writer.Write(profile.Id);
                writer.Write(profile.Username);
                writer.Write(profile.DisplayName);
                writer.Write(profile.Level);
                writer.Write(profile.XP);
                writer.Write(profile.Developer);
                writer.Write(profile.IsBooster);
                writer.Write(profile.BootMultiplier);
                writer.Write(profile.IsSpecial);
            }
            data = ms.ToArray();
        }

        PacketSender.Send(PacketType.ProfileData, data);
    }

    public static uint GetMachineGuidAsUInt()
    {
        const string registryKeyPath = @"SOFTWARE\Microsoft\Cryptography";
        const string valueName = "MachineGuid";

        using (var key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
        using (var subKey = key.OpenSubKey(registryKeyPath))
        {
            if (subKey == null)
                throw new KeyNotFoundException($"Key Not Found: {registryKeyPath}");

            object value = subKey.GetValue(valueName);
            if (value == null)
                throw new IndexOutOfRangeException($"Value Not Found: {valueName}");

            return uint.Parse(value.ToString().Split('-')[0], NumberStyles.HexNumber);
        }
    }

    public sealed class PlayerProfile
    {
        public ulong Id { get; set; }
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public int Level { get; set; }
        public int XP { get; set; }
        public bool Developer { get; set; }
        public bool IsBooster { get; set; }
        public int BootMultiplier { get; set; }
        public bool IsSpecial { get; set; }
    }
}
