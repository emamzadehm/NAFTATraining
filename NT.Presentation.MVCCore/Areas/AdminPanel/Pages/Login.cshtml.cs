using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NT.UM.Application.Contracts.Interfaces;
using NT.UM.Application.Contracts.ViewModels;

namespace NT.Presentation.MVCCore.Areas.AdminPanel.Pages
{
    public class LoginModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        private readonly IUserApplication _iuserapplication;
        public LoginModel(IUserApplication iuserapplication)
        {
            _iuserapplication = iuserapplication;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost(LoginViewModel command)
        {
            var result = _iuserapplication.Login(command);
            if (result.isSuccessful)
                return RedirectToPage("/Index");
            Message = result.message;
            return RedirectToPage("/Login");
        }
    }
}
