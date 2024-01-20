using Cadof.Shared.Models.Character;
using System.Net.Http.Json;

namespace Cadof.Web.App.Services;

public class CharacterService
{
    private readonly HttpClient _client;

    public CharacterService(HttpClient client)
    {
        _client = client;
    }

    public Task<List<CharacterModel>?> GetAll() => _client.GetFromJsonAsync<List<CharacterModel>>("Character?take=10");
}
