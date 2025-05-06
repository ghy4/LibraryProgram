using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Server.DTOModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWeb
{
	public partial class AdminPanel : Form
	{
		private readonly HttpClient _httpClient;
		private string _currentEntityType = "Library";
		private List<UserDTO> _users = new List<UserDTO>();
		public AdminPanel()
		{
			InitializeComponent();
			_httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7221") };
		}

		private async void AdminPanel_LoadAsync(object sender, EventArgs e)
		{
			try
			{
				AdminRadioButton.Visible = false;
				UserRadioButton.Visible = false;
				AllRadioButton.Visible = false;
				var response = await _httpClient.GetAsync("/api/Library/Libraries");
				response.EnsureSuccessStatusCode();


				var content = await response.Content.ReadAsStreamAsync();
				var libraries = await JsonSerializer.DeserializeAsync<List<LibraryDTO>>(content, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});
				var data = libraries.Select(lib => new
				{
					lib.Id,
					lib.Name,
					lib.Address,
					lib.ContactNumber,
					Bookslist = string.Join(", ", lib.Books.Select(b => b.Title))
				});

				dataGridView1.DataSource = data.ToList();

				if (dataGridView1.Columns.Contains("Select"))
				{
					dataGridView1.Columns.Remove("Select");
				}
				DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
				{
					Name = "Select",
					HeaderText = "Select",
					FalseValue = false,
					TrueValue = true
				};
				dataGridView1.Columns.Insert(dataGridView1.Columns.Count, checkBoxColumn);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private async void BooksMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				AdminRadioButton.Visible = false;
				UserRadioButton.Visible = false;
				AllRadioButton.Visible = false;
				_currentEntityType = "Book";
				var response = await _httpClient.GetAsync("/api/Book/Books");
				response.EnsureSuccessStatusCode();


				var content = await response.Content.ReadAsStreamAsync();
				var books = await JsonSerializer.DeserializeAsync<List<BookDTO>>(content, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});
				var data = books.Select(b => new
				{
					b.Id,
					b.Title,
					b.Author,
					b.Description,
					b.DateOfPublication,
					b.Rating,
					Libraries = string.Join(", ", b.Libraries.Select(l => l.Name))
				});
				dataGridView1.DataSource = data.ToList();

				if (dataGridView1.Columns.Contains("Select"))
				{
					dataGridView1.Columns.Remove("Select");
				}
				DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
				{
					Name = "Select",
					HeaderText = "Select",
					FalseValue = false,
					TrueValue = true
				};
				dataGridView1.Columns.Insert(dataGridView1.Columns.Count, checkBoxColumn);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private async void UsersMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				AdminRadioButton.Visible = true;
				UserRadioButton.Visible = true;
				AllRadioButton.Visible = true;
				_currentEntityType = "User";
				var response = await _httpClient.GetAsync("/api/User/Users");
				response.EnsureSuccessStatusCode();


				var content = await response.Content.ReadAsStreamAsync();
				_users = await JsonSerializer.DeserializeAsync<List<UserDTO>>(content, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});


				dataGridView1.DataSource = _users;

				if (dataGridView1.Columns.Contains("Select"))
				{
					dataGridView1.Columns.Remove("Select");
				}
				DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
				{
					Name = "Select",
					HeaderText = "Select",
					FalseValue = false,
					TrueValue = true
				};
				dataGridView1.Columns.Insert(dataGridView1.Columns.Count, checkBoxColumn);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private async void LibrariesMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				AdminRadioButton.Visible = false;
				UserRadioButton.Visible = false;
				AllRadioButton.Visible = false;
				_currentEntityType = "Library";
				var response = await _httpClient.GetAsync("/api/Library/Libraries");
				response.EnsureSuccessStatusCode();


				var content = await response.Content.ReadAsStreamAsync();
				var libraries = await JsonSerializer.DeserializeAsync<List<LibraryDTO>>(content, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});
				var data = libraries.Select(lib => new
				{
					lib.Id,
					lib.Name,
					lib.Address,
					lib.ContactNumber,
					Bookslist = string.Join(", ", lib.Books.Select(b => b.Title))
				});

				dataGridView1.DataSource = data.ToList();

				if (dataGridView1.Columns.Contains("Select"))
				{
					dataGridView1.Columns.Remove("Select");
				}
				DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
				{
					Name = "Select",
					HeaderText = "Select",
					FalseValue = false,
					TrueValue = true
				};
				dataGridView1.Columns.Insert(dataGridView1.Columns.Count, checkBoxColumn);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private void CreateButton_Click(object sender, EventArgs e)
		{

		}

		private void EditButton_Click(object sender, EventArgs e)
		{

		}

		private async void DeleteButton_Click(object sender, EventArgs e)
		{
			List<Task> deleteTasks = new List<Task>();
			try
			{
				foreach (var item in dataGridView1.Columns)
				{
					if (item is DataGridViewCheckBoxColumn checkBoxColumn)
					{
						foreach (DataGridViewRow row in dataGridView1.Rows)
						{
							if (Convert.ToBoolean(row.Cells[checkBoxColumn.Index].Value) == true)
							{
								int id = Convert.ToInt32(row.Cells["Id"].Value);

								// Add the delete task to the list
								deleteTasks.Add(DeleteEntityAsync(_currentEntityType, id));
							}
						}
					}
				}
				await Task.WhenAll(deleteTasks);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}
		private async Task DeleteEntityAsync(string entityType, int id)
		{
			string endpoint = entityType switch
			{
				"Library" => $"/api/Library/{id}",
				"User" => $"/api/User/{id}",
				"Book" => $"/api/Book/{id}",
				_ => throw new ArgumentException("Invalid entity type")
			};

			var response = await _httpClient.DeleteAsync(endpoint);
			response.EnsureSuccessStatusCode();
		}

		private void RadioButton_CheckedChanged(object sender, EventArgs e)
		{
			ShowFilteredUsers();
		}
		private void ShowFilteredUsers()
		{
			IEnumerable<UserDTO> filtered = _users;

			if (AdminRadioButton.Checked)
				filtered = _users.Where(u => u.Role == "Admin");
			else if (UserRadioButton.Checked)
				filtered = _users.Where(u => u.Role == "User");

			dataGridView1.DataSource = filtered
				.Select(u => new { u.Id, u.Name, u.Email, u.Role })
				.ToList();
		}
	}
}
