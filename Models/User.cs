using System.Transactions;
using Microsoft.AspNetCore.Identity;


namespace SpendWise.Models
{
public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? LastLoginDate { get; set; }

        public ICollection<BudgetPlan> BudgetPlans { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}