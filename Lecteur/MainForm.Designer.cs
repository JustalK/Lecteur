/*
 * Created by SharpDevelop.
 * User: Latsuj
 * Date: 26/10/2015
 * Time: 20:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
using System.IO;
using System.Diagnostics;
using System.Media;
using Lecteur;
using WMPLib;
namespace Lecteur
{
	partial class MainForm
	{
		
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private WMPLib.WindowsMediaPlayer wplayer;	
		private int statePlayer;
		private System.ComponentModel.ComponentResourceManager rsc = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
		private string[] files;
		private int positionY = 2;
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		void Label3MouseHover(object sender, System.EventArgs e)
		{
		}
	
		void Label3MouseUp(object sender, System.EventArgs e)
		{

		}
		
		private void LayerColoredOn() {
				/**
				this.label3.BackColor = System.Drawing.Color.Blue;
				this.label4.BackColor = System.Drawing.Color.Blue;
				this.play.BackColor = System.Drawing.Color.Blue;
				this.play.Image = ((System.Drawing.Image)(rsc.GetObject("pause")));	
				**/
		}
		
		
		private void LayerColoredOff() {
				/**
				this.label3.BackColor = System.Drawing.Color.Red;
				this.label4.BackColor = System.Drawing.Color.Red;
				this.play.BackColor = System.Drawing.Color.Red;	
				this.play.Image = ((System.Drawing.Image)(rsc.GetObject("play.Image")));
				**/		
		}
		
		void Label3MouseLeave(object sender, System.EventArgs e)
		{

		}
		
		void wplayer_PlayStateChange(int NewState)
		{
			statePlayer = NewState;
			switch (NewState)
			{
			    case (int)WMPLib.WMPPlayState.wmppsMediaEnded:
					LayerColoredOff();
			        Debug.WriteLine("End");
			        break;
			    case (int)WMPLib.WMPPlayState.wmppsPlaying:
			        Debug.WriteLine("Playing");
			        break;
			    default:
			        break;
			}

		}
		
		private void searchMP3() {
			// Search in the current directory the mp3 files
			files = Directory.GetFiles(@"./", "*.mp3");
			foreach (string str in files)
			{
			    Debug.WriteLine("{0} ", str);
			}
		}
		
		private void addMP3() {
			System.Windows.Forms.Label mp3_song = new System.Windows.Forms.Label();
			System.Windows.Forms.Label button_play = new System.Windows.Forms.Label();
			System.Windows.Forms.Label mp3_title = new System.Windows.Forms.Label();
			
			mp3_title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			mp3_title.BackColor = System.Drawing.Color.Gray;
			mp3_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			mp3_title.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			mp3_title.Location = new System.Drawing.Point(12, 2+this.positionY);
			mp3_title.MinimumSize = new System.Drawing.Size(416, 45);
			mp3_title.MaximumSize = new System.Drawing.Size(416, 45);
			mp3_title.Text = "Title.mp3";
			mp3_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			mp3_title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Label3MouseUp);
			this.Controls.Add(mp3_title);				
			
			button_play.BackColor = System.Drawing.Color.Gray;
			button_play.Image = ((System.Drawing.Image)(rsc.GetObject("play")));
			button_play.Location = new System.Drawing.Point(530, this.positionY+1);
			button_play.MinimumSize = new System.Drawing.Size(48, 49);
			button_play.MaximumSize = new System.Drawing.Size(48, 49);
			button_play.Click += new System.EventHandler(this.Label5Click);
			this.Controls.Add(button_play);	
			
			mp3_song.BackColor = System.Drawing.Color.Gray;
			mp3_song.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			mp3_song.Location = new System.Drawing.Point(2, this.positionY);
			mp3_song.MinimumSize = new System.Drawing.Size(580, 51);
			mp3_song.MaximumSize = new System.Drawing.Size(580, 51);
			mp3_song.MouseHover += new System.EventHandler(this.Label3MouseHover);
			mp3_song.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Label3MouseUp);	
			this.Controls.Add(mp3_song);	
			
			this.positionY += 55;
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.pause = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Location = new System.Drawing.Point(2, 440);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(580, 2);
			this.label1.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label2.Location = new System.Drawing.Point(482, 446);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Justal \"Latsuj\" K.";
			// 
			// pause
			// 
			this.pause.Location = new System.Drawing.Point(0, 0);
			this.pause.Name = "pause";
			this.pause.Size = new System.Drawing.Size(100, 23);
			this.pause.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(584, 466);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "Lecteur";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label pause;
		
		void Label5Click(object sender, System.EventArgs e)
		{
			if(statePlayer!=(int)WMPLib.WMPPlayState.wmppsPlaying) {
				this.wplayer = new WMPLib.WindowsMediaPlayer();
				LayerColoredOn();
				this.wplayer.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(wplayer_PlayStateChange);
				this.wplayer.URL = "./fx2.mp3";
				this.wplayer.controls.play();
			}			
		}
	}
}
