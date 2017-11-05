using AlexaSkillNet.Extensions;
using System.Collections.Generic;

namespace AlexaSkillNet.Services
{
    public static class MessagesService
    {
        private static readonly List<string> LaunchRequestMessages = new List<string>
        {
            "Hallo"
        };

        private static readonly List<string> AmazonHelpIntentMessages = new List<string>
        {
            "Hilfe"
        };

        private static readonly List<string> AmazonStopOrCancelIntentMessages = new List<string>
        {
            "Stop"
        };

        private static readonly List<string> ErrorMessages = new List<string>
        {
            "Fehler"
        };


        public static string GetLaunchMessage()
        {
            return LaunchRequestMessages.PickRandom();
        }

        public static string GetHelpMessage()
        {
            return AmazonHelpIntentMessages.PickRandom();
        }

        public static string GetStopOrCancelMessage()
        {
            return AmazonStopOrCancelIntentMessages.PickRandom();
        }

        public static string GetErrorMessage()
        {
            return ErrorMessages.PickRandom();
        }
    }
}