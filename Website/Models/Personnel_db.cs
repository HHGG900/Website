using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Website.Models
{
	public class Personnel_db
	{
		private readonly string ConnStr = "Data Source=WIN-6M12QM5R44F;Initial Catalog=webphone;Persist Security Info=True;User ID=sa;Password=1qaz!QAZ;MultipleActiveResultSets=True;Application Name=EntityFramework";

		public List<Personnel> GetPersonnel()
		{
			List<Personnel> personnels = new List<Personnel>();
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand("SELECT TOP 10 * FROM personnel ORDER BY tim DESC");
			sqlCommand.Connection = sqlConnection;
			sqlConnection.Open();

			SqlDataReader reader = sqlCommand.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					Personnel personnel = new Personnel
					{
						name = reader.GetString(reader.GetOrdinal("name")),
						post1 = reader.GetString(reader.GetOrdinal("post1")),
						post2 = reader.GetString(reader.GetOrdinal("post2")),
						six = reader.GetString(reader.GetOrdinal("six")),
						blood = reader.GetString(reader.GetOrdinal("blood")),
						born = reader.GetString(reader.GetOrdinal("born")),
						//signature = reader.GetString(reader.GetOrdinal("signature")),
						ID_number = reader.GetString(reader.GetOrdinal("ID_number")),
						phone = reader.GetString(reader.GetOrdinal("phone")),
						census = reader.GetString(reader.GetOrdinal("census")),
						contact = reader.GetString(reader.GetOrdinal("contact")),
						identity_card_positive = reader.GetString(reader.GetOrdinal("identity_card_positive")),
						identity_card_rebel = reader.GetString(reader.GetOrdinal("identity_card_rebel")),
						education = reader.GetString(reader.GetOrdinal("education")),
						professional_license = reader.GetString(reader.GetOrdinal("professional_license")),
						CPR_training_certificate = reader.GetString(reader.GetOrdinal("CPR_training_certificate")),
						Long_term_work_permit = reader.GetString(reader.GetOrdinal("Long_term_work_permit")),
						related_training1 = reader.GetString(reader.GetOrdinal("related_training1")),
						related_training2 = reader.GetString(reader.GetOrdinal("related_training2")),
						related_training3 = reader.GetString(reader.GetOrdinal("related_training3")),
						related_training4 = reader.GetString(reader.GetOrdinal("related_training4")),
						work_contract_scan = reader.GetString(reader.GetOrdinal("work_contract_scan"))
					};
					personnels.Add(personnel);
				}
			}

			sqlConnection.Close();
			return personnels;
		}


		public void personnel_insert(Personnel personnel)
		{
			string time = DateTime.Now.AddHours(8).ToString("yyyyMMddHmm");
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand(
				@"INSERT INTO personnel (name ,post1 ,post2 ,six ,blood ,born ,signature ,ID_number ,phone ,census ,contact ,identity_card_positive ,identity_card_rebel ,education ,professional_license ,CPR_training_certificate ,Long_term_work_permit , related_training1 , related_training2 , related_training3 , related_training4 , work_contract_scan, tim) 
				VALUES (@name ,@post1 ,@post2 ,@six ,@blood ,@born ,@signature ,@ID_number ,@phone ,@census ,@contact ,@identity_card_positive ,@identity_card_rebel ,@education ,@professional_license ,@CPR_training_certificate ,@Long_term_work_permit , @related_training1 , @related_training2 , @related_training3 , @related_training4 , @work_contract_scan, " + time + ")");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@name", personnel.name));
			sqlCommand.Parameters.Add(new SqlParameter("@post1", personnel.post1));
			sqlCommand.Parameters.Add(new SqlParameter("@post2", personnel.post2));
			sqlCommand.Parameters.Add(new SqlParameter("@six", personnel.six));
			sqlCommand.Parameters.Add(new SqlParameter("@blood", personnel.blood));
			sqlCommand.Parameters.Add(new SqlParameter("@born", personnel.born));
			sqlCommand.Parameters.Add(new SqlParameter("@signature", personnel.signature));
			sqlCommand.Parameters.Add(new SqlParameter("@ID_number", personnel.ID_number));
			sqlCommand.Parameters.Add(new SqlParameter("@phone", personnel.phone));
			sqlCommand.Parameters.Add(new SqlParameter("@census", personnel.census));
			sqlCommand.Parameters.Add(new SqlParameter("@contact", personnel.contact));
			sqlCommand.Parameters.Add(new SqlParameter("@identity_card_positive", personnel.identity_card_positive));
			sqlCommand.Parameters.Add(new SqlParameter("@identity_card_rebel", personnel.identity_card_rebel));
			sqlCommand.Parameters.Add(new SqlParameter("@education", personnel.education));
			sqlCommand.Parameters.Add(new SqlParameter("@professional_license", personnel.professional_license));
			sqlCommand.Parameters.Add(new SqlParameter("@CPR_training_certificate", personnel.CPR_training_certificate));
			sqlCommand.Parameters.Add(new SqlParameter("@Long_term_work_permit", personnel.Long_term_work_permit));
			sqlCommand.Parameters.Add(new SqlParameter("@related_training1", personnel.related_training1));
			sqlCommand.Parameters.Add(new SqlParameter("@related_training2", personnel.related_training2));
			sqlCommand.Parameters.Add(new SqlParameter("@related_training3", personnel.related_training3));
			sqlCommand.Parameters.Add(new SqlParameter("@related_training4", personnel.related_training4));
			sqlCommand.Parameters.Add(new SqlParameter("@work_contract_scan", personnel.work_contract_scan));
			if (personnel.signature == null)
				sqlCommand.Parameters.Add(new SqlParameter("@signature", DBNull.Value));

			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}

		public void personnel_update(Personnel personnel)
		{
			string time = DateTime.Now.AddHours(8).ToString("yyyyMMddHmm");
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand(
			"update personnel set name = @name, post1 = @post1, post2 = @post2, six = @six, blood = @blood, born = @born, phone = @phone, census = @census, contact = @contact, tim = " + time + " WHERE ID_number = @ID_number");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@name", personnel.name));
			sqlCommand.Parameters.Add(new SqlParameter("@post1", personnel.post1));
			sqlCommand.Parameters.Add(new SqlParameter("@post2", personnel.post2));
			sqlCommand.Parameters.Add(new SqlParameter("@six", personnel.six));
			sqlCommand.Parameters.Add(new SqlParameter("@blood", personnel.blood));
			sqlCommand.Parameters.Add(new SqlParameter("@born", personnel.born)); 
			sqlCommand.Parameters.Add(new SqlParameter("@ID_number", personnel.ID_number));
			sqlCommand.Parameters.Add(new SqlParameter("@phone", personnel.phone));
			sqlCommand.Parameters.Add(new SqlParameter("@census", personnel.census));
			sqlCommand.Parameters.Add(new SqlParameter("@contact", personnel.contact));
			sqlCommand.Parameters.Add(new SqlParameter("@signature", personnel.signature));
			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}

		public List<Personnel> personnel_select(string ID_number)
		{
			List<Personnel> personnel = new List<Personnel>();
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM personnel WHERE ID_number = '" + ID_number + "'");
			sqlCommand.Connection = sqlConnection;
			//sqlCommand.Parameters.Add(new SqlParameter("@ID_number", ID_number));
			sqlConnection.Open();

			SqlDataReader reader = sqlCommand.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					Personnel personne = new Personnel
					{
						name = reader.GetString(reader.GetOrdinal("name")),
						post1 = reader.GetString(reader.GetOrdinal("post1")),
						post2 = reader.GetString(reader.GetOrdinal("post2")),
						six = reader.GetString(reader.GetOrdinal("six")),
						blood = reader.GetString(reader.GetOrdinal("blood")),
						born = reader.GetString(reader.GetOrdinal("born")),
						signature = reader.GetString(reader.GetOrdinal("signature")),
						ID_number = reader.GetString(reader.GetOrdinal("ID_number")),
						phone = reader.GetString(reader.GetOrdinal("phone")),
						census = reader.GetString(reader.GetOrdinal("census")),
						contact = reader.GetString(reader.GetOrdinal("contact")),
						identity_card_positive = reader.GetString(reader.GetOrdinal("identity_card_positive")),
						identity_card_rebel = reader.GetString(reader.GetOrdinal("identity_card_rebel")),
						education = reader.GetString(reader.GetOrdinal("education")),
						professional_license = reader.GetString(reader.GetOrdinal("professional_license")),
						CPR_training_certificate = reader.GetString(reader.GetOrdinal("CPR_training_certificate")),
						Long_term_work_permit = reader.GetString(reader.GetOrdinal("Long_term_work_permit")),
						related_training1 = reader.GetString(reader.GetOrdinal("related_training1")),
						related_training2 = reader.GetString(reader.GetOrdinal("related_training2")),
						related_training3 = reader.GetString(reader.GetOrdinal("related_training3")),
						related_training4 = reader.GetString(reader.GetOrdinal("related_training4")),
						work_contract_scan = reader.GetString(reader.GetOrdinal("work_contract_scan"))

					};
					personnel.Add(personne);
				}
			}
			sqlConnection.Close();
			return personnel;
		}
	}
}