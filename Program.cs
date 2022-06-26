using Discord;
using Discord.WebSocket;

using LegendarBot.Stuff;

using Newtonsoft.Json;

namespace LegendarBot {
  public class Program {

    public static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

    public static DiscordSocketClient _client;

    private Task Log(LogMessage msg) {
      Console.WriteLine(msg.ToString());
      return Task.CompletedTask;
    }

    public async Task MainAsync() {
      var discordConfig = new DiscordSocketConfig { MessageCacheSize = 100 };
      var config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("Stuff/config.json"));

      var token = config.Token;
      var prefix = config.Prefix;
      var lang = config.Language;

      _client = new DiscordSocketClient(discordConfig);
      _client.Log += Log;

      _client.Ready += () => {
        Console.WriteLine("бот заебца");
        return Task.CompletedTask;
      };

      await _client.LoginAsync(TokenType.Bot, token);
      await _client.StartAsync();

      await Task.Delay(-1);
    }
  }
}
