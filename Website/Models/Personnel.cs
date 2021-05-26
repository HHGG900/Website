using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
	public class Personnel
	{
		public string edit_data { get; set; }
		
		[DisplayName("姓名")]
		
		public string name { get; set; }

		[DisplayName("職務一")]
		public string post1 { get; set; }

		[DisplayName("職務二")]
		public string post2 { get; set; }

        [DisplayName("性別")]
		public string six { get; set; }

		[DisplayName("血型")]
		public string blood { get; set; }

		[DisplayName("出生")]
		public string born { get; set; }

		
        [DisplayName("簽章")]
		public string signature { get; set; }//圖片

		[DisplayName("身分證字號")]
		public string ID_number { get; set; }

		[DisplayName("手機")]
		public string phone { get; set; }

		[DisplayName("戶籍")]
		public string census { get; set; }

        [DisplayName("聯繫方式")]
		public string contact { get; set; }

		
		[DisplayName("身分證正面")]
		public string identity_card_positive { get; set; }//圖片

		[DisplayName("身分證反面")]
		public string identity_card_rebel { get; set; }//圖片

		[DisplayName("最高學歷")]
		public string education { get; set; }//圖片

		[DisplayName("專業證書")]
		public string professional_license { get; set; }//圖片

		[DisplayName("CPR訓練證書")]
		public string CPR_training_certificate { get; set; }//圖片

		[DisplayName("長照工作證")]
		public string Long_term_work_permit { get; set; }//圖片

		[DisplayName("相關證明一")]
		public string related_training1 { get; set; }//圖片

		[DisplayName("相關證明二")]

		public string related_training2 { get; set; }//圖片

		[DisplayName("相關證明三")]
		public string related_training3 { get; set; }//圖片

		[DisplayName("相關證明四")]
		public string related_training4 { get; set; }//圖片

		[DisplayName("工作契約掃描")]
		public string work_contract_scan { get; set; }//圖片

	}
}