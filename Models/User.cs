using System.Transactions;

namespace SpendWise.Models
{
public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } //required?
        public string Password { get; set; } //required?
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime SignInDate { get; set; }
        public DateTime? LastLoginDate { get; set; }

        public ICollection<BudgetPlan> BudgetPlans { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}