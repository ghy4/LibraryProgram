using ClientWeb.Services;
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
		private readonly LibraryHttpClientService _libraryService;
		private readonly UserHttpClientService _userService;
		private readonly int _userId;

		private List<LibraryDTO> _libraries;
		public MainPage(LibraryHttpClientService libraryService, UserHttpClientService userService, int userId)
		{
			InitializeComponent();
			_libraryService = libraryService;
			_userService = userService;
			_userId = userId;
		}
		private async void MainPage_Load(object sender, EventArgs e)
		{
			LoadPage();
		}

		private async void LoadPage()
		{
			_libraries = await LoadLibraries();
			LibraryMenuComboBox.Items.Clear();
			foreach (var item in _libraries)
				LibraryMenuComboBox.Items.Add(item.Name);

			if (LibraryMenuComboBox.Items.Count > 0)
				LibraryMenuComboBox.SelectedIndex = 0;
		}

		private async Task<List<LibraryDTO>> LoadLibraries()
		{
			try
			{
				return await _libraryService.GetLibrariesAsync();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
			return null;
		}

		private async void ReviewClose(object sender, FormClosedEventArgs e)
		{
			try
			{
				_libraries = await LoadLibraries();
				LibraryMenuComboBox_SelectedIndexChanged(LibraryMenuComboBox, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}");
			}
		}

		private async void LibraryMenuComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_libraries == null || LibraryMenuComboBox.SelectedIndex < 0) return;

			var selectedLibrary = _libraries[LibraryMenuComboBox.SelectedIndex];

			int y = 10;
			MainPagePanel.Controls.Clear();

			foreach (var item in selectedLibrary.Books)
			{
				Panel bookPanel = new Panel
				{
					Width = MainPagePanel.Width - 30, 
					Height = 175,
					Location = new Point(10, y),
					BorderStyle = BorderStyle.FixedSingle,
					BackColor = Color.WhiteSmoke,
					Tag = item 
				};

				Label titleLabel = new Label
				{
					Text = $"Title: {item.Title}",
					Font = new Font("Segoe UI", 11, FontStyle.Bold),
					Location = new Point(10, 10),
					AutoSize = true
				};
				bookPanel.Controls.Add(titleLabel);

				Label authorLabel = new Label
				{
					Text = $"Author: {item.Author}",
					Font = new Font("Segoe UI", 10, FontStyle.Regular),
					Location = new Point(10, 35),
					AutoSize = true
				};
				bookPanel.Controls.Add(authorLabel);

				Label descLabel = new Label
				{
					Text = $"Description: {item.Description}",
					Font = new Font("Segoe UI", 9, FontStyle.Italic),
					Location = new Point(10, 60),
					Size = new Size(bookPanel.Width - 150, 70),
					AutoEllipsis = true
				};
				bookPanel.Controls.Add(descLabel);

				Label ratLabel = new Label
				{
					Text = $"Rating: {item.Rating?.ToString("0.0") ?? "N/A"}",
					Font = new Font("Segoe UI", 9, FontStyle.Italic),
					Location = new Point(20, 135),
					AutoSize = true,
					AutoEllipsis = true
				};
				bookPanel.Controls.Add(ratLabel);

				int buttonWidth = 80;
				int buttonHeight = 30;
				int buttonsStartX = bookPanel.Width - (buttonWidth + 10);

				Button reviewBtn = new Button
				{
					Text = "Review",
					Size = new Size(buttonWidth, buttonHeight),
					Location = new Point(buttonsStartX, 50),
				};
				reviewBtn.Click += (s, e) =>
				{
					ReviewForm form = new ReviewForm(_userService, _userId, item.Id);
					form.FormClosed += ReviewClose;
					form.Show();
				};
				bookPanel.Controls.Add(reviewBtn);

				MainPagePanel.Controls.Add(bookPanel);

				y += bookPanel.Height + 10;
			}
		}

		private void SearchMenuItem_Click(object sender, EventArgs e)
		{
			SearchForm form = new SearchForm(_libraryService, LibraryMenuComboBox.SelectedIndex);
			form.Show();
		}
	}
}
