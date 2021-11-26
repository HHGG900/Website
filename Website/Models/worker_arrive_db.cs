using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Website.Models
	{
	public class worker_arrive_db
	{
		private readonly string ConnStr = "Data Source=WIN-6M12QM5R44F;Initial Catalog=webphone;Persist Security Info=True;User ID=sa;Password=1qaz!QAZ;MultipleActiveResultSets=True;Application Name=EntityFramework";

		public void worker_arrive_insert(string name)
		{
			string date = string.Format(DateTime.Now.ToString("yyyy-MM-dd"));
			string time = string.Format(DateTime.Now.ToString("yyyy-MM-dd H-mm"));
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand(
				@"INSERT into worker_arrive(worker_name, arrive_time, tim)
				VALUES (@worker_name,'" + time + "', '" + date + "')");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@worker_name", name));
			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
		public void worker_arrive_update(string worker)
		{
			string date = string.Format(DateTime.Now.ToString("yyyy-MM-dd"));
			string time = string.Format(DateTime.Now.ToString("yyyy-MM-dd H-mm"));
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand(
				@"UPDATE worker_arrive SET leave_time = '" + time + "' WHERE tim = '" + date + "' AND arrive_time = (select max(arrive_time) from worker_arrive where worker_name = @worker_name)");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@worker_name", worker));
			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
		public List<worker_arrive> worker_arrive_select(string UserId, string time1, string time2)
		{
			List<worker_arrive> worker_arrive = new List<worker_arrive>();
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM worker_arrive WHERE (worker_name IN (SELECT name FROM organization_account where class = (select class from organization_account where name = @worker_name))) AND tim BETWEEN @time1 and @time2");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@worker_name", UserId));
			sqlCommand.Parameters.Add(new SqlParameter("@time1", time1));
			sqlCommand.Parameters.Add(new SqlParameter("@time2", time2));
			sqlConnection.Open();

			SqlDataReader reader = sqlCommand.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					worker_arrive worker_arrive1 = new worker_arrive
					{
						worker_name = GetString(reader.GetOrdinal("worker_name"), reader),
						arrive_time = GetString(reader.GetOrdinal("arrive_time"), reader),
						leave_time = GetString(reader.GetOrdinal("leave_time"), reader),
						tim = GetString(reader.GetOrdinal("tim"), reader)
					};
					worker_arrive.Add(worker_arrive1);
				}
			}
			sqlConnection.Close();
			return worker_arrive;
		}
		public string GetString(int i, SqlDataReader reader)
	{
		try
		{
			return reader.GetString(i);
		}
		catch
		{
			return " ";
		}
	}
	}
	
}