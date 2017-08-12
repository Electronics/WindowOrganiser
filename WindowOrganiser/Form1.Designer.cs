namespace WindowOrganiser
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.button_getOpenWindows = new System.Windows.Forms.Button();
			this.button_move = new System.Windows.Forms.Button();
			this.button_getPos = new System.Windows.Forms.Button();
			this.button_save = new System.Windows.Forms.Button();
			this.button_load = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(894, 804);
			this.dataGridView1.TabIndex = 0;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.button_load);
			this.splitContainer1.Panel1.Controls.Add(this.button_save);
			this.splitContainer1.Panel1.Controls.Add(this.button_getPos);
			this.splitContainer1.Panel1.Controls.Add(this.button_move);
			this.splitContainer1.Panel1.Controls.Add(this.button_getOpenWindows);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
			this.splitContainer1.Size = new System.Drawing.Size(894, 908);
			this.splitContainer1.SplitterDistance = 100;
			this.splitContainer1.TabIndex = 1;
			// 
			// button_getOpenWindows
			// 
			this.button_getOpenWindows.Dock = System.Windows.Forms.DockStyle.Left;
			this.button_getOpenWindows.Location = new System.Drawing.Point(0, 0);
			this.button_getOpenWindows.Name = "button_getOpenWindows";
			this.button_getOpenWindows.Size = new System.Drawing.Size(143, 100);
			this.button_getOpenWindows.TabIndex = 0;
			this.button_getOpenWindows.Text = "Get Open Windows";
			this.button_getOpenWindows.UseVisualStyleBackColor = true;
			this.button_getOpenWindows.Click += new System.EventHandler(this.button1_Click);
			// 
			// button_move
			// 
			this.button_move.Dock = System.Windows.Forms.DockStyle.Left;
			this.button_move.Location = new System.Drawing.Point(143, 0);
			this.button_move.Name = "button_move";
			this.button_move.Size = new System.Drawing.Size(149, 100);
			this.button_move.TabIndex = 1;
			this.button_move.Text = "Move Windows Now";
			this.button_move.UseVisualStyleBackColor = true;
			this.button_move.Click += new System.EventHandler(this.button_move_Click);
			// 
			// button_getPos
			// 
			this.button_getPos.Dock = System.Windows.Forms.DockStyle.Left;
			this.button_getPos.Location = new System.Drawing.Point(292, 0);
			this.button_getPos.Name = "button_getPos";
			this.button_getPos.Size = new System.Drawing.Size(149, 100);
			this.button_getPos.TabIndex = 2;
			this.button_getPos.Text = "Get Window Positions";
			this.button_getPos.UseVisualStyleBackColor = true;
			this.button_getPos.Click += new System.EventHandler(this.button_getPos_Click);
			// 
			// button_save
			// 
			this.button_save.Dock = System.Windows.Forms.DockStyle.Left;
			this.button_save.Location = new System.Drawing.Point(441, 0);
			this.button_save.Name = "button_save";
			this.button_save.Size = new System.Drawing.Size(149, 100);
			this.button_save.TabIndex = 3;
			this.button_save.Text = "Save";
			this.button_save.UseVisualStyleBackColor = true;
			this.button_save.Click += new System.EventHandler(this.button_save_Click);
			// 
			// button_load
			// 
			this.button_load.Dock = System.Windows.Forms.DockStyle.Left;
			this.button_load.Location = new System.Drawing.Point(590, 0);
			this.button_load.Name = "button_load";
			this.button_load.Size = new System.Drawing.Size(149, 100);
			this.button_load.TabIndex = 4;
			this.button_load.Text = "Load";
			this.button_load.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(894, 908);
			this.Controls.Add(this.splitContainer1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button button_getOpenWindows;
		private System.Windows.Forms.Button button_move;
		private System.Windows.Forms.Button button_getPos;
		private System.Windows.Forms.Button button_load;
		private System.Windows.Forms.Button button_save;
	}
}

