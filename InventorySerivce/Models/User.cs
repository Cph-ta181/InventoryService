using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySerivce.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        public float Balance { get; set; }


    }
}
