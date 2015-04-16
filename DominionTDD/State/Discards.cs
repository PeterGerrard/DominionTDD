using System.Linq;
using DominionTDD.Cards;

namespace DominionTDD.State
{
    public class Discards : CardCollection, IDiscards
    {
        public ICard TopCard
        {
            get { return Cards.LastOrDefault(); }
        }
    }
}