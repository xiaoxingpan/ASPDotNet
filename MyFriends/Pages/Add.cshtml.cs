using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFriends.Models;

namespace MyFriends.Pages
{
    public class AddModel : PageModel
    {
        private readonly Data.FriendContext _context;

        public AddModel(Data.FriendContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Friend NewFriend { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Friends.Add(NewFriend);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

