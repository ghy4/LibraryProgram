using Data.Services;
using Server.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientWeb.Services
{
	public class UserHttpClientService
	{
		private readonly HttpClient _httpClient;

		public UserHttpClientService(HttpClient client)
		{
			_httpClient = client;
		}

		public async Task<List<UserDTO>> GetUsersAsync()
		{
			var response = await _httpClient.GetAsync("/api/User/Users");
			response.EnsureSuccessStatusCode();
			var stream = await response.Content.ReadAsStreamAsync();
			var users = await JsonSerializer.DeserializeAsync<List<UserDTO>>(stream, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});
			return users;
		}

		public async Task<UserDTO?> GetUserByIdAsync(int id)
		{
			var response = await _httpClient.GetAsync($"/api/User/{id}");
			if (!response.IsSuccessStatusCode)
				return null;

			return await response.Content.ReadFromJsonAsync<UserDTO>();
		}

		public async Task<bool> UpdateUserAsync(UserDTO user)
		{
			var response = await _httpClient.PutAsJsonAsync($"/api/User/{user.Id}", user);
			return response.IsSuccessStatusCode;
		}

		public async Task DeleteUserAsync(int id)
		{
			var response = await _httpClient.DeleteAsync($"/api/User/{id}");
			response.EnsureSuccessStatusCode();
		}

		public async Task<bool> CreateUserAsync(CreateUserDTO user)
		{
			user.Password = Encryptor.CreateMD5(user.Password);
			var response = await _httpClient.PostAsJsonAsync("/api/User", user);
			return response.IsSuccessStatusCode;
		}
		public async Task<UserDTO?> GetUserByEmailAsync(string email)
		{
			var response = await _httpClient.GetAsync($"/api/User/email?email={Uri.EscapeDataString(email)}");
			if (!response.IsSuccessStatusCode)
				return null;

			return await response.Content.ReadFromJsonAsync<UserDTO>();
		}

		public async Task<bool> AddReviewAsync(int userId, int bookId, decimal rating, string reviewText)
		{
			var reviewDto = new CreateReviewDTO
			{
				UserId = userId,
				BookId = bookId,
				Rating = rating,
				ReviewText = reviewText
			};

			var response = await _httpClient.PostAsJsonAsync($"/api/User/{userId}/review", reviewDto);

			return response.IsSuccessStatusCode;
		}

		public void SetBearerToken(string token)
		{
			_httpClient.DefaultRequestHeaders.Authorization =
				new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
		}

		public async Task<RegisterResponse?> RegisterAsync(RegisterRequest request)
		{
			var response = await _httpClient.PostAsJsonAsync("/api/User/register", request);

			if (response.IsSuccessStatusCode)
			{
				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
				var result = await response.Content.ReadFromJsonAsync<RegisterResponse>(options);
				return result;
			}

			return null;
		}

		public async Task<LoginResponse?> Login(string email, string password)
		{
			var request = new { Email = email, Password = password };
			var json = JsonSerializer.Serialize(request);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await _httpClient.PostAsync("/api/User/login", content);

			if (!response.IsSuccessStatusCode)
				return null;

			var responseBody = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<LoginResponse>(responseBody, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});
		}

		public class LoginRequest
		{
			public string Email { get; set; }
			public string Password { get; set; }
		}

		public class RegisterRequest
		{
			public string Name { get; set; }
			public string Surname { get; set; }
			public string Email { get; set; }
			public string Password { get; set; }
			public string ContactNumber { get; set; }
			public string Role { get; set; } = "User";
		}

		public class UserLoginResponse
		{
			public string Token { get; set; }
			public UserDTO User { get; set; }
		}
	}
}
