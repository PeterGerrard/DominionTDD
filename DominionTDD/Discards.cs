using System.Collections.Generic;
using System.Linq;
using DominionTDD.Cards;

namespace DominionTDD
{
    public class Discards
    {
        private readonly IList<ICard> _cards = new List<ICard>();

        public void Add(ICard card)
        {
            _cards.Add(card);
        }

        public IEnumerable<ICard> TakeAll()
        {
            var taken = new List<ICard>(_cards);
            _cards.Clear();
            return taken;
        }

        public int Count
        {
            get { return _cards.Count; }
        }

        public ICard TopCard
        {
            get { return _cards.LastOrDefault(); }
        }
    }
}