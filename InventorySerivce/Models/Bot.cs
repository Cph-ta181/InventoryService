using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySerivce.Models
{
    public class Bot
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
    }
}
