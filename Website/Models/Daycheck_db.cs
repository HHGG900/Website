using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Website.Models
{
	public class Daycheck_db
	{
		private readonly string ConnStr = "Data Source=WIN-6M12QM5R44F;Initial Catalog=webphone;Persist Security Info=True;User ID=sa;Password=1qaz!QAZ;MultipleActiveResultSets=True;Application Name=EntityFramework";

		public void NewDaycheck(Daycheck daycheck)
		{
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand(
				@"INSERT INTO daycheck(usr_index,usr_name,temperature,Hand,Mask,Gloves,tim)
				VALUES (@usr_index,@usr_name,@temperature,@Hand,@Mask,@Gloves,@tim)");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@usr_index", daycheck.usr_index));
			sqlCommand.Parameters.Add(new SqlParameter("@usr_name", daycheck.usr_name));
			sqlCommand.Parameters.Add(new SqlParameter("@temperature", daycheck.temperature));
			sqlCommand.Parameters.Add(new SqlParameter("@Hand", daycheck.Hand));
			sqlCommand.Parameters.Add(new SqlParameter("@Mask", daycheck.Mask));
			if(daycheck.Gloves == null)
				sqlCommand.Parameters.Add(new SqlParameter("@Gloves", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@Gloves", daycheck.Gloves));
			sqlCommand.Parameters.Add(new SqlParameter("@tim", daycheck.tim));

			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}

		public Daycheck GetDaycheckByUserId (string usr_index)
		{
			Daycheck daycheck = new Daycheck();
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM daycheck WHERE usr_index = @usr_index");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@usr_index", usr_index));
			sqlConnection.Open();

			SqlDataReader reader = sqlCommand.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					daycheck = new Daycheck
					{
						usr_index = reader.GetString(reader.GetOrdinal("usr_index")),
						usr_name = reader.GetString(reader.GetOrdinal("usr_name")),
						temperature = reader.GetString(reader.GetOrdinal("temperature")),
						Hand = reader.GetString(reader.GetOrdinal("Hand")),
						Mask = reader.GetString(reader.GetOrdinal("Mask")),
						Gloves = reader.GetString(reader.GetOrdinal("Gloves")),
						tim = reader.GetDateTime(reader.GetOrdinal("tim")),

					};
				}
			}
			else
			{
				daycheck.usr_index = "未找到該筆資料";
			}
			sqlConnection.Close();
			return daycheck;
		}
	}
}