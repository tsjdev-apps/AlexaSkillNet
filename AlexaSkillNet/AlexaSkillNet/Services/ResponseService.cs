using Alexa.NET.Response;

namespace AlexaSkillNet.Services
{
    public static class ResponseService
    {
        /// <summary>
        /// Creates a plain text skill response.
        /// </summary>
        /// <param name="outputSpeech">The output speech.</param>
        /// <param name="shouldEndSession">if set to <c>true</c> [should end session].</param>
        /// <param name="repromtText">The repromt text.</param>
        /// <returns></returns>
        public static SkillResponse CreatePlainTextSkillResponse(string outputSpeech, bool shouldEndSession, string repromtText = "")
        {
            return CreateSkillResponse(new PlainTextOutputSpeech { Text = outputSpeech }, shouldEndSession, null, repromtText);
        }


        /// <summary>
        /// Creates a SSML skill response.
        /// </summary>
        /// <param name="outputSpeech">The output speech.</param>
        /// <param name="shouldEndSession">if set to <c>true</c> [should end session].</param>
        /// <param name="repromtText">The repromt text.</param>
        /// <returns></returns>
        public static SkillResponse CreateSsmlSkillResponse(string outputSpeech, bool shouldEndSession, string repromtText = "")
        {
            return CreateSkillResponse(new SsmlOutputSpeech { Ssml = outputSpeech }, shouldEndSession, null, repromtText);
        }

        /// <summary>
        /// Creates a plain text with card skill response.
        /// </summary>
        /// <param name="outputSpeech">The output speech.</param>
        /// <param name="shouldEndSession">if set to <c>true</c> [should end session].</param>
        /// <param name="card">The card.</param>
        /// <param name="repromtText">The repromt text.</param>
        /// <returns></returns>
        public static SkillResponse CreatePlainTextWithCardSkillResponse(string outputSpeech, bool shouldEndSession, ICard card, string repromtText)
        {
            return CreateSkillResponse(new PlainTextOutputSpeech { Text = outputSpeech }, shouldEndSession, card, repromtText);
        }

        /// <summary>
        /// Creates a SSML with card skill response.
        /// </summary>
        /// <param name="outputSpeech">The output speech.</param>
        /// <param name="shouldEndSession">if set to <c>true</c> [should end session].</param>
        /// <param name="card">The card.</param>
        /// <param name="repromtText">The repromt text.</param>
        /// <returns></returns>
        public static SkillResponse CreateSsmlWithCardSkillResponse(string outputSpeech, bool shouldEndSession, ICard card, string repromtText)
        {
            return CreateSkillResponse(new SsmlOutputSpeech { Ssml = outputSpeech }, shouldEndSession, card, repromtText);
        }

        /// <summary>
        /// Creates a simple card.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public static ICard CreateSimpleCard(string title, string content)
        {
            return new SimpleCard { Title = title, Content = content };
        }

        /// <summary>
        /// Creates a standard card.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="content">The content.</param>
        /// <param name="cardImage">The card image.</param>
        /// <returns></returns>
        public static ICard CreateStandardCard(string title, string content, CardImage cardImage = null)
        {
            return new StandardCard { Title = title, Content = content, Image = cardImage };
        }

        /// <summary>
        /// Creates a skill response.
        /// </summary>
        /// <param name="outputSpeech">The output speech.</param>
        /// <param name="shouldEndSession">if set to <c>true</c> [should end session].</param>
        /// <param name="card">The card.</param>
        /// <param name="repromtText">The repromt text.</param>
        /// <returns></returns>
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
