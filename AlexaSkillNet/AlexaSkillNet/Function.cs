using Amazon.Lambda.Core;
using Alexa.NET.Response;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using AlexaSkillNet.Services;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace AlexaSkillNet
{
    public class Function
    {
        private const string AmazonStopIntent = "AMAZON.StopIntent";
        private const string AmazonCancelIntent = "AMAZON.CancelIntent";
        private const string AmazonHelpIntent = "AMAZON.HelpIntent";

        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            var requestType = input.GetRequestType();

            if (requestType == typeof(LaunchRequest))
            {
                return MakeSkillResponse(MessagesService.GetLaunchMessage(), false);
            }

            if (requestType == typeof(IntentRequest))
            {
                if (!(input.Request is IntentRequest intentRequest))
                    return MakeSkillResponse(MessagesService.GetErrorMessage(), true);

                switch (intentRequest.Intent.Name)
                {
                    case AmazonHelpIntent:
                        return MakeSkillResponse(MessagesService.GetHelpMessage(), false);
                    case AmazonCancelIntent:
                    case AmazonStopIntent:
                        return MakeSkillResponse(MessagesService.GetStopOrCancelMessage(), true);
                    default:
                        return MakeSkillResponse(MessagesService.GetHelpMessage(), false);
                }
            }

            return MakeSkillResponse(MessagesService.GetErrorMessage(), true);
        }

        private static SkillResponse MakeSkillResponse(string outputSpeech, bool shouldEndSession, bool useSsml = false, string repromtText = "")
        {
            var response = new ResponseBody
            {
                ShouldEndSession = shouldEndSession,
            };

            if (useSsml)
                response.OutputSpeech = new SsmlOutputSpeech { Ssml = outputSpeech };
            else
                response.OutputSpeech = new PlainTextOutputSpeech { Text = outputSpeech };

            if (!string.IsNullOrEmpty(repromtText))
                response.Reprompt = new Reprompt { OutputSpeech = new PlainTextOutputSpeech { Text = repromtText } };

            var skillResponse = new SkillResponse
            {
                Response = response,
                Version = "1.0"
            };

            return skillResponse;
        }
    }
}