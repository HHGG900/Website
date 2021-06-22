using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Website.Models;
using System.IO;

namespace Website.Controllers
{
	public class HomeController : Controller
	{
		webphoneEntities3 db = new webphoneEntities3();
		// GET: Home
		public ActionResult Index()
		{
			var usr_name = db.sign_in.ToList();
			if (Session["usr_name"] == null)
			{
				return View("Index");
			}
			return View();
		}
		//登入畫面
		public ActionResult Login()
		{
			ViewBag.post1 = TempData["post1"];
			ViewBag.post2 = TempData["post2"];
			ViewBag.name = TempData["name"];

			TempData.Keep("name");
			return View();
		}
	 	[HttpPost]
		public ActionResult Login(Sign_in sign_in)
		{
			string usr_index = sign_in.usr_index;
			string usr_key = sign_in.usr_key;
			string usr_name = sign_in.usr_name;
			string post1 = "";
			string post2 = "";
			Sign_in_db sign_db = new Sign_in_db();
			List<Sign_in> sign = new List<Sign_in>();
			sign = sign_db.sign_in_select(usr_index, usr_key, usr_name);
			
			//抓去職位名
			foreach (Sign_in sig in sign)
			{
				if (sig.post1 != "")
					post1 = sig.post1;
				if(sig.post2 != "")
					post2 = sig.post2;
			}	
			TempData["post1"] = post1;
			TempData["post2"] = post2;
			TempData["name"] = usr_name;
			TempData["index"] = usr_index;
			return RedirectToAction("Login");
		}
		//登入測試
		public ActionResult Logintest()
		{
			return View();
		}
		//Get:Home/Register
	/*	public ActionResult Register()
		{
			return View();
		}
		//Post:Home/Register
		[HttpPost]
		public ActionResult Register(sign_in sign_in)
		{
			//若模型沒有通過驗證則顯示目前的View
			if (ModelState.IsValid == false)
			{
				return View();
			}
			// 依帳號取得會員並指定給member
			var member = db.sign_in
				.Where(m => m.usr_index == sign_in.usr_index)
				.FirstOrDefault();
			//若member為null，表示會員未註冊
			if (member == null)
			{
				//將會員記錄新增到tMember資料表
				db.sign_in.Add(sign_in);
				db.SaveChanges();
				//執行Home控制器的Login動作方法
				return RedirectToAction("Login");
			}
			ViewBag.Message = "此帳號己有人使用，註冊失敗";
			return View();
		}
	*/
		//Get:Index/Logout
		//登出
		public ActionResult Logout()
		{
			Session.Clear();  //清除Session變數資料
			return RedirectToAction("Login");
		}
		//主任工作手冊
		public ActionResult DirectorHandbook()
		{
			ViewBag.name = TempData["name"];
			TempData.Keep("name");
			return View();
		}
		//主任主頁面
		public ActionResult Director()
		{
			ViewBag.name = TempData["name"];
			TempData.Keep("name");
			return View();
		}
		[HttpPost]
		public ActionResult Director(Daycheck daycheck)
		{
			worker_arrive_db worker_db = new worker_arrive_db();
			Daycheck_db daycheck_db = new Daycheck_db();
			daycheck.tim = DateTime.Now.Date;
			if(daycheck.workButton == "on")
			{
				daycheck.usr_index = TempData["index"] as string;
				daycheck.usr_name = TempData["name"] as string;
				daycheck_db.NewDaycheck(daycheck);
				worker_db.worker_arrive_insert(TempData["name"] as string);
				TempData.Keep();
			}
			if (daycheck.offworkButton == "on")
			{
				daycheck.usr_index = TempData["index"] as string;
				daycheck.usr_name = TempData["name"] as string;
				worker_db.worker_arrive_update(TempData["name"] as string);
				TempData.Keep();
			}

			return RedirectToAction("Director");
		}
		//計畫管理
		public ActionResult Planmanagement()
		{
			return View();
		}

