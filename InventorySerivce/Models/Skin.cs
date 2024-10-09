namespace InventorySerivce.Models
{
    public class Skin
    {
        public Skin(string name, string imgUrl, string weaponType, string weapon)
        {
            Name = name;
            ImgUrl = imgUrl;
            WeaponType = weaponType;
            Weapon = weapon;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string WeaponType { get; set; }
        public string Weapon { get; set; }


    }
}
