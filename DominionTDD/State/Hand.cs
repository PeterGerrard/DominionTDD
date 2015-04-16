using DominionTDD.Cards;

namespace DominionTDD.State
{
    public class Hand : CardCollection, IHand
    {
        public bool Contains(ICard card)
        {
            return Cards.Contains(card);
        }

        public void RemoveCard(ICard card)
        {
            if (!Contains(card))
            {
                throw new CardNotInHandException();
            }
            Cards.Remove(card);
        }
    }
}