		//報表檢核
		public ActionResult Report_review()
		{
			return View();
		}


		//財務管理
		public ActionResult Financial_Management()
		{
			return View();
		}

		//財務計畫
		public ActionResult Financialplan()
		{
			return View();
		}
		//報稅
		public ActionResult Taxreturn()
		{
			return View();
		}
		//人事資料
		public ActionResult HRmanagement()
		{
			Personnel_db personnel_db = new Personnel_db();
			List<Personnel> personnels = personnel_db.GetPersonnel();
			ViewBag.personnels = personnels;
			ViewBag.name = TempData["name"];
			TempData.Keep("name");
		
			return View();
		}
		[HttpPost]
		public ActionResult HRmanagement(Personnel personnel, HttpPostedFileBase signature, HttpPostedFileBase identity_card_positive,
			HttpPostedFileBase identity_card_rebel, HttpPostedFileBase education, HttpPostedFileBase professional_license,
			HttpPostedFileBase CPR_training_certificate, HttpPostedFileBase Long_term_work_permit, HttpPostedFileBase related_training1,
			HttpPostedFileBase related_training2, HttpPostedFileBase related_training3, HttpPostedFileBase related_training4,
			HttpPostedFileBase work_contract_scan)
		{
			if (personnel.edit_data == null)
			{
				personnel.signature = string.Format("signature-{0}-{1}.jpg", personnel.name, DateTime.Now.ToString("yyyyMMddHmm"));
				personnel.identity_card_positive = string.Format("identity_card_positive-{0}-{1}.jpg", personnel.name, DateTime.Now.ToString("yyyyMMddHmm"));
				personnel.identity_card_rebel = string.Format("identity_card_rebel-{0}-{1}.jpg", personnel.name, DateTime.Now.ToString("yyyyMMddHmm"));
				personnel.education = string.Format("education-{0}-{1}.jpg", personnel.name, DateTime.Now.ToString("yyyyMMddHmm"));
				personnel.professional_license = string.Format("professional_license-{0}-{1}.jpg", personnel.name, DateTime.Now.ToString("yyyyMMddHmm"));
				personnel.CPR_training_certificate = string.Format("CPR_training_certificate-{0}-{1}.jpg", personnel.name, DateTime.Now.ToString("yyyyMMddHmm"));
				personnel.Long_term_work_permit = string.Format("Long_term_work_permit-{0}-{1}.jpg", personnel.name, DateTime.Now.ToString("yyyyMMddHmm"));
				personnel.related_training1 = string.Format("related_training1-{0}-{1}.jpg", personnel.name, DateTime.Now.ToString("yyyyMMddHmm"));
				personnel.related_training2 = string.Format("related_training2-{0}-{1}.jpg", personnel.name, DateTime.Now.ToString("yyyyMMddHmm"));
				personnel.related_training3 = string.Format("related_training3-{0}-{1}.jpg", personnel.name, DateTime.Now.ToString("yyyyMMddHmm"));
				personnel.related_training4 = string.Format("related_training4-{0}-{1}.jpg", personnel.name, DateTime.Now.ToString("yyyyMMddHmm"));
				personnel.work_contract_scan = string.Format("work_contract_scan-{0}-{1}.jpg", personnel.name, DateTime.Now.ToString("yyyyMMddHmm"));
				Personnel_db personnel_db = new Personnel_db();
				personnel_db.personnel_insert(personnel);
				if (personnel.post1 == "居家服務員" || personnel.post2 == "居家服務員")
				{
					Roster_db roster = new Roster_db();
					roster.Roster_insert(personnel.name);
				}
				string fileName = "";
				if (signature != null)
				{
					if (signature.ContentLength > 0)
					{
						fileName = Path.GetFileName(signature.FileName);
						var path = Path.Combine(Server.MapPath("~/Photos"), personnel.signature);
						signature.SaveAs(path);
					}
				}
				if (identity_card_positive != null)
				{
					if (identity_card_positive.ContentLength > 0)
					{
						fileName = Path.GetFileName(identity_card_positive.FileName);
						var path = Path.Combine(Server.MapPath("~/Photos"), personnel.identity_card_positive);
						identity_card_positive.SaveAs(path);
					}
				}
				if (identity_card_rebel != null)
				{
					if (identity_card_rebel.ContentLength > 0)
					{
						fileName = Path.GetFileName(identity_card_rebel.FileName);
						var path = Path.Combine(Server.MapPath("~/Photos"), personnel.identity_card_rebel);
						identity_card_rebel.SaveAs(path);
					}
				}
				if (education != null)
				{
					if (education.ContentLength > 0)
					{
						fileName = Path.GetFileName(education.FileName);
						var path = Path.Combine(Server.MapPath("~/Photos"), personnel.education);
						education.SaveAs(path);
					}
				}
				if (CPR_training_certificate != null)
				{
					if (CPR_training_certificate.ContentLength > 0)
					{
						fileName = Path.GetFileName(CPR_training_certificate.FileName);
						var path = Path.Combine(Server.MapPath("~/Photos"), personnel.CPR_training_certificate);
						CPR_training_certificate.SaveAs(path);
					}
				}
				if (Long_term_work_permit != null)
				{
					if (Long_term_work_permit.ContentLength > 0)
					{
						fileName = Path.GetFileName(Long_term_work_permit.FileName);
						var path = Path.Combine(Server.MapPath("~/Photos"), personnel.Long_term_work_permit);
						Long_term_work_permit.SaveAs(path);
					}
				}
				if (related_training1 != null)
				{
					if (related_training1.ContentLength > 0)
					{
						fileName = Path.GetFileName(related_training1.FileName);
						var path = Path.Combine(Server.MapPath("~/Photos"), personnel.related_training1);
						related_training1.SaveAs(path);
					}
				}
				if (related_training2 != null)
				{
					if (related_training2.ContentLength > 0)
					{
						fileName = Path.GetFileName(related_training2.FileName);
						var path = Path.Combine(Server.MapPath("~/Photos"), personnel.related_training2);
						related_training2.SaveAs(path);
					}
				}
				if (related_training3 != null)
				{
					if (related_training3.ContentLength > 0)
					{
						fileName = Path.GetFileName(related_training3.FileName);
						var path = Path.Combine(Server.MapPath("~/Photos"), personnel.related_training3);
						related_training3.SaveAs(path);
					}
				}
				if (related_training4 != null)
				{
					if (related_training4.ContentLength > 0)
					{
						fileName = Path.GetFileName(related_training4.FileName);
						var path = Path.Combine(Server.MapPath("~/Photos"), personnel.related_training4);
						related_training4.SaveAs(path);
					}
				}
				if (work_contract_scan != null)
				{
					if (work_contract_scan.ContentLength > 0)
					{
						fileName = Path.GetFileName(work_contract_scan.FileName);
						var path = Path.Combine(Server.MapPath("~/Photos"), personnel.work_contract_scan);
						work_contract_scan.SaveAs(path);
					}
				}


				return RedirectToAction("HRmanagement");
			}
			else
			{
				TempData["update_name"] = personnel.edit_data;
				return RedirectToAction("HRmanagement_Edit");
			}
		}
		//人事資料編輯頁面
		public ActionResult HRmanagement_Edit()
		{
			Personnel_db personnel_db = new Personnel_db();
			List<Personnel> personnel = personnel_db.personnel_select(TempData["update_name"] as string);
			ViewBag.personnels = personnel;
			var edit = new Website.Models.Personnel();
			return View(edit);
		}
		[HttpPost]
		public ActionResult HRmanagement_Edit(Personnel personnel)
		{
			Personnel_db personnel_db = new Personnel_db();
			personnel_db.personnel_update(personnel);
			return RedirectToAction("HRmanagement");
		}



