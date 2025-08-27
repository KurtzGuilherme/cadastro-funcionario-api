using Gerenciamento.Funcionarios.Data.Proxy.Interface;
using Gerenciamento.Funcionarios.Data.Proxy.Models;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Gerenciamento.Funcionarios.Data.Proxy;
public class AutenticacaoProxy : IAutenticacaoProxy
{
    private readonly IConfiguration _configuration;
    private AutenticacaoToken _token;

    private JsonSerializerOptions JsonSerializerOptions
    {
        get
        {
            return new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };
        }
    }

    public AutenticacaoProxy(IConfiguration configuration)
    {
        _token = new AutenticacaoToken();
        _configuration = configuration;
    }

    public async Task<string> GetToken()
    {
        if (TokenExpirado())
            return await GetNewToken();

        return _token.TokenAcesso;
    }

    public bool TokenExpirado()
        => _token.DataExpiracao < DateTime.Now;


    private async Task<string> GetNewToken()
    {
        var _userName = _configuration.GetValue<string>("Terra.Authentication:UserName").Trim();
        var _password = _configuration.GetValue<string>("Terra.Authentication:Password").Trim();
        var _urlToken = $"{_configuration.GetValue<string>("Terra.Authentication:BaseUrl").Trim()}/api/gettoken";

        var requestData = new Dictionary<string, string>();
        requestData.Add("grant_type", "password");
        requestData.Add("username", _userName);
        requestData.Add("password", _password);

        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, _urlToken) { Content = new FormUrlEncodedContent(requestData) };
        var response = await client.SendAsync(request);

        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"AutenticacaoServicoProxy - ERROR on request: {request.Method} - {request.RequestUri} \n  Status: {response.StatusCode} Response: {responseContent}");
        }

        try
        {
            _token = JsonSerializer.Deserialize<AutenticacaoToken>(responseContent, JsonSerializerOptions)!;
            _token.DataExpiracao = DateTime.Now.AddSeconds(_token.ExpiraEm);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return _token.TokenAcesso;
    }

}
