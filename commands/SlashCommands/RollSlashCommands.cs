using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenesysDiceBot.RollMachine;
using GenesysDiceBot.Dice;
using DSharpPlus.Entities;
using System.IO;
using DSharpPlus;
using DSharpPlus.Interactivity.Extensions;

namespace GenesysDiceBot.commands.SlashCommands
{
    public class RollSlashCommands : ApplicationCommandModule
    {

        [SlashCommand("roll", "Rolls a series of Genesys Dice and Icons")]
        public async Task RollSlashCommand(InteractionContext ctx, [Option("Ability", "Number of Ability Dice to roll")] long? abilityNum = 0,
                                                                    [Option("Proficiency", "Number of Proficiency Dice to roll")] long? proficiencyNum = 0,
                                                                    [Option("Boost", "Number of Boost Dice to roll")] long? boostNum = 0,
                                                                    [Option("Difficulty", "Number of Difficulty Dice to roll")] long? difficultyNum = 0,
                                                                    [Option("Challenge", "Number of Challenge Dice to roll")] long? challengeNum = 0,
                                                                    [Option("Setback", "Number of Setback Dice to roll")] long? setbackNum = 0,

                                                                    [Option("Successes", "Adds a number of Success icons to the final total")] long? succNum = 0,
                                                                    [Option("Failures", "Adds a number of Failure icons to the final total")] long? failNum = 0,
                                                                    [Option("Advantages", "Adds a number of Advantage icons to the final total")] long? advNum = 0,
                                                                    [Option("Threats", "Adds a number of Threat icons to the final total")] long? threatNum = 0,
                                                                    [Option("Triumphs", "Adds a number of Threat icons to the final total")] long? triNum = 0,
                                                                    [Option("Despairs", "Adds a number of Despair icons to the final total")] long? desNum = 0,

                                                                    [Option("Comment", "An optional comment to go with your roll")] string comment = ""
            )


        {
            await ctx.CreateResponseAsync(DSharpPlus.InteractionResponseType.ChannelMessageWithSource, new DSharpPlus.Entities.DiscordInteractionResponseBuilder().WithContent("Rolling..."));
            Roller r = new Roller();
            List<DiscordEmoji> discordEmojis = new List<DiscordEmoji>();
            r.AddToContainer(typeof(AbilityDie), abilityNum);
            r.AddToContainer(typeof(ProficiencyDie), proficiencyNum);
            r.AddToContainer(typeof(BoostDie), boostNum);
            r.AddToContainer(typeof(DifficultyDie), difficultyNum);
            r.AddToContainer(typeof(ChallengeDie), challengeNum);
            r.AddToContainer(typeof(SetbackDie), setbackNum);



            Dictionary<char, long?> iconDictionary = r.TallyIconTotal(r.RollDice(r.GetDiceContainer()));
            if (comment != "") { comment = $" **\"{comment}\"**"; }
            var emojiLineup = "";
            string addendum = "";
            long? addendumCounter = 0;
            if (succNum > 0) { iconDictionary['s'] += succNum; addendumCounter += succNum; addendum += $"{succNum} Successes were added to the roll.\n";
                for (int i = 0; i < succNum; i++) { r.imageFileQueue.Add("success"); }
            }
            if (failNum > 0) { iconDictionary['f'] += failNum; addendumCounter += failNum; addendum += $"{failNum} Failures were added to the roll.\n";
                for (int i = 0; i < failNum; i++) { r.imageFileQueue.Add("failure"); }
            }
            if (advNum > 0) { iconDictionary['a'] += advNum; addendumCounter += advNum; addendum += $"{advNum} Advantages were added to the roll.\n";
                for (int i = 0; i < advNum; i++) { r.imageFileQueue.Add("advantage"); }
            }
            if (threatNum > 0) { iconDictionary['h'] += threatNum; addendumCounter += threatNum; addendum += $"{threatNum} Threats were added to the roll.\n";
                for (int i = 0; i < threatNum; i++) { r.imageFileQueue.Add("threat"); }
            }
            if (triNum > 0) { iconDictionary['t'] += triNum; addendumCounter += triNum; addendum += $"{triNum} Threats were added to the roll.\n";
                for (int i = 0; i < triNum; i++) { r.imageFileQueue.Add("triumph"); }
            }
            if (triNum > 0) { iconDictionary['d'] += desNum; addendumCounter += desNum; addendum += $"{desNum} Despairs were added to the roll.\n";
                for (int i = 0; i < desNum; i++) { r.imageFileQueue.Add("despair"); }
            }

            foreach(string s in r.imageFileQueue)
            {
                emojiLineup += $"{r.emojis[s]}";
            }

            string finePrint = "";
            if (addendumCounter > 0) { finePrint += "\n\n*\n"; }
            await ctx.DeleteResponseAsync();
            await ctx.Channel.SendMessageAsync($"{ctx.User.Mention} \n" +
                $"You rolled:{comment}\n{emojiLineup}");
            await ctx.Channel.SendMessageAsync(r.ResultsWriteUp(r.NetIconTotal(iconDictionary)) + finePrint + addendum);

        } 
    }
}
