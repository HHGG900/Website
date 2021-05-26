using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Website.Models
{
	public class Assessment_db
	{
		private readonly string ConnStr = "Data Source=WIN-6M12QM5R44F;Initial Catalog=webphone;Persist Security Info=True;User ID=sa;Password=1qaz!QAZ;MultipleActiveResultSets=True;Application Name=EntityFramework";

		public List<Assessment> GetAssessment()
		{
			List<Assessment> assessment = new List<Assessment>();
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand("SELECT TOP 10 * FROM assessment ORDER BY tim DESC");
			sqlCommand.Connection = sqlConnection;
			sqlConnection.Open();

			SqlDataReader reader = sqlCommand.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					Assessment assessment1 = new Assessment
					{
						name = reader.GetString(reader.GetOrdinal("name")),
						year = reader.GetString(reader.GetOrdinal("year")),
						one = reader.GetString(reader.GetOrdinal("one")),
						two = reader.GetString(reader.GetOrdinal("two")),
						there = reader.GetString(reader.GetOrdinal("there")),
						four = reader.GetString(reader.GetOrdinal("four")),
						five = reader.GetString(reader.GetOrdinal("five")),
						six = reader.GetString(reader.GetOrdinal("six")),
						seven = reader.GetString(reader.GetOrdinal("seven")),
						eight = reader.GetString(reader.GetOrdinal("eight")),
						nine = reader.GetString(reader.GetOrdinal("nine")),
						ten = reader.GetString(reader.GetOrdinal("ten")),
						eleven = reader.GetString(reader.GetOrdinal("eleven")),
						twelve = reader.GetString(reader.GetOrdinal("twelve")),
						thirteen = reader.GetString(reader.GetOrdinal("thirteen")),
						fourteen = reader.GetString(reader.GetOrdinal("fourteen")),
						fifteen = reader.GetString(reader.GetOrdinal("fifteen")),
						sixteen = reader.GetString(reader.GetOrdinal("sixteen")),
						seventeen = reader.GetString(reader.GetOrdinal("seventeen")),
						eighteen = reader.GetString(reader.GetOrdinal("eighteen")),
						nineteen = reader.GetString(reader.GetOrdinal("nineteen")),
						twenty = reader.GetString(reader.GetOrdinal("twenty")),
						twentyone = reader.GetString(reader.GetOrdinal("twentyone")),
						twentytwo = reader.GetString(reader.GetOrdinal("twentytwo")),
						twentythere = reader.GetString(reader.GetOrdinal("twentythere")),
						twentyfour = reader.GetString(reader.GetOrdinal("twentyfour")),
						twentyfive = reader.GetString(reader.GetOrdinal("twentyfive")),
						total = reader.GetInt32(reader.GetOrdinal("total")),
						pic = reader.GetString(reader.GetOrdinal("pic"))
					};
					assessment.Add(assessment1);
				}
			}

			sqlConnection.Close();
			return assessment;
		}


		public void Assessment_insert(Assessment assessment)
		{
			string grade = "";
			string rewards = "";

			if (assessment.total >= 95)
			{
				grade = "優等";
				rewards = "給予1個月本薪年終獎金獎勵";
			}
				
			else if (assessment.total >= 85 && assessment.total < 95)
			{
				grade = "甲等";
				rewards = "給予1萬元年終獎金獎勵";
			}
				
			else if (assessment.total >= 75 && assessment.total < 85)
			{
				grade = "乙等";
				rewards = "不予績效獎金獎勵，並實施加強職教育";
			}
				
			else if (assessment.total < 75)
			{
				grade = "丙等";
				rewards = "不予績效獎金獎勵，次年不予續聘";
			}
				

			string time = DateTime.Now.ToString("yyyyMMddHmm");
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand(
				@"INSERT INTO assessment (name ,year ,one ,two ,there ,four ,five ,six ,seven ,eight ,nine ,ten ,eleven ,twelve ,thirteen ,fourteen ,fifteen , sixteen , seventeen , eighteen , nineteen , twenty, twentyone, twentytwo, twentythere, twentyfour, twentyfive, total, pic, tim, grade, rewards) 
				VALUES (@name ,@year ,@one ,@two ,@there ,@four ,@five ,@six ,@seven ,@eight ,@nine ,@ten ,@eleven ,@twelve ,@thirteen ,@fourteen ,@fifteen , @sixteen , @seventeen , @eighteen , @nineteen , @twenty, @twentyone, @twentytwo, @twentythere, @twentyfour, @twentyfive, @total, @pic,'" + time + "','" + grade + "','" + rewards + "')");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@name", assessment.name));
			sqlCommand.Parameters.Add(new SqlParameter("@year", assessment.year));
			sqlCommand.Parameters.Add(new SqlParameter("@one", assessment.one));
			sqlCommand.Parameters.Add(new SqlParameter("@two", assessment.two));
			sqlCommand.Parameters.Add(new SqlParameter("@there", assessment.there));
			sqlCommand.Parameters.Add(new SqlParameter("@four", assessment.four));
			sqlCommand.Parameters.Add(new SqlParameter("@five", assessment.five));
			sqlCommand.Parameters.Add(new SqlParameter("@six", assessment.six));
			sqlCommand.Parameters.Add(new SqlParameter("@seven", assessment.seven));
			sqlCommand.Parameters.Add(new SqlParameter("@eight", assessment.eight));
			sqlCommand.Parameters.Add(new SqlParameter("@nine", assessment.nine));
			sqlCommand.Parameters.Add(new SqlParameter("@ten", assessment.ten));
			sqlCommand.Parameters.Add(new SqlParameter("@eleven", assessment.eleven));
			sqlCommand.Parameters.Add(new SqlParameter("@twelve", assessment.twelve));
			sqlCommand.Parameters.Add(new SqlParameter("@thirteen", assessment.thirteen));
			sqlCommand.Parameters.Add(new SqlParameter("@fourteen", assessment.fourteen));
			sqlCommand.Parameters.Add(new SqlParameter("@fifteen", assessment.fifteen));
			sqlCommand.Parameters.Add(new SqlParameter("@sixteen", assessment.sixteen));
			sqlCommand.Parameters.Add(new SqlParameter("@seventeen", assessment.seventeen));
			sqlCommand.Parameters.Add(new SqlParameter("@eighteen", assessment.eighteen));
			sqlCommand.Parameters.Add(new SqlParameter("@nineteen", assessment.nineteen));
			sqlCommand.Parameters.Add(new SqlParameter("@twenty", assessment.twenty));
			sqlCommand.Parameters.Add(new SqlParameter("@twentyone", assessment.twentyone));
			sqlCommand.Parameters.Add(new SqlParameter("@total", (int)assessment.total));
			if (assessment.twentytwo == null)
				sqlCommand.Parameters.Add(new SqlParameter("@twentytwo", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@twentytwo", assessment.twentytwo));
			if (assessment.twentythere == null)
				sqlCommand.Parameters.Add(new SqlParameter("@twentythere", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@twentythere", assessment.twentythere));
			if (assessment.twentyfour == null)
				sqlCommand.Parameters.Add(new SqlParameter("@twentyfour", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@twentyfour", assessment.twentyfour));
			if (assessment.twentyfive == null)
				sqlCommand.Parameters.Add(new SqlParameter("@twentyfive", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@twentyfive", assessment.twentyfive));
			if (assessment.pic == null)
				sqlCommand.Parameters.Add(new SqlParameter("@pic", DBNull.Value));
			else
				sqlCommand.Parameters.Add(new SqlParameter("@pic", assessment.pic));

			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}

		public void assessment_update(Assessment assessment)
		{
			string time = DateTime.Now.AddHours(8).ToString("yyyyMMddHmm");
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand(
			"update assessment set  (pic = @pic, tim = " + time + ") where (name = @name and year = @year)");
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Parameters.Add(new SqlParameter("@name", assessment.name));
			sqlCommand.Parameters.Add(new SqlParameter("@year", assessment.year));
			sqlCommand.Parameters.Add(new SqlParameter("@pic", assessment.pic));

			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}

		public List<Assessment> assessment_select(string uname, string year)
		{
			List<Assessment> personnel = new List<Assessment>();
			SqlConnection sqlConnection = new SqlConnection(ConnStr);
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM assessment WHERE year = '"+year+"' and (name IN (SELECT name FROM organization_account where class = (select class from organization_account where name = '" + uname + "'))) ORDER BY tim DESC ");
			sqlCommand.Connection = sqlConnection;
			sqlConnection.Open();

			SqlDataReader reader = sqlCommand.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					Assessment assessment1 = new Assessment
					{
						name = reader.GetString(reader.GetOrdinal("name")),
						year = reader.GetString(reader.GetOrdinal("year")),
						one = reader.GetString(reader.GetOrdinal("one")),
						two = reader.GetString(reader.GetOrdinal("two")),
						there = reader.GetString(reader.GetOrdinal("there")),
						four = reader.GetString(reader.GetOrdinal("four")),
						five = reader.GetString(reader.GetOrdinal("five")),
						six = reader.GetString(reader.GetOrdinal("six")),
						seven = reader.GetString(reader.GetOrdinal("seven")),
						eight = reader.GetString(reader.GetOrdinal("eight")),
						nine = reader.GetString(reader.GetOrdinal("nine")),
						ten = reader.GetString(reader.GetOrdinal("ten")),
						eleven = reader.GetString(reader.GetOrdinal("eleven")),
						twelve = reader.GetString(reader.GetOrdinal("twelve")),
						thirteen = reader.GetString(reader.GetOrdinal("thirteen")),
						fourteen = reader.GetString(reader.GetOrdinal("fourteen")),
						fifteen = reader.GetString(reader.GetOrdinal("fifteen")),
						sixteen = reader.GetString(reader.GetOrdinal("sixteen")),
						seventeen = reader.GetString(reader.GetOrdinal("seventeen")),
						eighteen = reader.GetString(reader.GetOrdinal("eighteen")),
						nineteen = reader.GetString(reader.GetOrdinal("nineteen")),
						twenty = reader.GetString(reader.GetOrdinal("twenty")),
						twentyone = reader.GetString(reader.GetOrdinal("twentyone")),
						twentytwo = reader.GetString(reader.GetOrdinal("twentytwo")),
						twentythere = reader.GetString(reader.GetOrdinal("twentythere")),
						twentyfour = reader.GetString(reader.GetOrdinal("twentyfour")),
						twentyfive = reader.GetString(reader.GetOrdinal("twentyfive")),
						gettotal = reader.GetInt32(reader.GetOrdinal("total")),
						pic = reader.GetString(reader.GetOrdinal("pic")),
						grade = reader.GetString(reader.GetOrdinal("grade")),
						rewards = reader.GetString(reader.GetOrdinal("rewards")),
						tim = reader.GetString(reader.GetOrdinal("tim")),
					};
					personnel.Add(assessment1);
				}
			}
			sqlConnection.Close();
			return personnel;
		}
	}
}