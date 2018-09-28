using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
//using Data;
using System.IO; 


namespace FileUpload_
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class Upload : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputFile File1;
		protected System.Web.UI.WebControls.Image Image1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here			
			if(Request.Files.Count != 0)
			{				
				HttpPostedFile httpFile = Request.Files[0];
				string extension = this.getFileExtension(httpFile.ContentType);
				if(extension == null )
				{
					Response.Write("<h1>Mime type not Supported</h1>"); 
					return;
				}
				
				System.IO.BufferedStream bf = new BufferedStream(httpFile.InputStream);
				byte[] buffer = new byte[bf.Length];   
				bf.Read(buffer,0,buffer.Length);				
				// Creating the database object
                /*
				DataAccess data = new DataAccess(); 
				Response.Write(data.addImage(buffer,extension)); 
				Response.Write("Image Added!");
				*/

			}
		}

		private string getFileExtension(string mimetype)
		{
			mimetype = mimetype.Split('.')[1].ToLower();
		    Hashtable hTable = new Hashtable();
			hTable.Add("pjpeg","jpg");
			hTable.Add("jpeg","jpg");
			hTable.Add("gif","gif");
			hTable.Add("x-png","png");
			hTable.Add("bmp","bmp");
            hTable.Add("tif", "tif");
            hTable.Add("xls", "xls");
			if(hTable.Contains(mimetype))
			{
				return (string)hTable[mimetype];
			}
			else
			{
				return null;
			}			
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Submit1_ServerClick(object sender, System.EventArgs e)
		{
			

		}
	}
}
