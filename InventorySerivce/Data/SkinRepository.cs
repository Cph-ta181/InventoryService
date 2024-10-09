using InventorySerivce.Models;
using Microsoft.EntityFrameworkCore;

namespace InventorySerivce.Data
{
    public class SkinRepository : ISkinRepository
    {
        private readonly InventorySerivceContext _context;

        public SkinRepository(InventorySerivceContext context)
        {
            _context = context;
        }

        public IEnumerable<Skin> GetAll()
        {
            return _context.Skin.ToList();
        }

        public Skin GetById(int id)
        {
            return _context.Skin.Find(id);
        }

        public void Add(Skin skin)
        {
            _context.Skin.Add(skin);
        }

        public void Delete(int id)
        {
            var skin = _context.Skin.Find(id);
            if (skin != null)
            {
                _context.Skin.Remove(skin);
            }
        }

        public async Task<Skin> AddIfNotExist(Skin skin)
        {
            Console.WriteLine("Add if not exist");
            Skin? existingSkin = await _context.Skin.FirstOrDefaultAsync(s => s.Name == skin.Name);
            if (existingSkin == null)
            {
                await _context.Skin.AddAsync(skin);
                Console.WriteLine("New Skin id: " + skin.Id);
                return skin;
            }
            Console.WriteLine("existing skin id: " + existingSkin.Id);
            return existingSkin;
        }
    }
}
