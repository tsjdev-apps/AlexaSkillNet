using Amazon.Lambda.Core;
using Alexa.NET.Response;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using AlexaSkillNet.Services;
using AlexaSkillNet.Utils;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace AlexaSkillNet
{
    public class Function
    {
        /// <summary>
        /// Entry point of your alexa skill.
        /// Here you have the possibility to handle all provided intents.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            var requestType = input.GetRequestType();

            if (requestType == typeof(LaunchRequest))
            {
                return ResponseService.CreatePlainTextSkillResponse(MessagesService.GetLaunchMessage(), false);
            }

            if (requestType == typeof(IntentRequest))
            {
                if (!(input.Request is IntentRequest intentRequest))
                    return ResponseService.CreatePlainTextSkillResponse(MessagesService.GetErrorMessage(), true);

                switch (intentRequest.Intent.Name)
                {
                    case Statics.AmazonHelpIntent:
                        var helpMessage = MessagesService.GetHelpMessage();
                        return ResponseService.CreatePlainTextSkillResponse(helpMessage, false);
                    case Statics.AmazonCancelIntent:
                    case Statics.AmazonStopIntent:
                        return ResponseService.CreatePlainTextSkillResponse(MessagesService.GetStopOrCancelMessage(), true);
                    default:
                        return ResponseService.CreatePlainTextSkillResponse(MessagesService.GetHelpMessage(), false);
                }
            }

            return ResponseService.CreatePlainTextSkillResponse(MessagesService.GetErrorMessage(), true);
        }
    }
}