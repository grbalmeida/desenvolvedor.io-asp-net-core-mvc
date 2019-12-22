using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Views.ViewComponents
{
    [ViewComponent(Name = "Cart")]
    public class CartViewComponent : ViewComponent
    {
        public int ItemsInCart { get; set; }

        public CartViewComponent()
        {
            ItemsInCart = 3;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(ItemsInCart);
        }
    }
}
