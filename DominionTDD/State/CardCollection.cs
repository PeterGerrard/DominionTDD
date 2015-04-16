using System.Collections.Generic;
using DominionTDD.Cards;

namespace DominionTDD.State
{
    public class CardCollection
    {
        protected readonly IList<ICard> Cards = new List<ICard>();
        public int Count { get { return Cards.Count; } }

        public void AddCard(ICard card)
        {
            Cards.Add(card);
        }

        public IEnumerable<ICard> TakeAll()
        {
            var taken = new List<ICard>(Cards);
            Cards.Clear();
            return taken;
        }
    }
}