using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram;
using Telegram.Bot.Args;

namespace FlandreBotBeta
{
        class Flandre
        {
                public static async Task PrintAsync(object str, MessageEventArgs e)
                {
                        var s = Convert.ToString(str);
                        await Program.FlandreBot.SendTextMessageAsync(e.Message.Chat.Id, s);
                }

                public static async void RespondAsync(object sender, MessageEventArgs e)
                {
                        try
                        {
                                string input = e.Message.Text;
                                if (input == "")
                                {
                                        return;
                                }
                                if (input[0] != '/')
                                {
                                        return;
                                }
                                //Dice Function:
                                //"/r xdy+z"will order the bot to roll a dice
                                //such as"/r 1d20+3"
                                if (input[1] == 'r'&&input[2]==' ')
                                {
                                        int result = new Dice(input.Substring(3)).Roll();
                                        var prt = e.Message.From.Username+ ": " + input.Substring(3) + " = " + result;
                                        PrintAsync(prt,e);
                                }
                        }
                        catch
                        {
                        }
                        

                }
        }
}
