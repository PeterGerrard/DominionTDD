using System.Collections.Generic;
using DominionTDD.Cards;

namespace DominionTDD.State
{
    public class PlayArea
    {
        private readonly IList<ICard> _cards = new List<ICard>();

        public IEnumerable<ICard> Cards()
        {
            return _cards;
        }

        public void AddCard(ICard card)
        {
            _cards.Add(card);
        }

        public IEnumerable<ICard> TakeAll()
        {
            var taken = new List<ICard>(_cards);
            _cards.Clear();
            return taken;
        }
    }
}