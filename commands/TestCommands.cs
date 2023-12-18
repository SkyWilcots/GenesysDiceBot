using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Threading.Tasks;

namespace GenesysDiceBot.commands
{
    public class TestCommands : BaseCommandModule
    {
        //Declare Command in Square Brackets
        [Command("helloworld")]
        //Next, write the method. Method must be public and ASync
        public async Task FirstCommand(CommandContext ctx)
        {
            // This command sends a message to the channel where the command was triggered, and responds with "Hello" directly to the user who triggered it.
            await ctx.Channel.SendMessageAsync($"Hello, {ctx.Message.Author.Mention}!");
        }

        [Command("testroll")]
        public async Task TestRoll(CommandContext ctx)
        {
            // Pings the user with a random number between 1 and 10 
            Random rnd = new Random();
            int result = rnd.Next(10) + 1;
            await ctx.Channel.SendMessageAsync($"{ctx.Message.Author.Mention} \n `` {result} ``");
        }
    }
}
