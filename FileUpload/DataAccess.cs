using System;
using System.Data;
using Microsoft.Data.Odbc;  
   


namespace Data
{
	/// <summary>
	/// This class does the data manipulation
	/// </summary>
	public class DataAccess
	{

		private string _strConn = 
			@"Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;DATABASE=test;"; 


		private OdbcConnection _objConn;

		public DataAccess()
		{
			this._objConn = new OdbcConnection(this._strConn);  
		}

		public string addImage(byte [] buffer,string extension)
		{
			string strSql = "SELECT * FROM File";
			DataSet ds = new DataSet("Image");
			OdbcDataAdapter tempAP = new OdbcDataAdapter(strSql,this._objConn);
			OdbcCommandBuilder objCommand = new OdbcCommandBuilder(tempAP);
			tempAP.Fill(ds,"Table");
 
			try
			{
				this._objConn.Open();
				DataRow objNewRow = ds.Tables["Table"].NewRow();
				objNewRow["Extension"] = extension;
				objNewRow["Data"] = buffer;
				ds.Tables["Table"].Rows.Add(objNewRow);
				// trying to update the table to add the image
				tempAP.Update(ds,"Table"); 
			}
			catch(Exception e){return e.Message;}
			finally{this._objConn.Close();}
			return null;
		}

		public byte [] getImage(int imageNumber)
		{
			string strSql = "SELECT * FROM File";
			DataSet ds = new DataSet("Image");
			OdbcDataAdapter tempAP = new OdbcDataAdapter(strSql,this._objConn);
			OdbcCommandBuilder objCommand = new OdbcCommandBuilder(tempAP);
			tempAP.Fill(ds,"Table");
 
			try
			{
				this._objConn.Open();
				byte [] buffer = (byte [])ds.Tables["Table"].Rows[imageNumber]["Data"];
				return buffer;
			}
			catch{this._objConn.Close();return null;}
			finally{this._objConn.Close();}			
		}

		public int getCount()
		{
			string strSql = "SELECT COUNT(Data) FROM File";
			DataSet ds = new DataSet("Image");
			OdbcDataAdapter tempAP = new OdbcDataAdapter(strSql,this._objConn);
			OdbcCommandBuilder objCommand = new OdbcCommandBuilder(tempAP);
			tempAP.Fill(ds,"Table");
 
			try
			{
				this._objConn.Open();
				int count = (int)ds.Tables["Table"].Rows[0][0];
				return count;
			}
			catch{this._objConn.Close();return 0;}
			finally{this._objConn.Close();}
		}

	}
}
