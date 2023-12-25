using DSharpPlus;
using DSharpPlus.CommandsNext;
using GenesysDiceBot.commands;
using GenesysDiceBot.config;
using GenesysDiceBot.Dice;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace GenesysDiceBot
{
    internal class Program
    {
        //Initializes an instance of a Discord Client, to use it to connect to Discord and get the Bot online.
        private static DiscordClient Client { get; set; }
        
        //Makes a variable for the Commands that the Discord Bot will be used for.
        private static CommandsNextExtension Commands { get; set; }


        static async Task Main(string[] args)
        {
            // Make an instance of the JSONReader and execute its method.
            var jsonReader = new JSONReader();
            await jsonReader.ReadJSON();

            // Setup our first configuration for Discord
            var discordConfig = new DiscordConfiguration()
            {   
                Intents = DiscordIntents.All,
               
                // Puts in the token for use by the bot
                Token = jsonReader.token,

                // Categorize the token as a Bot token
                TokenType = TokenType.Bot,

                // On the occasion that the Bot crashes (as Bots can and tend to do), set the Bot so it can reconnect automatically.
                AutoReconnect = true
            };
            
            // Instantiate a new client with all the properties of the discordConfig object above.
            Client = new DiscordClient(discordConfig);
            
            // Task Handler Ready event turns on the Client 
            Client.Ready += Client_Ready;

            // Sets up the Commands Configuration
            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { jsonReader.prefix },
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = false,
            };
            
            Commands = Client.UseCommandsNext(commandsConfig);

            // Registers the commands.
            Commands.RegisterCommands<TestCommands>();
            
            // Connects to get the bot online and ensure it stays online indefinitely.
            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private static Task Client_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }

       
    }
}
