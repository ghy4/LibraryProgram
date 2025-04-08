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
			SingInButton = new Button();
			EmailTextBox = new TextBox();
			PasswordTextBox = new TextBox();
			EmailLabel = new Label();
			PasswordLabel = new Label();
			SingUpButton = new Button();
			SuspendLayout();
			// 
			// SingInButton
			// 
			SingInButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			SingInButton.Location = new Point(296, 540);
			SingInButton.Name = "SingInButton";
			SingInButton.Size = new Size(250, 60);
			SingInButton.TabIndex = 0;
			SingInButton.Text = "Sing In";
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
			PasswordTextBox.Multiline = true;
			PasswordTextBox.Name = "PasswordTextBox";
			PasswordTextBox.PlaceholderText = "Enter your password";
			PasswordTextBox.Size = new Size(350, 34);
			PasswordTextBox.TabIndex = 2;
			PasswordTextBox.UseSystemPasswordChar = true;
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
			SingUpButton.TabIndex = 5;
			SingUpButton.Text = "Sing up";
			SingUpButton.UseVisualStyleBackColor = true;
			SingUpButton.Click += Sing_up_Click;
			// 
			// SingInForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.InactiveBorder;
			ClientSize = new Size(1082, 653);
			Controls.Add(SingUpButton);
			Controls.Add(PasswordLabel);
			Controls.Add(EmailLabel);
			Controls.Add(PasswordTextBox);
			Controls.Add(EmailTextBox);
			Controls.Add(SingInButton);
			Name = "SingInForm";
			ShowIcon = false;
			Text = "SingIn";
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
	}
}