		// 人事契約(聘僱合約)-列印
		public ActionResult HRmanagement_print()
		{
			return View();
		}

		//職前訓練
		public ActionResult Pre_employment_training()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Pre_employment_training(Pre_employment_training_records pre_employment_training_records, HttpPostedFileBase picture1, HttpPostedFileBase picture2 ,HttpPostedFileBase content , HttpPostedFileBase give_back)
		{
			Pre_employment_training_records_db pre_employment_training_records_db = new Pre_employment_training_records_db();

			pre_employment_training_records.picture1 = string.Format("pre_employment_training_records-picture1-{0}-{1}.jpg", pre_employment_training_records.partner, DateTime.Now.ToString("yyyyMMddHmm"));
			pre_employment_training_records.picture2 = string.Format("pre_employment_training_records-picture2-{0}-{1}.jpg", pre_employment_training_records.partner, DateTime.Now.ToString("yyyyMMddHmm"));

			pre_employment_training_records_db.pre_employment_training_records_insert(pre_employment_training_records);
			string fileName ="";
			if (picture1 != null)
			{
				if (picture1.ContentLength > 0)
				{
					fileName = Path.GetFileName(picture1.FileName);
					var path = Path.Combine(Server.MapPath("~/Photos"), pre_employment_training_records.picture1);
					picture1.SaveAs(path);
				}
			}
			if (picture2 != null)
			{
				if (picture2.ContentLength > 0)
				{
					fileName = Path.GetFileName(picture2.FileName);
					var path = Path.Combine(Server.MapPath("~/Photos"), pre_employment_training_records.picture2);
					picture2.SaveAs(path);
				}
			}
			
			return RedirectToAction("Pre_employment_training");
		}


