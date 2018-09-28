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
using System.IO;

namespace FileUpload
{
	/// <summary>
	/// Summary description for Show.
	/// </summary>
	public class Show : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink link;
		protected System.Web.UI.WebControls.LinkButton linkb;
		protected System.Web.UI.WebControls.ImageButton ImageButton1;
		protected System.Web.UI.WebControls.Image myImage;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Data.DataAccess data = new Data.DataAccess();  			
			int imagenumber = 0;
			try
			{
				imagenumber = int.Parse(Request.QueryString["image"]);
			}
			catch(System.ArgumentNullException ee)
			{
				imagenumber = 0;
			}

			byte []  buffer = data.getImage(imagenumber);
			System.IO.MemoryStream stream1 = new System.IO.MemoryStream(buffer,true);    
			stream1.Write(buffer,0,buffer.Length);
			Bitmap m_bitmap = (Bitmap) Bitmap.FromStream(stream1,true);
			Response.ContentType = "Image/jpeg";
			m_bitmap.Save(Response.OutputStream,System.Drawing.Imaging.ImageFormat.Jpeg);         			
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

		private void linkb_Click(object sender, System.EventArgs e)
		{
			
			 

		}
	}
}
