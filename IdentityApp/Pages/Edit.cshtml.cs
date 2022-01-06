using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityApp.Pages
{
    public class EditModel : PageModel
    {
        public EditModel(ProductDbContext ctx) => DbCOntext = ctx;

        public ProductDbContext DbCOntext { get; set; }

        public Product Product {  get; set; }

        public void OnGet(long id)
        {
            Product = DbCOntext.Find<Product>(id) ?? new Product();
        }

        public IActionResult OnPost([Bind(Prefix = "Product")] Product p)
        {
            DbCOntext.Update(p);
            DbCOntext.SaveChanges();
            return RedirectToPage("Admin");
        }
    }
}
