using Alexa.NET.Response;

namespace AlexaSkillNet.Services
{
    public static class ResponseService
    {
        public static SkillResponse CreatePlainTextSkillResponse(string outputSpeech, bool shouldEndSession, string repromtText = "")
        {
            return CreateSkillResponse(new PlainTextOutputSpeech { Text = outputSpeech }, shouldEndSession, null, repromtText);
        }

        public static SkillResponse CreateSsmlSkillResponse(string outputSpeech, bool shouldEndSession, string repromtText = "")
        {
            return CreateSkillResponse(new SsmlOutputSpeech { Ssml = outputSpeech }, shouldEndSession, null, repromtText);
        }

        public static SkillResponse CreatePlainTextWithCardSkillResponse(string outputSpeech, bool shouldEndSession, ICard card, string repromtText)
        {
            return CreateSkillResponse(new PlainTextOutputSpeech { Text = outputSpeech }, shouldEndSession, card, repromtText);
        }

        public static SkillResponse CreateSsmlWithCardSkillResponse(string outputSpeech, bool shouldEndSession, ICard card, string repromtText)
        {
            return CreateSkillResponse(new SsmlOutputSpeech { Ssml = outputSpeech }, shouldEndSession, card, repromtText);
        }

        public static ICard CreateSimpleCard(string title, string content)
        {
            return new SimpleCard { Title = title, Content = content };
        }

        public static ICard CreateStandardCard(string title, string content, CardImage cardImage = null)
        {
            return new StandardCard { Title = title, Content = content, Image = cardImage };
        }

        private static SkillResponse CreateSkillResponse(IOutputSpeech outputSpeech, bool shouldEndSession, ICard card, string repromtText)
        {
            var response = new ResponseBody
            {
                ShouldEndSession = shouldEndSession,
                OutputSpeech = outputSpeech
            };

            if (card != null)
                response.Card = card;

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
