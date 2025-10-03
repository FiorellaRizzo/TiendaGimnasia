
using TiendaGimnasia.Shared.DTOs;
namespace TiendaGimnasia.UI.Services
{
    public class ProductosAPI
    {
        private readonly IHttpClientFactory _factory;
        private const string BasePath = "api/Productos"; // <- coincide con el controller

        public ProductosAPI(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        private HttpClient GetClient() => _factory.CreateClient("ApiClient");

        public async Task<List<ProductoDTO>> GetAllAsync(CancellationToken ct = default)
        {
            try
            {
                var client = GetClient();
                var list = await client.GetFromJsonAsync<List<ProductoDTO>>(BasePath, ct);
                return list ?? new List<ProductoDTO>();
            }
            catch
            {
                return new List<ProductoDTO>();
            }
        }

        public async Task<ProductoDTO?> CreateAsync(ProductoCreateDTO dto, CancellationToken ct = default)
        {
            try
            {
                var client = GetClient();
                var resp = await client.PostAsJsonAsync(BasePath, dto, ct);
                if (!resp.IsSuccessStatusCode) return null;
                return await resp.Content.ReadFromJsonAsync<ProductoDTO>(cancellationToken: ct);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(int id, ProductoUpdateDTO dto, CancellationToken ct = default)
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
