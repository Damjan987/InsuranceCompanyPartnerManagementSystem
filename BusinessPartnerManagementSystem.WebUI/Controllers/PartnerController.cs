using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BusinessPartnerManagementSystem.WebUI.Models;
using BusinessPartnerManagementSystem.WebUI.Repository;
using BusinessPartnerManagementSystem.WebUI.ViewModels;
using Dapper;

namespace BusinessPartnerManagementSystem.WebUI.Controllers
{
    public class PartnerController : Controller
    {
        private readonly IGenericRepository<Partner> _iGenericRepository;
        private readonly string _partnerTableName = "Partners";

        public PartnerController(IGenericRepository<Partner> iGenericRepository)
        {
            _iGenericRepository = iGenericRepository;
        }

        public async Task<ActionResult> Index()
        {
            List<PartnerListItem> viewModelList = new List<PartnerListItem>();
            List<Partner> partners = (List<Partner>)await _iGenericRepository.GetAll(_partnerTableName);
            foreach (var partner in partners)
            {
                if (partner.Policies.Count > 4)
                {
                    PartnerListItem item = new PartnerListItem();
                    item.Partner = partner;
                    item.HasFiveOrMorePolicies = true;
                    viewModelList.Add(item);
                }
            }

            return View(viewModelList);
        }

        public async Task<ActionResult> Details(string id)
        {
            Partner partner = (Partner)await _iGenericRepository.GetById(_partnerTableName, id);
            return PartialView("PartnerDetailsModal", partner);
        }
        public ActionResult Create()
        {
            return View();
        }

        public async Task<ActionResult> AddPolicyToPartnerForm(string id)
        {
            PartnerPolicy viewModel = new PartnerPolicy();
            viewModel.Partner = await _iGenericRepository.GetById(_partnerTableName, id);
            viewModel.Policies = (IEnumerable<Policy>)await _iGenericRepository.GetAll("Policies");
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPolicyToPartnerForm(PartnerPolicy partnerPolicy)
        {
            if (ModelState.IsValid)
            {
                object partnerPolicyToCreate = new { Policy_Id = partnerPolicy.SelectedPolicy, Partner_Id = partnerPolicy.Partner };
                await _iGenericRepository.AddToSharedTable("PolicyPartners", partnerPolicyToCreate);

                return RedirectToAction(nameof(Index));
            }
            return View(partnerPolicy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Partner partner)
        {
            if (ModelState.IsValid)
            {
                await _iGenericRepository.Add(_partnerTableName, partner);

                return RedirectToAction(nameof(Index));
            }
            return View(partner);
        }

        public async Task<ActionResult> Edit(string id)
        {
            var _Partner = await _iGenericRepository.GetById(_partnerTableName, id);
            return View(_Partner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, Partner partner)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    partner.Id = id;
                    await _iGenericRepository.Update(_partnerTableName, partner);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(partner);
        }
        public async Task<ActionResult> Delete(string id)
        {
            var _Partner = await _iGenericRepository.GetById(_partnerTableName, id);
            return View(_Partner);
        }

        [HttpDelete, ActionName("DeleteConfirmed")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await _iGenericRepository.Delete(_partnerTableName, id);
            return RedirectToAction(nameof(Index));
        }
    }
}