using System.Numerics;
using Levi9_competition.Models;

namespace Levi9_competition.Interfaces
{
    public interface IPlayerRepo
    {
        Task<List<Player>> GetAllAsync();
        Task<Player?> GetByFullNameAsync(string fullName);
    }
}
