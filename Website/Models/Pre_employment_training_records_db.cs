using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Website.Models
{
	public class Pre_employment_training_records_db
	{
		private readonly string ConnStr = "Data Source=WIN-6M12QM5R44F;Initial Catalog=webphone;Persist Security Info=True;User ID=sa;Password=1qaz!QAZ;MultipleActiveResultSets=True;Application Name=EntityFramework";

		public void pre_employment_training_records_insert(Pre_employment_training_records pre_employment_training_records)
		{

			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand(
				
			@"INSERT INTO pre_employment_training_records(year ,season ,date ,location ,partner ,picture1 ,picture2 ,content ,give_back)
				VALUES (@year ,@season ,@date ,@location ,@partner ,@picture1 ,@picture2 ,@content ,@give_back)");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@year", pre_employment_training_records.year));
			sqlCommand.Parameters.Add(new SqlParameter("@season", pre_employment_training_records.season));
			sqlCommand.Parameters.Add(new SqlParameter("@date", pre_employment_training_records.date));
			sqlCommand.Parameters.Add(new SqlParameter("@location", pre_employment_training_records.location));
			sqlCommand.Parameters.Add(new SqlParameter("@partner", pre_employment_training_records.partner));
			sqlCommand.Parameters.Add(new SqlParameter("@picture1", pre_employment_training_records.picture1));
			sqlCommand.Parameters.Add(new SqlParameter("@picture2", pre_employment_training_records.picture2));
			sqlCommand.Parameters.Add(new SqlParameter("@content", pre_employment_training_records.content));
			sqlCommand.Parameters.Add(new SqlParameter("@give_back", pre_employment_training_records.give_back));
			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}

		public Pre_employment_training_records pre_employment_training_records_select(string year)
		{
			Pre_employment_training_records pre_employment_training_records = new Pre_employment_training_records();
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM pre_employment_training_records WHERE year = @year");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@year", year));
			sqlConnection.Open();

			SqlDataReader reader = sqlCommand.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					pre_employment_training_records = new Pre_employment_training_records
					{
						year = reader.GetString(reader.GetOrdinal("year")),
						season = reader.GetString(reader.GetOrdinal("season")),
						date = reader.GetString(reader.GetOrdinal("date")),
						location = reader.GetString(reader.GetOrdinal("location")),
						partner = reader.GetString(reader.GetOrdinal("partner")),
						picture1 = reader.GetString(reader.GetOrdinal("picture1")),
						picture2 = reader.GetString(reader.GetOrdinal("picture2")),
						content = reader.GetString(reader.GetOrdinal("content")),
						give_back = reader.GetString(reader.GetOrdinal("give_back"))
					};
				}
			}
			sqlConnection.Close();
			return pre_employment_training_records;
		}
	}
}