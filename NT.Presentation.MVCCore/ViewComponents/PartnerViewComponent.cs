using Microsoft.AspNetCore.Mvc;

namespace NT.Presentation.MVCCore.ViewComponents
{
    public class PartnerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
