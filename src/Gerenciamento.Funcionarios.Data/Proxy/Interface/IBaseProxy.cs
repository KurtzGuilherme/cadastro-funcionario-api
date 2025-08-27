namespace Gerenciamento.Funcionarios.Data.Proxy.Interface;
public interface IBaseProxy
{
    Task<TGet> GetAsync<TGet>(string url);
    Task<TReturn> PostAsync<TReturn>(string url, object body);
    Task PostAsync(string url, object body);
    Task PutAsync(string url, object body);
    Task<TReturn> PutAsync<TReturn>(string url);
    Task<TReturn> PutAsync<TReturn>(string url, object body);
    Task DeleteAsync(string url, object body);
}
