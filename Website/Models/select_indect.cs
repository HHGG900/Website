using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Website.Models
{
	public class select_indect
	{
		private readonly string ConnStr = "Data Source=WIN-6M12QM5R44F;Initial Catalog=webphone;Persist Security Info=True;User ID=sa;Password=1qaz!QAZ;MultipleActiveResultSets=True;Application Name=EntityFramework";
		
		//居督名稱, 資料庫名稱 回傳 序號 類別
		public string[] Get_Case_informatio(string name, string sheet)
		{
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand("SELECT Top 1 [index] FROM " + sheet + " ORDER BY [index]");
			//sqlCommand.Parameters.Add(new SqlParameter("@name", name));
			sqlCommand.Connection = sqlConnection;
			sqlConnection.Open();
			SqlDataReader reader = sqlCommand.ExecuteReader();
			string index = "";
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					index = reader.GetString(reader.GetOrdinal("index"));
				};
			}
			sqlConnection.Close();

			SqlConnection sqlConnection1 = new SqlConnection(ConnStr);
			SqlCommand sqlCommand1 = new SqlCommand("select class from organization_account where name = @name");
			sqlCommand1.Parameters.Add(new SqlParameter("@name", name));
			sqlCommand1.Connection = sqlConnection1;
			sqlConnection1.Open();
			SqlDataReader reader1 = sqlCommand1.ExecuteReader();
			string xlass = "";
			if (reader1.HasRows)
			{
				while (reader1.Read())
				{
					xlass = reader1.GetString(reader1.GetOrdinal("class"));
				};
			}
			string []list = { xlass, index };
			sqlConnection.Close();
			return list;
		}
	}
}