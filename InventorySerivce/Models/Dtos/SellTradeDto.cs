using System.ComponentModel.DataAnnotations;

namespace InventorySerivce.Models.Dtos
{
    public class SellTradeDto
    {
        [Required]
        public long userId { get; set;}
        [Required]
        public List<SellItemDto> items { get; set; } = [];

        public SellTradeDto(long userId, List<SellItemDto> items)
        {
            this.userId = userId;
            this.items = items;
        }
        /*public SellTradeDto(long userId) 
        {
            this.userId = userId;
        }*/
        public SellTradeDto() { }
    }
}
