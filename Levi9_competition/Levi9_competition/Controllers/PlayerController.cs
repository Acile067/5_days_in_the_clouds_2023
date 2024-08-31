using Microsoft.AspNetCore.Mvc;
using Levi9_competition.Data;
using Levi9_competition.Interfaces;
using Levi9_competition.Mappers;

namespace Levi9_competition.Controllers
{
    [Route("stats/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPlayerRepo _playerRepo;
        public PlayerController(AppDbContext context, IPlayerRepo playerRepo)
        {
            _playerRepo = playerRepo;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var players = await _playerRepo.GetAllAsync();

            var playersDto = players.Select(s => s.ToPlayerDto());

            return Ok(playersDto);
        }
        [HttpGet]
        [Route("{fullName}")]
        public async Task<IActionResult> GetByName([FromRoute] string fullName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var player = await _playerRepo.GetByFullNameAsync(fullName);

            if (player == null)
            {
                return NotFound("Player not found");
            }

            return Ok(player.ToPlayerDto());
        }
    }
}
