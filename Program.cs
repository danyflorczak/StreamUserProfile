using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;
using System.Threading.Tasks;

namespace SteamAPI
{
    class SteamAPI
    {
        static async Task Main(string[] args)
        {
            string steamId = "76561198057073414";
            string apiKey = "10CE6174A0F180746BA156D8A9B84AF4";
            UserProfile profile = await CreateAndFillUserProfile(steamId, apiKey);

            // export UserProfile object to XML file
            XmlSerializer serializer = new XmlSerializer(typeof(UserProfile));
            using (FileStream stream = new FileStream("UserProfile.xml", FileMode.Create))
            {
                serializer.Serialize(stream, profile);
            }

            // saving to json file
            var tempjson = JsonConvert.SerializeObject(profile);
            File.WriteAllText("dane.json", tempjson);
        }

        private static async Task<UserProfile> CreateAndFillUserProfile(string steamId, string apiKey)
        {
            string url = $"http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={apiKey}&include_appinfo=true&steamid={steamId}&format=json";
            UserProfile profile = new UserProfile();
            profile.SteamId = steamId;
            profile.UserName = GetPersonalDetails();
            profile.CountryCode = GetCountryCode();
            profile.Games = new List<Game>();
            profile.GamesCount = 0;

            using (HttpClient client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                if (result == null || json == null)
                {
                    MessageBox.Show("Error getting data");
                    return profile;
                }
            dynamic result = JsonConvert.DeserializeObject(json) ?? throw new ArgumentException("Błąd");
            if (result?(json == null)
            {
            MessageBox.Show("Error getting data");
            return profile;
            }
            dynamic result = JsonConvert.DeserializeObject(json) ?? throw new ArgumentException("Błąd");
            if (result?.response?.games == null)
            {
                MessageBox.Show("Error getting games data");
                return profile;
            }

            profile.GamesCount = result.response.game_count;

            // adding games to the user's profile
            foreach (var game in result.response.games)
            {
                Game gameProfile = new Game();
                gameProfile.Name = game.name;
                gameProfile.Playtime = game.playtime_forever;
                gameProfile.Developer = GetGameDetails((string)game.appid);
                gameProfile.Genres = GetGameGenres((string)game.appid);
                gameProfile.isFree = GetGameIsFree((string)game.appid);
                profile.Games.Add(gameProfile);
            }

            return profile;
        }
    }

    private string GetGameDetails(string appID)
    {
        string gameDetailsUrl = $"http://store.steampowered.com/api/appdetails?appids={appID}";
            using (HttpClient client = new HttpClient())
            {
                var json = client.GetStringAsync(gameDetailsUrl).Result;
                if (json == null)
                {
                    return "Error GetGameDetails";
                }
                dynamic result = JsonConvert.DeserializeObject(json) ?? throw new ArgumentException("Błąd");
                if (result[$"{appID}"]["data"] == null)
                {
                    return "empty_field";
                }

                return result[$"{appID}"]["data"]["developers"][0];
            }
        }
    }

    private string GetGameGenres(string appID)
    {
         string gameDetailsUrl = $"http://store.steampowered.com/api/appdetails?appids={appID}";
            using (HttpClient client = new HttpClient())
            {
                var json = client.GetStringAsync(gameDetailsUrl).Result;
                if (json == null)
                {
                    return "Error GetGameGenres";
                }
                dynamic result = JsonConvert.DeserializeObject(json) ?? throw new ArgumentException("Błąd");
                if (result[$"{appID}"]["data"] == null)
                {
                    return "empty_field";
                }

                return result[$"{appID}"]["data"]["genres"][0]["description"];
            }
    }

    private string GetGameIsFree(string appID)
    {
        string gameDetailsUrl = $"http://store.steampowered.com/api/appdetails?appids={appID}";
            using (HttpClient client = new HttpClient())
            {
                var json = client.GetStringAsync(gameDetailsUrl).Result;
                if (json == null)
                {
                    return "Error GetGameIsFree";
                }
                dynamic result = JsonConvert.DeserializeObject(json) ?? throw new ArgumentException("Błąd");
                if (result[$"{appID}"]["data"] == null)
                {
                    return "empty_field";

                }

                if(result[$"{appID}"]["data"]["is_free"] == false)
                {
                    return "Paid";
                }
                else if(result[$"{appID}"]["data"]["is_free"] == true)
                {
                    return "Free";
                }
                else
                {
                    return "not_info";
                }
            }
    }

    private string GetPersonalDetails()
    {
        string steamId = "76561198057073414";
            string apiKey = "10CE6174A0F180746BA156D8A9B84AF4";
            string personalDetailsUrl = $"https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v2/?key={apiKey}&steamids={steamId}";
            
            using (HttpClient client = new HttpClient())
            {
                var json = client.GetStringAsync(personalDetailsUrl).Result;
                if (json == null)
                {
                    return "Error GetPersonalDetails";
                }
                dynamic result = JsonConvert.DeserializeObject(json) ?? throw new ArgumentException("Błąd");
                if (result.response.players[0].personaname == null)
                {
                    return "empty_field";
                }

                return result.response.players[0].personaname;
            }
    }

    private string GetCountryCode()
    {
        string steamId = "76561198057073414";
        string apiKey = "10CE6174A0F180746BA156D8A9B84AF4";
        string personalDetailsUrl = $"https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v2/?key={apiKey}&steamids={steamId}";
        
        using (HttpClient client = new HttpClient())
        {
            var json = client.GetStringAsync(personalDetailsUrl).Result;
            if (json == null)
            {
                return "Error GetCountryCode";
            }
            dynamic result = JsonConvert.DeserializeObject(json) ?? throw new ArgumentException("Błąd");
            if (result.response.players[0].loccountrycode == null)
            {
                return "empty_field";
            }

            return result.response.players[0].loccountrycode;
        }
    }

    private void exportXMLButton_Click(object sender, EventArgs e)
    {
        // export UserProfile object to XML file
        XmlSerializer serializer = new XmlSerializer(typeof(UserProfile));
        using (FileStream stream = new FileStream("UserProfile.xml", FileMode.Create))
        {
            serializer.Serialize(stream, _profile);
        }
        MessageBox.Show("XML file created!");
    }
}


