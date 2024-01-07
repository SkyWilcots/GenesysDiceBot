using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenesysDiceBot.Dice;

namespace GenesysDiceBot.RollMachine
{
    public class Roller
    {
        public List<Die> diceContainer { get; set; }
        public List<Type> listOfDieTypes { get; }
        public AbilityDie abilityDie { get; }
        public ProficiencyDie proficiencyDie { get; }
        public BoostDie boostDie { get; }
        public DifficultyDie difficultyDie { get; }
        public ChallengeDie challengeDie { get; }
        public SetbackDie setbackDie { get; }

        public List<String> imageFileQueue { get; set; }
        private string emojiFolderPath { get; }

        // Get all .png files in the Emoji folder
        private string[] imageFiles { get; }
        public Dictionary<string, string> emojis { get; private set; }

        public Roller()
        {
            diceContainer = new List<Die>();
            listOfDieTypes = new List<Type>
            {
                typeof(Die),
                typeof(AbilityDie),
                typeof(ProficiencyDie),
                typeof(BoostDie),
                typeof(DifficultyDie),
                typeof(ChallengeDie),
                typeof(SetbackDie)
            };

            abilityDie = new AbilityDie();
            proficiencyDie = new ProficiencyDie();
            boostDie = new BoostDie();
            difficultyDie = new DifficultyDie();
            challengeDie = new ChallengeDie();
            setbackDie = new SetbackDie();
            this.emojiFolderPath = "Dice/Emoji";
            this.imageFiles = Directory.GetFiles(emojiFolderPath, "*.png");
            imageFileQueue = new List<String>();
            
            emojis = new Dictionary<string, string>()
            {
                {"AbilityDie", "<:AbilityDie:1193596931679735932>"},
                {"AbilityDies", "<:AbilityDies:1193596936238923797>"},
                {"AbilityDiess","<:AbilityDiess:1193596940953337977>"},
                {"AbilityDiesa", "<:AbilityDiesa:1193596939434991697>"},
                {"AbilityDieaa", "<:AbilityDieaa:1193596935278432376>"},
                {"AbilityDiea", "<:AbilityDiea:1193596933948854404>"},
                
                {"BoostDie", "<:BoostDie:1193597030761762826>"},
                {"BoostDies", "<:BoostDies:1193597035169980456>"},
                {"BoostDiesa", "<:BoostDiesa:1193597037640437870>"},
                {"BoostDieaa", "<:BoostDieaa:1193597033857159168>"},
                {"BoostDiea", "<:BoostDiea:1193597032972173384>"},

                {"ProficiencyDie", "<:ProficiencyDie:1193597453363073126>"},
                {"ProficiencyDies", "<:ProficiencyDies:1193597460287856670>"},
                {"ProficiencyDiess", "<:ProficiencyDiess:1193597463446179960>"},
                {"ProficiencyDiesa", "<:ProficiencyDiesa:1193597461932036187>"},
                {"ProficiencyDieaa", "<:ProficiencyDieaa:1193597458014543892>"},
                {"ProficiencyDiea", "<:ProficiencyDiea:1193597456202612837>"},
                {"ProficiencyDiet", "<:ProficiencyDiet:1193597465643974826>"},

                {"DifficultyDie", "<:DifficultyDie:1193671629977440266>"},
                {"DifficultyDief", "<:DifficultyDief:1193597354566221956>"},
                {"DifficultyDieff", "<:DifficultyDieff:1193597355740643469>"},
                {"DifficultyDiefh", "<:DifficultyDiefh:1193597357707755520>"},
                {"DifficultyDiehh", "<:DifficultyDiehh:1193597360702500884>"},
                {"DifficultyDieh", "<:DifficultyDieh:1193597358890557490>"},

                {"ChallengeDie", "<:ChallengeDie:1193597153281593444>"},
                {"ChallengeDief", "<:ChallengeDief:1193597156163080214>"},
                {"ChallengeDieff", "<:ChallengeDieff:1193597158285389834>"},
                {"ChallengeDiefh", "<:ChallengeDiefh:1193597160357372035>"},
                {"ChallengeDiehh", "<:ChallengeDiehh:1193597162727145644>"},
                {"ChallengeDieh", "<:ChallengeDieh:1193597161523388426>"},
                {"ChallengeDied", "<:ChallengeDied:1193597154414047352>"},

                {"SetbackDie", "<:SetbackDie:1193597617221931140>"},
                {"SetbackDief", "<:SetbackDief:1193597619189055720>"},
                {"SetbackDieh", "<:SetbackDieh:1193597620409618612>"},

                {"success", "<:successicon:1193597622250913812>"},
                {"failure", "<:failureicon:1193597616274030612>"}, 
                {"advantage", "<:advantageicon:1193597606585180272>"},
                {"threat", "<:threaticon:1193597625249841233>"},
                {"triumph", "<:triumphicon:1193597628106154076>"},
                {"despair", "<:despairicon:1193597614583717940>"}
            };

        }

