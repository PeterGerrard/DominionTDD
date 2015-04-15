using System.Collections.Generic;

namespace DominionTDD.State
{
    public interface IShuffler<T>
    {
        IEnumerable<T> Shuffle(IEnumerable<T> cards);
    }
}