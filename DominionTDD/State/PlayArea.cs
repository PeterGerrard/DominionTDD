using System.Collections.Generic;
using DominionTDD.Cards;

namespace DominionTDD.State
{
    public class PlayArea : CardCollection, IPlayArea
    {
        public IEnumerable<ICard> GetCards()
        {
            return Cards;
        }
    }
}