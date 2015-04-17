using DominionTDD.Cards;

namespace DominionTDD.State
{
    public interface IPlayerState
    {
        void GainCard<T>() where T : ICard;
    }
}