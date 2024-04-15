namespace Watched_page
{
    partial class Watched
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
            label1 = new Label();
            dataGridView1 = new DataGridView();
            azCBox = new ComboBox();
            GenreCbox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(98, 97);
            label1.Name = "label1";
            label1.Size = new Size(191, 32);
            label1.TabIndex = 0;
            label1.Text = "Watched Movies";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 204);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(395, 175);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // azCBox
            // 
            azCBox.FormattingEnabled = true;
            azCBox.Items.AddRange(new object[] { "A-Z", "Z-A" });
            azCBox.Location = new Point(40, 469);
            azCBox.Name = "azCBox";
            azCBox.Size = new Size(121, 23);
            azCBox.TabIndex = 2;
            azCBox.Text = "Sort";
            azCBox.SelectedIndexChanged += azCBox_SelectedIndexChanged;
            // 
            // GenreCbox
            // 
            GenreCbox.FormattingEnabled = true;
            GenreCbox.Location = new Point(227, 469);
            GenreCbox.Name = "GenreCbox";
            GenreCbox.Size = new Size(121, 23);
            GenreCbox.TabIndex = 3;
            GenreCbox.Text = "Genre";
            GenreCbox.SelectedIndexChanged += GenreCbox_SelectedIndexChanged;
            // 
            // Watched
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.money;
            ClientSize = new Size(398, 776);
            Controls.Add(GenreCbox);
            Controls.Add(azCBox);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Watched";
            Text = "Form1";
            Load += Watched_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private ComboBox azCBox;
        private ComboBox GenreCbox;
    }
}