namespace AlexaSkillNet.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Determines whether the object is not null.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        ///   <c>true</c> if [is not null] [the specified object]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }

        /// <summary>
        /// Determines whether the object is null.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        ///   <c>true</c> if the specified object is null; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }
    }
}