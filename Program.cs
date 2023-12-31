﻿using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext.Exceptions;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;
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
        public static DiscordClient Client { get; private set; }
        
        //Makes a variable for the Commands that the Discord Bot will be used for.
        public static CommandsNextExtension Commands { get; private set; }


        static async Task Main(string[] args)
        {
            // Make an instance of the JSONReader and execute its method.
            var jsonReader = new JSONReader();
            await jsonReader.ReadJSON();

            // Setup our first configuration for Discord
            var discordConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.AllUnprivileged
            | DiscordIntents.GuildEmojis
            | DiscordIntents.MessageContents,
               
                // Puts in the token for use by the bot
                Token = jsonReader.token,

                // Categorize the token as a Bot token
                TokenType = TokenType.Bot,

                // On the occasion that the Bot crashes (as Bots can and tend to do), set the Bot so it can reconnect automatically.
                AutoReconnect = true
            };
            
            // Instantiate a new client with all the properties of the discordConfig object above.
            Client = new DiscordClient(discordConfig);

            // Set the default timeout for Commands that use interactivity
         /*   Client.UseInteractivity(new InteractivityConfiguration()
            {
                Timeout = TimeSpan.FromMinutes(2)
            });*/
            
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
            var slashCommandsConfig = Client.UseSlashCommands();


            // Registers the commands.
            Commands.RegisterCommands<TestCommands>();
            slashCommandsConfig.RegisterCommands<commands.SlashCommands.RollSlashCommands>();
            
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
