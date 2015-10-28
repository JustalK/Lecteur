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
using System.Collections;
using System;
using Lecteur;
using WMPLib;
using System.Collections.Generic;
using System.Linq;
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
		private List<string> selected = new List<string>();
		private int positionY = 2;
		private int count = 0;
		private string objectCount;
		private int currentPlay;
		private System.Windows.Forms.Label objectButton;
		private System.Windows.Forms.Label objectSong;
		private System.Windows.Forms.Label objectTitle;
		
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
		
		private void searchMP3() {
			// Search in the current directory the mp3 files
			files = Directory.GetFiles(@"./", "*.mp3");
			int cpt = 0;
			foreach (string str in files)
			{
				addMP3(cpt);
				cpt++;
			}
		}
		
		private void addMP3(int cpt) {
			System.Windows.Forms.Label mp3_song = new System.Windows.Forms.Label();
			System.Windows.Forms.Label button_play = new System.Windows.Forms.Label();
			System.Windows.Forms.Label mp3_title = new System.Windows.Forms.Label();
			
			
			mp3_title.Name = "title_"+count;
			mp3_title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			mp3_title.BackColor = System.Drawing.SystemColors.ButtonShadow;	
			mp3_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			mp3_title.ForeColor = System.Drawing.Color.Black;
			mp3_title.Location = new System.Drawing.Point(12, 2+this.positionY);
			mp3_title.MinimumSize = new System.Drawing.Size(416, 45);
			mp3_title.MaximumSize = new System.Drawing.Size(416, 45);
			mp3_title.Text = Path.GetFileName(files[cpt]);
			mp3_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			mp3_title.Click += new System.EventHandler(this.selectedClick);
			this.Controls.Add(mp3_title);				
			
			button_play.Name = "button_"+count;
			button_play.BackColor = System.Drawing.SystemColors.ButtonShadow;	
			button_play.Image = ((System.Drawing.Image)(rsc.GetObject("play")));
			button_play.Location = new System.Drawing.Point(530, this.positionY+1);
			button_play.MinimumSize = new System.Drawing.Size(40, 49);
			button_play.MaximumSize = new System.Drawing.Size(40, 49);
			button_play.Click += new System.EventHandler(this.playClick);
			this.Controls.Add(button_play);	
			
			mp3_song.Name = "song_"+count;
			mp3_song.BackColor = System.Drawing.SystemColors.ButtonShadow;	
			mp3_song.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			mp3_song.Location = new System.Drawing.Point(2, this.positionY);
			mp3_song.MinimumSize = new System.Drawing.Size(580, 51);
			mp3_song.MaximumSize = new System.Drawing.Size(580, 51);
			mp3_song.Click += new System.EventHandler(this.selectedClick);
			this.Controls.Add(mp3_song);	
			
			this.positionY += 55;
			count++;
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
		
		void playClick(object sender, System.EventArgs e)
		{
			string name = ((System.Windows.Forms.Label)sender).Name;
			System.Windows.Forms.Label ctn = (System.Windows.Forms.Label)this.Controls[name];
			char[] delimiterChars = {'_'};
			this.objectCount = name.Split(delimiterChars)[1];
			
			if(statePlayer==(int)WMPLib.WMPPlayState.wmppsPlaying) {
				this.objectButton.Image = ((System.Drawing.Image)(rsc.GetObject("play")));
				this.wplayer.controls.stop();
			}				
			this.objectButton = (System.Windows.Forms.Label)this.Controls["button_"+objectCount];
			this.objectButton.Image = ((System.Drawing.Image)(rsc.GetObject("pause")));	
			if(!selected.Contains(this.objectCount)) {
				selected.Add(this.objectCount);
				this.objectTitle = (System.Windows.Forms.Label)this.Controls["title_"+objectCount];
				this.objectSong = (System.Windows.Forms.Label)this.Controls["song_"+objectCount];
				this.objectButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
				this.objectTitle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
				this.objectSong.BackColor = System.Drawing.SystemColors.ButtonHighlight;			
			} 
			this.currentPlay = this.selected.IndexOf(this.objectCount);
			play(currentPlay);
		}

		private void play(int id) {
			this.wplayer = new WMPLib.WindowsMediaPlayer();
			this.wplayer.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(wplayer_PlayStateChange);
			this.wplayer.URL = files[id];
			Debug.WriteLine(currentPlay);
			this.wplayer.controls.play();			
		}
		
		void selectedClick(object sender, System.EventArgs e)
		{
					Debug.WriteLine("azea");
			string name = ((System.Windows.Forms.Label)sender).Name;
			System.Windows.Forms.Label ctn = (System.Windows.Forms.Label)this.Controls[name];
			char[] delimiterChars = {'_'};
			string tmp = name.Split(delimiterChars)[1];
			
			if(!selected.Contains(tmp)) {
				selected.Add(name.Split(delimiterChars)[1]);
				this.objectButton = (System.Windows.Forms.Label)this.Controls["button_"+tmp];
				this.objectTitle = (System.Windows.Forms.Label)this.Controls["title_"+tmp];
				this.objectSong = (System.Windows.Forms.Label)this.Controls["song_"+tmp];
				this.objectButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
				this.objectTitle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
				this.objectSong.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			} else {
				Debug.WriteLine(this.currentPlay);
					Debug.WriteLine(":: "+this.selected.Count());
				if((this.selected.IndexOf(this.objectCount)>this.selected.IndexOf(tmp)) || (this.currentPlay>=this.selected.Count()-1)) {
					this.currentPlay-=1;
					Debug.WriteLine("azeazeae");
				}
				selected.Remove(tmp);
				this.objectButton = (System.Windows.Forms.Label)this.Controls["button_"+tmp];
				this.objectTitle = (System.Windows.Forms.Label)this.Controls["title_"+tmp];
				this.objectSong = (System.Windows.Forms.Label)this.Controls["song_"+tmp];
				this.objectButton.BackColor = System.Drawing.SystemColors.ButtonShadow;	
				this.objectTitle.BackColor = System.Drawing.SystemColors.ButtonShadow;	
				this.objectSong.BackColor = System.Drawing.SystemColors.ButtonShadow;					
			}
					Debug.WriteLine("azea");
		}
		
		void nextPlay() {
			this.currentPlay+=1;
			if(this.selected.Any()) {
				if(this.currentPlay<this.selected.Count()) {
					this.objectButton = (System.Windows.Forms.Label)this.Controls["button_"+this.selected.ElementAt(this.currentPlay)];
					play(this.currentPlay);
				} else {
					this.currentPlay = 0;
					this.objectButton = (System.Windows.Forms.Label)this.Controls["button_"+this.selected.ElementAt(this.currentPlay)];
					play(0);
				}
			}
		}
		
		void wplayer_PlayStateChange(int NewState)
		{
			statePlayer = NewState;
			switch (NewState)
			{
			    case (int)WMPLib.WMPPlayState.wmppsMediaEnded:
					Debug.WriteLine(":: "+this.currentPlay);
					Debug.WriteLine(":: "+this.selected.Count());
					Debug.WriteLine(":: "+this.selected.ElementAt(this.currentPlay));
					this.objectButton = (System.Windows.Forms.Label)this.Controls["button_"+this.selected.ElementAt(this.currentPlay)];
					this.objectButton.Image = ((System.Drawing.Image)(rsc.GetObject("play")));
					nextPlay();
			        break;
			    case (int)WMPLib.WMPPlayState.wmppsPlaying:
					this.objectButton = (System.Windows.Forms.Label)this.Controls["button_"+this.selected.ElementAt(this.currentPlay)];
					this.objectButton.Image = ((System.Drawing.Image)(rsc.GetObject("pause")));
			        break;
			    default:
			        break;
			}

		}
		

	}
}
