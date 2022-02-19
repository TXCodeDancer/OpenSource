namespace PlexHelperUI
{
    public class Messages
    {
        public static void Display(string message, string caption = "Error")
        {
            MessageBox.Show(message, caption);
        }
    }
}
