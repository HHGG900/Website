using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Website.Models
{
	public class care_place_db
	{
		private readonly string ConnStr = "Data Source=WIN-6M12QM5R44F;Initial Catalog=webphone;Persist Security Info=True;User ID=sa;Password=1qaz!QAZ;MultipleActiveResultSets=True;Application Name=EntityFramework";

		public void Care_place_insert(Care_place care_place, Case_informatio case_)
		{
			string Month = DateTime.Now.ToString("MM");
			string Year = DateTime.Now.ToString("yyyy");
			Year = (Int32.Parse(Year) - 1911).ToString();

			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand(
				@"INSERT into care_place (usr_name,worker_name,tim_y,tim_m,BA01,BA02,BA03,BA04,BA05,BA06,BA07,BA08,BA09,BA01_tem,BA02_tem,BA03_tem,BA04_tem,BA05_tem,BA06_tem,BA07_tem,BA08_tem,BA09_tem)
							VALUES(@usr_name,@worker_name,@tim_y,@tim_m,@BA01,@BA02,@BA03,@BA04,@BA05,@BA06,@BA07,@BA08,@BA09,@BA01_tem,@BA02_tem,@BA03_tem,@BA04_tem,@BA05_tem,@BA06_tem,@BA07_tem,@BA08_tem,@BA09_tem)");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@usr_name", care_place.usr_name));
			sqlCommand.Parameters.Add(new SqlParameter("@tim_y", Year));
			sqlCommand.Parameters.Add(new SqlParameter("@tim_m", Month));
			sqlCommand.Parameters.Add(new SqlParameter("@worker_name", care_place.worker_name));
			if (case_.BAList[0] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA01", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA01", case_.BAList[0]));
			if (case_.BAList[1] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA02", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA02", case_.BAList[1]));
			if (case_.BAList[2] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA03", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA03", case_.BAList[2]));
			if (case_.BAList[3] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA04", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA04", case_.BAList[3]));
			if (case_.BAList[4] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA05", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA05", case_.BAList[4]));
			if (case_.BAList[5] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA06", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA06", case_.BAList[5]));
			if (case_.BAList[6] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA07", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA07", case_.BAList[6]));
			if (case_.BAList[7] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA08", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA08", case_.BAList[7]));
			if (case_.BAList[8] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA09", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA09", case_.BAList[8]));

			sqlCommand.Parameters.Add(new SqlParameter("@BA01_tem", DBNull.Value));
			sqlCommand.Parameters.Add(new SqlParameter("@BA02_tem", DBNull.Value));
			sqlCommand.Parameters.Add(new SqlParameter("@BA03_tem", DBNull.Value));
			sqlCommand.Parameters.Add(new SqlParameter("@BA04_tem", DBNull.Value));
			sqlCommand.Parameters.Add(new SqlParameter("@BA05_tem", DBNull.Value));
			sqlCommand.Parameters.Add(new SqlParameter("@BA06_tem", DBNull.Value));
			sqlCommand.Parameters.Add(new SqlParameter("@BA07_tem", DBNull.Value));
			sqlCommand.Parameters.Add(new SqlParameter("@BA08_tem", DBNull.Value));
			sqlCommand.Parameters.Add(new SqlParameter("@BA09_tem", DBNull.Value));

			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();

		}
		public List<Care_place> Care_place_select(string UserId, string case_name, string year, string month)
		{
			List<Care_place> care_place = new List<Care_place>();
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM care_place WHERE (usr_name = '" + UserId + "' and worker_name = '" + case_name + "' and tim_m = " + Int32.Parse(month) + " and tim_y =" + Int32.Parse(year)+")");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@usr_name", UserId));
			sqlCommand.Parameters.Add(new SqlParameter("@worker_name", case_name));
			sqlConnection.Open();

			SqlDataReader reader = sqlCommand.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					Care_place care = new Care_place
					{
						usr_name = reader.GetString(reader.GetOrdinal("usr_name")),
						worker_name = reader.GetString(reader.GetOrdinal("worker_name")),
						BA01 = GetString(reader.GetOrdinal("BA01"), reader),
						BA02 = GetString(reader.GetOrdinal("BA02"), reader),
						BA03 = GetString(reader.GetOrdinal("BA03"), reader),
						BA04 = GetString(reader.GetOrdinal("BA04"), reader),
						BA05 = GetString(reader.GetOrdinal("BA05"), reader),
						BA06 = GetString(reader.GetOrdinal("BA06"), reader),
						BA07 = GetString(reader.GetOrdinal("BA07"), reader),
						BA08 = GetString(reader.GetOrdinal("BA08"), reader),
						BA09 = GetString(reader.GetOrdinal("BA09"), reader),
						BA01_tem = GetInt(reader.GetOrdinal("BA01_tem"), reader),
						BA02_tem = GetInt(reader.GetOrdinal("BA02_tem"), reader),
						BA03_tem = GetInt(reader.GetOrdinal("BA03_tem"), reader),
						BA04_tem = GetInt(reader.GetOrdinal("BA04_tem"), reader),
						BA05_tem = GetInt(reader.GetOrdinal("BA05_tem"), reader),
						BA06_tem = GetInt(reader.GetOrdinal("BA06_tem"), reader),
						BA07_tem = GetInt(reader.GetOrdinal("BA07_tem"), reader),
						BA08_tem = GetInt(reader.GetOrdinal("BA08_tem"), reader),
						BA09_tem = GetInt(reader.GetOrdinal("BA09_tem"), reader),
						tim_m = reader.GetString(reader.GetOrdinal("tim_m")),
						tim_y = reader.GetString(reader.GetOrdinal("tim_y")),
					};
					care_place.Add(care);
				}
			}
			sqlConnection.Close();
			return care_place;
		}

		public void Care_place_update_pic(Care_place care_place, Case_informatio case_)
		{
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand(
				@"UPDATE care_place SET BA01 = @BA01, BA02 = @BA02, BA03 = @BA03, BA04 = @BA04, BA05 = @BA05, BA06 = BA06, BA07 = @BA07, BA08 = @BA08, BA09 = @BA09 
							WHERE (usr_name = '" + care_place.usr_name + "' and worker_name = '" + care_place.worker_name + "' and tim_m = (SELECT MAX(tim_m) FROM care_place where worker_name = '" + care_place.worker_name + "' and tim_y = (SELECT MAX(tim_y) FROM care_place where worker_name = '" + care_place.worker_name + "')) and tim_y = (SELECT MAX(tim_y) FROM care_place where worker_name = '" + care_place.worker_name + "'))");
			sqlCommand.Connection = sqlConnection;

			sqlCommand.Parameters.Add(new SqlParameter("@usr_name", care_place.usr_name));
			sqlCommand.Parameters.Add(new SqlParameter("@worker_name", care_place.worker_name));
			sqlCommand.Parameters.Add(new SqlParameter("@BA01", case_.BAList[0]));
			if (case_.BAList[1] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA02", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA02", case_.BAList[1]));
			if (case_.BAList[2] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA03", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA03", case_.BAList[2]));
			if (case_.BAList[3] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA04", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA04", case_.BAList[3]));
			if (case_.BAList[4] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA05", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA05", case_.BAList[4]));
			if (case_.BAList[5] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA06", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA06", case_.BAList[5]));
			if (case_.BAList[6] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA07", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA07", case_.BAList[6]));
			if (case_.BAList[7] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA08", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA08", case_.BAList[7]));
			if (case_.BAList[8] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA09", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA09", case_.BAList[8]));
			sqlConnection.Open();

			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}

		public void Care_place_update_tem(List<int> int_ls, string work_name, string usr_name, List<Care_place> place)
		{
			

			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand(
				@"UPDATE care_place SET BA01_tem = @BA01_tem, BA02_tem = @BA02_tem, BA03_tem = @BA03_tem, BA04_tem = @BA04_tem, BA05_tem = @BA05_tem, BA06_tem = @BA06_tem, BA07_tem = @BA07_tem, BA08_tem = @BA08_tem, BA09_tem = @BA09_tem
									WHERE (usr_name = '" + usr_name + "' and worker_name = '" + work_name + "' and tim_m = (SELECT MAX(tim_m) FROM care_place where worker_name = '" + work_name + "' and tim_y = (SELECT MAX(tim_y) FROM care_place where worker_name = '" + work_name + "')) and tim_y = (SELECT MAX(tim_y) FROM care_place where worker_name = '" + work_name + "'))");
			sqlCommand.Connection = sqlConnection;
			foreach (Care_place care_ in place)
			{
							
				try { sqlCommand.Parameters.Add(new SqlParameter("@BA01_tem", care_.BA01_tem + int_ls[0])); }
					catch { sqlCommand.Parameters.Add(new SqlParameter("@BA01_tem", care_.BA01_tem)); }
				try { sqlCommand.Parameters.Add(new SqlParameter("@BA02_tem", care_.BA02_tem + int_ls[1])); }
				catch { sqlCommand.Parameters.Add(new SqlParameter("@BA02_tem", care_.BA02_tem)); }
				try { sqlCommand.Parameters.Add(new SqlParameter("@BA03_tem", care_.BA03_tem + int_ls[2])); }
				catch { sqlCommand.Parameters.Add(new SqlParameter("@BA03_tem", care_.BA03_tem)); }
				
				try
					{
						sqlCommand.Parameters.Add(new SqlParameter("@BA04_tem", care_.BA04_tem + int_ls[3]));
					}
				catch { sqlCommand.Parameters.Add(new SqlParameter("@BA04_tem", care_.BA04_tem)); }
				try
					{
						sqlCommand.Parameters.Add(new SqlParameter("@BA05_tem", care_.BA05_tem + int_ls[4]));
					}
				catch { sqlCommand.Parameters.Add(new SqlParameter("@BA05_tem", care_.BA05_tem)); }
				try { sqlCommand.Parameters.Add(new SqlParameter("@BA06_tem", care_.BA06_tem + int_ls[5])); }
					catch { sqlCommand.Parameters.Add(new SqlParameter("@BA06_tem", care_.BA06_tem)); }
				try
					{ sqlCommand.Parameters.Add(new SqlParameter("@BA07_tem", care_.BA07_tem + int_ls[6])); }
						catch { sqlCommand.Parameters.Add(new SqlParameter("@BA07_tem", care_.BA07_tem)); }
				try
					{ sqlCommand.Parameters.Add(new SqlParameter("@BA08_tem", care_.BA08_tem + int_ls[7])); }
				catch 
				{ sqlCommand.Parameters.Add(new SqlParameter("@BA08_tem", care_.BA08_tem)); }
				try 
				{ sqlCommand.Parameters.Add(new SqlParameter("@BA09_tem", care_.BA09_tem + int_ls[8])); }
					
				catch
				{ sqlCommand.Parameters.Add(new SqlParameter("@BA09_tem", care_.BA09_tem)); }
				sqlConnection.Open();
				sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
				
			}
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
		public int GetInt(int i, SqlDataReader reader)
		{
			try
			{
				return reader.GetInt32(i);
			}
			catch
			{
				return 0;
			}
		}
	}
}