using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client.Views
{
	/// <summary>
	/// Логика взаимодействия для LoginView.xaml
	/// </summary>
	public partial class LoginView : Window
	{
		public LoginView()
		{
			InitializeComponent();
		}

		private void LoginBtn_Click(object sender, RoutedEventArgs e)
		{
			if(EmailTextBox.Text.Length == 0)
			{
				errormessage.Text = "Enter a valid email";
				EmailTextBox.Focus();
			}
			else if(!Regex.IsMatch(EmailTextBox.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
			{
				errormessage.Text = "Enter a valid email";
				EmailTextBox.Select(0, EmailTextBox.Text.Length);
				EmailTextBox.Focus();
			}
			else
			{
				
			}
		}
		private void SignUp_Click(object sender, RoutedEventArgs e)
		{
			
			(new RegistrationView()).Show();
			this.Close();
		}
	}
}
