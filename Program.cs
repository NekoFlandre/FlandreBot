using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace FlandreBotBeta
{
        class Program
        {
                public static TelegramBotClient FlandreBot = new TelegramBotClient("");
                static void Main(string[] args)
                {
                        //Initialize bot message
                        FlandreBot.OnMessage += Flandre.RespondAsync;
                        var me = FlandreBot.GetMeAsync().Result;
                        Console.Title = me.Username;//The title of the console will represent Flandre's ID
                        FlandreBot.StartReceiving();
                        Console.WriteLine("Press enter to turn down..");
                        Console.ReadLine();
                }
                static void InputLoop()
                {

                }
        }
}
