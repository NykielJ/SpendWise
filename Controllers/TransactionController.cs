using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpendWise.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

[Authorize]
public class TransactionController : Controller
{
    private readonly UserDataContext _context;
    private async Task<bool> TransactionExists(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Pobranie Id zalogowanego użytkownika
        return await _context.Transactions.AnyAsync(t => t.Id == id && t.UserId == userId);
    }

    public TransactionController(UserDataContext context)
    {
        _context = context;
    }

    // GET: /Transaction
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Pobranie Id zalogowanego użytkownika
        var transactions = await _context.Transactions.Where(t => t.UserId == UserId).ToListAsync(); // Pobranie transakcji zalogowanego użytkownika

        return View(transactions);
    }

    // GET: /Transaction/Create
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(_context.ExpenseCategories, "Id", "Name"); // Pobranie kategorii wydatków z bazy danych (do wyboru w formularzu)
        return View();
    }

    // POST: /Transaction/Create
    [HttpPost]
    [ValidateAntiForgeryToken] // Zabezpieczenie przed atakami CSRF
    public async Task<IActionResult> Create(Transaction transaction)
    {
        if (ModelState.IsValid)
        {
            transaction.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new ArgumentNullException(nameof(transaction.UserId)); // Przypisanie Id zalogowanego użytkownika
            _context.Transactions.Add(transaction); // Dodanie transakcji do bazy danych
            await _context.SaveChangesAsync(); // Zapisanie zmian w bazie danych
            Console.WriteLine("jestem w ifie");
            return RedirectToAction(nameof(Index)); // Przekierowanie do akcji Index
        }
        foreach (var modelStateKey in ViewData.ModelState.Keys)
        {
            var value = ViewData.ModelState[modelStateKey];
            foreach (var error in value.Errors)
            {
                Console.WriteLine($"Key: {modelStateKey}, Error: {error.ErrorMessage}");
            }
        }
        ViewBag.Categories = new SelectList(_context.ExpenseCategories, "Id", "Name", transaction.CategoryId); // Pobranie kategorii wydatków z bazy danych (do wyboru w formularzu)
        Console.WriteLine("Error");
        return View(transaction);
    }

    // GET: /Transaction/Edit
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        if (id == 0)
        {
            return NotFound();
        }
        var transaction = await _context.Transactions.FindAsync(id); // Pobranie transakcji o podanym Id z bazy danych
        if (transaction == null || transaction.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
        {
            return NotFound();
        }
        ViewBag.Categories = new SelectList(_context.ExpenseCategories, "Id", "Name", transaction.CategoryId); // Pobranie kategorii wydatków z bazy danych (do wyboru w formularzu)
        return View(transaction);
    }

    // POST: /Transaction/Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Transaction transaction)
    {
        if (id != transaction.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                transaction.UserId = User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new ArgumentNullException(nameof(transaction.UserId)); // Przypisanie Id zalogowanego użytkownika
                _context.Transactions.Update(transaction); // Aktualizacja transakcji w bazie danych
                await _context.SaveChangesAsync(); // Zapisanie zmian w bazie danych

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TransactionExists(transaction.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index)); // Przekierowanie do akcji Index
        }
        ViewBag.Categories = new SelectList(_context.ExpenseCategories, "Id", "Name", transaction.CategoryId); // Pobranie kategorii wydatków z bazy danych (do wyboru w formularzu)
        return View(transaction);

    }



    // GET: /Transaction/Delete/{id}
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        if (id == 0)
        {
            return NotFound();
        }
        var transaction = await _context.Transactions.FindAsync(id); // Pobranie transakcji o podanym Id z bazy danych
        if (transaction == null || transaction.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
        {
            return NotFound();
        }

        return View(transaction);
    }

    // POST: /Transaction/Delete/{id}
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var transaction = await _context.Transactions.FindAsync(id); // Pobranie transakcji o podanym Id z bazy danych
        if (transaction != null)
        {
            _context.Transactions.Remove(transaction); // Usunięcie transakcji z bazy danych
        }
        await _context.SaveChangesAsync(); // Zapisanie zmian w bazie danych
        return RedirectToAction(nameof(Index)); // Przekierowanie do akcji Index
    }

}