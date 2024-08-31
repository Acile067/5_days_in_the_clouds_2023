using Microsoft.EntityFrameworkCore;
using Levi9_competition.Data;
using Levi9_competition.Interfaces;
using Levi9_competition.Models;

namespace Levi9_competition.Repos
{
    public class PlayerRepo : IPlayerRepo
    {
        private readonly AppDbContext _context;
        public PlayerRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Player>> GetAllAsync()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<Player?> GetByFullNameAsync(string fullName)
        {
            return await _context.Players.FirstOrDefaultAsync(x => x.FullName.ToLower() == fullName.ToLower());
        }
    }
}
