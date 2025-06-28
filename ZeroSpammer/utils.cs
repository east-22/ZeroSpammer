namespace ZeroSpammer
{
    public class utils
    {

        public static void logo(bool type)
        {
            string[] logo;
            if (type)
            {
                logo = new string[]
                {
                        "███████╗███████╗██████╗░░█████╗░",
                        "╚════██║██╔════╝██╔══██╗██╔══██╗",
                        "░░███╔═╝█████╗░░██████╔╝██║░░██║",
                        "██╔══╝░░██╔══╝░░██╔══██╗██║░░██║",
                        "███████╗███████╗██║░░██║╚█████╔╝",
                        "╚══════╝╚══════╝╚═╝░░╚═╝░╚════╝░",
                        "Zero Spammer made by east_22",
                };
            }
            else
            {
                logo = new string[]
                {
@"$$$$$$$$\$$$$$$$$\$$$$$$$\  $$$$$$\         $$$$$$\ $$$$$$$\  $$$$$$\ $$\      $$\$$\      $$\$$$$$$$$\$$$$$$$\  ",
@"\____$$  $$  _____$$  __$$\$$  __$$\       $$  __$$\$$  __$$\$$  __$$\$$$\    $$$ $$$\    $$$ $$  _____$$  __$$\ ",
@"    $$  /$$ |     $$ |  $$ $$ /  $$ |      $$ /  \__$$ |  $$ $$ /  $$ $$$$\  $$$$ $$$$\  $$$$ $$ |     $$ |  $$ |",
@"   $$  / $$$$$\   $$$$$$$  $$ |  $$ |      \$$$$$$\ $$$$$$$  $$$$$$$$ $$\$$\$$ $$ $$\$$\$$ $$ $$$$$\   $$$$$$$  |",
@"  $$  /  $$  __|  $$  __$$<$$ |  $$ |       \____$$\$$  ____/$$  __$$ $$ \$$$  $$ $$ \$$$  $$ $$  __|  $$  __$$<",
@" $$  /   $$ |     $$ |  $$ $$ |  $$ |      $$\   $$ $$ |     $$ |  $$ $$ |\$  /$$ $$ |\$  /$$ $$ |     $$ |  $$ |",
@"$$$$$$$$\$$$$$$$$\$$ |  $$ |$$$$$$  |      \$$$$$$  $$ |     $$ |  $$ $$ | \_/ $$ $$ | \_/ $$ $$$$$$$$\$$ |  $$ |",
@"\________\________\__|  \__|\______/        \______/\__|     \__|  \__\__|     \__\__|     \__\________\__|  \__|",
""
                };
            }


            Console.ForegroundColor = ConsoleColor.Red;

            int consoleWidth = Console.WindowWidth;
            int startRow = type
                ? Console.WindowHeight / 2 - logo.Length / 2  // center vertically if animated logo
                : 2; // print near top when false

            foreach (var text in logo)
            {
                if (type) Thread.Sleep(250);
                int padding = Math.Max((consoleWidth - text.Length) / 2, 0);
                Console.SetCursorPosition(padding, startRow++);
                Console.WriteLine(text);
            }

            Console.ResetColor();

            if (type)
            {
                Thread.Sleep(1500);
                Console.Clear();
            }

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
