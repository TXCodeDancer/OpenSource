namespace HelperLibrary
{
    public class NameChange
    {
        public static string ConvertSpace(string name, char replacement = '.')
        {
            name = name.Trim();
            name = name.Replace(" ", replacement.ToString());
            name = name.Replace("-", "");
            name = name.Replace("_", "");

            string result = name[0].ToString();
            for (int i = 1; i < name.Length; i++)
            {
                if (name[i] != replacement || name[i] != name[i - 1])
                {
                    result += name[i];
                }
            }

            return result;
        }
    }
}
