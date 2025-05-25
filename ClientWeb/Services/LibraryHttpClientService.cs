using Server.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientWeb.Services
{
	public class LibraryHttpClientService
	{
		private readonly HttpClient _httpClient;

		public LibraryHttpClientService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<LibraryDTO>> GetLibrariesAsync()
		{
			var response = await _httpClient.GetAsync("/api/Library/Libraries");
			response.EnsureSuccessStatusCode();

			var stream = await response.Content.ReadAsStreamAsync();
			var libraries = await JsonSerializer.DeserializeAsync<List<LibraryDTO>>(stream, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});
			return libraries;
		}
		public async Task<LibraryDTO> GetLibraryByIdAsync(int id)
		{
			var response = await _httpClient.GetAsync($"/api/Library/{id}");
			response.EnsureSuccessStatusCode();

			var stream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<LibraryDTO>(stream, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});
		}

		public async Task<bool> AddBookToLibraryAsync(int libraryId, int bookId)
		{
			var dto = new
			{
				LibraryId = libraryId,
				BookId = bookId
			};
			var json = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

			var response = await _httpClient.PostAsync("/api/Library/add-book", json);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> CreateLibraryAsync(CreateLibraryDTO dto)
		{
			var json = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

			var response = await _httpClient.PostAsync("/api/Library", json);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> UpdateLibraryAsync(UpdateLibraryDTO dto)
		{
			var json = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

			var response = await _httpClient.PutAsync($"/api/Library/{dto.Id}", json);
			return response.IsSuccessStatusCode;
		}

		public async Task DeleteLibraryAsync(int id)
		{
			var response = await _httpClient.DeleteAsync($"/api/Library/{id}");
			response.EnsureSuccessStatusCode();
		}
	}
}
