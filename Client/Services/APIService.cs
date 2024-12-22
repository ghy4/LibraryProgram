using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
	public class APIService
	{
		private readonly HttpClient _httpclient;
		public APIService(string baseUrl)
		{
			_httpclient = new HttpClient()
			{
				BaseAddress = new Uri(baseUrl)
			};
		}
		public async Task<T> GetAllAsync<T>()
		{
			var response = await _httpclient.GetAsync(_httpclient.BaseAddress);
			response.EnsureSuccessStatusCode();
			var content = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(content);
		}
		
	}
}
