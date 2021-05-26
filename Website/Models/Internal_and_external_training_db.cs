using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Website.Models
{
	public class Internal_and_external_training_db
	{
		private readonly string ConnStr = "Data Source=WIN-6M12QM5R44F;Initial Catalog=webphone;Persist Security Info=True;User ID=sa;Password=1qaz!QAZ;MultipleActiveResultSets=True;Application Name=EntityFramework";

		public void internal_and_external_training_insert(Internal_and_external_training internal_and_external_training)
		{
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand(
				@"INSERT into internal_and_external_training (year ,course_title ,name ,hour ,unit ,certified_documents ,training_class)
				VALUES (@year ,@course_title ,@name ,@hour ,@unit ,@certified_documents ,@training_class)");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@year", internal_and_external_training.year));
			sqlCommand.Parameters.Add(new SqlParameter("@course_title", internal_and_external_training.course_title));
			sqlCommand.Parameters.Add(new SqlParameter("@name", internal_and_external_training.name));
			sqlCommand.Parameters.Add(new SqlParameter("@hour", internal_and_external_training.hour));
			sqlCommand.Parameters.Add(new SqlParameter("@unit", internal_and_external_training.unit));
			sqlCommand.Parameters.Add(new SqlParameter("@certified_documents", internal_and_external_training.certified_documents));
			sqlCommand.Parameters.Add(new SqlParameter("@training_class", internal_and_external_training.training_class));
			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}

		public List<Internal_and_external_training> internal_and_external_training_db_select(string year, string name)
		{
			List<Internal_and_external_training> internal_and_external_training = new List<Internal_and_external_training>();
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM internal_and_external_training WHERE year = @year and name = @name");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@year", year));
			sqlCommand.Parameters.Add(new SqlParameter("@name", name));
			sqlConnection.Open();

			SqlDataReader reader = sqlCommand.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					Internal_and_external_training internal_and_external_train = new Internal_and_external_training
					{
						year = reader.GetString(reader.GetOrdinal("year")),
						course_title = reader.GetString(reader.GetOrdinal("course_title")),
						name = reader.GetString(reader.GetOrdinal("name")),
						hour = reader.GetString(reader.GetOrdinal("hour")),
						unit = reader.GetString(reader.GetOrdinal("unit")),
						certified_documents = reader.GetString(reader.GetOrdinal("certified_documents")),
						training_class = reader.GetString(reader.GetOrdinal("training_class"))			
					};
					internal_and_external_training.Add(internal_and_external_train);
				}
			}
			sqlConnection.Close();
			return internal_and_external_training;
		}
		public List<Internal_and_external_training> internal_and_external_training_db_select_all()
		{
			List<Internal_and_external_training> internal_and_external_training = new List<Internal_and_external_training>();
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM internal_and_external_training");
			sqlCommand.Connection = sqlConnection;
			sqlConnection.Open();

			SqlDataReader reader = sqlCommand.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					Internal_and_external_training internal_and_external_train= new Internal_and_external_training
					{
						year = reader.GetString(reader.GetOrdinal("year")),
						course_title = reader.GetString(reader.GetOrdinal("course_title")),
						name = reader.GetString(reader.GetOrdinal("name")),
						hour = reader.GetString(reader.GetOrdinal("hour")),
						unit = reader.GetString(reader.GetOrdinal("unit")),
						certified_documents = reader.GetString(reader.GetOrdinal("certified_documents")),
						training_class = reader.GetString(reader.GetOrdinal("training_class"))
					};
					internal_and_external_training.Add(internal_and_external_train);
				}
			}
			sqlConnection.Close();
			return internal_and_external_training;
		}
	}
}