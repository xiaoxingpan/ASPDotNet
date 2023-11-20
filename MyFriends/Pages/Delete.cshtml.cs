using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyFriends.Models;


namespace MyFriends.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly MyFriends.Data.FriendContext _context;

        public DeleteModel(MyFriends.Data.FriendContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Friend Friend { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friend = await _context.Friends.FirstOrDefaultAsync(m => m.Id == id);

            if (friend == null)
            {
                return NotFound();
            }
            else
            {
                Friend = friend;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friend = await _context.Friends.FindAsync(id);
            if (friend != null)
            {
                Friend = friend;
                _context.Friends.Remove(Friend);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./FriendList");
        }
    }
}

