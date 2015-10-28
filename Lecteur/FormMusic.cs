/*
 * Created by SharpDevelop.
 * User: Latsuj
 * Date: 28/10/2015
 * Time: 22:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Diagnostics;
namespace Lecteur
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class FormMusic
	{
		private Form windows;
		private Player player;
		private int index;
		private System.Windows.Forms.Label backgroung = new System.Windows.Forms.Label();
		private System.Windows.Forms.Label button = new System.Windows.Forms.Label();
		private System.Windows.Forms.Label title = new System.Windows.Forms.Label();
		private System.ComponentModel.ComponentResourceManager rsc = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
		
		public FormMusic(Player player,int index,Form form,string title,int positionX,int positionY,System.Drawing.Color color)
		{
			this.windows = form;
			this.player = player;
			this.index = index;
			
			this.button.BackColor = color;	
			this.button.Image = ((System.Drawing.Image)(rsc.GetObject("play")));
			this.button.Location = new System.Drawing.Point(530, positionY+2);
			this.button.MinimumSize = new System.Drawing.Size(40, 46);
			this.button.MaximumSize = new System.Drawing.Size(40, 46);
			button.Click += new System.EventHandler(this.playClick);
			this.windows.Controls.Add(button);	
			
			
			this.title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.title.BackColor = color;	
			this.title.Text = "   "+title;
			this.title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.title.ForeColor = System.Drawing.Color.Black;
			this.title.Location = new System.Drawing.Point(positionX, positionY);
			this.title.MinimumSize = new System.Drawing.Size(580, 50);
			this.title.MaximumSize = new System.Drawing.Size(580, 50);
			//title.Text = Path.GetFileName(files[cpt]);
			this.title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.title.Click += new System.EventHandler(this.selectedClick);
			this.windows.Controls.Add(this.title);
		}
		
		public void selectedClick(object sender, System.EventArgs e)
		{
			player.selected(this.index);
		}
		
		public void setSelected(bool selected) {
			if(selected) {
				this.title.BackColor = System.Drawing.SystemColors.ButtonHighlight;
				this.button.BackColor = System.Drawing.SystemColors.ButtonHighlight;			
			} else {
				this.title.BackColor = System.Drawing.SystemColors.ButtonShadow;
				this.button.BackColor = System.Drawing.SystemColors.ButtonShadow;				
			}
		}

		public void setPlayed(bool played) {
			if(played) {
				this.button.Image = ((System.Drawing.Image)(rsc.GetObject("pause")));
			} else {
				this.button.Image = ((System.Drawing.Image)(rsc.GetObject("play")));
			}
		}
		
		public void playClick(object sender, System.EventArgs e)
		{
			player.read(this.index);
		}		
		
	}
}
