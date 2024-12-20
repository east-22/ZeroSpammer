namespace ZeroSpammer
{
    public class utils
    {

        public static void Intro()
        {
            string[] logo = new string[]
            {
        "███████╗███████╗██████╗░░█████╗░",
        "╚════██║██╔════╝██╔══██╗██╔══██╗",
        "░░███╔═╝█████╗░░██████╔╝██║░░██║",
        "██╔══╝░░██╔══╝░░██╔══██╗██║░░██║",
        "███████╗███████╗██║░░██║╚█████╔╝",
        "╚══════╝╚══════╝╚═╝░░╚═╝░╚════╝░",
        "Zero Spammer made by east_22",
            };

            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;
            int startRow = consoleHeight / 2 - logo.Length / 2;
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var text in logo)
            {
                Thread.Sleep(250);
                int padding = (consoleWidth - text.Length) / 2;
                Console.SetCursorPosition(0, startRow);
                Console.WriteLine(new string(' ', padding) + text);
                startRow++;
            }
            Console.ResetColor();
            Thread.Sleep(1500);
            Console.Clear();
        }



        public static void ConsoleLog(string txt, int type)
        {
            if (type == 0)
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("+");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("] - ");
                Console.WriteLine(txt);
            }
            else if (type == 1)
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("+");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("] - ");
                Console.WriteLine(txt);
            }
            else if (type == 2)
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("+");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("] - ");
                Console.WriteLine(txt);
            }

        }

    }
}
