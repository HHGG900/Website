using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Website.Models
{
	public class Exception_notification_db
	{
		private readonly string ConnStr = "Data Source=WIN-6M12QM5R44F;Initial Catalog=webphone;Persist Security Info=True;User ID=sa;Password=1qaz!QAZ;MultipleActiveResultSets=True;Application Name=EntityFramework";

		public List<Exception_notification> GetException_notification(string year)
		{
			DateTime dateTime = new DateTime(Int32.Parse(year) + 1911, 1, 1);
			DateTime dateTime2 = new DateTime(Int32.Parse(year) + 1911, 12, 31);
			List<Exception_notification> exception_notifications = new List<Exception_notification>();
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM exception_notification " +
				"where (tim between @date1 and @date2) order by tim desc");
			sqlCommand.Parameters.Add(new SqlParameter("@date1", dateTime));
			sqlCommand.Parameters.Add(new SqlParameter("@date2", dateTime2));
			sqlCommand.Connection = sqlConnection;
			sqlConnection.Open();

			SqlDataReader reader = sqlCommand.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					Exception_notification exception_notificationrd = new Exception_notification
					{
						id = reader.GetInt32(reader.GetOrdinal("id")).ToString(),
						working_name = reader.GetString(reader.GetOrdinal("working_name")),
						event_description = reader.GetString(reader.GetOrdinal("event_description")),
						exception_class = reader.GetString(reader.GetOrdinal("exception_class")),
						ten_index = tostring(reader, "ten_index"),
						execution = tostring(reader, "execute"),
						tracking = tostring(reader, "track"),
						tim = reader.GetDateTime(reader.GetOrdinal("tim"))
					
				};
					exception_notifications.Add(exception_notificationrd);
				}
			}
			else
			{
				Console.WriteLine("資料庫為空！");
			}
			sqlConnection.Close();
			return exception_notifications;
		}
		public List<Exception_notification> GetException_notification_one(string id)
		{
			List<Exception_notification> exception_notifications = new List<Exception_notification>();
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM exception_notification " +
				"where id = @id order by tim desc");
			sqlCommand.Parameters.Add(new SqlParameter("@id", int.Parse(id)));
			sqlCommand.Connection = sqlConnection;
			sqlConnection.Open();

			SqlDataReader reader = sqlCommand.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					Exception_notification exception_notificationrd = new Exception_notification
					{
						working_name = reader.GetString(reader.GetOrdinal("working_name")),
						event_description = reader.GetString(reader.GetOrdinal("event_description")),
						exception_class = reader.GetString(reader.GetOrdinal("exception_class")),
						ten_index = tostring(reader,"ten_index"),
						execution = tostring(reader,"execute"),
						tracking = tostring(reader, "track"),
						tim = reader.GetDateTime(reader.GetOrdinal("tim"))

					};
					exception_notifications.Add(exception_notificationrd);
				}
			}
			else
			{
				Console.WriteLine("資料庫為空！");
			}
			sqlConnection.Close();
			return exception_notifications;
		}
		public void sign_in_db_insert(Exception_notification exception_notification)
				{
			int id = exception_notification_top_select();
					SqlConnection sqlConnection = new SqlConnection(ConnStr);
					SqlCommand sqlCommand = new SqlCommand(
						@"INSERT INTO exception_notification (working_name,event_description,exception_class,ten_index,tim,id)
						VALUES(@working_name,@event_description,@exception_class,@ten_index,@tim,@id)");
					sqlCommand.Connection = sqlConnection;
					sqlCommand.Parameters.Add(new SqlParameter("@working_name", exception_notification.working_name));
					sqlCommand.Parameters.Add(new SqlParameter("@event_description", exception_notification.event_description));
					sqlCommand.Parameters.Add(new SqlParameter("@exception_class", exception_notification.exception_class));
					if (exception_notification.ten_index == null)
						sqlCommand.Parameters.Add(new SqlParameter("@ten_index", DBNull.Value));
					else
						sqlCommand.Parameters.Add(new SqlParameter("@ten_index", exception_notification.ten_index));
					sqlCommand.Parameters.Add(new SqlParameter("@tim", exception_notification.tim));
					sqlCommand.Parameters.Add(new SqlParameter("@id", id));
					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
				}
		public int exception_notification_top_select()
		{
			Exception_notification exception_notification = new Exception_notification();
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand("SELECT MAX(id+1) as id FROM exception_notification");
			sqlCommand.Connection = sqlConnection;
			sqlConnection.Open();
			int id = 0;
			SqlDataReader reader = sqlCommand.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					id = reader.GetInt32(reader.GetOrdinal("id"));
						
				}
			}
			sqlConnection.Close();
			return id;
		}
		public Exception_notification exception_notification_select(string working_name)
				{
					Exception_notification exception_notification = new Exception_notification();
					SqlConnection sqlConnection = new SqlConnection(ConnStr);
					SqlCommand sqlCommand = new SqlCommand("SELECT * FROM exception_notification WHERE working_name = @working_name");
					sqlCommand.Connection = sqlConnection;
					sqlCommand.Parameters.Add(new SqlParameter("@working_name", working_name));
					sqlConnection.Open();

					SqlDataReader reader = sqlCommand.ExecuteReader();
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							exception_notification = new Exception_notification
							{
								working_name = reader.GetString(reader.GetOrdinal("working_name")),
								event_description = reader.GetString(reader.GetOrdinal("event_description")),
								exception_class = reader.GetString(reader.GetOrdinal("exception_class")),
								ten_index = reader.GetString(reader.GetOrdinal("ten_index")),
								tim = reader.GetDateTime(reader.GetOrdinal("tim"))
							};
						}
					}
					sqlConnection.Close();
					return exception_notification;
				}
		public void exception_notification_update(int id , Exception_notification exception_notification)
		{
			string sql;
			if (id == 0)
			{
				sql = "update exception_notification set [execute] = '"+exception_notification.execution+"' where id = "+exception_notification.id;
			}
			else
				sql = "update exception_notification set track = '"+ exception_notification.tracking + "',state = 'y' where id = '"+exception_notification.id+"'";
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand(sql);
			sqlCommand.Connection = sqlConnection;
			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
		public string tostring(SqlDataReader reader, string ii)
		{
			try { 
				return reader.GetString(reader.GetOrdinal(ii)); 
			}
			catch
			{
				return null;
			}
		}
	}
}