		//單位帳號管理
		public ActionResult Organization_account_management()
		{
			ViewBag.inf = TempData["name"];
			TempData.Keep("name");
			Organization_account_db organization_accountn_db = new Organization_account_db();
			List<Organization_account> organization_accounts = organization_accountn_db.GetOrganization_account(ViewBag.inf);
			ViewBag.organization_accounts = organization_accounts;
			
			return View();
		}
		[HttpPost]
		public ActionResult Organization_account_management(Organization_account organization_account )
		{
			Organization_account_db organization_accountn_db = new Organization_account_db();
			string name = "";
			if(TempData.ContainsKey("name"))
				name = TempData["name"] as string;
				TempData.Keep("name");
			organization_accountn_db.organization_account_insert(organization_account, name);
			return RedirectToAction("Organization_account_management");
		}

		//單位帳號編輯
		public ActionResult Organization_account_management_Edit(int id)
		{
			Organization_account_db organization_accountn_db = new Organization_account_db();
			Organization_account organization_account = organization_accountn_db.organization_account_select(id);
			return View(organization_account);
		}
		[HttpPost]
		public ActionResult Organization_account_management_Edit(Organization_account organization_account)
		{
			Organization_account_db organization_accountn_db = new Organization_account_db();
			organization_accountn_db.organization_account_update(organization_account);
			return RedirectToAction("Organization_account_management");
		}

