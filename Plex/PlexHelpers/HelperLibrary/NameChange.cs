namespace HelperLibrary
{
    public class NameChange
    {
        public static string ConvertSpace(string name, char replacement = '.')
        {
            name = name.Replace(" ", replacement.ToString());
            name = name.Replace("-", "");
            name = name.Replace("_", "");

            string result = "";
            for (int i = 0; i < name.Length - 1; i++)
            {
                if (name[i] != replacement || name[i] != name[i + 1])
                {
                    result += name[i];
                }
            }
            result += name[name.Length - 1];

            return result;
        }
    }
}
