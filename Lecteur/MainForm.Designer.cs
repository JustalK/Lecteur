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
using System.Windows.Forms;
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
		private System.ComponentModel.ComponentResourceManager rsc = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
		private List<string> selected = new List<string>();
		
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
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panContent = new System.Windows.Forms.Panel();
			this.searchDirectory = new System.Windows.Forms.Label();
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
			// panContent
			// 
			this.panContent.AutoScroll = true;
			this.panContent.Location = new System.Drawing.Point(2, -1);
			this.panContent.Name = "panContent";
			this.panContent.Size = new System.Drawing.Size(580, 438);
			this.panContent.TabIndex = 2;
			// 
			// searchDirectory
			// 
			this.searchDirectory.Image = ((System.Drawing.Image)(resources.GetObject("searchDirectory.Image")));
			this.searchDirectory.Location = new System.Drawing.Point(4, 443);
			this.searchDirectory.Name = "searchDirectory";
			this.searchDirectory.Size = new System.Drawing.Size(31, 23);
			this.searchDirectory.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(584, 466);
			this.Controls.Add(this.searchDirectory);
			this.Controls.Add(this.panContent);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "Lecteur";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label searchDirectory;
		private System.Windows.Forms.Panel panContent;
	}
}
