/*
 * Created by SharpDevelop.
 * User: dwkang161
 * Date: 2019-06-14
 * Time: 오전 11:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace webImagesPreview
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox txtUrl;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtContent;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtStag;
		private System.Windows.Forms.TextBox txtSattr;
		
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.txtContent = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbPng = new System.Windows.Forms.RadioButton();
			this.rbMp4 = new System.Windows.Forms.RadioButton();
			this.rbGif = new System.Windows.Forms.RadioButton();
			this.rbJpg = new System.Windows.Forms.RadioButton();
			this.txtSattr = new System.Windows.Forms.TextBox();
			this.txtStag = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtUrl = new System.Windows.Forms.TextBox();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(18, 164);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(245, 448);
			this.listBox1.TabIndex = 19;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1SelectedIndexChanged);
			// 
			// webBrowser1
			// 
			this.webBrowser1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.webBrowser1.Location = new System.Drawing.Point(274, 164);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(654, 444);
			this.webBrowser1.TabIndex = 20;
			// 
			// txtContent
			// 
			this.txtContent.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtContent.Enabled = false;
			this.txtContent.Location = new System.Drawing.Point(18, 116);
			this.txtContent.Multiline = true;
			this.txtContent.Name = "txtContent";
			this.txtContent.Size = new System.Drawing.Size(912, 42);
			this.txtContent.TabIndex = 21;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.groupBox2.Controls.Add(this.groupBox1);
			this.groupBox2.Controls.Add(this.txtSattr);
			this.groupBox2.Controls.Add(this.txtStag);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.txtUrl);
			this.groupBox2.Location = new System.Drawing.Point(20, 5);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(907, 102);
			this.groupBox2.TabIndex = 22;
			this.groupBox2.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbPng);
			this.groupBox1.Controls.Add(this.rbMp4);
			this.groupBox1.Controls.Add(this.rbGif);
			this.groupBox1.Controls.Add(this.rbJpg);
			this.groupBox1.Location = new System.Drawing.Point(348, 43);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(290, 39);
			this.groupBox1.TabIndex = 25;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "확장자 선택";
			// 
			// rbPng
			// 
			this.rbPng.Checked = true;
			this.rbPng.Location = new System.Drawing.Point(123, 10);
			this.rbPng.Name = "rbPng";
			this.rbPng.Size = new System.Drawing.Size(44, 26);
			this.rbPng.TabIndex = 3;
			this.rbPng.TabStop = true;
			this.rbPng.Text = "png";
			this.rbPng.UseVisualStyleBackColor = true;
			// 
			// rbMp4
			// 
			this.rbMp4.Location = new System.Drawing.Point(236, 10);
			this.rbMp4.Name = "rbMp4";
			this.rbMp4.Size = new System.Drawing.Size(48, 25);
			this.rbMp4.TabIndex = 2;
			this.rbMp4.Text = "mp4";
			this.rbMp4.UseVisualStyleBackColor = true;
			// 
			// rbGif
			// 
			this.rbGif.Location = new System.Drawing.Point(186, 9);
			this.rbGif.Name = "rbGif";
			this.rbGif.Size = new System.Drawing.Size(44, 26);
			this.rbGif.TabIndex = 1;
			this.rbGif.Text = "gif";
			this.rbGif.UseVisualStyleBackColor = true;
			// 
			// rbJpg
			// 
			this.rbJpg.Location = new System.Drawing.Point(80, 10);
			this.rbJpg.Name = "rbJpg";
			this.rbJpg.Size = new System.Drawing.Size(44, 26);
			this.rbJpg.TabIndex = 0;
			this.rbJpg.Text = "jpg";
			this.rbJpg.UseVisualStyleBackColor = true;
			// 
			// txtSattr
			// 
			this.txtSattr.Location = new System.Drawing.Point(214, 48);
			this.txtSattr.Name = "txtSattr";
			this.txtSattr.Size = new System.Drawing.Size(99, 21);
			this.txtSattr.TabIndex = 24;
			// 
			// txtStag
			// 
			this.txtStag.Location = new System.Drawing.Point(81, 49);
			this.txtStag.Name = "txtStag";
			this.txtStag.Size = new System.Drawing.Size(52, 21);
			this.txtStag.TabIndex = 23;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(146, 52);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 23);
			this.label4.TabIndex = 22;
			this.label4.Text = "속성명:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(21, 52);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 23);
			this.label3.TabIndex = 21;
			this.label3.Text = "태그명:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(840, 17);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(54, 26);
			this.button1.TabIndex = 20;
			this.button1.Text = "Run";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(15, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(28, 22);
			this.label1.TabIndex = 19;
			this.label1.Text = "url :";
			// 
			// txtUrl
			// 
			this.txtUrl.Location = new System.Drawing.Point(47, 20);
			this.txtUrl.Name = "txtUrl";
			this.txtUrl.Size = new System.Drawing.Size(787, 21);
			this.txtUrl.TabIndex = 18;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(939, 612);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.txtContent);
			this.Controls.Add(this.webBrowser1);
			this.Controls.Add(this.listBox1);
			this.Name = "MainForm";
			this.Text = "webImagesPreview";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.RadioButton rbPng;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rbJpg;
		private System.Windows.Forms.RadioButton rbGif;
		private System.Windows.Forms.RadioButton rbMp4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.WebBrowser webBrowser1;
	}
}
