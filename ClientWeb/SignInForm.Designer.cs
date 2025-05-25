using System.Windows.Forms;
using System.Windows.Forms.PropertyGridInternal;

namespace ClientWeb
{
	partial class SignInForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignInForm));
			SingInButton = new Button();
			EmailTextBox = new TextBox();
			PasswordTextBox = new TextBox();
			EmailLabel = new Label();
			PasswordLabel = new Label();
			SingUpButton = new Button();
			PasswordIcon = new PictureBox();
			((System.ComponentModel.ISupportInitialize)PasswordIcon).BeginInit();
			SuspendLayout();
			// 
			// SingInButton
			// 
			SingInButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			SingInButton.Location = new Point(296, 540);
			SingInButton.Name = "SingInButton";
			SingInButton.Size = new Size(250, 60);
			SingInButton.TabIndex = 3;
			SingInButton.Text = "Sign In";
			SingInButton.UseVisualStyleBackColor = true;
			SingInButton.Click += SingInButton_Click;
			// 
			// EmailTextBox
			// 
			EmailTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			EmailTextBox.Location = new Point(472, 186);
			EmailTextBox.Multiline = true;
			EmailTextBox.Name = "EmailTextBox";
			EmailTextBox.PlaceholderText = "Enter your email";
			EmailTextBox.Size = new Size(350, 34);
			EmailTextBox.TabIndex = 1;
			// 
			// PasswordTextBox
			// 
			PasswordTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			PasswordTextBox.Location = new Point(472, 310);
			PasswordTextBox.Name = "PasswordTextBox";
			PasswordTextBox.PasswordChar = '*';
			PasswordTextBox.PlaceholderText = "Enter your password";
			PasswordTextBox.Size = new Size(350, 32);
			PasswordTextBox.TabIndex = 2;
			// 
			// EmailLabel
			// 
			EmailLabel.AutoSize = true;
			EmailLabel.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
			EmailLabel.Location = new Point(296, 185);
			EmailLabel.Name = "EmailLabel";
			EmailLabel.Size = new Size(75, 35);
			EmailLabel.TabIndex = 3;
			EmailLabel.Text = "Email";
			// 
			// PasswordLabel
			// 
			PasswordLabel.AutoSize = true;
			PasswordLabel.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
			PasswordLabel.Location = new Point(296, 309);
			PasswordLabel.Name = "PasswordLabel";
			PasswordLabel.Size = new Size(120, 35);
			PasswordLabel.TabIndex = 4;
			PasswordLabel.Text = "Password";
			// 
			// SingUpButton
			// 
			SingUpButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			SingUpButton.Location = new Point(572, 540);
			SingUpButton.Name = "SingUpButton";
			SingUpButton.Size = new Size(250, 60);
			SingUpButton.TabIndex = 4;
			SingUpButton.Text = "Sign up";
			SingUpButton.UseVisualStyleBackColor = true;
			SingUpButton.Click += Sing_up_Click;
			// 
			// PasswordIcon
			// 
			PasswordIcon.Image = (Image)resources.GetObject("PasswordIcon.Image");
			PasswordIcon.Location = new Point(859, 309);
			PasswordIcon.Name = "PasswordIcon";
			PasswordIcon.Size = new Size(34, 34);
			PasswordIcon.SizeMode = PictureBoxSizeMode.StretchImage;
			PasswordIcon.TabIndex = 5;
			PasswordIcon.TabStop = false;
			PasswordIcon.Click += PasswordIcon_Click;
			// 
			// SignInForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.InactiveBorder;
			ClientSize = new Size(1082, 653);
			Controls.Add(PasswordIcon);
			Controls.Add(SingUpButton);
			Controls.Add(PasswordLabel);
			Controls.Add(EmailLabel);
			Controls.Add(PasswordTextBox);
			Controls.Add(EmailTextBox);
			Controls.Add(SingInButton);
			Name = "SignInForm";
			ShowIcon = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "SingIn";
			((System.ComponentModel.ISupportInitialize)PasswordIcon).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button SingInButton;
		private TextBox EmailTextBox;
		private TextBox PasswordTextBox;
		private Label EmailLabel;
		private Label PasswordLabel;
		private Button SingUpButton;
		private PictureBox PasswordIcon;
	}
}
