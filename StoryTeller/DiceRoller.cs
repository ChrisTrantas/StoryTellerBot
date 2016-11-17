using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller
{
    partial class MyBot
    {
        // 1. User types what roll to use ex !roll 6
        // 2. User types how many dice to use ex !roll 5 6
        // 3. Advantage ex !roll adv/dis
        // 4. Advantage with mod. !roll adv/dis 5
        // 5. Stats
        partial void RegisterRollDiceCommand()
        {

            int roll, dieSize, mod, advRoll;
            string die, modifier;

            commands.CreateCommand("roll")
                .Parameter("roll", Discord.Commands.ParameterType.Required)
                .Do(async (e) =>
                {
                    die = e.GetArg("roll");
                    int.TryParse(die, out dieSize);
                    roll = rand.Next(1, dieSize + 1);
                    await e.Channel.SendMessage("You rolled a **" + roll.ToString() + "**");
                });   

            commands.CreateCommand("adv")
                .Parameter("modifier", Discord.Commands.ParameterType.Required)
                .Do(async (e) =>
                {
                    modifier = e.GetArg("modifier");
                    int.TryParse(modifier, out mod);            
                    roll = rand.Next(1, 21);
                    advRoll = rand.Next(1, 21);
                    if (roll >= advRoll)                    
                        roll = roll + mod;                    
                    else                    
                        roll = advRoll + mod;
                    
                    await e.Channel.SendMessage("You rolled a **" + roll.ToString() + "** with your advantage");
                    await e.Channel.SendMessage(" ADV Roll: " + advRoll.ToString() + " Mod: " + mod.ToString());
                });

            commands.CreateCommand("dis")
                .Parameter("modifier")
                .Do(async (e) =>
                {
                    modifier = e.GetArg("Modifier");
                    int.TryParse(modifier, out mod);
                    roll = rand.Next(1, 21);
                    advRoll = rand.Next(1, 21);
                    if (roll <= advRoll)
                        roll = roll + mod;
                    else
                        roll = advRoll + mod;
                    await e.Channel.SendMessage("You rolled a **" + roll.ToString() + "** with your disadvantage");
                    await e.Channel.SendMessage("Roll: " + roll.ToString() + " ADV Roll: " + advRoll.ToString() + " Mod: " + mod.ToString());
                });
        }
    }
}
