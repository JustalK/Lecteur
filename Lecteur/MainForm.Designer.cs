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
		private System.Windows.Forms.Label label3;
		private WMPLib.WindowsMediaPlayer wplayer;	
		private int statePlayer;
		private System.Windows.Forms.Label label4;
		
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
			if(statePlayer!=(int)WMPLib.WMPPlayState.wmppsPlaying) {
				this.label3.BackColor = System.Drawing.Color.Blue;
				this.wplayer = new WMPLib.WindowsMediaPlayer();
				
				this.wplayer.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(wplayer_PlayStateChange);
				this.wplayer.URL = "fx2.mp3";
				this.wplayer.controls.play();
			}
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
					this.label3.BackColor = System.Drawing.Color.Red;
			        Debug.WriteLine("End");
			        break;
			    case (int)WMPLib.WMPPlayState.wmppsPlaying:
			        Debug.WriteLine("Playing");
			        break;
			    default:
			        break;
			}

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
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Location = new System.Drawing.Point(2, 445);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(580, 2);
			this.label1.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(482, 449);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Justal \"Latsuj\" K.";
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Red;
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label3.Location = new System.Drawing.Point(2, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(580, 51);
			this.label3.TabIndex = 3;
			this.label3.MouseLeave += new System.EventHandler(this.Label3MouseLeave);
			this.label3.MouseHover += new System.EventHandler(this.Label3MouseHover);
			this.label3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Label3MouseUp);
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.label4.BackColor = System.Drawing.Color.Red;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label4.Location = new System.Drawing.Point(12, 2);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(416, 51);
			this.label4.TabIndex = 4;
			this.label4.Text = "Title.mp3";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Label3MouseUp);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(584, 466);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "Lecteur";
			this.ResumeLayout(false);

		}
	}
}
