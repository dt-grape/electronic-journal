namespace electronic_journal
{
    partial class JournalForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JournalForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.JournalDataGridView = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.CalculateAverageButton_Click = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.DateTextBox = new System.Windows.Forms.TextBox();
            this.AddDateButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.GroupNameLabel = new System.Windows.Forms.Label();
            this.SubjectNameLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.SubjectListBox = new System.Windows.Forms.ListBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.OpenAddSubjectFormButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateListBox = new System.Windows.Forms.ToolStripMenuItem();
            this.reference = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JournalDataGridView)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 631);
            this.panel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.JournalDataGridView);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(150, 169);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(796, 462);
            this.panel6.TabIndex = 3;
            // 
            // JournalDataGridView
            // 
            this.JournalDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.JournalDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.JournalDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.JournalDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.JournalDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.JournalDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JournalDataGridView.Location = new System.Drawing.Point(0, 0);
            this.JournalDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.JournalDataGridView.Name = "JournalDataGridView";
            this.JournalDataGridView.RowHeadersWidth = 51;
            this.JournalDataGridView.RowTemplate.Height = 24;
            this.JournalDataGridView.Size = new System.Drawing.Size(794, 460);
            this.JournalDataGridView.TabIndex = 0;
            this.JournalDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.JournalDataGridView_CellValidating);
            // 
            // panel3
            // 
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(150, 28);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(796, 141);
            this.panel3.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel10);
            this.panel5.Controls.Add(this.panel9);
            this.panel5.Controls.Add(this.GroupNameLabel);
            this.panel5.Controls.Add(this.SubjectNameLabel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(646, 141);
            this.panel5.TabIndex = 4;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.CalculateAverageButton_Click);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(319, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(165, 139);
            this.panel10.TabIndex = 6;
            // 
            // CalculateAverageButton_Click
            // 
            this.CalculateAverageButton_Click.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CalculateAverageButton_Click.Font = new System.Drawing.Font("Cascadia Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CalculateAverageButton_Click.Location = new System.Drawing.Point(29, 77);
            this.CalculateAverageButton_Click.Margin = new System.Windows.Forms.Padding(2);
            this.CalculateAverageButton_Click.Name = "CalculateAverageButton_Click";
            this.CalculateAverageButton_Click.Size = new System.Drawing.Size(110, 48);
            this.CalculateAverageButton_Click.TabIndex = 4;
            this.CalculateAverageButton_Click.Text = "Расчитать оценку";
            this.CalculateAverageButton_Click.UseVisualStyleBackColor = true;
            this.CalculateAverageButton_Click.Click += new System.EventHandler(this.CalculateAverageButton_Click_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.DateTextBox);
            this.panel9.Controls.Add(this.AddDateButton);
            this.panel9.Controls.Add(this.label2);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(484, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(160, 139);
            this.panel9.TabIndex = 5;
            // 
            // DateTextBox
            // 
            this.DateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTextBox.Location = new System.Drawing.Point(26, 44);
            this.DateTextBox.Name = "DateTextBox";
            this.DateTextBox.Size = new System.Drawing.Size(112, 23);
            this.DateTextBox.TabIndex = 3;
            this.DateTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DateTextBox_KeyPress);
            this.DateTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.DateTextBox_Validating);
            this.DateTextBox.Validated += new System.EventHandler(this.DateTextBox_Validated);
            // 
            // AddDateButton
            // 
            this.AddDateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddDateButton.Font = new System.Drawing.Font("Cascadia Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddDateButton.Location = new System.Drawing.Point(26, 77);
            this.AddDateButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddDateButton.Name = "AddDateButton";
            this.AddDateButton.Size = new System.Drawing.Size(112, 46);
            this.AddDateButton.TabIndex = 1;
            this.AddDateButton.Text = "Добавить дату";
            this.AddDateButton.UseVisualStyleBackColor = true;
            this.AddDateButton.Click += new System.EventHandler(this.AddDateButton_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(23, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Дата";
            // 
            // GroupNameLabel
            // 
            this.GroupNameLabel.AutoSize = true;
            this.GroupNameLabel.Font = new System.Drawing.Font("Cascadia Mono", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupNameLabel.Location = new System.Drawing.Point(4, 108);
            this.GroupNameLabel.Name = "GroupNameLabel";
            this.GroupNameLabel.Size = new System.Drawing.Size(0, 35);
            this.GroupNameLabel.TabIndex = 1;
            // 
            // SubjectNameLabel
            // 
            this.SubjectNameLabel.AutoSize = true;
            this.SubjectNameLabel.Font = new System.Drawing.Font("Cascadia Mono", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SubjectNameLabel.Location = new System.Drawing.Point(4, 75);
            this.SubjectNameLabel.Name = "SubjectNameLabel";
            this.SubjectNameLabel.Size = new System.Drawing.Size(0, 35);
            this.SubjectNameLabel.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(646, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(150, 141);
            this.panel4.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LogoutButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(148, 139);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Пользователь";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // LogoutButton
            // 
            this.LogoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogoutButton.AutoSize = true;
            this.LogoutButton.Font = new System.Drawing.Font("Cascadia Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogoutButton.Location = new System.Drawing.Point(19, 75);
            this.LogoutButton.Margin = new System.Windows.Forms.Padding(2);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(112, 48);
            this.LogoutButton.TabIndex = 0;
            this.LogoutButton.Text = "Выйти";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 603);
            this.panel2.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.SubjectListBox);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 140);
            this.panel8.Margin = new System.Windows.Forms.Padding(2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(150, 463);
            this.panel8.TabIndex = 1;
            // 
            // SubjectListBox
            // 
            this.SubjectListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SubjectListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubjectListBox.Font = new System.Drawing.Font("Cascadia Mono", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SubjectListBox.FormattingEnabled = true;
            this.SubjectListBox.ItemHeight = 22;
            this.SubjectListBox.Location = new System.Drawing.Point(0, 0);
            this.SubjectListBox.Margin = new System.Windows.Forms.Padding(2);
            this.SubjectListBox.Name = "SubjectListBox";
            this.SubjectListBox.Size = new System.Drawing.Size(150, 463);
            this.SubjectListBox.TabIndex = 0;
            this.SubjectListBox.SelectedIndexChanged += new System.EventHandler(this.SubjectListBox_SelectedIndexChanged);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.OpenAddSubjectFormButton);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(150, 140);
            this.panel7.TabIndex = 0;
            // 
            // OpenAddSubjectFormButton
            // 
            this.OpenAddSubjectFormButton.Font = new System.Drawing.Font("Cascadia Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenAddSubjectFormButton.Location = new System.Drawing.Point(19, 47);
            this.OpenAddSubjectFormButton.Margin = new System.Windows.Forms.Padding(2);
            this.OpenAddSubjectFormButton.Name = "OpenAddSubjectFormButton";
            this.OpenAddSubjectFormButton.Size = new System.Drawing.Size(112, 47);
            this.OpenAddSubjectFormButton.TabIndex = 1;
            this.OpenAddSubjectFormButton.Text = "Добавить предмет";
            this.OpenAddSubjectFormButton.UseVisualStyleBackColor = true;
            this.OpenAddSubjectFormButton.Click += new System.EventHandler(this.OpenAddSubjectFormButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFile,
            this.reference});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(946, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OpenFile
            // 
            this.OpenFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem,
            this.UpdateListBox});
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(59, 24);
            this.OpenFile.Text = "Файл";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.ExitToolStripMenuItem.Text = "Закрыть";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // UpdateListBox
            // 
            this.UpdateListBox.Name = "UpdateListBox";
            this.UpdateListBox.Size = new System.Drawing.Size(161, 26);
            this.UpdateListBox.Text = "Обновить";
            this.UpdateListBox.Click += new System.EventHandler(this.UpdateListBox_Click);
            // 
            // reference
            // 
            this.reference.Name = "reference";
            this.reference.Size = new System.Drawing.Size(81, 24);
            this.reference.Text = "Справка";
            // 
            // JournalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(946, 631);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Cascadia Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(484, 452);
            this.Name = "JournalForm";
            this.Text = "Электронный журнал для преподавателей";
            this.Load += new System.EventHandler(this.JournalForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.JournalDataGridView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DateTextBox;

        private System.Windows.Forms.Button AddDateButton;

        private System.Windows.Forms.ToolStripMenuItem UpdateListBox;

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView JournalDataGridView;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel8;
        public System.Windows.Forms.ListBox SubjectListBox;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button OpenAddSubjectFormButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OpenFile;
        private System.Windows.Forms.ToolStripMenuItem reference;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label GroupNameLabel;
        private System.Windows.Forms.Label SubjectNameLabel;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.Button CalculateAverageButton_Click;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
    }
}

