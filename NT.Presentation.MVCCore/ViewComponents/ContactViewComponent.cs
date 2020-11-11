using Microsoft.AspNetCore.Mvc;

namespace NT.Presentation.MVCCore.ViewComponents
{
    public class ContactViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
