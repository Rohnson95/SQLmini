namespace tempSQL
{
    internal class Helper
    {

        internal static int MenuIndexer(string[] array, bool hasBack = false, string headerText = "")
        {
            if (hasBack)
            {
                Array.Resize(ref array, array.Length + 1);
                array[array.Length - 1] = "Go Back";
            }
            menu menu = new menu(array);
            if (!string.IsNullOrEmpty(headerText))
            {
                menu.PrintMenu(headerText);
            }
            else
            {
                menu.PrintMenu();
            }
            int index = menu.UseMenu();
            return index;
        }
    }
}
