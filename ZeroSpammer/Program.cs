using System.Diagnostics;
using System.Net;
using System.Text;
using ZeroSpammer;

namespace Zero.Main
{
    public class ZeroMain
    {
        public static string webhook = "";
        public static utils x = new utils();

        public static void Main(string[] args)
        {
            if (File.Exists("config.ini"))
            {
                webhook = File.ReadAllText("config.ini");
            }
            Console.Title = "Zero Spammer | Loading...";
#if !DEBUG
            utils.logo(true);
#endif
            Menu();
        }

        private static void Menu()
        {
            while (true)
            {
                Console.Clear();
                utils.logo(false);
                Console.Title = "Zero Spammer | Main Menu";

                Console.Write("Webhook: ");
                Console.ForegroundColor = string.IsNullOrEmpty(webhook) ? ConsoleColor.Red : ConsoleColor.Green;
                Console.WriteLine(string.IsNullOrEmpty(webhook) ? "No webhook" : "True");
                Console.ResetColor();

                Console.WriteLine("[1] - Edit webhook\t[2] - Start spamming\t[3] - Open github");
                Console.Write("-> ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        utils.logo(false);
                        Console.WriteLine("Enter your webhook URL (must start with https://discord.com/api/webhooks/):");
                        Console.WriteLine("OR, type 'remove' to remove it");
                        Console.Write("-> ");
                        var entered = Console.ReadLine();
                        if (entered.Equals("remove", StringComparison.OrdinalIgnoreCase))
                        {
                            webhook = "";
                            File.WriteAllText("config.ini", "");
                            continue;
                        }
                        if (entered.StartsWith("https://discord.com/api/webhooks/"))
                        {
                            webhook = entered;
                            File.WriteAllText("config.ini", webhook);
                        }

                        else
                        {
                            Error("Invalid webhook!");
                            continue;
                        }
                        break;

                    case "2":
                        if (string.IsNullOrEmpty(webhook)) { Error("No webhook!"); continue; }
                        Spammer();
                        break;

                    case "3":
                        Process.Start("explorer.exe","https://github.com/east-22");
                        break;

                    default:
                        Error("Invalid option!");
                        break;
                }
            }
        }

        private static void Spammer()
        {
            Console.Clear();
            utils.logo(false);
            Console.Title = "Zero Spammer | Spamming...";

            Console.Write("Message: ");
            var msg = Console.ReadLine();
            Console.Write("How many: ");
            int.TryParse(Console.ReadLine(), out var count);

            int sent = 0;
            for (int i = 0; i < count; i++)
            {
                try
                {
                    using var client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    var payload = "{\"content\": \"" + msg + "\"}";
                    client.UploadData(webhook, Encoding.UTF8.GetBytes(payload));
                    utils.ConsoleLog($"Sent message {i + 1}/{count}", 1);
                    sent++;
                }
                catch
                {
                    utils.ConsoleLog($"Didn't send: {i + 1}/{count}", 2);
                }
            }

            utils.ConsoleLog($"Sent {sent}/{count}", 0);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void Error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
            Thread.Sleep(500);
        }
    }
}
