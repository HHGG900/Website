using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Website.Models
{
	public class Organization_account_db
	{
		private readonly string ConnStr = "Data Source=WIN-6M12QM5R44F;Initial Catalog=webphone;Persist Security Info=True;User ID=sa;Password=1qaz!QAZ;MultipleActiveResultSets=True;Application Name=EntityFramework";

		public List<Organization_account> GetOrganization_account(string name)
		{
			List<Organization_account> organization_Account = new List<Organization_account>();
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM organization_account where class = (select class from organization_account where name = @name)");
			sqlCommand.Parameters.Add(new SqlParameter("@name", name));
			sqlCommand.Connection = sqlConnection;
			sqlConnection.Open();

			SqlDataReader reader = sqlCommand.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					Organization_account organization_Account1 = new Organization_account
					{
						Id = reader.GetInt32(reader.GetOrdinal("id")),
						unitname = reader.GetString(reader.GetOrdinal("unitname")),
						unitcode = reader.GetString(reader.GetOrdinal("unitcode")),
						name = reader.GetString(reader.GetOrdinal("name")),
						nickname = reader.GetString(reader.GetOrdinal("nickname")),
						phone = reader.GetString(reader.GetOrdinal("phone")),
						status = reader.GetString(reader.GetOrdinal("status")),
						time = reader.GetDateTime(reader.GetOrdinal("time"))
					};
					organization_Account.Add(organization_Account1);
				}
			}
			
			sqlConnection.Close();
			return organization_Account;
		}
		public void organization_account_insert(Organization_account organization_account, string conname)
		{
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			
			SqlCommand sqlCommand = new SqlCommand(
				@"INSERT INTO organization_account (unitname  ,unitcode ,name ,nickname ,phone  ,status,time ,class )
						VALUES(@unitname,@unitcode,@name,@nickname,@phone,@status,@time, (select class from organization_account where name = @classname))");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@unitname", organization_account.unitname));
			sqlCommand.Parameters.Add(new SqlParameter("@unitcode", organization_account.unitcode));
			sqlCommand.Parameters.Add(new SqlParameter("@name", organization_account.name));
			sqlCommand.Parameters.Add(new SqlParameter("@nickname", organization_account.nickname));
			sqlCommand.Parameters.Add(new SqlParameter("@phone", organization_account.phone));
			sqlCommand.Parameters.Add(new SqlParameter("@status", organization_account.status));
			sqlCommand.Parameters.Add(new SqlParameter("@time", organization_account.time));
			sqlCommand.Parameters.Add(new SqlParameter("@classname", conname));
			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
			Update(organization_account.unitname, conname);
			string status = "n";
			String key = organization_account.phone.Substring(organization_account.phone.Length - 5, 5);
			SqlConnection sqlConnection1 = new SqlConnection(ConnStr);
			if (organization_account.status == "正常")
				status = "y";
			SqlCommand sqlCommand1 = new SqlCommand(
				@"INSERT INTO sign_in (usr_index ,usr_name , usr_key, work_yes_no)
				VALUES (@usr_index, @usr_name, @key, @working_yes_no)");
			sqlCommand1.Connection = sqlConnection1;
			sqlCommand1.Parameters.Add(new SqlParameter("@usr_index", organization_account.unitcode));
			sqlCommand1.Parameters.Add(new SqlParameter("@usr_name", organization_account.name));
			sqlCommand1.Parameters.Add(new SqlParameter("@working_yes_no", status));
			sqlCommand1.Parameters.Add(new SqlParameter("@key", key));
			;
			
			sqlConnection1.Open();
			sqlCommand1.ExecuteNonQuery();
			sqlConnection1.Close();
		}
		public void Update(string unitneme, string conname)
		{
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand(
				@"UPDATE organization_account set class = (select class from organization_account where(unitname = @caser_name)) where unitname = @unitname");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@caser_name", conname));
			sqlCommand.Parameters.Add(new SqlParameter("@unitname", unitneme));
			
			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
		public Organization_account organization_account_select(int id)
		{
			Organization_account organization_account = new Organization_account();
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM organization_account WHERE id = @id");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@id", id));
			sqlConnection.Open();

			SqlDataReader reader = sqlCommand.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					organization_account = new Organization_account
					{
						Id = reader.GetInt32(reader.GetOrdinal("id")),
						unitname = reader.GetString(reader.GetOrdinal("unitname")),
						unitcode = reader.GetString(reader.GetOrdinal("unitcode")),
						name = reader.GetString(reader.GetOrdinal("name")),
						nickname = reader.GetString(reader.GetOrdinal("nickname")),
						phone = reader.GetString(reader.GetOrdinal("phone")),
						status = reader.GetString(reader.GetOrdinal("status")),
						time = reader.GetDateTime(reader.GetOrdinal("time"))
					};
				}
			}
			sqlConnection.Close();
			return organization_account;
		}

		public void organization_account_update(Organization_account organization_account)
		{
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand(
				@"UPDATE organization_account SET unitname = @unitname ,unitcode = @unitcode ,name = @name ,nickname = @nickname ,phone = @phone ,status = @status ,time = @time where id = @id");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@unitname", organization_account.unitname));
			sqlCommand.Parameters.Add(new SqlParameter("@unitcode", organization_account.unitcode));
			sqlCommand.Parameters.Add(new SqlParameter("@name", organization_account.name));
			sqlCommand.Parameters.Add(new SqlParameter("@nickname", organization_account.nickname));
			sqlCommand.Parameters.Add(new SqlParameter("@phone", organization_account.phone));
			sqlCommand.Parameters.Add(new SqlParameter("@status", organization_account.status));
			sqlCommand.Parameters.Add(new SqlParameter("@time", organization_account.time));
			sqlCommand.Parameters.Add(new SqlParameter("@id", organization_account.Id));
			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
	}
}