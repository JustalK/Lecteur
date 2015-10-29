/*
 * Created by SharpDevelop.
 * User: Latsuj
 * Date: 28/10/2015
 * Time: 21:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using WMPLib;
using Lecteur;
namespace Lecteur
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class Player
	{
		private List<Music> listMusics;
		private List<FormMusic> listForms;
		private Form windows;
		private WMPLib.WindowsMediaPlayer wplayer;	
		private int lastSong = -1;
		static readonly System.Drawing.Color BACK_COLOR = System.Drawing.SystemColors.ButtonShadow;
		const int DISTANCE_BETWEEN_MUSICS = 2;
		public Player(Form form)
		{
			this.listMusics = new List<Music>();
			this.listForms = new List<FormMusic>();
			this.windows = form;
			
			System.Windows.Forms.Label tmp = this.windows.Controls["searchDirectory"]  as System.Windows.Forms.Label;
			tmp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.searchDirectory);
		}
		
		void searchDirectory(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			 FolderBrowserDialog fbd = new FolderBrowserDialog();
			 DialogResult result = fbd.ShowDialog();
			 newMusicsList(fbd.SelectedPath);
		}
		
		public void newMusicsList(string path) {
			cleanMusicsList();
			string[] files = Directory.GetFiles(@""+path, "*.mp3");
			int positionY = 2;
			int lengthBar = 0;
			if(files.Length >=9) {
				lengthBar = 20;
			}
			for (int i = 0; i < files.Length; i++)
        	{
				Music music = new Music(files[i]);
				FormMusic form = new FormMusic(this,i,this.windows,getBasename(files[i]),2,positionY,lengthBar,BACK_COLOR);
				addFormMusics(form);
				addMusic(music);
				positionY+=50+DISTANCE_BETWEEN_MUSICS;
        	}
		}
		
		public void cleanMusicsList() {
			if(lastSong!=-1 && listMusics[lastSong].getState()==1) {
				this.wplayer.controls.stop();	
			}
			listMusics.Clear();
			System.Windows.Forms.Panel tmp = this.windows.Controls["panContent"] as System.Windows.Forms.Panel;
			tmp.Controls.Clear();
			listForms.Clear();
			
		}
		
		public void selected(int i) {
			if(listMusics[i].isSelected()) {
				listMusics[i].setSelected(false);
				listForms[i].setSelected(false);
			} else {
				listMusics[i].setSelected(true);
				listForms[i].setSelected(true);
			}
		}
		
		public void play(int i) {
			this.wplayer = new WMPLib.WindowsMediaPlayer();
			this.wplayer.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(wplayer_PlayStateChange);
			this.wplayer.URL = listMusics[i].getPath();
			this.wplayer.controls.play();			
		}
		
		public void read(int i) {
			if(lastSong!=-1 && lastSong!=i) {
				listMusics[lastSong].setState(0);
				this.wplayer.controls.stop();
				listForms[lastSong].setPlayed(false);
			}
			if(listMusics[i].getState()==0) {
				if(!listMusics[i].isSelected()) {
					listMusics[i].setSelected(true);
					listForms[i].setSelected(true);
				}
				listMusics[i].setState(1);
				listForms[i].setPlayed(true);
				lastSong=i;
				play(i);
			} else {	
				listForms[i].setPlayed(false);
				listMusics[i].setState(0);
				this.wplayer.controls.stop();	
			}
		}
		
		public int nextSong() {
			for (int i = lastSong+1; i < listMusics.Count; i++)
        	{
				if(listMusics[i].isSelected()) {
					read(i);
					return 1;
				}
			}
			for (int i = 0; i <= lastSong; i++)
        	{
				if(listMusics[i].isSelected()) {
					read(i);
					return 2;
				}
			}
			return 0;
		}
		
		public void wplayer_PlayStateChange(int NewState)
		{
			if(NewState==(int)WMPLib.WMPPlayState.wmppsMediaEnded) {
				listMusics[lastSong].setState(0);
				listForms[lastSong].setPlayed(false);
				nextSong();
			}
		}
		
		public void addFormMusics(FormMusic form) {
			this.listForms.Add(form);
		}
		
		public string getBasename(string path) {
			return Path.GetFileNameWithoutExtension(path);
		}
		
		public void createMusicsList() {
			string[] files = Directory.GetFiles(@"./", "*.mp3");
			int positionY = 2;
			int lengthBar = 0;
			if(files.Length >=9) {
				lengthBar = 20;
			}
			for (int i = 0; i < files.Length; i++)
        	{
				Music music = new Music(files[i]);
				FormMusic form = new FormMusic(this,i,this.windows,getBasename(files[i]),2,positionY,lengthBar,BACK_COLOR);
				addFormMusics(form);
				addMusic(music);
				positionY+=50+DISTANCE_BETWEEN_MUSICS;
        	}
		}
		
		/*
		 * Adding a music to the list
		 */
		public void addMusic(Music music) {
			this.listMusics.Add(music);
		}
		
		
		
	}
}