		bool a = true;
		//內外訓登錄
		public ActionResult training()
		{
			//if (a == true){
			//Internal_and_external_training_db internal_and_external_training_db = new Internal_and_external_training_db();
			//List<Internal_and_external_training> training = internal_and_external_training_db.internal_and_external_training_db_select_all();
			//ViewBag.training = training;
			//	a = false;
			//}
			ViewBag.training = TempData["aa"];
			return View();
		}
			[HttpPost]
			public ActionResult training(Internal_and_external_training internal_and_external_training, HttpPostedFileBase certified_documents)
			{
				internal_and_external_training.certified_documents = string.Format("training-certified_documents-{0}-{1}.jpg", internal_and_external_training.name, DateTime.Now.ToString("yyyyMMddHmm"));
				if (internal_and_external_training.s_year == null)
				{
					var path = Path.Combine(Server.MapPath("~/training"), internal_and_external_training.certified_documents);
					certified_documents.SaveAs(path);
					Internal_and_external_training_db internal_and_external_training_db = new Internal_and_external_training_db();
					internal_and_external_training_db.internal_and_external_training_insert(internal_and_external_training);
					a = true;
				}
				else
			{
				Internal_and_external_training_db internal_and_external_training_db = new Internal_and_external_training_db();
				List<Internal_and_external_training> training = internal_and_external_training_db.internal_and_external_training_db_select(internal_and_external_training.s_year, internal_and_external_training.s_train_name);
				ViewBag.training = training;
				TempData["aa"] = training;
			}
				
			return RedirectToAction("training");
			}
		/*	public string Showtraining()
			{
				string show = "";
				DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/training"));
				FileInfo[] fInfo = dir.GetFiles();
				int n = 0;
				foreach (FileInfo result in fInfo)
				{
					n++;
					show += "<a href='../training/" + result.Name + " ' target='_blank'><img src='../training/" + result.Name + "'width='90' height='60' border='0'></a>";
					if (n % 4 == 0)
					{
						show += "<p>";
					}
				}
				show += "<p><a href='training'>返回</a></p>";
				return show;

			}*/


		//員工出勤
		public ActionResult Staffattendance()
		{
			List<worker_arrive> Worker_arrive = TempData["worker_arrive"] as List<worker_arrive>;
			ViewBag.Worker_arrive = Worker_arrive;
			TempData.Keep("worker_arrive");
			return View();
		}
		[HttpPost]
		public ActionResult Staffattendance(worker_arrive worker_arrive1)
		{
			worker_arrive_db worker_db = new worker_arrive_db();
			List< worker_arrive> Worker_arrive = worker_db.worker_arrive_select(TempData["name"] as string, worker_arrive1.time1, worker_arrive1.time2);
			TempData["worker_arrive"] = Worker_arrive;
			TempData.Keep();

			return RedirectToAction("Staffattendance");
		}

		//人事考核
		public ActionResult Personnelassessment()
		{
			ViewBag.year = TempData["year"] as string;
			ViewBag.name = TempData["name"] as string;
			TempData.Keep();
			List<Assessment> assessments = TempData["assess"] as List<Assessment>;
			ViewBag.assessments = assessments;
			return View();
		}
		[HttpPost]
			public ActionResult Personnelassessment(string years)
			{
			Assessment_db assessment_db = new Assessment_db();
			string uname = TempData["name"] as string;
			List< Assessment> assessments =  assessment_db.assessment_select(uname , years);
			TempData.Keep();
			TempData["year"] = years;
			TempData["assess"] = assessments;
			//string fileName = "";
			//if (photo != null)
			//{
			//	if (photo.ContentLength > 0)
			//	{
			//		fileName = Path.GetFileName(photo.FileName);
			//		var path = Path.Combine(Server.MapPath("~/Personnelassessment"), fileName);
			//		photo.SaveAs(path);
			//	}
			//}
			return Json("Home/Personnelassessment");
		}
		/*	public string ShowPersonnelassessment()
			{
				string show = "";
				DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Personnelassessment"));
				FileInfo[] fInfo = dir.GetFiles();
				int n = 0;
				foreach (FileInfo result in fInfo)
				{
					n++;
					show += "<a href='../Personnelassessment/" + result.Name + " ' target='_blank'><img src='../Personnelassessment/" + result.Name + "'width='90' height='60' border='0'></a>";
					if (n % 4 == 0)
					{
						show += "<p>";
					}
				}
				show += "<p><a href='Personnelassessment'>返回</a></p>";
				return show;
			}*/
		//主任自我考核表
		public ActionResult Directorselfassessment()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Directorselfassessment(string name, string years, string[] deta, float total)
		{
			Assessment assessment = new Assessment();
			assessment.name = name;
			assessment.year = years;
			assessment.total = total;
			assessment.one = deta[0];
			assessment.two = deta[1];
			assessment.there = deta[2];
			assessment.four = deta[3];
			assessment.five = deta[4];
			assessment.six = deta[5];
			assessment.seven = deta[6];
			assessment.eight = deta[7];
			assessment.nine = deta[8];
			assessment.ten = deta[9];
			assessment.eleven = deta[10];
			assessment.twelve = deta[11];
			assessment.thirteen = deta[12];
			assessment.fourteen = deta[13];
			assessment.fifteen = deta[14];
			assessment.sixteen = deta[15];
			assessment.seventeen = deta[16];
			assessment.eighteen = deta[17];
			assessment.nineteen = deta[18];
			assessment.twenty = deta[19];
			assessment.twentyone = deta[20];
			assessment.twentytwo = deta[21];
			assessment.twentythere = deta[22];
			assessment.twentyfour = deta[23];
			assessment.twentyfive = deta[24];
			Assessment_db assessment_db = new Assessment_db();
			assessment_db.Assessment_insert(assessment);
			
			return Json(Url.Action("Personnelassessment", "Home"));
		}
		//[HttpPost]
		//public ActionResult Directorselfassessment(Assessment assessment)
		//{
		//	Assessment_db assessment_db = new Assessment_db();
		//	assessment_db.Assessment_insert(assessment);
		//	return RedirectToAction("Personnelassessment");
		//}
	//督導考核表
	public ActionResult SupervisionAssessmentForm()
		{
			return View();
		}
		//居家服務員考核表
		public ActionResult HomeWaiterAssessmentForm()
		{
			return View();
		}
		//保險安全管理
		public ActionResult Insurance_security_management()
		{
			return View();
		}
		//申訴管理
		public ActionResult Grievancemanagement()
		{
			return View();
		}
		//申訴處理表 - 第一步
		public ActionResult Firststep()
		{
			return View();
		}
		//申訴處理表 - 第二步

