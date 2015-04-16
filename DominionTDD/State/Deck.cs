using System.Linq;
using DominionTDD.Cards;

namespace DominionTDD.State
{
    public class Deck : CardCollection, IDeck
    {
        public ICard TakeCard()
        {
            if (Cards.Count == 0)
            {
                throw new DeckIsEmptyException();
            }
            var top = Cards.Last();
            Cards.RemoveAt(Cards.Count-1);
            return top;
        }
    }
}