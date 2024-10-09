namespace InventorySerivce.Models.Dtos
{
    public class BotItemCountDto
    {

        public long botId { get; set; }
        public int count { get; set; }
        public BotItemCountDto(long botId, int count)
        {
            this.botId = botId;
            this.count = count;
        }

        public BotItemCountDto() { }

    }
}
