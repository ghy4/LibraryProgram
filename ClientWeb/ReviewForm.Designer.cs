namespace ClientWeb
{
	partial class ReviewForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			SaveButton = new Button();
			ReviewTextBox = new TextBox();
			Rating1RadioButton = new RadioButton();
			Rating2RadioButton = new RadioButton();
			Rating3RadioButton = new RadioButton();
			Rating4RadioButton = new RadioButton();
			Rating5RadioButton = new RadioButton();
			SuspendLayout();
			// 
			// SaveButton
			// 
			SaveButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			SaveButton.Location = new Point(659, 255);
			SaveButton.Name = "SaveButton";
			SaveButton.Size = new Size(129, 35);
			SaveButton.TabIndex = 0;
			SaveButton.Text = "Save";
			SaveButton.UseVisualStyleBackColor = true;
			SaveButton.Click += SaveButton_Click;
			// 
			// ReviewTextBox
			// 
			ReviewTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			ReviewTextBox.Location = new Point(32, 59);
			ReviewTextBox.Multiline = true;
			ReviewTextBox.Name = "ReviewTextBox";
			ReviewTextBox.Size = new Size(739, 174);
			ReviewTextBox.TabIndex = 1;
			// 
			// Rating1RadioButton
			// 
			Rating1RadioButton.AutoSize = true;
			Rating1RadioButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			Rating1RadioButton.Location = new Point(41, 24);
			Rating1RadioButton.Name = "Rating1RadioButton";
			Rating1RadioButton.Size = new Size(43, 29);
			Rating1RadioButton.TabIndex = 2;
			Rating1RadioButton.TabStop = true;
			Rating1RadioButton.Text = "1";
			Rating1RadioButton.UseVisualStyleBackColor = true;
			// 
			// Rating2RadioButton
			// 
			Rating2RadioButton.AutoSize = true;
			Rating2RadioButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			Rating2RadioButton.Location = new Point(108, 24);
			Rating2RadioButton.Name = "Rating2RadioButton";
			Rating2RadioButton.Size = new Size(43, 29);
			Rating2RadioButton.TabIndex = 3;
			Rating2RadioButton.TabStop = true;
			Rating2RadioButton.Text = "2";
			Rating2RadioButton.UseVisualStyleBackColor = true;
			// 
			// Rating3RadioButton
			// 
			Rating3RadioButton.AutoSize = true;
			Rating3RadioButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			Rating3RadioButton.Location = new Point(184, 24);
			Rating3RadioButton.Name = "Rating3RadioButton";
			Rating3RadioButton.Size = new Size(43, 29);
			Rating3RadioButton.TabIndex = 4;
			Rating3RadioButton.TabStop = true;
			Rating3RadioButton.Text = "3";
			Rating3RadioButton.UseVisualStyleBackColor = true;
			// 
			// Rating4RadioButton
			// 
			Rating4RadioButton.AutoSize = true;
			Rating4RadioButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			Rating4RadioButton.Location = new Point(257, 24);
			Rating4RadioButton.Name = "Rating4RadioButton";
			Rating4RadioButton.Size = new Size(43, 29);
			Rating4RadioButton.TabIndex = 5;
			Rating4RadioButton.TabStop = true;
			Rating4RadioButton.Text = "4";
			Rating4RadioButton.UseVisualStyleBackColor = true;
			// 
			// Rating5RadioButton
			// 
			Rating5RadioButton.AutoSize = true;
			Rating5RadioButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			Rating5RadioButton.Location = new Point(332, 24);
			Rating5RadioButton.Name = "Rating5RadioButton";
			Rating5RadioButton.Size = new Size(43, 29);
			Rating5RadioButton.TabIndex = 6;
			Rating5RadioButton.TabStop = true;
			Rating5RadioButton.Text = "5";
			Rating5RadioButton.UseVisualStyleBackColor = true;
			// 
			// ReviewForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 302);
			Controls.Add(Rating5RadioButton);
			Controls.Add(Rating4RadioButton);
			Controls.Add(Rating3RadioButton);
			Controls.Add(Rating2RadioButton);
			Controls.Add(Rating1RadioButton);
			Controls.Add(ReviewTextBox);
			Controls.Add(SaveButton);
			Name = "ReviewForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "ReviewForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button SaveButton;
		private TextBox ReviewTextBox;
		private RadioButton Rating1RadioButton;
		private RadioButton Rating2RadioButton;
		private RadioButton Rating3RadioButton;
		private RadioButton Rating4RadioButton;
		private RadioButton Rating5RadioButton;
	}
}