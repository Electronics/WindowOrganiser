namespace WindowOrganiser
{
    partial class WindowOrganiser
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowOrganiser));
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.button_cull = new System.Windows.Forms.Button();
			this.button_load = new System.Windows.Forms.Button();
			this.button_save = new System.Windows.Forms.Button();
			this.button_getPos = new System.Windows.Forms.Button();
			this.button_move = new System.Windows.Forms.Button();
			this.button_getOpenWindows = new System.Windows.Forms.Button();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.button_settings = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridView
			// 
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView.Location = new System.Drawing.Point(0, 0);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowTemplate.Height = 24;
			this.dataGridView.Size = new System.Drawing.Size(1023, 804);
			this.dataGridView.TabIndex = 0;
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
			this.splitContainer1.Panel1.Controls.Add(this.button_settings);
			this.splitContainer1.Panel1.Controls.Add(this.button_cull);
			this.splitContainer1.Panel1.Controls.Add(this.button_load);
			this.splitContainer1.Panel1.Controls.Add(this.button_save);
			this.splitContainer1.Panel1.Controls.Add(this.button_getPos);
			this.splitContainer1.Panel1.Controls.Add(this.button_move);
			this.splitContainer1.Panel1.Controls.Add(this.button_getOpenWindows);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dataGridView);
			this.splitContainer1.Size = new System.Drawing.Size(1023, 908);
			this.splitContainer1.SplitterDistance = 100;
			this.splitContainer1.TabIndex = 1;
			// 
			// button_cull
			// 
			this.button_cull.Dock = System.Windows.Forms.DockStyle.Left;
			this.button_cull.Location = new System.Drawing.Point(739, 0);
			this.button_cull.Name = "button_cull";
			this.button_cull.Size = new System.Drawing.Size(149, 100);
			this.button_cull.TabIndex = 5;
			this.button_cull.Text = "Cull";
			this.button_cull.UseVisualStyleBackColor = true;
			this.button_cull.Click += new System.EventHandler(this.button_cull_Click);
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
			this.button_load.Click += new System.EventHandler(this.button_load_Click);
			// 
			// button_save
			// 
			this.button_save.Dock = System.Windows.Forms.DockStyle.Left;
			this.button_save.Location = new System.Drawing.Point(441, 0);
			this.button_save.Name = "button_save";
			this.button_save.Size = new System.Drawing.Size(149, 100);
			this.button_save.TabIndex = 3;
			this.button_save.Text = "Cull and Save";
			this.button_save.UseVisualStyleBackColor = true;
			this.button_save.Click += new System.EventHandler(this.button_save_Click);
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
			// notifyIcon1
			// 
			this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "Window Organiser";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
			// 
			// button_settings
			// 
			this.button_settings.Dock = System.Windows.Forms.DockStyle.Left;
			this.button_settings.Location = new System.Drawing.Point(888, 0);
			this.button_settings.Name = "button_settings";
			this.button_settings.Size = new System.Drawing.Size(132, 100);
			this.button_settings.TabIndex = 6;
			this.button_settings.Text = "Settings";
			this.button_settings.UseVisualStyleBackColor = true;
			this.button_settings.Click += new System.EventHandler(this.button_settings_Click);
			// 
			// WindowOrganiser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1023, 908);
			this.Controls.Add(this.splitContainer1);
			this.Name = "WindowOrganiser";
			this.Text = "Window Organiser";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button button_getOpenWindows;
		private System.Windows.Forms.Button button_move;
		private System.Windows.Forms.Button button_getPos;
		private System.Windows.Forms.Button button_cull;
		private System.Windows.Forms.Button button_load;
		private System.Windows.Forms.Button button_save;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.Button button_settings;
	}
}

