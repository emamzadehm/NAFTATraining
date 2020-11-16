using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NT.CM.Application.Contracts;
using NT.CM.Application.Contracts.Interfaces;
using NT.CM.Application.Contracts.ViewModels.BaseInfo;
using NT.CM.Application.Contracts.ViewModels.Candidates;
using NT.CM.Application.Contracts.ViewModels.Companies;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages.CourseManagement.Candidates
{
    public class IndexModel : PageModel
    {
        private readonly ICandidateApplication _icandidateapplication;
        private readonly ICompanyApplication _icompanyapplication;
        private readonly IBaseInfoApplication _ibaseinfoapplication;
        public CompanyViewModel searchmodelcompany;
        public BaseInfoViewModel searchmodelbaseinfo;

        public List<CandidateViewModel> candidateVM { get; set; }
        public CandidateViewModel SearchModel { get; set; }

        public IndexModel(ICandidateApplication icandidateapplication, ICompanyApplication icompanyapplication, IBaseInfoApplication ibaseinfoapplication)
        {
            _icandidateapplication = icandidateapplication;
            _icompanyapplication = icompanyapplication;
            _ibaseinfoapplication = ibaseinfoapplication;
        }

        public void OnGet(CandidateViewModel searchmodel)
        {
            candidateVM = _icandidateapplication.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            searchmodelcompany = new CompanyViewModel();
            searchmodelbaseinfo = new BaseInfoViewModel();
            var command = new CandidateViewModel
            {
                Nationality = _ibaseinfoapplication.Search(searchmodelbaseinfo),
                CompanyList = _icompanyapplication.Search(searchmodelcompany)
            };
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CandidateViewModel candidatevm)
        {
            var result = _icandidateapplication.Create(candidatevm);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(int id)
        {
            //if 
            //var searchmodelcompany = _icompanyapplication.GetBy(selecteditem.CompanyID);
            //var searchmodelbaseinfo = _ibaseinfoapplication.GetBy(selecteditem.NationalityID);
            var selecteditem = _icandidateapplication.GetBy(id);
            searchmodelcompany = new CompanyViewModel();
            searchmodelbaseinfo = new BaseInfoViewModel();
            selecteditem.CompanyList = _icompanyapplication.Search(searchmodelcompany);
            selecteditem.Nationality = _ibaseinfoapplication.Search(searchmodelbaseinfo);

            return Partial("./Edit", selecteditem);

        }
        public JsonResult OnPostEdit(CandidateViewModel candidatevm)
        {
            var result = _icandidateapplication.Edit(candidatevm);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(CandidateViewModel candidatevm)
        {
            _icandidateapplication.Remove(candidatevm.ID);
            return RedirectToPage("Index");
        }

    }
}
