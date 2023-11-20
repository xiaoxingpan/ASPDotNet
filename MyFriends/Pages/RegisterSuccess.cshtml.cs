using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyFriends.Pages
{
    public class RegisterSuccessModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; } = string.Empty;
        public void OnGet(string email)
        {
            Email = email;
        }
    }
}
