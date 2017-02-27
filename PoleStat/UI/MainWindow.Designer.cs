namespace PoleStat.UI
{
	partial class MainWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.tbActiveMessageTopLine = new System.Windows.Forms.TextBox();
			this.tbActiveMessageBottomLine = new System.Windows.Forms.TextBox();
			this.gbActiveMessage = new System.Windows.Forms.GroupBox();
			this.niTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.btnExit = new System.Windows.Forms.Button();
			this.lbPages = new System.Windows.Forms.ListBox();
			this.gbPages = new System.Windows.Forms.GroupBox();
			this.gbActiveMessage.SuspendLayout();
			this.gbPages.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbActiveMessageTopLine
			// 
			this.tbActiveMessageTopLine.BackColor = System.Drawing.Color.Black;
			this.tbActiveMessageTopLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbActiveMessageTopLine.Font = new System.Drawing.Font("Consolas", 12F);
			this.tbActiveMessageTopLine.ForeColor = System.Drawing.Color.Chartreuse;
			this.tbActiveMessageTopLine.Location = new System.Drawing.Point(6, 19);
			this.tbActiveMessageTopLine.Multiline = true;
			this.tbActiveMessageTopLine.Name = "tbActiveMessageTopLine";
			this.tbActiveMessageTopLine.ReadOnly = true;
			this.tbActiveMessageTopLine.Size = new System.Drawing.Size(223, 25);
			this.tbActiveMessageTopLine.TabIndex = 0;
			this.tbActiveMessageTopLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbActiveMessageBottomLine
			// 
			this.tbActiveMessageBottomLine.BackColor = System.Drawing.Color.Black;
			this.tbActiveMessageBottomLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbActiveMessageBottomLine.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbActiveMessageBottomLine.ForeColor = System.Drawing.Color.Chartreuse;
			this.tbActiveMessageBottomLine.Location = new System.Drawing.Point(6, 46);
			this.tbActiveMessageBottomLine.Multiline = true;
			this.tbActiveMessageBottomLine.Name = "tbActiveMessageBottomLine";
			this.tbActiveMessageBottomLine.ReadOnly = true;
			this.tbActiveMessageBottomLine.Size = new System.Drawing.Size(223, 25);
			this.tbActiveMessageBottomLine.TabIndex = 1;
			this.tbActiveMessageBottomLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// gbActiveMessage
			// 
			this.gbActiveMessage.Controls.Add(this.tbActiveMessageTopLine);
			this.gbActiveMessage.Controls.Add(this.tbActiveMessageBottomLine);
			this.gbActiveMessage.Location = new System.Drawing.Point(303, 12);
			this.gbActiveMessage.Name = "gbActiveMessage";
			this.gbActiveMessage.Size = new System.Drawing.Size(235, 76);
			this.gbActiveMessage.TabIndex = 2;
			this.gbActiveMessage.TabStop = false;
			this.gbActiveMessage.Text = "Active Message on Display";
			// 
			// niTrayIcon
			// 
			this.niTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("niTrayIcon.Icon")));
			this.niTrayIcon.Text = "PoleStat";
			this.niTrayIcon.Visible = true;
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(463, 117);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(75, 23);
			this.btnExit.TabIndex = 3;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.ExitApp);
			// 
			// lbPages
			// 
			this.lbPages.Enabled = false;
			this.lbPages.FormattingEnabled = true;
			this.lbPages.Location = new System.Drawing.Point(6, 19);
			this.lbPages.Name = "lbPages";
			this.lbPages.Size = new System.Drawing.Size(272, 108);
			this.lbPages.TabIndex = 4;
			// 
			// gbPages
			// 
			this.gbPages.Controls.Add(this.lbPages);
			this.gbPages.Location = new System.Drawing.Point(13, 12);
			this.gbPages.Name = "gbPages";
			this.gbPages.Size = new System.Drawing.Size(284, 128);
			this.gbPages.TabIndex = 5;
			this.gbPages.TabStop = false;
			this.gbPages.Text = "Loaded pages";
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(550, 152);
			this.Controls.Add(this.gbPages);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.gbActiveMessage);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PoleStat";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
			this.gbActiveMessage.ResumeLayout(false);
			this.gbActiveMessage.PerformLayout();
			this.gbPages.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox tbActiveMessageTopLine;
		private System.Windows.Forms.TextBox tbActiveMessageBottomLine;
		private System.Windows.Forms.GroupBox gbActiveMessage;
		private System.Windows.Forms.NotifyIcon niTrayIcon;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.ListBox lbPages;
		private System.Windows.Forms.GroupBox gbPages;
	}
}