        public void ClearImageQueue()
        {
            this.imageFileQueue.Clear();
        }
        public List<Type> GetTypes()
        {
            return listOfDieTypes;
        }
        public void AddToContainer(Type diceType, int diceToAdd)
        {
            if(diceToAdd < 0) diceToAdd = 0;
            if (diceToAdd == 0) return;
            else
            {
                for (int i = 0; i < diceToAdd; i++)
                {
                    Die d = (Die)Activator.CreateInstance(diceType);
                    d.Initialize();
                    this.diceContainer.Add(d);
                }
            }
        }

        public void AddToContainer(Type diceType, long? diceToAdd)
        {
            if (diceToAdd < 0) diceToAdd = 0;
            if (diceToAdd == 0) return;
            else
            {
                for (int i = 0; i < diceToAdd; i++)
                {
                    Die d = (Die)Activator.CreateInstance(diceType);
                    d.Initialize();
                    this.diceContainer.Add(d);

                }
            }
        }



        public List<Die> GetDiceContainer()
        {
           return this.diceContainer;
        }

        public void ClearContainer()
        {
            this.diceContainer?.Clear();
        }
        public void GetImagePath(string[] imageFiles, Die d, string rollResult)
        {
            string dieTypeName = d.GetType().Name;

            // Construct the expected file name based on the type of die and the roll result
            string expectedFileName = $"{dieTypeName}{rollResult}.png";

            // Search for the file in the available image files
            string imagePath = this.imageFiles.FirstOrDefault(file => file.Equals(expectedFileName, StringComparison.OrdinalIgnoreCase));

            // If not found, use a default image
            if (string.IsNullOrEmpty(imagePath))
            {
                imagePath = "DiceImages/default.png";
            }

            this.imageFileQueue.Add(imagePath);
        }
            public string RollDice(List<Die> diceContainer)
        {
            this.imageFileQueue.Clear();

            string dieTypeName = "";
            string expectedFileName = "";
            string totalString = "";
            string rolledDiceString = "";

            foreach (Die d in diceContainer)
            {
               rolledDiceString = "";
               rolledDiceString = d.Roll();
               dieTypeName = d.GetType().Name;
               expectedFileName = $"{dieTypeName}{rolledDiceString}";
               this.imageFileQueue.Add($"{expectedFileName}");
               totalString += rolledDiceString;
               
            }
            return totalString;
        }

        public Dictionary<char,long?> TallyIconTotal(string rolledString)
        {
            //string resultMessage = "You have rolled: \n";
            Dictionary<char, long?> iconCounter = new Dictionary<char, long?>();

            iconCounter.Add('s',0);
            iconCounter.Add('f',0);
            iconCounter.Add('a',0);
            iconCounter.Add('h',0);
            iconCounter.Add('t',0);
            iconCounter.Add('d',0);


            foreach (char c in rolledString)
            {
                    iconCounter[c] ++;
            }
            return iconCounter;
        }

