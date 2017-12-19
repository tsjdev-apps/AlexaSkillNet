using System.Collections.Generic;
using Alexa.NET.Response;
using Alexa.NET.Response.Directive;

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
            return CreateSkillResponse(new PlainTextOutputSpeech { Text = outputSpeech }, shouldEndSession, null, null, repromtText);
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
            return CreateSkillResponse(new SsmlOutputSpeech { Ssml = outputSpeech }, shouldEndSession, null, null, repromtText);
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
            return CreateSkillResponse(new PlainTextOutputSpeech { Text = outputSpeech }, shouldEndSession, card, null, repromtText);
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
            return CreateSkillResponse(new SsmlOutputSpeech { Ssml = outputSpeech }, shouldEndSession, card, null, repromtText);
        }

        /// <summary>
        /// Creates a SSML with card skill response.
        /// </summary>
        /// <param name="outputSpeech">The output speech.</param>
        /// <param name="shouldEndSession">if set to <c>true</c> [should end session].</param>
        /// <param name="card">The card.</param>
        /// <param name="directives">The directives.</param>
        /// <param name="repromtText">The repromt text.</param>
        /// <returns></returns>
        public static SkillResponse CreateSsmlWithCardAndDirectivesSkillResponse(string outputSpeech, bool shouldEndSession, ICard card, IList<IDirective> directives, string repromtText)
        {
            return CreateSkillResponse(new SsmlOutputSpeech { Ssml = outputSpeech }, shouldEndSession, card, directives, repromtText);
        }

        /// <summary>
        /// Creates a plain text with card skill response.
        /// </summary>
        /// <param name="outputSpeech">The output speech.</param>
        /// <param name="shouldEndSession">if set to <c>true</c> [should end session].</param>
        /// <param name="card">The card.</param>
        /// <param name="directvies">The directives.</param>
        /// <param name="repromtText">The repromt text.</param>
        /// <returns></returns>
        public static SkillResponse CreatePlainTextWithCardAndDirectivesSkillResponse(string outputSpeech, bool shouldEndSession, ICard card, IList<IDirective> directvies, string repromtText)
        {
            return CreateSkillResponse(new PlainTextOutputSpeech { Text = outputSpeech }, shouldEndSession, card, directvies, repromtText);
        }


        /// <summary>
        /// Creates a SSML with card skill response.
        /// </summary>
        /// <param name="outputSpeech">The output speech.</param>
        /// <param name="shouldEndSession">if set to <c>true</c> [should end session].</param>
        /// <param name="directives">The directives.</param>
        /// <param name="repromtText">The repromt text.</param>
        /// <returns></returns>
        public static SkillResponse CreateSsmlWithDirectivesSkillResponse(string outputSpeech, bool shouldEndSession, IList<IDirective> directives, string repromtText)
        {
            return CreateSkillResponse(new SsmlOutputSpeech { Ssml = outputSpeech }, shouldEndSession, null, directives, repromtText);
        }

        /// <summary>
        /// Creates a plain text with card skill response.
        /// </summary>
        /// <param name="outputSpeech">The output speech.</param>
        /// <param name="shouldEndSession">if set to <c>true</c> [should end session].</param>
        /// <param name="directvies">The directives.</param>
        /// <param name="repromtText">The repromt text.</param>
        /// <returns></returns>
        public static SkillResponse CreatePlainTextWithDirectivesSkillResponse(string outputSpeech, bool shouldEndSession, IList<IDirective> directvies, string repromtText)
        {
            return CreateSkillResponse(new PlainTextOutputSpeech { Text = outputSpeech }, shouldEndSession, null, directvies, repromtText);
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
        /// Create a Display Render Template Directive with the provided template.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <returns></returns>
        public static IDirective DisplayRenderTemplateDirective(ITemplate template)
        {
            return new DisplayRenderTemplateDirective { Template = template };
        }

        /// <summary>
        /// Creates a skill response.
        /// </summary>
        /// <param name="outputSpeech">The output speech.</param>
        /// <param name="shouldEndSession">if set to <c>true</c> [should end session].</param>
        /// <param name="card">The card.</param>
        /// <param name="directives">The directives.</param>
        /// <param name="repromtText">The repromt text.</param>
        /// <returns></returns>
        private static SkillResponse CreateSkillResponse(IOutputSpeech outputSpeech, bool shouldEndSession, ICard card, IList<IDirective> directives, string repromtText)
        {
            var response = new ResponseBody
            {
                ShouldEndSession = shouldEndSession,
                OutputSpeech = outputSpeech
            };

            if (card != null)
                response.Card = card;

            if (directives != null)
                response.Directives = directives;

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
