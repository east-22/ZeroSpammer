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
            Console.Title = "Zero Spammer | Loading...";
#if !DEBUG
            utils.Intro();
#endif
            Menu();
        }

        private static void Menu()
        {
            Console.Clear();
            Console.Title = "Zero Spammer | Main Menu";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Zero Spammer made in C# for discord | github.com/east-22\n\n");
            Console.ResetColor();

            if (string.IsNullOrEmpty(webhook))
            {
                Console.Write($"Webhook: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("No webhook\n"); Console.ResetColor();
            }
            else
            {
                Console.Write($"Webhook: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("True\n"); Console.ResetColor();

            }
                

            Console.WriteLine("[1] - Enter webhook\t[2] - Start spamming\t[3] - Open github");
            Console.Write("-> ");
            var result = Console.ReadLine();

            if (result == "1")
            {
                Console.Write("Enter webhook: ");
                var entered_webhook = Console.ReadLine();
                if (entered_webhook.StartsWith("https://discord.com/api/webhooks/"))
                {
                    webhook = entered_webhook;
                    Menu();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Invalid webhook!"); Console.ResetColor(); Thread.Sleep(500); Menu();
                }

            }
            if (result == "2")
            {
                if (!string.IsNullOrEmpty(webhook))
                {
                    Spammer();
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No webhook!");
                    Console.ResetColor();
                    Thread.Sleep(500);
                    Menu();
                }

            }
            if (result == "3")
            {
                Process.Start("explorer.exe","https://github.com/east-22");
                Menu();
            }
            if (result == string.Empty)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid option!");
                Console.ResetColor();
                Thread.Sleep(500);
                Menu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid option!");
                Console.ResetColor();
                Thread.Sleep(500);
                Menu();
            }
        }

        private static void Spammer()
        {
            Console.Clear();
            Console.Title = "Zero Spammer | Spamming...";

            Console.Write("Message: ");
            var message = Console.ReadLine();
            Console.Write("How many: ");
            int.TryParse(Console.ReadLine(), out var how_many);

            int sent = 0;
            for (int i = 0; i < how_many; i++)
            {
                try
                {
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    string payload = "{\"content\": \"" + message + "\"}";
                    client.UploadData(webhook, Encoding.UTF8.GetBytes(payload));
                    utils.ConsoleLog($"Sent message {i + 1}/{how_many}", 1);
                    sent++;
                }
                catch
                {
                    utils.ConsoleLog($"Didnt sent: {i + 1}/{how_many}", 2);
                    sent--;
                }
            }
            utils.ConsoleLog($"Sent {sent}/{how_many}", 0);
            Console.WriteLine("Press any key to continue...");
            Console.Read();
        }
    }
}