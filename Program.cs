using System;
using System.Net.Http;
using Newtonsoft.Json;

class SteamAPI {
    static void Main(string[] args) {
        string steamId = "76561198209273776";
        string apiKey = "EF5C8E2B08A10F7FF30BFBC4A595C2BB";
        string url = $"http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={apiKey}&include_appinfo=true&steamid={steamId}&format=json";

        using (HttpClient client = new HttpClient()) {
            var json = client.GetStringAsync(url).Result;
            if (json == null) {
                Console.WriteLine("Error getting data");
                return;
            }
            dynamic result = JsonConvert.DeserializeObject(json) ?? throw new ArgumentException("dupa");
            if (result?.response?.games == null)
            {
                Console.WriteLine("Error getting games data");
                return;
            }
            // Print the names of the player's games
            foreach (var game in result.response.games) {
                Console.WriteLine((string)Convert.ToString(game.name));
            }
        }
    }
}