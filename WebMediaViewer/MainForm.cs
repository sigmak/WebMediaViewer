﻿/*
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

using HtmlAgilityPack;  

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
			
			txtContent.ReadOnly=true; //읽기전용으로 
			
			
		}

		
		

		void BtnScrapClick(object sender, EventArgs e)
		{
            txtContent.Text ="";

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
            txtContent.Text=responseFromServer;
		}
		
		void BtnMediaExtractClick(object sender, EventArgs e)
		{
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(txtContent.Text);

            listBox1.Items.Clear();
            int CntJpg=0;
            int CntPng=0;
            int CntBmp=0;
            int CntGif=0;
            int CntMp4=0;
            string chkMediaStr="";
            try {
            	
            	var my_img_nodes = doc.DocumentNode.SelectNodes(".//"+ txtStag.Text + "/@" + txtSattr.Text  );
            	
				//참고 : https://codeday.me/ko/qa/20190328/161753.html

            	//MessageBox.Show(my_img_nodes.Count + "");
				foreach(HtmlAgilityPack.HtmlNode node in my_img_nodes)
	            {
					string attributeValue = node.GetAttributeValue(txtSattr.Text, "");
					if (attributeValue != "") {
		                if (rbJpg.Checked==true){ //jpg 이면
  							chkMediaStr="jpg,jpeg ";
							if ((attributeValue.ToLower()).Contains(".jpg") || (attributeValue.ToLower()).Contains(".jpeg") ){
			                   	listBox1.Items.Add(attributeValue);
		                        CntJpg++;
			                }
	                    }else if (rbPng.Checked==true){ //png 이면
  							chkMediaStr="png ";
							if ((attributeValue.ToLower()).Contains(".png")){
			                   	listBox1.Items.Add(attributeValue);
		                        CntPng++;
			                }
	                    }else if (rbBmp.Checked==true){ //bmp 이면
  							chkMediaStr="bmp ";
							if ((attributeValue.ToLower()).Contains(".bmp")){
			                   	listBox1.Items.Add(attributeValue);
		                        CntBmp++;
			                }
	                    }else if (rbGif.Checked==true){ //gif 이면
  							chkMediaStr="gif ";
							if ((attributeValue.ToLower()).Contains(".gif")){
			                   	listBox1.Items.Add(attributeValue);
		                        CntGif++;
			                }
	                    }else if (rbMp4.Checked==true){ //mp4 이면
  							chkMediaStr="mp4 ";
							if ((attributeValue.ToLower()).Contains(".mp4")){
			                   	listBox1.Items.Add(attributeValue);
		                        CntMp4++;
			                }
	                    }
					}
				}  
				//doc.RemoveAll();			
            }catch {
            	
            }

          //MessageBox.Show(listBox1.Items.Count.ToString());
          lblResult.Text = "검색결과 : " + chkMediaStr + "총 파일수 = " + listBox1.Items.Count.ToString(); 
			
		}
		
		
		string imgTagStr(int no, string imgFileName){
			string result= no + "<img src='" + imgFileName + "' width='240' height='180'> &nbsp; &nbsp;";
			return ( result );
		}
		string imgTagStr2(int no, string imgFileName){
			string result= no + "<img src='" + imgFileName + "' > &nbsp; &nbsp;";
			return ( result );
		}
		string mp4TagStr(int no,string imgFileName){
			string result="" //<div>
                         +  no +  "<video autoplay='autoplay' preload='metadata' width='480' height='340' controls>"
                         + "<source src='" + imgFileName + "' type='video/mp4' />"
            		     + "<object id='ie_player' width='480' height='340'>"
            		     + "<param name='AutoStart' value='true'>"
            		     + "<param name='PlayCount' value='1'>"
            		     + "<param name='ShowControls' value='true'>"
            		     + "</object>"
                         + "</video> &nbsp; &nbsp;"; // + "</div>"; 
			
			return ( result );
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

			string fileNameStr="";
			if (cbUrlPath.Checked==true ){
				fileNameStr=listBox1.SelectedItem.ToString();
   			}else {
	   			fileNameStr=txtUrl.Text + listBox1.SelectedItem.ToString();
	   		}
            
            if (rbJpg.Checked==true){ //jpg 이면
            	//<img src="이미지경로" width="100" height="200">
            	htmlText="<html><body>"
            		    +  (listBox1.SelectedIndex+1) +  "<img src='" + fileNameStr + "' >"
            		    + "</body></html>"; 

            }else if (rbPng.Checked==true){ //gif 이면
            	htmlText="<html><body>"
            		    +  (listBox1.SelectedIndex+1) +  "<img src='" + fileNameStr + "' >"
            		    + "</body></html>"; 

            }else if (rbGif.Checked==true){ //gif 이면
            	htmlText="<html><body>"
            		    +  (listBox1.SelectedIndex+1) +  "<img src='" + fileNameStr + "' >"
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
                         + "<source src='" + fileNameStr + "' type='video/mp4' />"
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
