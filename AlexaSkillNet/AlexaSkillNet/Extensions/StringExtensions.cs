namespace AlexaSkillNet.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether the string is neither null nor empty.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        ///   <c>true</c> if [is neither null nor empty] [the specified input]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNeitherNullNorEmpty(this string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        /// <summary>
        /// Determines whether the string is null or empty.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        ///   <c>true</c> if [is null or empty] [the specified input]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
        }
    }
}
