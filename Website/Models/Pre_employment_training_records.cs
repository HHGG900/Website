using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
	public class Pre_employment_training_records
	{
		[DisplayName("年度")]
		[Required]
		public string year { get; set; }

		[DisplayName("季")]
		[Required]
		public string season { get; set; }

		[DisplayName("日期")]
		[Required]
		public string date { get; set; }

		[DisplayName("地點")]
		[Required]
		public string location { get; set; }

		[DisplayName("參加者")]
		[Required]
		public string partner { get; set; }

		[DisplayName("照片記錄1")]
		[Required]
		public string picture1 { get; set; }


        [DisplayName("照片紀錄2")]
		[Required]
		public string picture2 { get; set; }

		[DisplayName("內容")]
		[Required]
		public string content { get; set; }

		[DisplayName("學員受訓回饋")]
		[Required]
		public string give_back { get; set; }

	}
}