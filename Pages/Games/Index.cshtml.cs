#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razor_ef_2022.Model;

namespace razor_ef_2022.Pages.Games;
public class IndexModel : PageModel
{
	private readonly GameStoreContext _context;
	private readonly ILogger<IndexModel> _logger;

	[BindProperty(SupportsGet = true, Name = "Query")]
	public string Query { get; set; }

	public IndexModel(GameStoreContext context, ILogger<IndexModel> logger)
	{
		_logger = logger;
		_context = context;
	}

	public IList<Game> Games { get; set; }

	public async Task OnGetAsync()
	{

		var games = from g in _context.Game select g;

		if (!string.IsNullOrEmpty(Query))
		{
			games = games.Where(g => g.Title.Contains(Query));
		}

		_logger.Log(LogLevel.Information, Query);
		Games = await games.ToListAsync();
	}
}
