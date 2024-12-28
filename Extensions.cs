using System.Text;

namespace LethalBingoAPI
{
    public static class Extensions
    {
        public const string IllegalChars = ".,?!@#$%^&*()_+-=';:'\"";

        public static string MakeValidId(this string input)
        {
            StringBuilder builder = new();
            foreach (char character in input)
            {
                if (character == ' ')
                {
                    builder.Append('_');
                }
                else if (!IllegalChars.Contains(character) && char.IsLetterOrDigit(character))
                {
                    if (char.IsUpper(character)) builder.Append(char.ToLower(character));
                    else builder.Append(character);
                }
            }
            return builder.ToString();
        }
    }
}
