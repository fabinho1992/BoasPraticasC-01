using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console;

// cria instância de HttpClient para consumir API Adopet
HttpClient client = ConfiguraHttpClient("http://localhost:5057");
Console.ForegroundColor = ConsoleColor.Green;
try
{
    // args[0] é o comando a ser executado pelo programa
    string comando = args[0].Trim();

	switch (comando)
    {
        case "import":
            var import = new import();
            import.ImportacaoArquivoPetAsync(caminhoArquivoImportado: args[1]);

            break;
        case "help":
            var help = new Help();
            if (args.Length == 2)
            {
                help.HelpDoComando(comando: args[1]);
            }
            else
            {
                help.HelpProjeto();
            }
                
            break;
        case "show":
            var show = new Show();
            show.MostrarArquivo(caminhoDoArquivo: args[1]);
            break;
        case "list":
            var lista = new Listar();
            await lista.ListaAsync();
            break;
        default:
            // exibe mensagem de comando inválido
            Console.WriteLine("Comando inválido!");
            break;
    }
}
catch (Exception ex)
{
    // mostra a exceção em vermelho
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}

HttpClient ConfiguraHttpClient(string url)
{
    HttpClient _client = new HttpClient();
    _client.DefaultRequestHeaders.Accept.Clear();
    _client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
    _client.BaseAddress = new Uri(url);
    return _client;
}

//Task<HttpResponseMessage> CreatePetAsync(Pet pet)
//{
//    HttpResponseMessage? response = null;
//    using (response = new HttpResponseMessage())
//    {
//        return client.PostAsJsonAsync("pet/add", pet);
//    }
//}

//async Task<IEnumerable<Pet>?> ListPetsAsync()
//{
//    HttpResponseMessage response = await client.GetAsync("pet/list");
//    return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
//}