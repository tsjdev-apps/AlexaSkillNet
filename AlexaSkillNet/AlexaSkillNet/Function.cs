using System;
using Amazon.Lambda.Core;
using Alexa.NET.Response;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using AlexaSkillNet.Enums;
using AlexaSkillNet.Services;
using AlexaSkillNet.Utils;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace AlexaSkillNet
{
    public class Function
    {
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
                    case Statics.AmazonHelpIntent:
                        var helpMessage = MessagesService.GetHelpMessage();
                        return MakeSkillResponse(helpMessage, false, CreateCard(CardType.Simple, string.Empty, helpMessage));
                    case Statics.AmazonCancelIntent:
                    case Statics.AmazonStopIntent:
                        return MakeSkillResponse(MessagesService.GetStopOrCancelMessage(), true);
                    default:
                        return MakeSkillResponse(MessagesService.GetHelpMessage(), false);
                }
            }

            return MakeSkillResponse(MessagesService.GetErrorMessage(), true);
        }

        private static SkillResponse MakeSkillResponse(string outputSpeech, bool shouldEndSession, ICard card = null, bool useSsml = false, string repromtText = "")
        {
            var response = new ResponseBody
            {
                ShouldEndSession = shouldEndSession,
            };

            if (card != null)
                response.Card = card;

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

        private static ICard CreateCard(CardType cardType, string cardTitle, string cardContent, CardImage cardImage = null)
        {

            switch (cardType)
            {
                case CardType.Simple:
                    return new SimpleCard { Title = cardTitle, Content = cardContent };
                case CardType.Standard:
                    var standardCard = new StandardCard { Title = cardTitle, Content = cardContent };
                    if (cardImage != null)
                        standardCard.Image = cardImage;
                    return standardCard;
                default:
                    throw new ArgumentOutOfRangeException(nameof(cardType), cardType, null);
            }
        }
    }
}