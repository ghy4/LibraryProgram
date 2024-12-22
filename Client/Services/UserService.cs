using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks; 

namespace Client.Services
{
	public  class UserService : IUserService
	{
		private readonly HttpClient _httpClient;
		private readonly string _baseUrl;

		public UserService(string baseUrl, HttpClient httpClient)
		{
			_baseUrl = baseUrl + "/api/User";
			_httpClient = httpClient;
		}
		public async Task<IEnumerable<UserDTO>>
	}
}
