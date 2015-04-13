using System.Collections.Generic;
using System.Linq;
using DominionTDD.Cards;

namespace DominionTDD
{
    public class Deck
    {
        private readonly IList<ICard> _cards = new List<ICard>();

        public void PlaceOnTop(ICard card)
        {
            _cards.Add(card);
        }

        public int Count { get { return _cards.Count; } }

        public ICard TakeCard()
        {
            if (_cards.Count == 0)
            {
                throw new DeckIsEmptyException();
            }
            var top = _cards.Last();
            _cards.RemoveAt(_cards.Count-1);
            return top;
        }
    }
}