using System;
using System.Net;
using Newtonsoft.Json;

class SteamAPI {
    static void Main(string[] args) {
        string steamId = "YOUR_STEAM_ID";
        string apiKey = "YOUR_API_KEY";
        string url = $"http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={apiKey}&steamid={steamId}&format=json";

        using (WebClient client = new WebClient()) {
            string json = client.DownloadString(url);
            dynamic result = JsonConvert.DeserializeObject(json);

            // Print the names of the player's games
            foreach (var game in result.response.games) {
                Console.WriteLine(game.name);
            }
        }
    }
}
