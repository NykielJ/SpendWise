1. Przygotowanie Modelu i Kontekstu Bazy Danych
Task 1.1: Stworzenie modelu Transaction

Opis: Stwórz model Transaction w folderze Models, zawierający właściwości takie jak Id, Amount, Description, Date, Category, UserId.
Technologie: C#, Entity Framework Core
Kroki:
Dodaj nowy plik Transaction.cs w folderze Models.
Zdefiniuj model z odpowiednimi właściwościami.
Task 1.2: Dodanie modelu do kontekstu bazy danych

Opis: Dodaj DbSet<Transaction> do klasy UserDataContext.
Technologie: C#, Entity Framework Core
Kroki:
Otwórz plik UserDataContext.cs.
Dodaj DbSet<Transaction> jako właściwość klasy.
2. Implementacja Akcji Index
Task 2.1: Implementacja akcji Index

Opis: Zaimplementuj akcję Index, która wyświetli wszystkie transakcje zalogowanego użytkownika.
Technologie: C#, ASP.NET Core MVC, Entity Framework Core
Kroki:
Stwórz akcję Index w TransactionController.
Pobierz transakcje zalogowanego użytkownika z bazy danych.
Zwróć widok z listą transakcji.
3. Implementacja Akcji Create
Task 3.1: Implementacja akcji Create (GET)

Opis: Stwórz akcję Create (GET), która wyświetli formularz do dodawania nowej transakcji.
Technologie: C#, ASP.NET Core MVC
Kroki:
Stwórz akcję Create (GET) w TransactionController.
Zwróć widok formularza.
Task 3.2: Implementacja akcji Create (POST)

Opis: Stwórz akcję Create (POST), która zapisze nową transakcję w bazie danych.
Technologie: C#, ASP.NET Core MVC, Entity Framework Core
Kroki:
Sprawdź poprawność modelu.
Ustaw UserId na ID zalogowanego użytkownika.
Dodaj transakcję do bazy danych.
Zapisz zmiany i przekieruj do akcji Index.
4. Implementacja Akcji Edit
Task 4.1: Implementacja akcji Edit (GET)

Opis: Stwórz akcję Edit (GET), która wyświetli formularz do edycji istniejącej transakcji.
Technologie: C#, ASP.NET Core MVC, Entity Framework Core
Kroki:
Stwórz akcję Edit (GET) w TransactionController.
Pobierz transakcję z bazy danych.
Sprawdź, czy transakcja należy do zalogowanego użytkownika.
Zwróć widok formularza edycji.
Task 4.2: Implementacja akcji Edit (POST)

Opis: Stwórz akcję Edit (POST), która zaktualizuje istniejącą transakcję w bazie danych.
Technologie: C#, ASP.NET Core MVC, Entity Framework Core
Kroki:
Sprawdź poprawność modelu.
Ustaw UserId na ID zalogowanego użytkownika.
Zaktualizuj transakcję w bazie danych.
Zapisz zmiany i obsłuż wyjątek DbUpdateConcurrencyException.
5. Implementacja Akcji Delete
Task 5.1: Implementacja akcji Delete (GET)

Opis: Stwórz akcję Delete (GET), która wyświetli stronę potwierdzenia usunięcia transakcji.
Technologie: C#, ASP.NET Core MVC, Entity Framework Core
Kroki:
Stwórz akcję Delete (GET) w TransactionController.
Pobierz transakcję z bazy danych.
Sprawdź, czy transakcja należy do zalogowanego użytkownika.
Zwróć widok potwierdzenia usunięcia.
Task 5.2: Implementacja akcji DeleteConfirmed (POST)

Opis: Stwórz akcję DeleteConfirmed (POST), która usunie transakcję z bazy danych.
Technologie: C#, ASP.NET Core MVC, Entity Framework Core
Kroki:
Pobierz transakcję z bazy danych.
Sprawdź, czy transakcja należy do zalogowanego użytkownika.
Usuń transakcję z bazy danych.
Zapisz zmiany i przekieruj do akcji Index.
6. Testowanie i Walidacja
Task 6.1: Testowanie akcji kontrolera

Opis: Przetestuj wszystkie akcje kontrolera TransactionController.
Technologie: xUnit, Moq, ASP.NET Core Testing
Kroki:
Napisz testy jednostkowe dla akcji kontrolera.
Użyj Moq do tworzenia fałszywych zależności (mock dependencies).
Task 6.2: Walidacja i poprawność danych

