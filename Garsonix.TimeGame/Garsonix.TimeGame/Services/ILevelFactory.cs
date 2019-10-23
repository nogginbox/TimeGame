using Garsonix.TimeGame.Models;

namespace Garsonix.TimeGame.Services
{
    public interface ILevelFactory<T>
    {
        Level<T> NextLevel(Level<T> level);

        Level<T> CreateLevel(int difficulty);
    }
}