		public ActionResult Secondstep()
		{
			return View();
		}
		//申訴處理表 - 第三步

		public ActionResult Thirdtep()
		{
			return View();
		}
		//申訴處理表 - 第四步

		public ActionResult fourthstep()
		{
			return View();
		}
		//支出流水帳
		public ActionResult Expenditureregister()
		{
			return View();
		}
		//照顧收費
		public ActionResult Carecharge()
		{
			return View();
		}
		//照顧核銷
		public ActionResult License_verification()
		{
			return View();
		}
		//財產登錄
		public ActionResult Property_registration()
		{
			return View();
		}
		//社區連結工作
		public ActionResult Link_work()
		{
			return View();
		}
		//資源緊密合作
		public ActionResult Resource_teamwork()
		{
			return View();
		}
		//社區宣導
		public ActionResult Community_advocacy()
		{
			return View();
		}
		//內規管理
		public ActionResult Internal_regulations()
		{
			return View();
		}
		//員工工作手冊1
		public ActionResult Employee_Handbook_1()
		{
			return View();
		}
		//員工工作手冊2
		public ActionResult Employee_Handbook_2()
		{
			return View();
		}
		//員工工作手冊3
		public ActionResult Employee_Handbook_3()
		{
			return View();
		}
		//員工工作手冊4
		public ActionResult Employee_Handbook_4()
		{
			return View();
		}
		//員工工作手冊5
		public ActionResult Employee_Handbook_5()
		{
			return View();
		}
		//財務會計制度
		public ActionResult Financial_Management_Method()
		{
			return View();
		}
		//財產管理辦法
		public ActionResult	Property_Management_Method()
		{
			return View();
		}
		//個資保安辦法
		public ActionResult Personal_information_Method()
		{
			return View();
		}
		//員工工作安全辦法
		public ActionResult Work_safety_measures_for_employees()
		{
			return View();
		}
		//職務代理要點
		public ActionResult Key_points_of_job_agency()
		{
			return View();
		}
		//員工福利制度
		public ActionResult Employee_benefits()
		{
			return View();
		}
		//評鑑查核
		public ActionResult Evaluation_area()
		{
			return View();
		}
		//評鑑專區 第一大項 
		public ActionResult The_first_Organization_management()
		{
			return View();
		}
		/*(缺轉檔格式)*/
		//評鑑專區 第二大項 
		public ActionResult The_second_Professional_management()
		{
			return View();
		}
		//評鑑專區 第三大項 
		public ActionResult The_third_human_resource_management()
		{
			return View();
		}
		//評鑑專區 第四大項 
		public ActionResult The_Fourth_Improvement_and_innovation()
		{
			return View();
		}










