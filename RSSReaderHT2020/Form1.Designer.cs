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
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.newPodcastBtn = new System.Windows.Forms.Button();
            this.removePodcastBtn = new System.Windows.Forms.Button();
            this.savePodcastBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.comboBoxInterval = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.removeCategoryBtn = new System.Windows.Forms.Button();
            this.saveCategoryBtn = new System.Windows.Forms.Button();
            this.newCategoryBtn = new System.Windows.Forms.Button();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.listBoxCategory = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxPodcast = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPodcast)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(18, 42);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(265, 22);
            this.textBoxURL.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dataGridPodcast);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 206);
            this.panel1.TabIndex = 3;
            // 
            // dataGridPodcast
            // 
            this.dataGridPodcast.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPodcast.Location = new System.Drawing.Point(21, 54);
            this.dataGridPodcast.Name = "dataGridPodcast";
            this.dataGridPodcast.RowHeadersWidth = 51;
            this.dataGridPodcast.RowTemplate.Height = 24;
            this.dataGridPodcast.Size = new System.Drawing.Size(582, 126);
            this.dataGridPodcast.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Podcasts";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.newPodcastBtn);
            this.panel2.Controls.Add(this.removePodcastBtn);
            this.panel2.Controls.Add(this.savePodcastBtn);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboBoxCategory);
            this.panel2.Controls.Add(this.comboBoxInterval);
            this.panel2.Controls.Add(this.textBoxURL);
            this.panel2.Location = new System.Drawing.Point(12, 239);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(624, 161);
            this.panel2.TabIndex = 4;
            // 
            // newPodcastBtn
            // 
            this.newPodcastBtn.Location = new System.Drawing.Point(377, 75);
            this.newPodcastBtn.Name = "newPodcastBtn";
            this.newPodcastBtn.Size = new System.Drawing.Size(75, 39);
            this.newPodcastBtn.TabIndex = 11;
            this.newPodcastBtn.Text = "New";
            this.newPodcastBtn.UseVisualStyleBackColor = true;
            this.newPodcastBtn.Click += new System.EventHandler(this.newPodcastBtn_Click);
            // 
            // removePodcastBtn
            // 
            this.removePodcastBtn.Location = new System.Drawing.Point(541, 75);
            this.removePodcastBtn.Name = "removePodcastBtn";
            this.removePodcastBtn.Size = new System.Drawing.Size(66, 41);
            this.removePodcastBtn.TabIndex = 6;
            this.removePodcastBtn.Text = "Ta bort";
            this.removePodcastBtn.UseVisualStyleBackColor = true;
            this.removePodcastBtn.Click += new System.EventHandler(this.removePodcastBtn_Click);
            // 
            // savePodcastBtn
            // 
            this.savePodcastBtn.Location = new System.Drawing.Point(458, 75);
            this.savePodcastBtn.Name = "savePodcastBtn";
            this.savePodcastBtn.Size = new System.Drawing.Size(77, 39);
            this.savePodcastBtn.TabIndex = 6;
            this.savePodcastBtn.Text = "Save";
            this.savePodcastBtn.UseVisualStyleBackColor = true;
            this.savePodcastBtn.Click += new System.EventHandler(this.savePodcastBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(538, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Category";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(374, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Updating interval";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "URL";
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(540, 37);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(67, 24);
            this.comboBoxCategory.TabIndex = 7;
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
            this.comboBoxInterval.Location = new System.Drawing.Point(377, 37);
            this.comboBoxInterval.Name = "comboBoxInterval";
            this.comboBoxInterval.Size = new System.Drawing.Size(112, 24);
            this.comboBoxInterval.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.removeCategoryBtn);
            this.panel3.Controls.Add(this.saveCategoryBtn);
            this.panel3.Controls.Add(this.newCategoryBtn);
            this.panel3.Controls.Add(this.categoryTextBox);
            this.panel3.Controls.Add(this.listBoxCategory);
            this.panel3.Location = new System.Drawing.Point(662, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(456, 373);
            this.panel3.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "Categories";
            // 
            // removeCategoryBtn
            // 
            this.removeCategoryBtn.Location = new System.Drawing.Point(202, 315);
            this.removeCategoryBtn.Name = "removeCategoryBtn";
            this.removeCategoryBtn.Size = new System.Drawing.Size(84, 34);
            this.removeCategoryBtn.TabIndex = 9;
            this.removeCategoryBtn.Text = "Remove";
            this.removeCategoryBtn.UseVisualStyleBackColor = true;
            this.removeCategoryBtn.Click += new System.EventHandler(this.removeCategoryBtn_Click);
            // 
            // saveCategoryBtn
            // 
            this.saveCategoryBtn.Location = new System.Drawing.Point(108, 316);
            this.saveCategoryBtn.Name = "saveCategoryBtn";
            this.saveCategoryBtn.Size = new System.Drawing.Size(88, 33);
            this.saveCategoryBtn.TabIndex = 8;
            this.saveCategoryBtn.Text = "Save";
            this.saveCategoryBtn.UseVisualStyleBackColor = true;
            this.saveCategoryBtn.Click += new System.EventHandler(this.saveCategoryBtn_Click);
            // 
            // newCategoryBtn
            // 
            this.newCategoryBtn.Location = new System.Drawing.Point(13, 316);
            this.newCategoryBtn.Name = "newCategoryBtn";
            this.newCategoryBtn.Size = new System.Drawing.Size(89, 33);
            this.newCategoryBtn.TabIndex = 8;
            this.newCategoryBtn.Text = "New";
            this.newCategoryBtn.UseVisualStyleBackColor = true;
            this.newCategoryBtn.Click += new System.EventHandler(this.newCategoryBtn_Click);
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Location = new System.Drawing.Point(13, 287);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(424, 22);
            this.categoryTextBox.TabIndex = 7;
            // 
            // listBoxCategory
            // 
            this.listBoxCategory.FormattingEnabled = true;
            this.listBoxCategory.ItemHeight = 16;
            this.listBoxCategory.Location = new System.Drawing.Point(13, 32);
            this.listBoxCategory.Name = "listBoxCategory";
            this.listBoxCategory.Size = new System.Drawing.Size(424, 228);
            this.listBoxCategory.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.textBoxPodcast);
            this.panel4.Location = new System.Drawing.Point(12, 434);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(624, 279);
            this.panel4.TabIndex = 6;
            // 
            // textBoxPodcast
            // 
            this.textBoxPodcast.FormattingEnabled = true;
            this.textBoxPodcast.ItemHeight = 16;
            this.textBoxPodcast.Location = new System.Drawing.Point(18, 13);
            this.textBoxPodcast.Name = "textBoxPodcast";
            this.textBoxPodcast.Size = new System.Drawing.Size(589, 244);
            this.textBoxPodcast.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 411);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Podcast avsnitt";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.textBoxDescription);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(662, 434);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(456, 279);
            this.panel5.TabIndex = 8;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(13, 51);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(424, 22);
            this.textBoxDescription.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Beskrivning av avsnitt...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Podcast avsnitt ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 725);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
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
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
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
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridPodcast;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button newPodcastBtn;
    }
}

