using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Website.Models
{
	public class staff_service_record_db
	{
		private readonly string ConnStr = "Data Source=WIN-6M12QM5R44F;Initial Catalog=webphone;Persist Security Info=True;User ID=sa;Password=1qaz!QAZ;MultipleActiveResultSets=True;Application Name=EntityFramework";

		public void staff_service_record_db_insert(staff_service_record staff_service_record, string classes)
		{
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand(
				@"INSERT into staff_service_record (year ,season ,date ,location ,partner ,picture1 ,picture2, picture3, picture4, classes)
				VALUES (@year ,@season ,@date ,@location ,@partner ,@picture1 ,@picture2, @picture3, @picture4,  @classes )");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@year", staff_service_record.year));
			sqlCommand.Parameters.Add(new SqlParameter("@season", staff_service_record.season));
			sqlCommand.Parameters.Add(new SqlParameter("@date", staff_service_record.date));
			sqlCommand.Parameters.Add(new SqlParameter("@location", staff_service_record.location));
			sqlCommand.Parameters.Add(new SqlParameter("@partner", staff_service_record.partner));
			sqlCommand.Parameters.Add(new SqlParameter("@picture1", staff_service_record.picture1));
			sqlCommand.Parameters.Add(new SqlParameter("@picture2", staff_service_record.picture2));
			sqlCommand.Parameters.Add(new SqlParameter("@picture3", staff_service_record.picture3));
			sqlCommand.Parameters.Add(new SqlParameter("@picture4", staff_service_record.picture4));
			sqlCommand.Parameters.Add(new SqlParameter("@classes", classes));
			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}

		public List<staff_service_record> staff_service_record_db_select(string UserId)
		{
			List<staff_service_record> staff_service_record = new List<staff_service_record>();
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM staff_service_record WHERE caser_name = @caser_name");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@caser_name", UserId));
			sqlConnection.Open();

			SqlDataReader reader = sqlCommand.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					staff_service_record staff_service_record1 = new staff_service_record
					{
						year = reader.GetString(reader.GetOrdinal("year")),
						season = reader.GetString(reader.GetOrdinal("season")),
						date = reader.GetString(reader.GetOrdinal("date")),
						location = reader.GetString(reader.GetOrdinal("location")),
						partner = reader.GetString(reader.GetOrdinal("partner")),
						picture1 = reader.GetString(reader.GetOrdinal("picture1")),
						picture2 = reader.GetString(reader.GetOrdinal("picture2")),
						picture3 = reader.GetString(reader.GetOrdinal("picture3")),
						picture4 = reader.GetString(reader.GetOrdinal("picture4"))
					};
					staff_service_record.Add(staff_service_record1);
				}
			}
			sqlConnection.Close();
			return staff_service_record;
		}
	}
}