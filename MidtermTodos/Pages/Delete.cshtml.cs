using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MidtermTodos.Models;

namespace MidtermTodos.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly Data.TodoContext _context;
        private readonly ILogger<LoginModel> _logger;

        public DeleteModel(Data.TodoContext context, ILogger<LoginModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Todo TodoToDelete { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currTodo = await _context.Todos.FirstOrDefaultAsync(m => m.Id == id);

            if (currTodo == null)
            {
                return NotFound();
            }
            else
            {
                TodoToDelete = currTodo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currTodo = await _context.Todos.FindAsync(id);
            if (currTodo != null)
            {
                TodoToDelete = currTodo;
                _context.Todos.Remove(TodoToDelete);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Todo {TodoToDelete} is deleted.");
                TempData["FlashMessage"] = $"Todo {TodoToDelete.Id} is deleted.";
            }

            return RedirectToPage("./Index");
        }

    }
}