		//督導工作手冊
		public ActionResult SuperviseHandbook()
		{
			return View();
		}
		//督導主頁面
		public ActionResult Supervise()
		{
			ViewBag.username = TempData["name"] as string;
			TempData.Keep();
			return View();
		}
		[HttpPost]
		public ActionResult Supervise(Daycheck daycheck)
		{
			worker_arrive_db worker_db = new worker_arrive_db();
			Daycheck_db daycheck_db = new Daycheck_db();
			daycheck.tim = DateTime.Now.Date;
			if (daycheck.workButton == "on")
			{
				daycheck.usr_index = TempData["index"] as string;
				daycheck.usr_name = TempData["name"] as string;
				daycheck_db.NewDaycheck(daycheck);
				worker_db.worker_arrive_insert(TempData["name"] as string);
				TempData.Keep();
			}
			if (daycheck.offworkButton == "on")
			{
				daycheck.usr_index = TempData["index"] as string;
				daycheck.usr_name = TempData["name"] as string;
				worker_db.worker_arrive_update(TempData["name"] as string);
				TempData.Keep();
			}

			return RedirectToAction("Supervise");
		}
		//個案排班須知
		public ActionResult Case_scheduling()
		{
			return View();
		}

		//排班原則(新增班表)
		public ActionResult New_class_schedule()
		{
			Roster_db roser_db = new Roster_db();
			if (TempData["roser"] == null)
			{
				List<Roser> lists = roser_db.Roser_select_time();
				TempData["roser"] = lists;
			}
			
			ViewBag.roser = TempData["roser"];
			ViewBag.roser_list = TempData["roser_list"];
			return View();
		}
		[HttpPost]
		public ActionResult New_class_schedule(Roser roster)
		{
			Roster_db roser_db = new Roster_db();
			if(roster.in_time != null)
			{
				List< Roser> roster1 = roser_db.Roser_select_time(roster.in_time);
				TempData["roser"] = roster1;
				TempData["tr"] = true;
			}
			if(roster.in_name != null)
			{
				List<Roser> roster1 = roser_db.Roster_select_name(roster.in_name);
				TempData["roser_list"] = roster1;
				TempData["tr"] = false;
				TempData["work_name"] = roster.in_name;
			}
			if (roster.one_one != null)
			{
				TempData["tr"] = true;
				roser_db.Roster_update(roster, TempData["work_name"] as string);
				TempData.Keep("work_name");
				List<Roser> roster1 = roser_db.Roster_select_name(TempData["work_name"] as string);
				TempData["roser_list"] = roster1;
			}
				
			TempData["in_tim"] = roster.in_time;
			return RedirectToAction("New_class_schedule");
			//if (roster.in_name != null)
			//{

			//}

		}

		//個案資料
		public ActionResult Case_information()
		{
			ViewBag.name = TempData["name"] as string;
			TempData.Keep();
			Personnel_db personnel_Db = new Personnel_db();
			List<Personnel> personnels = personnel_Db.personnel_select_worker(ViewBag.name);

			Case_information_db case_Information = new Case_information_db();
			List<Case_informatio> list1 = case_Information.Get_Case_informatio("停案");
			List<Case_informatio> list2 = case_Information.Get_Case_informatio("穩定服務");
			List<Case_informatio> list3 = case_Information.Get_Case_informatio("結案");
			ViewBag.case1 = list1;
			ViewBag.case2 = list2;
			ViewBag.case3 = list3;
			ViewBag.personnel = personnels;
			return View();
		}
		[HttpPost]
		public ActionResult Case_information(Case_informatio case_Information)
		{
			Case_information_db case_Information_Db = new Case_information_db();
			case_Information_Db.New_case_information(case_Information, TempData["name"] as string);
			TempData.Keep();
			return Json(Url.Action("Case_information"));
		}
		//個案新進
		public ActionResult New_cases()
		{
			return View();
		}
		//個案新進列印
		public ActionResult New_cases_print()
		{
			return View();
		}
		//評估計畫-個案選擇
		public ActionResult Assessing_care_plan_selection_cases()
		{
			return View();
		}
		//初評計畫內容
		public ActionResult conversation_record()
		{
			return View();
		}
		//複評計畫內容
		public ActionResult conversation_record2()
		{
			return View();
		}



