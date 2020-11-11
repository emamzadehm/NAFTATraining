using Microsoft.AspNetCore.Mvc;

namespace NT.Presentation.MVCCore.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
