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
            "LaunchRequest"
        };

        /// <summary>
        /// The amazon help intent messages
        /// </summary>
        private static readonly List<string> AmazonHelpIntentMessages = new List<string>
        {
            "HelpIntent"
        };

        /// <summary>
        /// The amazon stop intent messages
        /// </summary>
        private static readonly List<string> AmazonStopIntentMessages = new List<string>
        {
            "StopIntent"
        };

        /// <summary>
        /// The amazon cancel intent messages
        /// </summary>
        private static readonly List<string> AmazonCancelIntentMessages = new List<string>
        {
            "CancelIntent"
        };

        /// <summary>
        /// The error messages
        /// </summary>
        private static readonly List<string> ErrorMessages = new List<string>
        {
            "Error"
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
        /// Gets a random stop message after the AMAZON.StopIntent was recognized.
        /// </summary>
        /// <returns>The random message.</returns>
        public static string GetStopMessage()
        {
            return AmazonStopIntentMessages.PickRandom();
        }

        /// <summary>
        /// Gets a random cancel message after the AMAZON.CancelIntent was recognized.
        /// </summary>
        /// <returns>The random message.</returns>
        public static string GetCancelMessage()
        {
            return AmazonCancelIntentMessages.PickRandom();
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