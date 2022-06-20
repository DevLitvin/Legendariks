using Discord;
using Discord.WebSocket;

using Legendar_Bot.Stuff;

using Newtonsoft.Json;

using System;
using System.IO;
using System.Threading.Tasks;

namespace LegendarBot { // тест коммент
  public class Bot {

    public static Task Main(string[] args) => new Bot().MainAsync(); // типо вот запускается в асинхроном режиме

    private DiscordSocketClient _client;

    private Task Log(LogMessage msg) { // логи
      Console.WriteLine(msg.ToString());
      return Task.CompletedTask;
    }

    public async Task MainAsync() { // подключается к сети в Discord
      _client = new DiscordSocketClient();
      _client.Log += Log;
      var config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("Stuff/config.json"));
      var token = config.Token;
      var prefix = config.Prefix;
      var lang = config.Language;

      await _client.LoginAsync(TokenType.Bot, token);
      await _client.StartAsync();

      await Task.Delay(-1);
    }
  }
}
