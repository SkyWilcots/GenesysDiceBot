using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenesysDiceBot.commands.SlashCommands
{
    public class RollSlashCommands : ApplicationCommandModule
    {
        [SlashCommand("roll", "Rolls a series of Genesys Dice and Icons")]
        public async Task RollSlashCommand(InteractionContext ctx)
        {

        }

    }
}
