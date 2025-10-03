using System.Net.Http.Json;
using TiendaGimnasia.Shared.DTOs;

namespace TiendaGimnasia.UI.Services
{
    public class UsuariosAPI
    {
        private readonly IHttpClientFactory _factory;
        private const string BasePath = "api/Usuarios";
        public UsuariosAPI(IHttpClientFactory factory) => _factory = factory;
        private HttpClient Client() => _factory.CreateClient("ApiClient");

        public async Task<List<UsuarioDTO>> GetAllAsync()
            => await Client().GetFromJsonAsync<List<UsuarioDTO>>(BasePath) ?? new();

        public async Task<UsuarioDTO?> CreateAsync(UsuarioCreateDTO dto)
        {
            var resp = await Client().PostAsJsonAsync(BasePath, dto);
            if (!resp.IsSuccessStatusCode) return null;
            return await resp.Content.ReadFromJsonAsync<UsuarioDTO>();
        }

        public async Task<bool> UpdateAsync(int id, UsuarioUpdateDTO dto)
        {
            var resp = await Client().PutAsJsonAsync($"{BasePath}/{id}", dto);
            return resp.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var resp = await Client().DeleteAsync($"{BasePath}/{id}");
            return resp.IsSuccessStatusCode;
        }
    }
}
