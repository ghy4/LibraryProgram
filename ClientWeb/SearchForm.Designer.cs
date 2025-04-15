namespace ClientWeb
{
	partial class SearchForm
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
			TitleLabel = new Label();
			TitleTextBox = new TextBox();
			IdLabel = new Label();
			IdTextBox = new TextBox();
			NameSearchButton = new Button();
			IdSearchButton = new Button();
			SuspendLayout();
			// 
			// TitleLabel
			// 
			TitleLabel.AutoSize = true;
			TitleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			TitleLabel.Location = new Point(22, 20);
			TitleLabel.Name = "TitleLabel";
			TitleLabel.Size = new Size(53, 28);
			TitleLabel.TabIndex = 0;
			TitleLabel.Text = "Title:";
			// 
			// TitleTextBox
			// 
			TitleTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			TitleTextBox.Location = new Point(110, 20);
			TitleTextBox.Name = "TitleTextBox";
			TitleTextBox.PlaceholderText = "Enter a title";
			TitleTextBox.Size = new Size(436, 34);
			TitleTextBox.TabIndex = 1;
			// 
			// IdLabel
			// 
			IdLabel.AutoSize = true;
			IdLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			IdLabel.Location = new Point(22, 82);
			IdLabel.Name = "IdLabel";
			IdLabel.Size = new Size(33, 28);
			IdLabel.TabIndex = 2;
			IdLabel.Text = "Id:";
			// 
			// IdTextBox
			// 
			IdTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			IdTextBox.Location = new Point(110, 82);
			IdTextBox.Name = "IdTextBox";
			IdTextBox.PlaceholderText = "Enter a Id";
			IdTextBox.Size = new Size(436, 34);
			IdTextBox.TabIndex = 3;
			// 
			// NameSearchButton
			// 
			NameSearchButton.Location = new Point(618, 20);
			NameSearchButton.Name = "NameSearchButton";
			NameSearchButton.Size = new Size(125, 34);
			NameSearchButton.TabIndex = 4;
			NameSearchButton.Text = "Search ";
			NameSearchButton.UseVisualStyleBackColor = true;
			NameSearchButton.Click += TitleSearchButton_Click;
			// 
			// IdSearchButton
			// 
			IdSearchButton.Location = new Point(618, 81);
			IdSearchButton.Name = "IdSearchButton";
			IdSearchButton.Size = new Size(125, 35);
			IdSearchButton.TabIndex = 5;
			IdSearchButton.Text = "Search";
			IdSearchButton.UseVisualStyleBackColor = true;
			IdSearchButton.Click += IdSearchButton_Click;
			// 
			// SearchForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(767, 137);
			Controls.Add(IdSearchButton);
			Controls.Add(NameSearchButton);
			Controls.Add(IdTextBox);
			Controls.Add(IdLabel);
			Controls.Add(TitleTextBox);
			Controls.Add(TitleLabel);
			Name = "SearchForm";
			Text = "SearchForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label TitleLabel;
		private TextBox TitleTextBox;
		private Label IdLabel;
		private TextBox IdTextBox;
		private Button NameSearchButton;
		private Button IdSearchButton;
	}
}