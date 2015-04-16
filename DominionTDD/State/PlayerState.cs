using DominionTDD.Cards;

namespace DominionTDD.State
{
    public class PlayerState
    {
        private readonly IDeck _deck;
        private readonly IHand _hand;
        private readonly IDiscards _discards;
        private readonly IShuffler<ICard> _shuffler;
        private readonly IPlayArea _playArea;

        public PlayerState(IDeck deck, IHand hand, IDiscards discards, IShuffler<ICard> shuffler, IPlayArea playArea)
        {
            _deck = deck;
            _hand = hand;
            _discards = discards;
            _shuffler = shuffler;
            _playArea = playArea;
        }

        public void DrawCard()
        {
            if (_deck.Count == 0)
            {
                if (_discards.Count > 0)
                {
                    var discards = _discards.TakeAll();
                    var shuffled = _shuffler.Shuffle(discards);
                    foreach (var card in shuffled)
                    {
                        _deck.PlaceOnTop(card);
                    }
                }
                else
                {
                    return;
                }
            }
            var drawn = _deck.TakeCard();
            _hand.AddCard(drawn);
        }

        public void DiscardHand()
        {
            var hand = _hand.TakeAll();
            foreach (var card in hand)
            {
                _discards.Add(card);
            }
        }

        public void PlayCard(ICard card)
        {
            if (_hand.Contains(card))
            {
                _hand.RemoveCard(card);
                _playArea.AddCard(card);
            }
        }

        public void EmptyPlayArea()
        {
            var cards = _playArea.TakeAll();
            foreach (var card in cards)
            {
                _discards.Add(card);
            }
        }

        public void GainCard(ICard card)
        {
            _discards.Add(card);
        }
    }
}