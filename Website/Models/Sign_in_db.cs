using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Website.Models
{
		public class Sign_in_db
		{
		private readonly string ConnStr = "Data Source=WIN-6M12QM5R44F;Initial Catalog=webphone;Persist Security Info=True;User ID=sa;Password=1qaz!QAZ;MultipleActiveResultSets=True;Application Name=EntityFramework";

		public void sign_in_db_insert(Sign_in sign_in)
			{
				SqlConnection sqlConnection = new SqlConnection(ConnStr);
				SqlCommand sqlCommand = new SqlCommand(
					@"INSERT INTO sign_in (usr_index ,usr_name , usr_key, working_yes_no)
				VALUES (@usr_index, @usr_name, @usr_key, 1)");
				sqlCommand.Connection = sqlConnection;
				sqlCommand.Parameters.Add(new SqlParameter("@usr_index", sign_in.usr_index));
				sqlCommand.Parameters.Add(new SqlParameter("@usr_name", sign_in.usr_name));
				sqlCommand.Parameters.Add(new SqlParameter("@usr_key", sign_in.usr_key));
				sqlConnection.Open();
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
			}


			public List<Sign_in> sign_in_select(string usr_index, string usr_key, string usr_name)
			{
			List<Sign_in> sign = new List<Sign_in>();
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
				SqlCommand sqlCommand = new SqlCommand("SELECT * FROM sign_in WHERE usr_index = @usr_index");
				sqlCommand.Connection = sqlConnection;
				sqlCommand.Parameters.Add(new SqlParameter("@usr_index", usr_index));
				sqlConnection.Open();
				SqlDataReader reader = sqlCommand.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						if (reader.GetString(reader.GetOrdinal("work_yes_no")) == "y")

							if ((reader.GetString(reader.GetOrdinal("usr_name")) == usr_name) && (reader.GetString(reader.GetOrdinal("usr_key")) == usr_key))
							{
								SqlConnection sqlConnection1 = new SqlConnection(ConnStr);
								SqlCommand Command = new SqlCommand("SELECT post1,post2 FROM personnel WHERE name = @usr_name ");
								Command.Connection = sqlConnection1;
								Command.Parameters.Add(new SqlParameter("@usr_name", usr_name));
								sqlConnection1.Open();

								SqlDataReader reader1 = Command.ExecuteReader();
								if (reader1.HasRows)
									while (reader1.Read())
									{
									Sign_in sign_in = new Sign_in
									{
										post1 = reader1.GetString(reader1.GetOrdinal("post1")),
										post2 = reader1.GetString(reader1.GetOrdinal("post2"))
									};
									sign.Add(sign_in);
									}
							sqlConnection1.Close();
							}
						else { 
							Sign_in sign_in = new Sign_in
							{
								post1 = "±b±K¿ù»~"
							};
							sign.Add(sign_in); 
						}
					else
					{
						Sign_in sign_in = new Sign_in
						{
							post1 = "¤wÂ÷Â¾"
						};
						sign.Add(sign_in);
					}


				}
				}
				sqlConnection.Close();
				
			return sign;
			}
		}
	}