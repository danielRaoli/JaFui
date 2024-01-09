using OpenAI_API;
using OpenAI_API.Completions;

namespace ViagemApi.Services
{
    public static class GeradorDeDescricao
    {

        public static async Task<string> GerarDescricao(string destino)
        {
            string query = $"Faça um resumo sobre o local {destino} enfatizando o porque este lugar é incrível Utilize uma linguagem informal e até 2000 caracteres";

            string outPutResult = "";

            var openAi = new OpenAIAPI("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");

            CompletionRequest completionRequest = new()
            {
                Prompt = query,
                Model = OpenAI_API.Models.Model.DefaultModel,
                MaxTokens = 2000
            };

            var completions = await openAi.Completions.CreateCompletionAsync(completionRequest);

            foreach (var completer in completions.Completions)
            {

                outPutResult += completer.Text;
            }

            return outPutResult;
        }
    }
}
