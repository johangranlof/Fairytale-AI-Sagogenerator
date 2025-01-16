using OpenAI_API;
using OpenAI_API.Models;

namespace Sagogenerator.Components.Services
{
    public class OpenAIService
    {
        private readonly IConfiguration _configuration;
        private OpenAIAPI _api;

        public OpenAIService(IConfiguration configuration)
        {
            _configuration = configuration;
            var key = _configuration.GetValue<string>("OPENAI_KEY"); //Hämta nyckeln
            _api = new OpenAIAPI(new APIAuthentication(key));
        }

        public async Task<string> GenerateResponseAsync(string prompt)
        {
            var chat = _api.Chat.CreateConversation();
            chat.Model = Model.ChatGPTTurbo;
            chat.AppendUserInput(prompt);

            var response = await chat.GetResponseFromChatbotAsync();

            return response;
        }

        public async Task<string> GenerateImageAsync(string prompt)
        {
            try
            {
                var result = await _api.ImageGenerations.CreateImageAsync(prompt, Model.DALLE3);

                return result.Data[0].Url;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return "";
            }
        }
    }
}
