namespace SpendWise.Models
{
    public class BudgetPlan
    {
        public int Id { get; set; } // id budżetu
        public int UserId { get; set; } // Id użytkownika, do którego należy ten plan budżetu
        public User User { get; set; } // użytkownik, do którego należy ten plan budżetu
        public string Name { get; set; } // nazwa planu budżetu
        public string Description { get; set; } // opis planu budżetu
        public decimal PlannedAmount { get; set; } // planowana kwota budżetu
        public DateTime StartDate { get; set; } // data rozpoczęcia planu budżetu
        public DateTime EndDate { get; set; } // data zakończenia planu budżetu
    }
}