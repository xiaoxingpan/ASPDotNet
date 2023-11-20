using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyFriends.Models;


namespace MyFriends.Pages
{
    public class ViewModel : PageModel
    {
        private readonly Data.FriendContext _context;

        public ViewModel(Data.FriendContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Friend Friend { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

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
            Friend = friend;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Friend).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendExists(Friend.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./FriendList");
        }

        private bool FriendExists(int id)
        {
            return _context.Friends.Any(e => e.Id == id);
        }
    }


}
