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
		[DisplayName("�~��")]
		[Required]
		public string year { get; set; }

		[DisplayName("�u")]
		[Required]
		public string season { get; set; }

		[DisplayName("���")]
		[Required]
		public string date { get; set; }

		[DisplayName("�a�I")]
		[Required]
		public string location { get; set; }

		[DisplayName("�ѥ[��")]
		[Required]
		public string partner { get; set; }

		[DisplayName("�Ӥ��O��1")]
		[Required]
		public string picture1 { get; set; }


        [DisplayName("�Ӥ�����2")]
		[Required]
		public string picture2 { get; set; }

		[DisplayName("���e")]
		[Required]
		public string content { get; set; }

		[DisplayName("�ǭ����V�^�X")]
		[Required]
		public string give_back { get; set; }

	}
}