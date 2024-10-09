using System.ComponentModel.DataAnnotations;

namespace InventorySerivce.Models.Dtos
{
    public class SellItemDto
    {
        [Required]
        public long SteamId { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public string SkinName { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        [Required]
        public string WeaponType { get; set; }
        [Required]
        public string Weapon { get; set;}

        public SellItemDto(long steamId, float price, string skinName, string imgUrl, string weaponType, string weapon)
        {
            SteamId = steamId;
            Price = price;
            SkinName = skinName;
            ImgUrl = imgUrl;
            WeaponType = weaponType;
            Weapon = weapon;
        }
        public SellItemDto() { }
    }
}
