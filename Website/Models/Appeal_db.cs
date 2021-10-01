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
			string time = DateTime.Now.AddHours(8).ToString("yyyyMMddHmm");
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand(
				@"IINSERT into appeal_db (US_name,user_status,phone,fall_class,conten,pic_one,tim)
				VALUES(@US_name,@user_status,@phone,@fall_class,@conten,@pic_one,@tim)");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@US_name", appeal.US_name));
			sqlCommand.Parameters.Add(new SqlParameter("@user_status", appeal.user_status));
			sqlCommand.Parameters.Add(new SqlParameter("@phone", appeal.phone));
			sqlCommand.Parameters.Add(new SqlParameter("@fall_class", appeal.fall_class));
			sqlCommand.Parameters.Add(new SqlParameter("@conten", appeal.conten));
			sqlCommand.Parameters.Add(new SqlParameter("@pic_one", appeal.pic_one));
			sqlCommand.Parameters.Add(new SqlParameter("@tim", time));
			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}

		public List<appeal> appeal_select(string UserId)
		{
			List<appeal> Appeal = new List<appeal>();
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM appeal_db WHERE US_name = @US_name");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@US_name", UserId));
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
						pic_one = reader.GetString(reader.GetOrdinal("pic_one")),
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