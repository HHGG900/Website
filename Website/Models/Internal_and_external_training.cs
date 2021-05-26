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
		[DisplayName("�~��")]
		[Required]
		public string year { get; set; }

		[DisplayName("�ҵ{�W��")]
		[Required]
		public string course_title { get; set; }

		[DisplayName("���V�̩m�W")]
		[Required]
		public string name { get; set; }

		[DisplayName("�V�m���O")]
		[Required]
		public string training_class { get; set; }
        
		[DisplayName("�V�m�ɼ�")]
		[Required]
		public string hour { get; set; }

		[DisplayName("�V�m���")]
		[Required]
		public string unit { get; set; }

		[DisplayName("�ҩ����")]
		[Required]
		public string certified_documents { get; set; }

		[DisplayName("�~��")]
		[Required]
		public string s_year { get; set; }

		[DisplayName("��J�W")]
		[Required]
		public string s_train_name { get; set; }
		

	}
}