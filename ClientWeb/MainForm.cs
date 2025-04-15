using Microsoft.CodeAnalysis.CSharp;
using Server.DTOModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWeb
{
	public partial class MainPage : Form
	{
		private HttpClient _httpClient;
		public MainPage()
		{
			InitializeComponent();
			_httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7221") };
		}
		private async void MainPage_Load(object sender, EventArgs e)
		{
			try
			{
				var response = await _httpClient.GetAsync("/api/Library/Libraries");
				response.EnsureSuccessStatusCode();


				var content = await response.Content.ReadAsStreamAsync();
				var libraries = await JsonSerializer.DeserializeAsync<List<LibraryDTO>>(content, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});

				foreach (var item in libraries)
					LibraryMenuComboBox.Items.Add(item);
				LibraryMenuComboBox.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private async void LibraryMenuComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var response = await _httpClient.GetAsync("/api/Library/Libraries");
			response.EnsureSuccessStatusCode();


			var content = await response.Content.ReadAsStreamAsync();
			var libraries = await JsonSerializer.DeserializeAsync<List<LibraryDTO>>(content, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});
			int y = 10;
			MainPagePanel.Controls.Clear();
			foreach (var item in libraries[LibraryMenuComboBox.SelectedIndex].Books)
			{
				Label label = new Label();
				label.Text = $"Title: {item.Title}";
				label.Font = new Font("Segoe UI", 11, FontStyle.Regular);
				label.AutoSize = true;
				label.Location = new Point(10, y);
				y += label.Height + 10;
				Label label1 = new Label();
				label1.Text = $"Author: {item.Author}";
				label1.Font = new Font("Segoe UI", 11, FontStyle.Regular);
				label1.AutoSize = true;
				label1.Location = new Point(10, y);
				y += label.Height + 10;
				Label label2 = new Label();
				label2.Text = $"Description: {item.Description}";
				label2.Font = new Font("Segoe UI", 11, FontStyle.Regular);
				label2.AutoSize = true;
				label2.Location = new Point(10, y);
				y += label.Height + 10;

				MainPagePanel.Controls.Add(label);
				MainPagePanel.Controls.Add(label1);
				MainPagePanel.Controls.Add(label2);
				y += label.Height + 10;
			}
		}

		private void SearchMenuItem_Click(object sender, EventArgs e)
		{
			SearchForm form = new SearchForm(LibraryMenuComboBox.SelectedIndex);
			form.Show();
		}
	}
}
