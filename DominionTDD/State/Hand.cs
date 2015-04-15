using System.Collections.Generic;
using DominionTDD.Cards;

namespace DominionTDD.State
{
    public class Hand : IHand
    {
        private readonly IList<ICard> _cards = new List<ICard>();

        public void AddCard(ICard card)
        {
            _cards.Add(card);
        }

        public IEnumerable<ICard> TakeAll()
        {
            var removed = new List<ICard>(_cards);
            _cards.Clear();
            return removed;
        }

        public int Count { get { return _cards.Count; } }

        public bool Contains(ICard card)
        {
            return _cards.Contains(card);
        }

        public void RemoveCard(ICard card)
        {
            if (!Contains(card))
            {
                throw new CardNotInHandException();
            }
            _cards.Remove(card);
        }
    }
}