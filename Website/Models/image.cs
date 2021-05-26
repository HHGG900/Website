using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Website.Models;

namespace Website.Models
{
	public class image
	{
		private readonly string ConnStr = "Data Source=WIN-6M12QM5R44F;Initial Catalog=webphone;Persist Security Info=True;User ID=sa;Password=1qaz!QAZ;MultipleActiveResultSets=True;Application Name=EntityFramework";


		public void AddEmployee(string name, string post1, string post2, string six, string blood, string born, string signature, string ID_number, string phone, string census, string contact, string identity_card_positive, string identity_card_rebel, string education, string professional_license, string CPR_training_certificate, string Long_term_work_permit, string related_training1, string related_training2, string related_training3, string related_training4, string work_contract_scan)
		{ 
			byte[] Related_training1 = GetPhoto(related_training1);
			byte[] Related_training2 = GetPhoto(related_training2);
			byte[] Related_training3 = GetPhoto(related_training3);
			byte[] Related_training4 = GetPhoto(related_training4);
			byte[] Work_contract_scan = GetPhoto(work_contract_scan);
			byte[] Signature = GetPhoto(signature);
			byte[] Identity_card_positive = GetPhoto(identity_card_positive);
			byte[] Identity_card_rebel = GetPhoto(identity_card_rebel);
			byte[] Education = GetPhoto(education);
			byte[] Professional_license = GetPhoto(professional_license);
			byte[] CPR_Training_certificate = GetPhoto(CPR_training_certificate);
			byte[] Long_Term_work_permit = GetPhoto(Long_term_work_permit);

			SqlConnection sqlConnection = new SqlConnection(ConnStr);

			SqlCommand sqlCommand = new SqlCommand("@INSERT into personnel(name, post1, post2, six, blood, born, signature, ID_number, phone, census, contact, identity_card_positive, identity_card_rebel, education, professional_license, CPR_training_certificate, Long_term_work_permit, related_training1, related_training2, related_training3, related_training4, work_contract_scan)"+
				"VALUES(@name, @post1, @post2, @six, @blood, @born, @signature, @ID_number, @phone, @census, @contact, @identity_card_positive, @identity_card_rebel, @education, @professional_license, @CPR_training_certificate, @Long_term_work_permit, @related_training1, @related_training2, @related_training3, @related_training4, @work_contract_scan)");

			sqlCommand.Parameters.Add(new SqlParameter("@name", name));
			sqlCommand.Parameters.Add(new SqlParameter("@post1", post1));
			sqlCommand.Parameters.Add(new SqlParameter("@post2", post2));
			sqlCommand.Parameters.Add(new SqlParameter("@six", six));
			sqlCommand.Parameters.Add(new SqlParameter("@blood", blood));
			sqlCommand.Parameters.Add(new SqlParameter("@born", born));
			sqlCommand.Parameters.Add(new SqlParameter("@signature", Signature));
			sqlCommand.Parameters.Add(new SqlParameter("@ID_number", ID_number));
			sqlCommand.Parameters.Add(new SqlParameter("@phone", phone));
			sqlCommand.Parameters.Add(new SqlParameter("@census", census));
			sqlCommand.Parameters.Add(new SqlParameter("@contact", contact));
			sqlCommand.Parameters.Add(new SqlParameter("@identity_card_positive", Identity_card_positive));
			sqlCommand.Parameters.Add(new SqlParameter("@identity_card_rebel", Identity_card_rebel));
			sqlCommand.Parameters.Add(new SqlParameter("@education", Education));
			sqlCommand.Parameters.Add(new SqlParameter("@professional_license", Professional_license));
			sqlCommand.Parameters.Add(new SqlParameter("@CPR_training_certificate", CPR_Training_certificate));
			sqlCommand.Parameters.Add(new SqlParameter("@Long_term_work_permit", Long_Term_work_permit));
			sqlCommand.Parameters.Add(new SqlParameter("@related_training1", Related_training1));
			sqlCommand.Parameters.Add(new SqlParameter("@related_training2", Related_training2));
			sqlCommand.Parameters.Add(new SqlParameter("@related_training3", Related_training3));
			sqlCommand.Parameters.Add(new SqlParameter("@related_training4", Related_training4));
			sqlCommand.Parameters.Add(new SqlParameter("@work_contract_scan", Work_contract_scan));

			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
		}
		public static byte[] GetPhoto(string filePath)
		{
			FileStream stream = new FileStream(
				filePath, FileMode.Open, FileAccess.Read);
			BinaryReader reader = new BinaryReader(stream);

			byte[] photo = reader.ReadBytes((int)stream.Length);

			reader.Close();
			stream.Close();

			return photo;
		}
	}

		

}
