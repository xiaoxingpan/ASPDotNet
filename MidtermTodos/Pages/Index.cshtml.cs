using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MidtermTodos.Data;
using MidtermTodos.Models;
using Microsoft.AspNetCore.Identity;

namespace MidtermTodos.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TodoContext _context;

        public IndexModel(ILogger<IndexModel> logger, TodoContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
        }

        public IList<Todo> Todos { get; set; } = null!;

        public async Task OnGetAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                Todos = await _context.Todos.Where(todo => todo.Owner.UserName == User.Identity.Name).ToListAsync();
            }
        }
    }
}