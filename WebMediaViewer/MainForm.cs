/*
 * Created by SharpDevelop.
 * User: dwkang161
 * Date: 2019-06-14
 * Time: 오전 11:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace webImagesPreview
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	///
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
    		webBrowser1.Navigate("about:blank");

		}

		void MainFormLoad(object sender, EventArgs e)
		{
			txtUrl.Text = "https://www.wikipedia.org/";
			txtStag.Text = "link";//"a";
			txtSattr.Text="href";
			//txtSwords.Text ="jpg";
			
		}

		void Button1Click(object sender, EventArgs e)
		{
			//getImgs(txtUrl.Text); //---
			WebRequest request = WebRequest.Create(txtUrl.Text);
			request.Credentials = CredentialCache.DefaultCredentials;
			
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			 
			Encoding encode;
            if (response.CharacterSet.ToLower() == "utf-8") { encode = Encoding.UTF8; }
            else { encode = Encoding.Default; }

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream, encode);
 
            string responseFromServer = reader.ReadToEnd();            


            dataStream.Close();
            reader.Close();
            txtContent.Text ="";
            txtContent.Text=responseFromServer;
            
            //http://kaliko.com/blog/extract-image-tags-from-html-in-c/
            List<string> images = new List<string>();
            //string pattern = @"<(a)\b[^>]*>"; // a 태그 찾기 @"<(a)\b[^>]*>"
            string pattern = @"<(" + txtStag.Text + ")\\b[^>]*>"; // a 태그 찾기 @"<(a)\b[^>]*>"

            
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            MatchCollection matches = rgx.Matches(responseFromServer);

            
            
            listBox1.Items.Clear();
            
            XmlDocument doc = new XmlDocument();
            int CntJpg=0;
            int CntPng=0;
            int CntGif=0;
            int CntMp4=0;

            for(int i=0, l=matches.Count; i<l; i++) {
                
                // 위에서 가져온 <img ...> 태그 형태에 </img>태그를 붙여서
                // xml 태그 형태로 만든다음
                doc.LoadXml(matches[i].Value + "</" + txtStag.Text  + ">");  // "</a>"  
                
                
                //doc.SelectNodes("//img/@src") 를 이용해서 img 태그의  src 속성값만 뽑아와서
                //출처 : http://stackoverflow.com/questions/1100156/how-to-select-nodes-with-xpath-in-c
                foreach (XmlNode node in doc.SelectNodes("//"+ txtStag.Text  + "/@" + txtSattr.Text )){  //"//a/@href"
                //foreach (XmlNode node in doc.SelectNodes("//a/@href" )){  //"//a/@href"                

	                if (rbJpg.Checked==true){ //jpg 이면
	                    if ((node.InnerText).Contains(".jpg")){   
		                   	listBox1.Items.Add(node.InnerText);
	                        CntJpg++;
		                }
                    }else if (rbPng.Checked==true){ //png 이면
	                    if ((node.InnerText).Contains(".png")){   
		                   	listBox1.Items.Add(node.InnerText);
	                        CntPng++;
		                }
                    }else if (rbGif.Checked==true){ //gif 이면
	                    if ((node.InnerText).Contains(".gif")){   
		                   	listBox1.Items.Add(node.InnerText);
	                        CntGif++;
		                }
                    }else if (rbMp4.Checked==true){ //mp4 이면
	                    if ((node.InnerText).Contains(".mp4")){   
		                   	listBox1.Items.Add(node.InnerText);
	                        CntMp4++;
		                }
                    }
                
                }
                doc.RemoveAll();
            }      

          MessageBox.Show(listBox1.Items.Count.ToString());

		}
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
/*			
			pictureBox1.Image=null;
            pictureBox1.ImageLocation=txtUrl.Text + listBox1.SelectedItem.ToString();
            pictureBox1.SizeMode =PictureBoxSizeMode.StretchImage;
*/            
            
/* */            
            //webBrowser1.DocumentText = "<html><body></img></body></html>";
             //MessageBox.Show("test1");
             
            String htmlText ="<html><body></img></body></html>";
            
            if (rbJpg.Checked==true){ //jpg 이면
            	//<img src="이미지경로" width="100" height="200">
            	htmlText="<html><body>"
            		    +  (listBox1.SelectedIndex+1) +  "<img src='" + txtUrl.Text + listBox1.SelectedItem.ToString() + "' >"
            		    + "</body></html>"; 

            }else if (rbPng.Checked==true){ //gif 이면
            	htmlText="<html><body>"
            		    +  (listBox1.SelectedIndex+1) +  "<img src='" + txtUrl.Text + listBox1.SelectedItem.ToString() + "' >"
            		    + "</body></html>"; 

            }else if (rbGif.Checked==true){ //gif 이면
            	htmlText="<html><body>"
            		    +  (listBox1.SelectedIndex+1) +  "<img src='" + txtUrl.Text + listBox1.SelectedItem.ToString() + "' >"
            		    + "</body></html>"; 

            }else if (rbMp4.Checked==true){ //mp4 이면
            	// 
                htmlText = "<!DOCTYPE html>"
                         + "<html>"
                         + "<head>"
                         + "<meta http-equiv='Content-Type' content='text/html; charset=unicode' />"
                         + "<meta http-equiv='X-UA-Compatible' content='IE=9' /> "
                         + "<title></title>"
                         + "</head>"
                         + "<body>"
                         + "<div>"
                         +  (listBox1.SelectedIndex+1) +  "<video autoplay='autoplay' preload='metadata' width='480' height='340' controls>"
                         + "<source src='" + txtUrl.Text + listBox1.SelectedItem.ToString() + "' type='video/mp4' />"
            		     + "<object id='ie_player' width='480' height='340'>"
            		     + "<param name='AutoStart' value='true'>"
            		     + "<param name='PlayCount' value='1'>"
            		     + "<param name='ShowControls' value='true'>"
            		     + "</object>"
                         + "</video>"
                         + "</div>"
                         + "</body>"
                         + "</html>";
            	
           }
            
    		webBrowser1.Navigate("about:blank");
    		webBrowser1.Document.OpenNew(false);
    		webBrowser1.Document.Write(htmlText);
    		webBrowser1.Refresh();
/* */            
	
		}
		
	}
}
