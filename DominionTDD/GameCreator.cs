using System.Collections.Generic;
using System.Linq;
using DominionTDD.Cards;
using DominionTDD.State;

namespace DominionTDD
{
    public class GameCreator
    {
        private readonly IKingdomState _kingdomState;
        private readonly IList<IPlayer> _players = new List<IPlayer>();
        private readonly IPlayerStateFactory _playerStateFactory;

        public GameCreator(IKingdomState kingdomState, IPlayerStateFactory playerStateFactory)
        {
            _kingdomState = kingdomState;
            _playerStateFactory = playerStateFactory;
        }

        public void CreateGame()
        {
            var playerCount = _players.Count;
            if (playerCount < 2 || playerCount > 4)
            {
                throw new IncorrectNumberOfPlayersException();
            }
            var victoryCardAmount = playerCount == 2 ? 8 : 12;
            _kingdomState.AddPile<Estate>(victoryCardAmount);
            _kingdomState.AddPile<Duchy>(victoryCardAmount);
            _kingdomState.AddPile<Province>(victoryCardAmount);

            _kingdomState.AddPile<Copper>(60 - (7 * playerCount));
            _kingdomState.AddPile<Silver>(40);
            _kingdomState.AddPile<Gold>(30);

            var playerStates = _players.Select(_playerStateFactory.CreatePlayerState).ToList();
            foreach (var playerState in playerStates)
            {
                for (var i = 0; i < 3; i++)
                {
                    playerState.GainCard<Estate>();
                }
                for (var i = 0; i < 7; i++)
                {
                    playerState.GainCard<Copper>();
                }
            }
        }

        public void AddPlayer(IPlayer player)
        {
            _players.Add(player);
        }
    }
}