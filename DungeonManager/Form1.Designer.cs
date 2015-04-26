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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.ChracterUpButton = new System.Windows.Forms.Button();
            this.CharacterDownButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add Character";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(16, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(335, 328);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(278, 411);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 32);
            this.button2.TabIndex = 4;
            this.button2.Text = "Delete Character";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 6);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(412, 60);
            this.button3.TabIndex = 5;
            this.button3.Text = "Open Character";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ChracterUpButton
            // 
            this.ChracterUpButton.Location = new System.Drawing.Point(357, 115);
            this.ChracterUpButton.Name = "ChracterUpButton";
            this.ChracterUpButton.Size = new System.Drawing.Size(71, 73);
            this.ChracterUpButton.TabIndex = 6;
            this.ChracterUpButton.Text = "/\\";
            this.ChracterUpButton.UseVisualStyleBackColor = true;
            this.ChracterUpButton.Click += new System.EventHandler(this.ChracterUpButton_Click);
            // 
            // CharacterDownButton
            // 
            this.CharacterDownButton.Location = new System.Drawing.Point(358, 247);
            this.CharacterDownButton.Name = "CharacterDownButton";
            this.CharacterDownButton.Size = new System.Drawing.Size(71, 73);
            this.CharacterDownButton.TabIndex = 7;
            this.CharacterDownButton.Text = "\\/";
            this.CharacterDownButton.UseVisualStyleBackColor = true;
            this.CharacterDownButton.Click += new System.EventHandler(this.CharacterDownButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(441, 457);
            this.Controls.Add(this.CharacterDownButton);
            this.Controls.Add(this.ChracterUpButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Text = "DungeonManager";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button ChracterUpButton;
        private System.Windows.Forms.Button CharacterDownButton;
    }
}

