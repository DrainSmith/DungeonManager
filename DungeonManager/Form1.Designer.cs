namespace DungeonManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.ChracterUpButton = new System.Windows.Forms.Button();
            this.CharacterDownButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSelectedCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(525, 428);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(603, 61);
            this.button3.TabIndex = 5;
            this.button3.Text = "Open Selected Character";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ChracterUpButton
            // 
            this.ChracterUpButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChracterUpButton.Location = new System.Drawing.Point(0, 0);
            this.ChracterUpButton.Name = "ChracterUpButton";
            this.ChracterUpButton.Size = new System.Drawing.Size(72, 213);
            this.ChracterUpButton.TabIndex = 6;
            this.ChracterUpButton.Text = "/\\";
            this.ChracterUpButton.UseVisualStyleBackColor = true;
            this.ChracterUpButton.Click += new System.EventHandler(this.ChracterUpButton_Click);
            // 
            // CharacterDownButton
            // 
            this.CharacterDownButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CharacterDownButton.Location = new System.Drawing.Point(0, 0);
            this.CharacterDownButton.Name = "CharacterDownButton";
            this.CharacterDownButton.Size = new System.Drawing.Size(72, 209);
            this.CharacterDownButton.TabIndex = 7;
            this.CharacterDownButton.Text = "\\/";
            this.CharacterDownButton.UseVisualStyleBackColor = true;
            this.CharacterDownButton.Click += new System.EventHandler(this.CharacterDownButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(603, 35);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveSelectedCharacterToolStripMenuItem,
            this.importCharacterToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveSelectedCharacterToolStripMenuItem
            // 
            this.saveSelectedCharacterToolStripMenuItem.Name = "saveSelectedCharacterToolStripMenuItem";
            this.saveSelectedCharacterToolStripMenuItem.Size = new System.Drawing.Size(290, 30);
            this.saveSelectedCharacterToolStripMenuItem.Text = "Export Selected Character";
            this.saveSelectedCharacterToolStripMenuItem.Click += new System.EventHandler(this.saveSelectedCharacterToolStripMenuItem_Click);
            // 
            // importCharacterToolStripMenuItem
            // 
            this.importCharacterToolStripMenuItem.Name = "importCharacterToolStripMenuItem";
            this.importCharacterToolStripMenuItem.Size = new System.Drawing.Size(290, 30);
            this.importCharacterToolStripMenuItem.Text = "Import Character from file";
            this.importCharacterToolStripMenuItem.Click += new System.EventHandler(this.importCharacterToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewCharacterToolStripMenuItem,
            this.deleteSelectedCharacterToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // addNewCharacterToolStripMenuItem
            // 
            this.addNewCharacterToolStripMenuItem.Name = "addNewCharacterToolStripMenuItem";
            this.addNewCharacterToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
            this.addNewCharacterToolStripMenuItem.Text = "Create New Character";
            this.addNewCharacterToolStripMenuItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // deleteSelectedCharacterToolStripMenuItem
            // 
            this.deleteSelectedCharacterToolStripMenuItem.Name = "deleteSelectedCharacterToolStripMenuItem";
            this.deleteSelectedCharacterToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
            this.deleteSelectedCharacterToolStripMenuItem.Text = "Delete Selected Character";
            this.deleteSelectedCharacterToolStripMenuItem.Click += new System.EventHandler(this.button2_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 35);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button3);
            this.splitContainer1.Size = new System.Drawing.Size(603, 495);
            this.splitContainer1.SplitterDistance = 428;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 9;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(603, 428);
            this.splitContainer2.SplitterDistance = 525;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.ChracterUpButton);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.CharacterDownButton);
            this.splitContainer3.Size = new System.Drawing.Size(72, 428);
            this.splitContainer3.SplitterDistance = 213;
            this.splitContainer3.SplitterWidth = 6;
            this.splitContainer3.TabIndex = 8;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "chr";
            this.saveFileDialog1.Filter = "Character File (*.chr)|*.chr";
            this.saveFileDialog1.Tag = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "chr";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Character File (*.chr)|*.chr";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(603, 530);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "DungeonManager";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button ChracterUpButton;
        private System.Windows.Forms.Button CharacterDownButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSelectedCharacterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importCharacterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedCharacterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewCharacterToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

