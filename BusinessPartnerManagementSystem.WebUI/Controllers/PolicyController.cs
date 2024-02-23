using BusinessPartnerManagementSystem.WebUI.Models;
using BusinessPartnerManagementSystem.WebUI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BusinessPartnerManagementSystem.WebUI.Controllers
{
    public class PolicyController : Controller
    {
        private readonly IGenericRepository<Policy> _iGenericRepository;
        private readonly string _policyTableName = "Policies";

        public PolicyController(IGenericRepository<Policy> iGenericRepository)
        {
            _iGenericRepository = iGenericRepository;
        }

        public async Task<ActionResult> Index()
        {
            var result = await _iGenericRepository.GetAll(_policyTableName);
            return View(result);
        }

        public async Task<ActionResult> Details(string id)
        {
            var result = await _iGenericRepository.GetById(_policyTableName, id);
            return View(result);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Policy policy)
        {
            if (ModelState.IsValid)
            {
                await _iGenericRepository.Add(_policyTableName, policy);

                return RedirectToAction(nameof(Index));
            }
            return View(policy);
        }

        public async Task<ActionResult> Edit(string id)
        {
            var _Policy = await _iGenericRepository.GetById(_policyTableName, id);
            return View(_Policy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, Policy policy)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    policy.Id = id;
                    await _iGenericRepository.Update(_policyTableName, policy);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(policy);
        }
        public async Task<ActionResult> Delete(string id)
        {
            var _policy = await _iGenericRepository.GetById(_policyTableName, id);
            return View(_policy);
        }

        [HttpDelete, ActionName("DeleteConfirmed")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await _iGenericRepository.Delete(_policyTableName, id);
            return RedirectToAction(nameof(Index));
        }
    }
}