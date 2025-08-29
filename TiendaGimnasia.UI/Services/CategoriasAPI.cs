using System.Net.Http.Json;
using TiendaGimnasia.UI.Models;

namespace TiendaGimnasia.UI.Services
{
    public class CategoriasAPI
    {
        private readonly IHttpClientFactory _factory;
        private const string BasePath = "api/Categorias"; 

        public CategoriasAPI(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        private HttpClient GetClient() => _factory.CreateClient("ApiClient");

        public async Task<List<CategoriaDTO>> GetAllAsync(CancellationToken ct = default)
        {
            try
            {
                var client = GetClient();
                var list = await client.GetFromJsonAsync<List<CategoriaDTO>>(BasePath, ct);
                return list ?? new List<CategoriaDTO>();
            }
            catch
            {
                // log opcional
                return new List<CategoriaDTO>();
            }
        }

        public async Task<CategoriaDTO?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            try
            {
                var client = GetClient();
                return await client.GetFromJsonAsync<CategoriaDTO>($"{BasePath}/{id}", ct);
            }
            catch
            {
                return null;
            }
        }

        public async Task<CategoriaDTO?> CreateAsync(CategoriaDTO nueva, CancellationToken ct = default)
        {
            try
            {
                var client = GetClient();
                var resp = await client.PostAsJsonAsync(BasePath, nueva, ct);
                if (!resp.IsSuccessStatusCode) return null;
                return await resp.Content.ReadFromJsonAsync<CategoriaDTO>(cancellationToken: ct);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(int id, CategoriaDTO dto, CancellationToken ct = default)
        {
            try
            {
                var client = GetClient();
                var resp = await client.PutAsJsonAsync($"{BasePath}/{id}", dto, ct);
                return resp.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            try
            {
                var client = GetClient();
                var resp = await client.DeleteAsync($"{BasePath}/{id}", ct);
                return resp.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
