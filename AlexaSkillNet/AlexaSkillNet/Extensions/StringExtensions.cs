namespace AlexaSkillNet.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNeitherNullNorEmpty(this string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
        }
    }
}
