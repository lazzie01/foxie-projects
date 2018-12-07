using BusinessModel;
using DataModel;
using PremiumCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PremiumCalculator.Controllers
{
    public class HomeController : Controller
    {
        private MemberModel memberModel;
        private EnumInsuredSumModel enumInsuredSumModel;
        private OwnPremiumPayerModel ownPremiumPayerModel;
        private OtherPremiumPayerModel otherPremiumPayerModel;
        private EnumPolicyFeeModel enumPolicyFeeModel;
        private HistoryModel historyModel;

        public HomeController()
        {
            memberModel = new MemberModel();
            enumInsuredSumModel = new EnumInsuredSumModel();
            ownPremiumPayerModel = new OwnPremiumPayerModel();
            otherPremiumPayerModel = new OtherPremiumPayerModel();
            enumPolicyFeeModel = new EnumPolicyFeeModel();
            historyModel = new HistoryModel();
        }

        public ActionResult Index()
        {

            var list = memberModel.List().Select(m => new MemberViewModel()
            {
                Id = m.Id,
                Name = m.Name,
                DateOfBirth = m.DateOfBirth.ToString("dd/MM/yyyy"),
                PremiumPayer = m.PayerId.HasValue ? memberModel.Read(m.PayerId.Value).Name : m.Name
            }).ToList();
            return View(list);
        }

        public JsonResult GetAllMembers()
        {
            List<SelectListItem> list = memberModel.List().Select(s => new SelectListItem() { Value = s.Id.ToString(), Text = s.Name })
                                        .ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPremiumPayerId(long id)
        {
            return Json(memberModel.PremiumPayerId(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetInsuredSums(bool ownPremiumPayer)
        {
            var list = enumInsuredSumModel.InsuredSumList(ownPremiumPayer)
                       .Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Value.ToString() })
                       .ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Calculate(long memberId, long insuredId, bool ownPremiumPayer)
        {
            double premiumFee = -1;
            double policyFee = -1;
            double policyTotal = -1;
            Member m = memberModel.Read(memberId);
            if (m != null)
            {
                double insuredSum = enumInsuredSumModel.GetInsuredSum(insuredId);

                policyFee = enumPolicyFeeModel.PolicyFee();
                premiumFee = PickPremium(m, insuredSum, ownPremiumPayer);
                policyTotal = premiumFee + policyFee;

                //log data to history table
                History history = new History()
                {
                    Date = DateTime.Now,
                    PolicyFee = policyFee,
                    Premium = premiumFee,
                    Insured = insuredSum,
                    PremiumPayer = ownPremiumPayer,
                    MemberId = memberId
                };
                historyModel.Create(history);
            }
            return Json(new double[] { policyFee, premiumFee, policyTotal }, JsonRequestBehavior.AllowGet);
        }

        private double PickPremium(Member m, double insuredSum, bool ownPremiumPayer)
        {
            double years = 0;
            TimeSpan ts = DateTime.Now.Subtract(m.DateOfBirth);
            years = ts.TotalDays / 365;

            if (ownPremiumPayer)
            {
                return ownPremiumPayerModel.GetPremium(years, insuredSum);
            }
            else
            {
                return otherPremiumPayerModel.GetPremium(years, insuredSum);
            }


        }

        [HttpPost]
        public JsonResult AddMember(MemberViewModel m)
        {
            memberModel.Create(m.ToMember());
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            memberModel.Delete(id);
            return RedirectToAction("Index");
        }

        public JsonResult History(long id)
        {
            List<HistoryViewModel> historyList = historyModel.List(id).Select(h => new HistoryViewModel()
            {
                Date = h.Date.ToString("dd/MM/yyyy hh:mm:ss"),
                PolicyFee = h.PolicyFee,
                Premium = h.Premium,
                Insured = h.Insured
            }).ToList();
            return Json(historyList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Calculator()
        {
            return View();
        }
    }
}