using NajotTalimOshxona.Consists;
using System.IO;
using System.Threading.Tasks;
using Telegram.Bot;

namespace NajotTalimOshxona.Repositories
{
    internal static class Bot
    {
        public static TelegramBotClient botClient = new(BotConfig.TOKEN);

        public static async Task SendFoodData()
        {
            using (var stream = File.Open(Paths.FoodsDbPath, FileMode.Open))
            {
                Telegram.Bot.Types.InputFiles.InputOnlineFile iof = new(stream);

                iof.FileName = "FoodsData.json";

                await botClient.SendDocumentAsync(BotConfig.ADMIN_CHAT, iof);
                Program.Enterance();

                return;
            }
        }
    }
}
