using DominionTDD.Cards;

namespace DominionTDD.State
{
    public interface IKingdomState
    {
        void AddPile<T>(int amont) where T : ICard;
    }
}