Opis: Zapewnij, że dane wprowadzane przez użytkowników są poprawnie walidowane.
Technologie: C#, ASP.NET Core MVC
Kroki:
Dodaj walidację danych w modelu Transaction.
Użyj atrybutów walidacji (np. [Required], [Range]).
7. Implementacja Widoków
Task 7.1: Stworzenie widoków dla akcji kontrolera

Opis: Stwórz widoki dla akcji Index, Create, Edit, Delete.
Technologie: Razor, HTML, CSS
Kroki:
W folderze Views/Transaction, dodaj widoki Index.cshtml, Create.cshtml, Edit.cshtml, Delete.cshtml.
Zaimplementuj formularze i tabele w widokach.
8. Dokumentacja
Task 8.1: Dokumentacja kodu

Opis: Udokumentuj kod kontrolera i modeli.
Technologie: XML Comments, Markdown
Kroki:
Dodaj komentarze XML do metod i właściwości.
Stwórz plik README.md z instrukcjami dla deweloperów.
9. Deploy i Monitoring
Task 9.1: Deploy aplikacji

Opis: Wdrożenie aplikacji na środowisko produkcyjne.
Technologie: Azure, AWS, Docker
Kroki:
Skonfiguruj środowisko produkcyjne.
Przeprowadź deploy aplikacji.
Task 9.2: Monitoring aplikacji

Opis: Ustaw monitoring aplikacji, aby śledzić błędy i wydajność.
Technologie: Application Insights, Log Analytics
Kroki:
Skonfiguruj narzędzia do monitoringu.
Dodaj logowanie i śledzenie w aplikacji.

1. Przygotowanie Modelu i Kontekstu Bazy Danych
Zadanie:

Stwórz model Transaction w projekcie.
Dodaj właściwości takie jak Id, Amount, Description, Date, Category, UserId.
Dodaj model do kontekstu bazy danych (UserDataContext).
Kroki:

W folderze Models, dodaj nowy plik Transaction.cs.
Zdefiniuj model Transaction z odpowiednimi właściwościami.
W UserDataContext, dodaj DbSet<Transaction>.
Przykład:

csharp
Skopiuj kod
public class Transaction
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Category { get; set; }
    public string UserId { get; set; } // Relacja z użytkownikiem
}
csharp
Skopiuj kod
public class UserDataContext : DbContext
{
    public DbSet<Transaction> Transactions { get; set; }
    // Inne właściwości DbSet

    public UserDataContext(DbContextOptions<UserDataContext> options)
        : base(options)
    {
    }
}
2. Implementacja Akcji Index
Zadanie:

Zaimplementuj akcję Index, która wyświetli wszystkie transakcje zalogowanego użytkownika.
Kroki:

W TransactionController, stwórz akcję Index.
Pobierz UserId zalogowanego użytkownika.
Pobierz transakcje z bazy danych, które należą do tego użytkownika.
Przekaż transakcje do widoku Index.
Przykład:

csharp
Skopiuj kod
public async Task<IActionResult> Index()
{
    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Pobierz ID zalogowanego użytkownika
    var transactions = await _context.Transactions
                                     .Where(t => t.UserId == userId)
                                     .ToListAsync();
    return View(transactions);
}
3. Implementacja Akcji Create (GET)
Zadanie:

Zaimplementuj akcję Create (GET), która wyświetli formularz do dodawania nowej transakcji.
Kroki:

W TransactionController, stwórz akcję Create.
Zwróć widok formularza do dodawania nowej transakcji.
Przykład:

csharp
Skopiuj kod
public IActionResult Create()
{
    return View();
}
4. Implementacja Akcji Create (POST)
Zadanie:

Zaimplementuj akcję Create (POST), która zapisze nową transakcję w bazie danych.
Kroki:

W TransactionController, stwórz akcję Create (POST).
Sprawdź, czy model jest poprawny (ModelState.IsValid).
Ustaw UserId transakcji na ID zalogowanego użytkownika.
Dodaj transakcję do kontekstu bazy danych i zapisz zmiany.
Przekieruj użytkownika do akcji Index.
Przykład:

