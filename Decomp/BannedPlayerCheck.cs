using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

internal sealed class BannedPlayerCheck
{
    public static void LoadBannedPlayers()
    {
        WebClient webClient = new WebClient();
        try
        {
            BannedPlayerIds = JsonConvert.DeserializeObject<List<ulong>>(webClient.DownloadString("https://raw.githubusercontent.com/nito9999/RecBox/main/Players.json"));
        }
        finally
        {
            ((IDisposable)webClient).Dispose();
        }
    }

    public static bool IsPlayerBanned(ulong playerId) // some code use this to check banned
    {
        LoadBannedPlayers();
        return BannedPlayerIds.Contains(playerId);
    }
    public static List<ulong> BannedPlayerIds = new List<ulong>();

}
