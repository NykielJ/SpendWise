namespace SpendWise.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsRead { get; set; }

        // Opcjonalne
        public string? Link { get; set; } // Link do strony, którą ma otworzyć użytkownik po kliknięciu w powiadomienie
        public DateTime? ExpirationDate { get; set; }

        // Właściwość tylko do odczytu, obliczana na podstawie ExpirationDate
        public bool IsExpired 
        { 
            get 
            {
                return ExpirationDate.HasValue && ExpirationDate.Value < DateTime.Now;
            } 
        }

        public string Priority { get; set; } = "Normal"; // Domyślna wartość
    }
}
