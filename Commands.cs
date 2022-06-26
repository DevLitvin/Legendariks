using System.Reflection;

using Discord.Commands;
using Discord.WebSocket;

namespace LegendarBot {
    public class CommandHandler {
        private readonly DiscordSocketClient _client = Program._client;
        private readonly CommandService _commands; 

        public CommandHandler(DiscordSocketClient client, CommandService commands) {
            _commands = commands;
            _client = client;      
        }

        public async Task InstallCommandsAsync() {
            // _client.MessageReceived += HandleCommandAsync; // todo
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), null);

        }
    }
}


// https://discordnet.dev/guides/text_commands/intro.html