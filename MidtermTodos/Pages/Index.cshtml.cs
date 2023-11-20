using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MidtermTodos.Data;
using MidtermTodos.Models;

namespace MidtermTodos.Pages;
using Microsoft.AspNetCore.Identity;


public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly UserManager<IdentityUser> _userManager;


    private readonly TodoContext _context;

    public IndexModel(ILogger<IndexModel> logger, TodoContext context, UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
    }

    public IList<Todo> Todos { get; set; } = null!;

    public async Task OnGetAsync()
    {

        var Owner = await _userManager.GetUserAsync(User);
        Console.WriteLine(User.Identity.Name);
        Todos = await _context.Todos.Where(todo => todo.Owner.UserName == User.Identity.Name).ToListAsync();
    }
}
