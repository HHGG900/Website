using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Website.Models
{
	public class case_information_db
	{
		private readonly string ConnStr = "Data Source=WIN-6M12QM5R44F;Initial Catalog=webphone;Persist Security Info=True;User ID=sa;Password=1qaz!QAZ;MultipleActiveResultSets=True;Application Name=EntityFramework";

		public void NewDaycheck(Daycheck daycheck)
		{
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand(
				@"INSERT INTO daycheck(name,six,birthday,identity,telephone,economic,obstacleclass,obstacledegree,contact,phone,notedate,CMS,BA1project,BA2project,BA3project,BA4project,BA5poject,BA6project,BA7project,BA8project,BA9project,BA10project,BA1amount,BA2amount,BA3amount,BA4amount,BA5amount,BA6amount,BA7amount,BA8amount,BA9amount,BA10amount,nateunit,waiter,status,no_service_reason,no_service_date)
				VALUES (@name,@six,@birthday,@identity,@telephone,@economic,@obstacleclass,@obstacledegree,@contact,@phone,@notedate,@CMS,@BA1project,@BA2project,@BA3project,@BA4project,@BA5poject,@BA6project,@BA7project,@BA8project,@BA9project,@BA10project,@BA1amount,@BA2amount,@BA3amount,@BA4amount,@BA5amount,@BA6amount,@BA7amount,@BA8amount,@BA9amount,@BA10amount,@nateunit,@waiter,@status,@no_service_reason,@no_service_date)");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@name", daycheck.name));
			sqlCommand.Parameters.Add(new SqlParameter("@six", daycheck.six));
            sqlCommand.Parameters.Add(new SqlParameter("@birthday", daycheck.birthday));
			sqlCommand.Parameters.Add(new SqlParameter("@identity", daycheck.identity));
			sqlCommand.Parameters.Add(new SqlParameter("@telephone", daycheck.telephone));
			sqlCommand.Parameters.Add(new SqlParameter("@economic", daycheck.economic));
			sqlCommand.Parameters.Add(new SqlParameter("@obstacleclass", daycheck.obstacleclass));
			sqlCommand.Parameters.Add(new SqlParameter("@obstacledegree", daycheck.obstacledegree));
			sqlCommand.Parameters.Add(new SqlParameter("@contact", daycheck.contact));
			sqlCommand.Parameters.Add(new SqlParameter("@phone", daycheck.phone));
			sqlCommand.Parameters.Add(new SqlParameter("@notedate", daycheck.notedate));
            sqlCommand.Parameters.Add(new SqlParameter("@CMS", daycheck.CMS));
			 if(daycheck.BA1project == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA1project", DBNull.Value));
			else
                sqlCommand.Parameters.Add(new SqlParameter("@BA1project", daycheck.BA1project));
			if(daycheck.BA2project == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA2project", DBNull.Value));
			else
                sqlCommand.Parameters.Add(new SqlParameter("@BA2project", daycheck.BA2project));
			if(daycheck.BA3project == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA3project", DBNull.Value));
			else
                sqlCommand.Parameters.Add(new SqlParameter("@BA3project", daycheck.BA3project));
			if(daycheck.BA4project == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA4project", DBNull.Value));
			else
                sqlCommand.Parameters.Add(new SqlParameter("@BA4project", daycheck.BA4project));
            if(daycheck.BA5project == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA5project", DBNull.Value));
			else
                sqlCommand.Parameters.Add(new SqlParameter("@BA5project", daycheck.BA5project));
			if(daycheck.BA6project == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA6project", DBNull.Value));
			else
                sqlCommand.Parameters.Add(new SqlParameter("@BA6project", daycheck.BA6project));
			if(daycheck.BA7project == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA7project", DBNull.Value));
			else
                sqlCommand.Parameters.Add(new SqlParameter("@BA7project", daycheck.BA7project));
			if(daycheck.BA8project == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA8project", DBNull.Value));
			else
                sqlCommand.Parameters.Add(new SqlParameter("@BA8project", daycheck.BA8project));
			if(daycheck.BA9project == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA9project", DBNull.Value));
			else
                sqlCommand.Parameters.Add(new SqlParameter("@BA9project", daycheck.BA9project));
            if(daycheck.BA10project == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA10project", DBNull.Value));
			else
                sqlCommand.Parameters.Add(new SqlParameter("@BA10project", daycheck.BA10project));
			if(daycheck.BA1amount == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA1amount", DBNull.Value));
			else
                sqlCommand.Parameters.Add(new SqlParameter("@BA1amount", daycheck.BA1amount));
			if(daycheck.BA2amount == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA2amount", DBNull.Value));
			else
                sqlCommand.Parameters.Add(new SqlParameter("@BA2amount", daycheck.BA2amount));
			if(daycheck.BA3amount == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA3amount", DBNull.Value));
			else
                sqlCommand.Parameters.Add(new SqlParameter("@BA3amount", daycheck.BA3amount));
            if(daycheck.BA4amount == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA4amount", DBNull.Value));
			else
                sqlCommand.Parameters.Add(new SqlParameter("@BA4amount", daycheck.BA4amount));
            if(daycheck.BA5amount == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA5amount", DBNull.Value));
			else
                sqlCommand.Parameters.Add(new SqlParameter("@BA5amount", daycheck.BA5amount));
			if(daycheck.BA6amount == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA6amount", DBNull.Value));
			else
                sqlCommand.Parameters.Add(new SqlParameter("@BA6amount", daycheck.BA6amount));
			if(daycheck.BA7amount == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA7amount", DBNull.Value));
			else
                sqlCommand.Parameters.Add(new SqlParameter("@BA7amount", daycheck.BA7amount));
			if(daycheck.BA8amount == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA8amount", DBNull.Value));
			else
                sqlCommand.Parameters.Add(new SqlParameter("@BA8amount", daycheck.BA8amount));
			if(daycheck.BA9amount == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA9amount", DBNull.Value));
			else
                sqlCommand.Parameters.Add(new SqlParameter("@BA9amount", daycheck.BA9amount));
            if(daycheck.BA10amount == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA10amount", DBNull.Value));
			else
                sqlCommand.Parameters.Add(new SqlParameter("@BA10amount", daycheck.BA10amount));
			sqlCommand.Parameters.Add(new SqlParameter("@nateunit", daycheck.nateunit));
			sqlCommand.Parameters.Add(new SqlParameter("@waiter", daycheck.waiter));
			sqlCommand.Parameters.Add(new SqlParameter("@status", daycheck.status));
			sqlCommand.Parameters.Add(new SqlParameter("@no_service_reason", daycheck.no_service_reason));
            sqlCommand.Parameters.Add(new SqlParameter("@no_service_date", daycheck.no_service_date));

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