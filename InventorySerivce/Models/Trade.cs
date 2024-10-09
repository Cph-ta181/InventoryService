using InventorySerivce.Controllers;

namespace InventorySerivce.Models
{
    public class Trade
    {
        public Trade(long userId, Status status, DateTime statusChange)
        {
            UserId = userId;
            Status = status;
            StatusChange = statusChange;
        }

        public int Id { get; set; }

        //foreign key for User
        public long UserId { get; set; }
        public User User { get; set; }

        //navigational property of collection of Items
        public ICollection<Item> Items { get; set; } = new List<Item>();
        public Status Status { get; set; }
        public DateTime StatusChange { get; set; }
    }

    public enum Status
    {
        Creating,
        Pending,
        Completed
    }
}
