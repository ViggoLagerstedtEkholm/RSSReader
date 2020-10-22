namespace RSSReaderHT2020
{
    partial class Form1
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
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridPodcast = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNamn = new System.Windows.Forms.TextBox();
            this.newPodcastBtn = new System.Windows.Forms.Button();
            this.removePodcastBtn = new System.Windows.Forms.Button();
            this.savePodcastBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.comboBoxInterval = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.renameBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.removeCategoryBtn = new System.Windows.Forms.Button();
            this.saveCategoryBtn = new System.Windows.Forms.Button();
            this.newCategoryBtn = new System.Windows.Forms.Button();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.listBoxCategory = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxPodcast = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPodcast)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(14, 52);
            this.textBoxURL.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(200, 20);
            this.textBoxURL.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dataGridPodcast);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(9, 22);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 207);
            this.panel1.TabIndex = 3;
            // 
            // dataGridPodcast
            // 
            this.dataGridPodcast.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPodcast.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridPodcast.Location = new System.Drawing.Point(16, 29);
            this.dataGridPodcast.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridPodcast.Name = "dataGridPodcast";
            this.dataGridPodcast.RowHeadersWidth = 51;
            this.dataGridPodcast.RowTemplate.Height = 24;
            this.dataGridPodcast.Size = new System.Drawing.Size(802, 162);
            this.dataGridPodcast.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Name";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Interval";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "AmountOfEpisodes";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Category";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 13);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Feed";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBoxNamn);
            this.panel2.Controls.Add(this.newPodcastBtn);
            this.panel2.Controls.Add(this.removePodcastBtn);
            this.panel2.Controls.Add(this.savePodcastBtn);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboBoxCategory);
            this.panel2.Controls.Add(this.comboBoxInterval);
            this.panel2.Controls.Add(this.textBoxURL);
            this.panel2.Location = new System.Drawing.Point(9, 233);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(830, 92);
            this.panel2.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Name";
            // 
            // textBoxNamn
            // 
            this.textBoxNamn.Location = new System.Drawing.Point(255, 52);
            this.textBoxNamn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxNamn.Name = "textBoxNamn";
            this.textBoxNamn.Size = new System.Drawing.Size(131, 20);
            this.textBoxNamn.TabIndex = 12;
            // 
            // newPodcastBtn
            // 
            this.newPodcastBtn.Location = new System.Drawing.Point(568, 40);
            this.newPodcastBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.newPodcastBtn.Name = "newPodcastBtn";
            this.newPodcastBtn.Size = new System.Drawing.Size(76, 33);
            this.newPodcastBtn.TabIndex = 11;
            this.newPodcastBtn.Text = "New";
            this.newPodcastBtn.UseVisualStyleBackColor = true;
            this.newPodcastBtn.Click += new System.EventHandler(this.newPodcastBtn_Click);
            // 
            // removePodcastBtn
            // 
            this.removePodcastBtn.Location = new System.Drawing.Point(737, 40);
            this.removePodcastBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.removePodcastBtn.Name = "removePodcastBtn";
            this.removePodcastBtn.Size = new System.Drawing.Size(80, 33);
            this.removePodcastBtn.TabIndex = 6;
            this.removePodcastBtn.Text = "Remove";
            this.removePodcastBtn.UseVisualStyleBackColor = true;
            this.removePodcastBtn.Click += new System.EventHandler(this.removePodcastBtn_Click);
            // 
            // savePodcastBtn
            // 
            this.savePodcastBtn.Location = new System.Drawing.Point(648, 40);
            this.savePodcastBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.savePodcastBtn.Name = "savePodcastBtn";
            this.savePodcastBtn.Size = new System.Drawing.Size(85, 33);
            this.savePodcastBtn.TabIndex = 6;
            this.savePodcastBtn.Text = "Save";
            this.savePodcastBtn.UseVisualStyleBackColor = true;
            this.savePodcastBtn.Click += new System.EventHandler(this.savePodcastBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(490, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Category";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(395, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Updating interval";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "URL";
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(493, 52);
            this.comboBoxCategory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(51, 21);
            this.comboBoxCategory.TabIndex = 7;
            this.comboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategory_SelectedIndexChanged);
            // 
            // comboBoxInterval
            // 
            this.comboBoxInterval.FormattingEnabled = true;
            this.comboBoxInterval.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "3",
            "4",
            "5",
            "6"});
            this.comboBoxInterval.Location = new System.Drawing.Point(398, 52);
            this.comboBoxInterval.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxInterval.Name = "comboBoxInterval";
            this.comboBoxInterval.Size = new System.Drawing.Size(85, 21);
            this.comboBoxInterval.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.renameBtn);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.removeCategoryBtn);
            this.panel3.Controls.Add(this.saveCategoryBtn);
            this.panel3.Controls.Add(this.newCategoryBtn);
            this.panel3.Controls.Add(this.categoryTextBox);
            this.panel3.Controls.Add(this.listBoxCategory);
            this.panel3.Location = new System.Drawing.Point(381, 353);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(458, 227);
            this.panel3.TabIndex = 5;
            // 
            // renameBtn
            // 
            this.renameBtn.Location = new System.Drawing.Point(380, 174);
            this.renameBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.renameBtn.Name = "renameBtn";
            this.renameBtn.Size = new System.Drawing.Size(56, 27);
            this.renameBtn.TabIndex = 11;
            this.renameBtn.Text = "Rename";
            this.renameBtn.UseVisualStyleBackColor = true;
            this.renameBtn.Click += new System.EventHandler(this.renameBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 10);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Categories";
            // 
            // removeCategoryBtn
            // 
            this.removeCategoryBtn.Location = new System.Drawing.Point(152, 174);
            this.removeCategoryBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.removeCategoryBtn.Name = "removeCategoryBtn";
            this.removeCategoryBtn.Size = new System.Drawing.Size(63, 28);
            this.removeCategoryBtn.TabIndex = 9;
            this.removeCategoryBtn.Text = "Remove";
            this.removeCategoryBtn.UseVisualStyleBackColor = true;
            this.removeCategoryBtn.Click += new System.EventHandler(this.removeCategoryBtn_Click);
            // 
            // saveCategoryBtn
            // 
            this.saveCategoryBtn.Location = new System.Drawing.Point(81, 174);
            this.saveCategoryBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveCategoryBtn.Name = "saveCategoryBtn";
            this.saveCategoryBtn.Size = new System.Drawing.Size(66, 27);
            this.saveCategoryBtn.TabIndex = 8;
            this.saveCategoryBtn.Text = "Save";
            this.saveCategoryBtn.UseVisualStyleBackColor = true;
            this.saveCategoryBtn.Click += new System.EventHandler(this.saveCategoryBtn_Click);
            // 
            // newCategoryBtn
            // 
            this.newCategoryBtn.Location = new System.Drawing.Point(10, 174);
            this.newCategoryBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.newCategoryBtn.Name = "newCategoryBtn";
            this.newCategoryBtn.Size = new System.Drawing.Size(67, 27);
            this.newCategoryBtn.TabIndex = 8;
            this.newCategoryBtn.Text = "New";
            this.newCategoryBtn.UseVisualStyleBackColor = true;
            this.newCategoryBtn.Click += new System.EventHandler(this.newCategoryBtn_Click);
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Location = new System.Drawing.Point(10, 151);
            this.categoryTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(427, 20);
            this.categoryTextBox.TabIndex = 7;
            // 
            // listBoxCategory
            // 
            this.listBoxCategory.FormattingEnabled = true;
            this.listBoxCategory.Location = new System.Drawing.Point(10, 26);
            this.listBoxCategory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxCategory.Name = "listBoxCategory";
            this.listBoxCategory.Size = new System.Drawing.Size(427, 121);
            this.listBoxCategory.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.textBoxPodcast);
            this.panel4.Location = new System.Drawing.Point(9, 353);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(368, 227);
            this.panel4.TabIndex = 6;
            // 
            // textBoxPodcast
            // 
            this.textBoxPodcast.FormattingEnabled = true;
            this.textBoxPodcast.Location = new System.Drawing.Point(14, 11);
            this.textBoxPodcast.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPodcast.Name = "textBoxPodcast";
            this.textBoxPodcast.Size = new System.Drawing.Size(342, 199);
            this.textBoxPodcast.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 334);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Podcast Episodes";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 589);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPodcast)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.ComboBox comboBoxInterval;
        private System.Windows.Forms.ListBox listBoxCategory;
        private System.Windows.Forms.Button removePodcastBtn;
        private System.Windows.Forms.Button savePodcastBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListBox textBoxPodcast;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button removeCategoryBtn;
        private System.Windows.Forms.Button saveCategoryBtn;
        private System.Windows.Forms.Button newCategoryBtn;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button newPodcastBtn;
        private System.Windows.Forms.Button renameBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNamn;
        private System.Windows.Forms.DataGridView dataGridPodcast;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}

