using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace GenesysDiceBot.commands
{
    public class TestCommands : BaseCommandModule
    {
        //Declare Command in Square Brackets
        [Command("HelloWorld")]
        //Next, write the method. Method must be public and ASync
        public async Task FirstCommand(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Hello!")
        }
    }
}