csharp
Skopiuj kod
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(Transaction transaction)
{
    if (ModelState.IsValid)
    {
        transaction.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Ustaw ID zalogowanego użytkownika
        _context.Add(transaction);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(transaction);
}
5. Implementacja Akcji Edit (GET)
Zadanie:

Zaimplementuj akcję Edit (GET), która wyświetli formularz do edycji istniejącej transakcji.
Kroki:

W TransactionController, stwórz akcję Edit (GET).
Pobierz transakcję o danym id z bazy danych.
Sprawdź, czy transakcja należy do zalogowanego użytkownika.
Zwróć widok formularza edycji z danymi transakcji.
Przykład:

csharp
Skopiuj kod
public async Task<IActionResult> Edit(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var transaction = await _context.Transactions.FindAsync(id);
    if (transaction == null || transaction.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
    {
        return NotFound();
    }
    return View(transaction);
}
6. Implementacja Akcji Edit (POST)
Zadanie:

Zaimplementuj akcję Edit (POST), która zaktualizuje istniejącą transakcję w bazie danych.
Kroki:

W TransactionController, stwórz akcję Edit (POST).
Sprawdź, czy id transakcji zgadza się z Id w modelu.
Sprawdź, czy model jest poprawny (ModelState.IsValid).
Ustaw UserId transakcji na ID zalogowanego użytkownika.
Zaktualizuj transakcję w kontekście bazy danych i zapisz zmiany.
Obsłuż wyjątek DbUpdateConcurrencyException w przypadku konfliktu.
Przekieruj użytkownika do akcji Index.
Przykład:

csharp
Skopiuj kod
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
            transaction.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Ustaw ID zalogowanego użytkownika
            _context.Update(transaction);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TransactionExists(transaction.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return RedirectToAction(nameof(Index));
    }
    return View(transaction);
}
7. Implementacja Akcji Delete (GET)
Zadanie:

Zaimplementuj akcję Delete (GET), która wyświetli stronę potwierdzenia usunięcia transakcji.
Kroki:

W TransactionController, stwórz akcję Delete (GET).
Pobierz transakcję o danym id z bazy danych.
Sprawdź, czy transakcja należy do zalogowanego użytkownika.
Zwróć widok potwierdzenia usunięcia z danymi transakcji.
Przykład:

csharp
Skopiuj kod
public async Task<IActionResult> Delete(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var transaction = await _context.Transactions
        .FirstOrDefaultAsync(m => m.Id == id && m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));
    if (transaction == null)
    {
        return NotFound();
    }

    return View(transaction);
}
8. Implementacja Akcji DeleteConfirmed (POST)
Zadanie:

Zaimplementuj akcję DeleteConfirmed (POST), która usunie transakcję z bazy danych.
Kroki:

W TransactionController, stwórz akcję DeleteConfirmed (POST).
Pobierz transakcję o danym id z bazy danych.
Sprawdź, czy transakcja należy do zalogowanego użytkownika.
Usuń transakcję z kontekstu bazy danych i zapisz zmiany.
Przekieruj użytkownika do akcji Index.
Przykład:

csharp
Skopiuj kod
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var transaction = await _context.Transactions.FindAsync(id);
    if (transaction == null || transaction.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
    {
        return NotFound();
    }

    _context.Transactions.Remove(transaction);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}
9. Implementacja Widoków
Zadanie:

Stwórz widoki dla akcji Index, Create, Edit, Delete.
Kroki:

W folderze Views/Transaction, dodaj widoki Index.cshtml, Create.cshtml, Edit.cshtml, Delete.cshtml.
W każdym widoku, stwórz formularze i tabele zgodnie z akcjami kontrolera.
Przykład Widoku Create.cshtml:
html
Skopiuj kod
@model Transaction

@{
    ViewData["Title"] = "Create Transaction";
}

<h2>Create Transaction</h2>

<form asp-action="Create">
    <div class="form-group">
        <label asp-for="Amount" class="control-label"></label>
        <input asp-for="Amount" class="form-control" />
        <span asp-validation-for="Amount" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label asp-for="Description" class="control-label"></label>
        <input asp-for="Description" class="form-control" />
        <span asp-validation-for="Description" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label asp-for="Date" class="control-label"></label>
        <input asp-for="Date" class="form-control" />
        <span asp-validation-for="Date" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label asp-for="Category" class="control-label"></label>
        <input asp-for="Category" class="form-control" />
        <span asp-validation-for="Category" class="text-danger"></span>
    </div>
    <div class="form-group">
        <input type="submit" value="Create" class="btn btn-primary" />
    </div>
</form>