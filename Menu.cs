namespace tempSQL
{
    internal class menu
    {
        private readonly string[] _menuItems;
        private int _selectedIndex;
        private string _headerText;

        public menu(string[] menuItems)
        {
            _menuItems = menuItems;
            _selectedIndex = 0;
        }

        public void PrintMenu(string headerText = "")
        {
            Console.Clear();
            if (!string.IsNullOrEmpty(headerText))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{_headerText}\n");
            }
            for (int i = 0; i < _menuItems.Length; i++)
            {
                Console.ForegroundColor = i == _selectedIndex ? ConsoleColor.DarkRed : ConsoleColor.White;
                Console.WriteLine(i == _selectedIndex ? $"⇛ {_menuItems[i]}" : $"  {_menuItems[i]}  ");
                Console.WriteLine();
            }
            Console.ResetColor();
        }
        public int SelectIndex
        {
            get => _selectedIndex;
            set => _selectedIndex = (value % _menuItems.Length + _menuItems.Length) % _menuItems.Length;
        }
        public int UseMenu(string headerText = "")
        {
            ConsoleKey userInput;
            do
            {
                userInput = Console.ReadKey(true).Key;
                switch (userInput)
                {
                    case ConsoleKey.UpArrow:
                        _selectedIndex--;
                        _selectedIndex = (_selectedIndex % _menuItems.Length + _menuItems.Length) % _menuItems.Length;
                        break;
                    case ConsoleKey.DownArrow:
                        _selectedIndex++;
                        _selectedIndex = (_selectedIndex % _menuItems.Length + _menuItems.Length) % _menuItems.Length;
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        var index = _selectedIndex;
                        PrintMenu(headerText);
                        return index;
                }
                PrintMenu(headerText);
            } while (true);
        }
        internal static void StartMenu()
        {
            menu mainMenu = new menu(new string[] { "Hour Report", "Users", "Projects", "New Person", "New Project", "Update Existing User", "Update Existing Project", "Adjust Existing hours Worked", "Exit" });

            mainMenu.PrintMenu();
            bool showMenu = true;

            while (showMenu)
            {
                int index = mainMenu.UseMenu();
                switch (index)
                {
                    case 0:
                        Program.ClockHours();
                        break;
                    case 1:
                        Program.Users();
                        break;
                    case 2:
                        Program.Projects();
                        break;
                    case 3:
                        Program.NewPerson();
                        break;
                    case 4:
                        Program.NewProject();
                        break;
                    case 5:
                        Program.UpdatePerson();
                        break;
                    case 6:
                        Program.UpdateProject();
                        break;
                    case 7:
                        Program.ModifyTime();
                        break;
                    case 8:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