        public Dictionary<char,long?> NetIconTotal(Dictionary<char,long?> talliedIconTotal)
        {
            if (talliedIconTotal['s'] + talliedIconTotal['t'] <= talliedIconTotal['f'] + talliedIconTotal['d'])
            {
                talliedIconTotal['f'] = talliedIconTotal['f'] + talliedIconTotal['d'] - talliedIconTotal['s'] - talliedIconTotal['t'];
                talliedIconTotal['s'] = 0;
            }
            else 
            { 
                talliedIconTotal['s'] = talliedIconTotal['s'] + talliedIconTotal['t'] - talliedIconTotal['f'] - talliedIconTotal['d'];
                talliedIconTotal['f'] = 0;
            }

            if (talliedIconTotal['a'] <= talliedIconTotal['h'])
            {
                talliedIconTotal['h'] -= talliedIconTotal['a'];
                talliedIconTotal['a'] = 0;
            }
            else
            {
                talliedIconTotal['a'] -= talliedIconTotal['h'];
                talliedIconTotal['h'] = 0;
            }

            if (talliedIconTotal['t'] <= talliedIconTotal['d'])
            {
                talliedIconTotal['d'] -= talliedIconTotal['t'];
                talliedIconTotal['t'] = 0;
            }
            else
            {
                talliedIconTotal['t'] -= talliedIconTotal['d'];
                talliedIconTotal['d'] = 0;
            }
           

            return talliedIconTotal;
        }

        public string ResultsWriteUp(Dictionary<char,long?> results)
        {
            string writeup = "";
        //    writeup += "You rolled: \n\n";
            writeup += "**Successes:** " + results['s'] + "\n";
            writeup += "**Failures:** " + results['f'] + "\n";
            writeup += "**Advantages:** " + results['a'] + "\n";
            writeup += "**Threats:** " + results['h'] + "\n";
            writeup += "**Triumphs:** " + results['t'] + "\n";
            writeup += "**Despairs:** " + results['d'];


            return writeup;


        }
    }
}

/*int keyCounter = 0;
string amp = "";
string semicolon = ".";
foreach (char key in results.Keys) 
{
   if (results[key] <= 0) { results.Remove(key); }
}
if (results.Count() > 1) { amp = "and "; semicolon = ","; }
if (results.Count() > 0) 
{
    while (results.Count() > 1)
    {
        semicolon = ",";
        if (results.ContainsKey('s')) 
        {
            if (results['s'] == 1)
            {
                writeup += "1 Success" + semicolon + "\n";
            }
            else
            {
                writeup += results['s'].ToString() + " Successes" + semicolon + "\n";
            }
            results.Remove('s');
            keyCounter--;

        }

        if (results.ContainsKey('f'))
        {
            if (results['f'] == 1)
            {
                writeup += "1 Failure" + semicolon + "\n";
            }
            else
            {
                writeup += results['f'].ToString() + " Failures" + semicolon + "\n";
            }
            results.Remove('f');
            keyCounter--;
        }

        if (results.ContainsKey('a'))
        {
            if (results['a'] == 1)
            {
                writeup += "1 Advantage" + semicolon + "\n";
            }
            else
            {
                writeup += results['a'].ToString() + " Advantages" + semicolon + "\n";
            }
            results.Remove('a');
            keyCounter--;
        }

        if (results.ContainsKey('h'))
        {
            if (results['h'] == 1)
            {
                writeup += "1 Threat" + semicolon + "\n";
            }
            else
            {
                writeup += results['h'].ToString() + " Threats" + semicolon + "\n";
            }
            results.Remove('h');
            keyCounter--;
        }

        if (results.ContainsKey('t'))
        {
            if (results['t'] == 1)
            {
                writeup += "1 Triumphs" + semicolon + "\n";
            }
            else
            {
                writeup += results['t'].ToString() + " Triumphs" + semicolon + "\n";
            }
            results.Remove('t');
            keyCounter--;
        }

    }
    semicolon = ".";
    string lastIcon = "";
    foreach(char key in results.Keys)
    {
        switch(key)
        {
            case 's':
                if (results[key] == 1) { lastIcon = " Success"; }
                else lastIcon = " Successes";
                break;
            case 'f':
                if (results[key] == 1) { lastIcon = " Failure"; }
                else lastIcon = " Failures";
                break;
            case 'a':
                if (results[key] == 1) { lastIcon = " Advantage"; }
                else lastIcon = " Advantages";
                break;
            case 'h':
                if (results[key] == 1) { lastIcon = " Threat"; }
                else lastIcon = " Threats";
                break;
            case 't':
                if (results[key] == 1) { lastIcon = " Triumph"; }
                else lastIcon = " Triumphs";
                break;
            case 'd':
                if (results[key] == 1) { lastIcon = " Despair"; }
                else lastIcon = " Despairs";
                break;
        }
        writeup += amp + results[key].ToString() + lastIcon + semicolon;
    }
}
else
{
    writeup = "A completely even roll!?";
}
return writeup;*/
