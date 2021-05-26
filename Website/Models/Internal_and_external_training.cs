using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
	public class Internal_and_external_training
	{
		[DisplayName("年度")]
		[Required]
		public string year { get; set; }

		[DisplayName("課程名稱")]
		[Required]
		public string course_title { get; set; }

		[DisplayName("受訓者姓名")]
		[Required]
		public string name { get; set; }

		[DisplayName("訓練類別")]
		[Required]
		public string training_class { get; set; }
        
		[DisplayName("訓練時數")]
		[Required]
		public string hour { get; set; }

		[DisplayName("訓練單位")]
		[Required]
		public string unit { get; set; }

		[DisplayName("證明文件")]
		[Required]
		public string certified_documents { get; set; }

		[DisplayName("年份")]
		[Required]
		public string s_year { get; set; }

		[DisplayName("輸入名")]
		[Required]
		public string s_train_name { get; set; }
		

	}
}