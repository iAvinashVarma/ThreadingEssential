namespace DownloadForm
{
	partial class Downloader
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Downloader));
			this.Tb_Url = new System.Windows.Forms.TextBox();
			this.Btn_DownloadSync = new System.Windows.Forms.Button();
			this.Btn_DownloadAsync = new System.Windows.Forms.Button();
			this.Lbl_Url = new System.Windows.Forms.Label();
			this.Lbl_Duration = new System.Windows.Forms.Label();
			this.Tmr_Watch = new System.Windows.Forms.Timer(this.components);
			this.Bw_Download = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// Tb_Url
			// 
			this.Tb_Url.Location = new System.Drawing.Point(88, 12);
			this.Tb_Url.Name = "Tb_Url";
			this.Tb_Url.Size = new System.Drawing.Size(357, 28);
			this.Tb_Url.TabIndex = 0;
			this.Tb_Url.Text = "http://www.deelay.me/5000/http://www.google.me/";
			// 
			// Btn_DownloadSync
			// 
			this.Btn_DownloadSync.Location = new System.Drawing.Point(13, 47);
			this.Btn_DownloadSync.Name = "Btn_DownloadSync";
			this.Btn_DownloadSync.Size = new System.Drawing.Size(432, 34);
			this.Btn_DownloadSync.TabIndex = 1;
			this.Btn_DownloadSync.Text = "Download Synchronously";
			this.Btn_DownloadSync.UseVisualStyleBackColor = true;
			this.Btn_DownloadSync.Click += new System.EventHandler(this.Btn_DownloadSync_Click);
			// 
			// Btn_DownloadAsync
			// 
			this.Btn_DownloadAsync.Location = new System.Drawing.Point(12, 87);
			this.Btn_DownloadAsync.Name = "Btn_DownloadAsync";
			this.Btn_DownloadAsync.Size = new System.Drawing.Size(433, 34);
			this.Btn_DownloadAsync.TabIndex = 2;
			this.Btn_DownloadAsync.Text = "Download Asynchronously";
			this.Btn_DownloadAsync.UseVisualStyleBackColor = true;
			this.Btn_DownloadAsync.Click += new System.EventHandler(this.Btn_DownloadAsync_Click);
			// 
			// Lbl_Url
			// 
			this.Lbl_Url.AutoSize = true;
			this.Lbl_Url.Location = new System.Drawing.Point(12, 15);
			this.Lbl_Url.Name = "Lbl_Url";
			this.Lbl_Url.Size = new System.Drawing.Size(37, 21);
			this.Lbl_Url.TabIndex = 3;
			this.Lbl_Url.Text = "URL";
			// 
			// Lbl_Duration
			// 
			this.Lbl_Duration.AutoSize = true;
			this.Lbl_Duration.Location = new System.Drawing.Point(12, 139);
			this.Lbl_Duration.Name = "Lbl_Duration";
			this.Lbl_Duration.Size = new System.Drawing.Size(70, 21);
			this.Lbl_Duration.TabIndex = 4;
			this.Lbl_Duration.Text = "Duration";
			// 
			// Tmr_Watch
			// 
			this.Tmr_Watch.Tick += new System.EventHandler(this.Tmr_Watch_Tick);
			// 
			// Bw_Download
			// 
			this.Bw_Download.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Bw_Download_DoWork);
			this.Bw_Download.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Bw_Download_RunWorkerCompleted);
			// 
			// Downloader
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(457, 181);
			this.Controls.Add(this.Lbl_Duration);
			this.Controls.Add(this.Lbl_Url);
			this.Controls.Add(this.Btn_DownloadAsync);
			this.Controls.Add(this.Btn_DownloadSync);
			this.Controls.Add(this.Tb_Url);
			this.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.Name = "Downloader";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Downloader";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox Tb_Url;
		private System.Windows.Forms.Button Btn_DownloadSync;
		private System.Windows.Forms.Button Btn_DownloadAsync;
		private System.Windows.Forms.Label Lbl_Url;
		private System.Windows.Forms.Label Lbl_Duration;
		private System.Windows.Forms.Timer Tmr_Watch;
		private System.ComponentModel.BackgroundWorker Bw_Download;
	}
}

