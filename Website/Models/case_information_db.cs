using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Website.Models
{
	public class Case_information_db
	{
		private readonly string ConnStr = "Data Source=WIN-6M12QM5R44F;Initial Catalog=webphone;Persist Security Info=True;User ID=sa;Password=1qaz!QAZ;MultipleActiveResultSets=True;Application Name=EntityFramework";

		public void New_case_information(Case_information case_Information)
		{
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand(
				@"INSERT INTO case_Informatio(name,six,birthday,[identity],telephone,economic,obstacleclass,obstacledegree,contact,phone,notedate,CMS,BA1project,BA2project,BA3project,BA4project,BA5poject,BA6project,BA7project,BA8project,BA9project,BA10project,BA1amount,BA2amount,BA3amount,BA4amount,BA5amount,BA6amount,BA7amount,BA8amount,BA9amount,BA10amount,nateunit,waiter,status,no_service_reason,no_service_date)
				VALUES (@name,@six,@birthday,@identity,@telephone,@economic,@obstacleclass,@obstacledegree,@contact,@phone,@notedate,@CMS,@BA1project,@BA2project,@BA3project,@BA4project,@BA5project,@BA6project,@BA7project,@BA8project,@BA9project,@BA10project,@BA1amount,@BA2amount,@BA3amount,@BA4amount,@BA5amount,@BA6amount,@BA7amount,@BA8amount,@BA9amount,@BA10amount,@nateunit,@waiter,@status,@no_service_reason,@no_service_date)");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@name", case_Information.name));
			sqlCommand.Parameters.Add(new SqlParameter("@six", case_Information.six));
			sqlCommand.Parameters.Add(new SqlParameter("@birthday", case_Information.birthday));
			sqlCommand.Parameters.Add(new SqlParameter("@identity", case_Information.identity));
			sqlCommand.Parameters.Add(new SqlParameter("@telephone", case_Information.telephone));
			sqlCommand.Parameters.Add(new SqlParameter("@economic", case_Information.economic));
			if (case_Information.obstacleclass == null)
				sqlCommand.Parameters.Add(new SqlParameter("@obstacleclass", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@obstacleclass", case_Information.obstacleclass));
			if (case_Information.obstacledegree == null)
				sqlCommand.Parameters.Add(new SqlParameter("@obstacledegree", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@obstacledegree", case_Information.obstacledegree));
			sqlCommand.Parameters.Add(new SqlParameter("@contact", case_Information.contact));
			sqlCommand.Parameters.Add(new SqlParameter("@phone", case_Information.phone));
			sqlCommand.Parameters.Add(new SqlParameter("@notedate", case_Information.notedate));
			sqlCommand.Parameters.Add(new SqlParameter("@CMS", case_Information.CMS));
			if (case_Information.BAList[0] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA1project", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA1project", case_Information.BAList[0]));
			if (case_Information.BAList[2] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA2project", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA2project", case_Information.BAList[2]));
			if (case_Information.BAList[4] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA3project", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA3project", case_Information.BAList[4]));
			if (case_Information.BAList[6] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA4project", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA4project", case_Information.BAList[6]));
			if (case_Information.BAList[8] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA5project", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA5project", case_Information.BAList[8]));
			if (case_Information.BAList[10] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA6project", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA6project", case_Information.BAList[10]));
			if (case_Information.BAList[12] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA7project", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA7project", case_Information.BAList[12]));
			if (case_Information.BAList[14] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA8project", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA8project", case_Information.BAList[14]));
			if (case_Information.BAList[16] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA9project", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA9project", case_Information.BAList[16]));
			if (case_Information.BAList[18] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA10project", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA10project", case_Information.BAList[18]));
			if (case_Information.BAList[1] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA1amount", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA1amount", case_Information.BAList[1]));
			if (case_Information.BAList[3] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA2amount", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA2amount", case_Information.BAList[3]));
			if (case_Information.BAList[5] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA3amount", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA3amount", case_Information.BAList[5]));
			if (case_Information.BAList[7] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA4amount", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA4amount", case_Information.BAList[7]));
			if (case_Information.BAList[9] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA5amount", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA5amount", case_Information.BAList[9]));
			if (case_Information.BAList[11] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA6amount", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA6amount", case_Information.BAList[11]));
			if (case_Information.BAList[13] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA7amount", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA7amount", case_Information.BAList[13]));
			if (case_Information.BAList[15] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA8amount", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA8amount", case_Information.BAList[15]));
			if (case_Information.BAList[17] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA9amount", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA9amount", case_Information.BAList[17]));
			if (case_Information.BAList[19] == null)
				sqlCommand.Parameters.Add(new SqlParameter("@BA10amount", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@BA10amount", case_Information.BAList[19]));
			sqlCommand.Parameters.Add(new SqlParameter("@nateunit", case_Information.nateunit));
			sqlCommand.Parameters.Add(new SqlParameter("@waiter", case_Information.waiter));
			sqlCommand.Parameters.Add(new SqlParameter("@status", case_Information.status));
			if (case_Information.no_service_reason == null)
				sqlCommand.Parameters.Add(new SqlParameter("@no_service_reason", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@no_service_reason", case_Information.no_service_reason));
			if (case_Information.no_service_date == null)
				sqlCommand.Parameters.Add(new SqlParameter("@no_service_date", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@no_service_date", case_Information.no_service_date));

			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}

		public List<Case_information> GetDaycheckByUserId(string usr_index)
		{
			List<Case_information> case_information = new List<Case_information>();
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM case_informatio");
			sqlCommand.Connection = sqlConnection;
			sqlConnection.Open();

			SqlDataReader reader = sqlCommand.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					Case_information case_information1 = new Case_information
					{
						name = reader.GetString(reader.GetOrdinal("name")),
						six = reader.GetString(reader.GetOrdinal("six")),
						birthday = reader.GetString(reader.GetOrdinal("birthday")),
						identity = reader.GetString(reader.GetOrdinal("identity")),
						telephone = reader.GetString(reader.GetOrdinal("telephone")),
						economic = reader.GetString(reader.GetOrdinal("economic")),
						obstacleclass = reader.GetString(reader.GetOrdinal("obstacleclass")),
						obstacledegree = reader.GetString(reader.GetOrdinal("obstacledegree")),
						contact = reader.GetString(reader.GetOrdinal("contact")),
						phone = reader.GetString(reader.GetOrdinal("phone")),
						notedate = reader.GetString(reader.GetOrdinal("notedate")),
						CMS = reader.GetString(reader.GetOrdinal("CMS")),
						BA1project = reader.GetString(reader.GetOrdinal("BA1project")),
						BA2project = reader.GetString(reader.GetOrdinal("BA2project")),
						BA3project = reader.GetString(reader.GetOrdinal("BA3project")),
						BA4project = reader.GetString(reader.GetOrdinal("BA4project")),
						BA5project = reader.GetString(reader.GetOrdinal("BA5project")),
						BA6project = reader.GetString(reader.GetOrdinal("BA6project")),
						BA7project = reader.GetString(reader.GetOrdinal("BA7project")),
						BA8project = reader.GetString(reader.GetOrdinal("BA8project")),
						BA9project = reader.GetString(reader.GetOrdinal("BA9project")),
						BA10project = reader.GetString(reader.GetOrdinal("BA10project")),
						BA1amount = reader.GetString(reader.GetOrdinal("BA1amount")),
						BA2amount = reader.GetString(reader.GetOrdinal("BA2amount")),
						BA3amount = reader.GetString(reader.GetOrdinal("BA3amount")),
						BA4amount = reader.GetString(reader.GetOrdinal("BA4amount")),
						BA5amount = reader.GetString(reader.GetOrdinal("BA5amount")),
						BA6amount = reader.GetString(reader.GetOrdinal("BA6amount")),
						BA7amount = reader.GetString(reader.GetOrdinal("BA7amount")),
						BA8amount = reader.GetString(reader.GetOrdinal("BA8amount")),
						BA9amount = reader.GetString(reader.GetOrdinal("BA9amount")),
						BA10amount = reader.GetString(reader.GetOrdinal("BA10amount")),
						nateunit = reader.GetString(reader.GetOrdinal("nateunit")),
						waiter = reader.GetString(reader.GetOrdinal("waiter")),
						status = reader.GetString(reader.GetOrdinal("status")),
						no_service_reason = reader.GetString(reader.GetOrdinal("no_service_reason")),
						no_service_date = reader.GetString(reader.GetOrdinal("no_service_date")),
					};
					case_information.Add(case_information1);
				}
			}
			sqlConnection.Close();
			return case_information;
		}
	}
}