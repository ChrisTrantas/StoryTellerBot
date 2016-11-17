using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller
{
    public partial class MyBot
    {
        // Discord
        DiscordClient discord;
        CommandService commands;
        Random rand;

        public MyBot()
        {
            rand = new Random();
            discord = new DiscordClient(x =>
           {
               x.LogLevel = LogSeverity.Info;
               x.LogHandler = Log;
           });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;               
            });

            commands = discord.GetService<CommandService>();

            #region RegisterCommandList
            RegisterRollDiceCommand();
            test();
            #endregion

            discord.ExecuteAndWait(async () => 
            {
                await discord.Connect("MjQ3NzE4NTcwNjUyMzM2MTM4.CwtTnw.cieBhKa3M5INA9JpYt3rh_yexcs"
, TokenType.Bot);
            });

           
        }

        partial void RegisterRollDiceCommand();
        private void test()
        {
            commands.CreateCommand("Test")
                .Do(async (e) =>
            {
                await e.Channel.SendMessage("It works. Your other code is fucked.");
            });
        }
        
        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
