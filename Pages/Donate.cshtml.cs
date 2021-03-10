using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Assign5.Models;
using Assign5.Infrastructure;

namespace Assign5.Pages
{
    public class DonateModel : PageModel
    {
        private iOidoRepository repository;
        //added the cart service below
        public DonateModel(iOidoRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long BookId, string returnUrl)
        {
            Project project = repository.Projects.FirstOrDefault(project => project.BookId == BookId);

            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(project, 1);
            //HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long BookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(clear =>
                clear.Project.BookId == BookId).Project);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
