/*
 * Created by SharpDevelop.
 * User: Latsuj
 * Date: 28/10/2015
 * Time: 21:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Lecteur
{
	public class Music
	{
		/* Path of the music */
		private string path;
		
		/* State of the music */
		private int state;

		/* isSelected ? */
		private bool selected;		
		
		public Music(string path)
		{
			this.path = path;
			this.state = 0;
			this.selected = false;
		}
		
		public void setSelected(bool selected) {
			this.selected=selected;
		}
		
		public bool isSelected() {
			return selected;
		}
		
		public void setState(int state) {
			this.state = state;
		}
		
		public int getState() {
			return state;
		}
		
		public void setPath(string path) {
			this.path = path;
		}
		
		public string getPath() {
			return this.path;
		}
	}
}
