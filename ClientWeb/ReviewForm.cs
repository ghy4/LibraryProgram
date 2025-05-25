using ClientWeb.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWeb
{
	public partial class ReviewForm : Form
	{
		private readonly UserHttpClientService _userService;
		private readonly int _userId;
		private readonly int _bookId;
		public ReviewForm(UserHttpClientService userService, int userId, int bookId)
		{
			InitializeComponent();
			_userService = userService;
			_userId = userId;
			_bookId = bookId;
		}

		private async void SaveButton_Click(object sender, EventArgs e)
		{
			try
			{
				var rating = 0;
				if(Rating1RadioButton.Checked)
					rating = 1;
				else if (Rating2RadioButton.Checked)
					rating = 2;
				else if (Rating3RadioButton.Checked)
					rating = 3;
				else if (Rating4RadioButton.Checked)
					rating = 4;
				else if (Rating5RadioButton.Checked)
					rating = 5;
				await _userService.AddReviewAsync(_userId, _bookId, rating, ReviewTextBox.Text);
				this.Close();

			}
			catch (Exception ex)
			{
				MessageBox.Show("Failed to create review: " + ex.Message);
			}
		}
	}
}
