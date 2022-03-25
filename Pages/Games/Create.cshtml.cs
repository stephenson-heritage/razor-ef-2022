#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using razor_ef_2022.Model;

namespace razor_ef_2022.Pages.Games
{
	public class CreateModel : PageModel
	{
		private readonly GameStoreContext _context;
		private readonly ILogger _logger;
		public CreateModel(ILogger<CreateModel> logger, GameStoreContext context)
		{
			_logger = logger;
			_context = context;
		}

		public IActionResult OnGet()
		{
			_logger.Log(LogLevel.Information, "got create page");
			return Page();
		}

		[BindProperty]
		public Game Game { get; set; }

		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Game.Add(Game);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
