using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

internal sealed class BannedPlayerCheck
{
    public static List<ulong> BannedPlayerIds = new List<ulong>();

    public static void LoadBannedPlayers()
    {
        WebClient webClient = new WebClient();
        try
        {
            string json = webClient.DownloadString("https://raw.githubusercontent.com/Dyno41/RecBox/main/Players.json");
            BannedPlayerIds = JsonConvert.DeserializeObject<List<ulong>>(json);
        }
        finally
        {
            ((IDisposable)webClient).Dispose();
        }
    }

    public static bool IsPlayerBanned(ulong playerId)
    {
        LoadBannedPlayers();
        return BannedPlayerIds.Contains(playerId);
    }
}
