namespace SpendWise.Models
{
    public class Transaction
    {
        public int Id { get; set; } // id transakcji
        public int UserId { get; set; } // Id użytkownika, do którego należy ta transakcja
        public User User { get; set; } // użytkownik, do którego należy ta transakcja
        public decimal Amount { get; set; } // kwota transakcji
        public DateTime TransactionDate { get; set; } // data transakcji
        public string Description { get; set; } // opis transakcji
        public ExpenseCategory Category { get; set; } // kategoria transakcji (wydatku)
        public int CategoryId { get; set; } // Id kategorii transakcji (wydatku)
        public bool IsIncome { get; set; } // czy transakcja jest przychodem
        public string? Comment { get; set; } // komentarz do transakcji
    }
}