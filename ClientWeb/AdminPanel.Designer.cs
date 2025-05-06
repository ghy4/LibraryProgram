namespace ClientWeb
{
	partial class AdminPanel
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
			menuStrip1 = new MenuStrip();
			LibrariesMenuItem = new ToolStripMenuItem();
			BooksMenuItem = new ToolStripMenuItem();
			UsersMenuItem = new ToolStripMenuItem();
			dataGridView1 = new DataGridView();
			EditButton = new Button();
			CreateButton = new Button();
			DeleteButton = new Button();
			AdminRadioButton = new RadioButton();
			UserRadioButton = new RadioButton();
			panel1 = new Panel();
			AllRadioButton = new RadioButton();
			menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.BackColor = Color.FromArgb(64, 64, 64);
			menuStrip1.ImageScalingSize = new Size(20, 20);
			menuStrip1.Items.AddRange(new ToolStripItem[] { LibrariesMenuItem, BooksMenuItem, UsersMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(1478, 33);
			menuStrip1.TabIndex = 0;
			menuStrip1.Text = "menuStrip1";
			// 
			// LibrariesMenuItem
			// 
			LibrariesMenuItem.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			LibrariesMenuItem.ForeColor = SystemColors.ButtonFace;
			LibrariesMenuItem.Name = "LibrariesMenuItem";
			LibrariesMenuItem.Size = new Size(98, 29);
			LibrariesMenuItem.Text = "Libraries";
			LibrariesMenuItem.Click += LibrariesMenuItem_Click;
			// 
			// BooksMenuItem
			// 
			BooksMenuItem.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			BooksMenuItem.ForeColor = SystemColors.ButtonFace;
			BooksMenuItem.Name = "BooksMenuItem";
			BooksMenuItem.Size = new Size(76, 29);
			BooksMenuItem.Text = "Books";
			BooksMenuItem.Click += BooksMenuItem_Click;
			// 
			// UsersMenuItem
			// 
			UsersMenuItem.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			UsersMenuItem.ForeColor = SystemColors.ButtonHighlight;
			UsersMenuItem.Name = "UsersMenuItem";
			UsersMenuItem.Size = new Size(72, 29);
			UsersMenuItem.Text = "Users";
			UsersMenuItem.Click += UsersMenuItem_Click;
			// 
			// dataGridView1
			// 
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(12, 82);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowHeadersWidth = 51;
			dataGridView1.RowTemplate.Height = 29;
			dataGridView1.Size = new Size(1444, 837);
			dataGridView1.TabIndex = 1;
			// 
			// EditButton
			// 
			EditButton.Location = new Point(153, 40);
			EditButton.Name = "EditButton";
			EditButton.Size = new Size(122, 36);
			EditButton.TabIndex = 2;
			EditButton.Text = "Edit";
			EditButton.UseVisualStyleBackColor = true;
			EditButton.Click += EditButton_Click;
			// 
			// CreateButton
			// 
			CreateButton.Location = new Point(12, 40);
			CreateButton.Name = "CreateButton";
			CreateButton.Size = new Size(122, 36);
			CreateButton.TabIndex = 3;
			CreateButton.Text = "Create";
			CreateButton.UseVisualStyleBackColor = true;
			CreateButton.Click += CreateButton_Click;
			// 
			// DeleteButton
			// 
			DeleteButton.Location = new Point(306, 40);
			DeleteButton.Name = "DeleteButton";
			DeleteButton.Size = new Size(122, 36);
			DeleteButton.TabIndex = 4;
			DeleteButton.Text = "Delete";
			DeleteButton.UseVisualStyleBackColor = true;
			DeleteButton.Click += DeleteButton_Click;
			// 
			// AdminRadioButton
			// 
			AdminRadioButton.AutoSize = true;
			AdminRadioButton.Location = new Point(466, 44);
			AdminRadioButton.Name = "AdminRadioButton";
			AdminRadioButton.Size = new Size(88, 29);
			AdminRadioButton.TabIndex = 5;
			AdminRadioButton.TabStop = true;
			AdminRadioButton.Text = "Admin";
			AdminRadioButton.UseVisualStyleBackColor = true;
			AdminRadioButton.CheckedChanged += RadioButton_CheckedChanged;
			// 
			// UserRadioButton
			// 
			UserRadioButton.AutoSize = true;
			UserRadioButton.Location = new Point(574, 44);
			UserRadioButton.Name = "UserRadioButton";
			UserRadioButton.Size = new Size(71, 29);
			UserRadioButton.TabIndex = 6;
			UserRadioButton.TabStop = true;
			UserRadioButton.Text = "User";
			UserRadioButton.UseVisualStyleBackColor = true;
			UserRadioButton.CheckedChanged += RadioButton_CheckedChanged;
			// 
			// panel1
			// 
			panel1.Location = new Point(434, 40);
			panel1.Name = "panel1";
			panel1.Size = new Size(298, 37);
			panel1.TabIndex = 7;
			// 
			// AllRadioButton
			// 
			AllRadioButton.AutoSize = true;
			AllRadioButton.Location = new Point(651, 44);
			AllRadioButton.Name = "AllRadioButton";
			AllRadioButton.Size = new Size(55, 29);
			AllRadioButton.TabIndex = 8;
			AllRadioButton.TabStop = true;
			AllRadioButton.Text = "All";
			AllRadioButton.UseVisualStyleBackColor = true;
			AllRadioButton.CheckedChanged += RadioButton_CheckedChanged;
			// 
			// AdminPanel
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1478, 941);
			Controls.Add(AllRadioButton);
			Controls.Add(UserRadioButton);
			Controls.Add(AdminRadioButton);
			Controls.Add(DeleteButton);
			Controls.Add(CreateButton);
			Controls.Add(EditButton);
			Controls.Add(dataGridView1);
			Controls.Add(menuStrip1);
			Controls.Add(panel1);
			Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			MainMenuStrip = menuStrip1;
			Margin = new Padding(4);
			Name = "AdminPanel";
			ShowIcon = false;
			Text = "Admin Panel";
			Load += AdminPanel_LoadAsync;
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip menuStrip1;
		private ToolStripMenuItem LibrariesMenuItem;
		private ToolStripMenuItem BooksMenuItem;
		private ToolStripMenuItem UsersMenuItem;
		private DataGridView dataGridView1;
		private Button EditButton;
		private Button CreateButton;
		private Button DeleteButton;
		private RadioButton AdminRadioButton;
		private RadioButton UserRadioButton;
		private Panel panel1;
		private RadioButton AllRadioButton;
	}
}