using Levi9_competition.Models;
using Levi9_competition.Dtos;

namespace Levi9_competition.Mappers
{
    public static class PlayerMapper
    {
        public static PlayerDto ToPlayerDto(this Player playerModel)
        {
            return new PlayerDto(playerModel)
            {

            };
        }
    }
}
