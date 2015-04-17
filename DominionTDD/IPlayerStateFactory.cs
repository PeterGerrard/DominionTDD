using DominionTDD.State;

namespace DominionTDD
{
    public interface IPlayerStateFactory
    {
        IPlayerState CreatePlayerState(IPlayer player);
    }
}