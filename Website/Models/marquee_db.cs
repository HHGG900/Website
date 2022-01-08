using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Website.Models
{
	public class marquee_db
	{
		private readonly string ConnStr = "Data Source=WIN-6M12QM5R44F;Initial Catalog=webphone;Persist Security Info=True;User ID=sa;Password=1qaz!QAZ;MultipleActiveResultSets=True;Application Name=EntityFramework";

		public void marquee_insert(marquee marquee, string classname)
		{
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand(
				@"INSERT into marquee(marquee1 , tim ,class)
				VALUES (@marquee1 , @tim,(select class from organization_account where name = @classname))");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@marquee1", marquee.marquee1));
			sqlCommand.Parameters.Add(new SqlParameter("@tim", marquee.tim));
			sqlCommand.Parameters.Add(new SqlParameter("@classname", classname));
			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}

		public List<marquee> marquee_db_select(string UserId)
		{
			List<marquee> marquee = new List<marquee>();
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM marquee WHERE tim = (select MAX(tim)from marquee where class = (select class from organization_account where name = @caser_name))");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@caser_name", UserId));
			sqlConnection.Open();

			SqlDataReader reader = sqlCommand.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					marquee marque = new marquee
					{
						marquee1 = reader.GetString(reader.GetOrdinal("marquee1")),
					};
					marquee.Add(marque);
				}
			}
			sqlConnection.Close();
			return marquee;
		}
	}
}