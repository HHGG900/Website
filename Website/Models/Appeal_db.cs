using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Website.Models
{
	public class appeal_db
	{
		private readonly string ConnStr = "Data Source=WIN-6M12QM5R44F;Initial Catalog=webphone;Persist Security Info=True;User ID=sa;Password=1qaz!QAZ;MultipleActiveResultSets=True;Application Name=EntityFramework";

		public void appeal_insert(appeal appeal)
		{
			string time = DateTime.Now.ToString("yyyy.MM.dd H.mm");
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand(
				@"INSERT into appeal (US_name,user_status,phone,fall_class,conten,tim)
				VALUES(@US_name,@user_status,@phone,@fall_class,@conten,@tim)");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@US_name", appeal.US_name));
			sqlCommand.Parameters.Add(new SqlParameter("@user_status", appeal.user_status));
			sqlCommand.Parameters.Add(new SqlParameter("@phone", appeal.phone));
			sqlCommand.Parameters.Add(new SqlParameter("@fall_class", appeal.fall_class));
			sqlCommand.Parameters.Add(new SqlParameter("@conten", appeal.conten));
			sqlCommand.Parameters.Add(new SqlParameter("@tim", time));
			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}

		public List<appeal> appeal_select(string year)
		{
			string dateTime = new DateTime(Int32.Parse(year) + 1911, 1, 1).ToString("yyyy.MM.dd H.mm");
			string dateTime2 = new DateTime(Int32.Parse(year) + 1911, 12, 31).ToString("yyyy.MM.dd H.mm");
			List<appeal> Appeal = new List<appeal>();
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM appeal WHERE (tim between @date1 and @date2) order by tim desc");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@date1", dateTime));
			sqlCommand.Parameters.Add(new SqlParameter("@date2", dateTime2));
			sqlConnection.Open();

			SqlDataReader reader = sqlCommand.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					appeal appeal = new appeal
					{
						US_name = reader.GetString(reader.GetOrdinal("US_name")),
						user_status = reader.GetString(reader.GetOrdinal("user_status")),
						phone = reader.GetString(reader.GetOrdinal("phone")),
						fall_class = reader.GetString(reader.GetOrdinal("fall_class")),
						conten = reader.GetString(reader.GetOrdinal("conten")),
						tim = reader.GetString(reader.GetOrdinal("tim"))
					};
					Appeal.Add(appeal);
				}
			}
			sqlConnection.Close();
			return Appeal;
		}
	}
}