using Server.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientWeb.Services
{
	public class BookHttpClientService
	{
		private readonly HttpClient _httpClient;
		private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		};

		public BookHttpClientService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<BookDTO>> GetBooksAsync()
    {
        var response = await _httpClient.GetAsync("/api/Book/Books");
        response.EnsureSuccessStatusCode();
        var stream = await response.Content.ReadAsStreamAsync();
        var books = await JsonSerializer.DeserializeAsync<List<BookDTO>>(stream, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        return books;
    }

		public async Task<BookDTO> GetBookByIdAsync(int id)
		{
			var response = await _httpClient.GetAsync($"/api/Book/{id}");
			response.EnsureSuccessStatusCode();

			var stream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<BookDTO>(stream, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});
		}

		public async Task<List<ReviewDTO>> GetReviewsForBookAsync(int bookId)
		{
			var response = await _httpClient.GetAsync($"/api/Book/Reviews/{bookId}");
			response.EnsureSuccessStatusCode();

			var stream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<List<ReviewDTO>>(stream, _jsonOptions);
		}

		public async Task<bool> CreateBookAsync(CreateBookDTO book)
		{
			var json = JsonSerializer.Serialize(book);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await _httpClient.PostAsync("/api/Book", content);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> UpdateBookAsync(UpdateBookDTO book)
		{
			var json = JsonSerializer.Serialize(book);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await _httpClient.PutAsync($"/api/Book/{book.Id}", content);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> AddReviewAsync(int bookId, CreateReviewDTO review)
		{
			var json = JsonSerializer.Serialize(review);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await _httpClient.PatchAsync($"/api/Book/AddReview?bookid={bookId}", content);
			return response.IsSuccessStatusCode;
		}

		public async Task DeleteBookAsync(int id)
		{
			var response = await _httpClient.DeleteAsync($"/api/Book/{id}");
			response.EnsureSuccessStatusCode();
		}
	}
}
