using AlexaSkillNet.Extensions;
using System.Collections.Generic;

namespace AlexaSkillNet.Services
{
    public static class MessagesService
    {
        /// <summary>
        /// The launch request messages
        /// </summary>
        private static readonly List<string> LaunchRequestMessages = new List<string>
        {
            "Hallo"
        };

        /// <summary>
        /// The amazon help intent messages
        /// </summary>
        private static readonly List<string> AmazonHelpIntentMessages = new List<string>
        {
            "Hilfe"
        };

        /// <summary>
        /// The amazon stop or cancel intent messages
        /// </summary>
        private static readonly List<string> AmazonStopOrCancelIntentMessages = new List<string>
        {
            "Stop"
        };

        /// <summary>
        /// The error messages
        /// </summary>
        private static readonly List<string> ErrorMessages = new List<string>
        {
            "Fehler"
        };


        /// <summary>
        /// Gets a random launch message after the launch intent was recognized.
        /// </summary>
        /// <returns>The random message.</returns>
        public static string GetLaunchMessage()
        {
            return LaunchRequestMessages.PickRandom();
        }

        /// <summary>
        /// Gets a random help message after the AMAZON.HelpIntent was recognized.
        /// </summary>
        /// <returns>The random message.</returns>
        public static string GetHelpMessage()
        {
            return AmazonHelpIntentMessages.PickRandom();
        }

        /// <summary>
        /// Gets a random stop or cancel message after the AMAZON.StopIntent or AMAZON.CancelIntent was recognized.
        /// </summary>
        /// <returns>The random message.</returns>
        public static string GetStopOrCancelMessage()
        {
            return AmazonStopOrCancelIntentMessages.PickRandom();
        }

        /// <summary>
        /// Gets a random error message if something gone wrong.
        /// </summary>
        /// <returns>The random message.</returns>
        public static string GetErrorMessage()
        {
            return ErrorMessages.PickRandom();
        }
    }
}