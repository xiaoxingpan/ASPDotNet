using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyFriends.Data;
using MyFriends.Models;

namespace MyFriends.Pages;

public class FriendListModel : PageModel
{
    private readonly ILogger<FriendListModel> _logger;
    private readonly FriendContext _context;
    public FriendListModel(ILogger<FriendListModel> logger, FriendContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IList<Friend> Friend { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Friend = await _context.Friends.ToListAsync();
    }
}
