using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Website.Models
{
	public class Sign_in_select { 
		private readonly string ConnStr = "Data Source=WIN-6M12QM5R44F;Initial Catalog=webphone;Persist Security Info=True;User ID=sa;Password=1qaz!QAZ;MultipleActiveResultSets=True;Application Name=EntityFramework";

		public Sign_in sign_in_select(Sign_in sign_in)
		{
			//查詢是否有帳號
			Sign_in Sign_in = new Sign_in();
			//SqlConnection sqlConnection = new SqlConnection(ConnStr);
			//SqlCommand sqlCommand = new SqlCommand("SELECT name FROM sign_in WHERE (usr_index = @usr_index and usr_key = @usr_key)");
			//sqlCommand.Connection = sqlConnection;
			//sqlCommand.Parameters.Add(new SqlParameter("@usr_index", sign_in.usr_index));
			//sqlCommand.Parameters.Add(new SqlParameter("@usr_key", sign_in.usr_key));
			//sqlConnection.Open();
			//SqlDataReader reader = sqlCommand.ExecuteReader();
            //string name = "";
			//if (reader.HasRows)
			//	name = reader.GetString(reader.GetOrdinal("name"));
			//sqlConnection.Close();
			//查詢職稱
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand= new SqlCommand("SELECT post1, post2 FROM personnel WHERE (usr_name  = (SELECT usr_name FROM sign_in WHERE (usr_index = @usr_index and usr_key = @usr_key)))");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@usr_index", sign_in.usr_index));
			sqlCommand.Parameters.Add(new SqlParameter("@usr_key", sign_in.usr_key));
			sqlConnection.Open();
			SqlDataReader reader = sqlCommand.ExecuteReader();

			if (reader.HasRows)
			{
				while (reader.Read())
				{
				sign_in = new Sign_in
				{
						usr_index = reader.GetString(reader.GetOrdinal("post1")),
						usr_key = reader.GetString(reader.GetOrdinal("post2")),						
					};
				}
			}
			sqlConnection.Close();

			return sign_in;
		}
	}
}