		//個案紀錄
		public ActionResult Assessing_care_plan_selection_cases_information()
		{
			return View();
		}

		//初評
		public ActionResult First_care_plan()
		{
			return View();
		}
		//主動關懷訪視
		public ActionResult Visit()
		{
			return View();
		}
		//主動關懷訪視next
		public ActionResult Visit_information()
		{
			return View();
		}
		//異常處理
		public ActionResult abnormal_event_process()
		{
			return View();
		}
		//異常處理 第一步驟
		public ActionResult abnormal_event_process_one()
		{
			return View();
		}
		//異常處理 第二步驟
		public ActionResult abnormal_event_process_two()
		{
			return View();
		}
		//異常處理 第三步驟
		public ActionResult abnormal_event_process_three()
		{
			return View();
		}


		//流行疫苗管理
		public ActionResult Sense_control()
		{
			return View();
		}

		//自我感控報表
		public ActionResult Sense_control_Report()
		{
			return View();
		}


		//會議舉行
		public ActionResult meeting()
		{
			return View();
		}


		//工作會議紀錄
		public ActionResult meeting_Record()
		{
			return View();
		}


		//服務滿意度管理
		public ActionResult Satisfaction_improvement_meeting()
		{
			return View();
		}
		//教育訓練
		public ActionResult Education_Training()
		{
			return View();
		}
		//職前訓練
		public ActionResult Pre_employment_training_Supervise()
		{
			return View();
		}
			//在職訓練計畫與紀錄
			public ActionResult On_the_job_training()
		{
			return View();
		}
		//業務督導
		public ActionResult Business_supervision()
		{
			return View();
		}
		//員工公吿欄
		public ActionResult Employee_bulletin_board()
		{
			return View();
		}
		//家屬工作
		public ActionResult Family_Notice_board()
		{
			return View();
		}
		//家屬公告
		public ActionResult Family_Notice()
		{
			return View();
		}
		//專欄區
		public ActionResult Column_area()
		{
			return View();
		}
		//家屬工作紀錄
		public ActionResult Family_work_records()
		{
			return View();
		}
		//身體健檢
		public ActionResult Physical_examination()
		{
			return View();
		}
		//員工福利
		public ActionResult Employee_Benefits_Supervise()
		{
			return View();
		}


		/*政府相關工作----未做*/
		//服務紀錄登打
		public ActionResult Service_record()
		{
			return View();
		}
		//公文收錄/行政工作
		public ActionResult Official_documents()
		{
			return View();
		}
		//報表檢查
		public ActionResult Record_quality_inspection_report()
		{
			return View();
		}
		//家屬表查閱
		public ActionResult Family_Care_Form()
		{
			return View();
		}
		/*		public ActionResult Each_guard_record_report()
				{
					return View();
				}
				public ActionResult Monthly_guard_record_report()
				{
					return View();
				}*/
		//照顧日誌表
		public ActionResult Service_Day_report()
			{
				return View();
			}
		//服務滿意度管理
		public ActionResult Service_satisfaction()
		{
			return View();
		}
		//照服員-異常事件通報
		public ActionResult Abnormal_event()
		{
			return View();
		}
		//申訴處理表
		public ActionResult Appeal()
		{
			return View();
		}










	}
}
