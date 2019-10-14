using Garsonix.TimeGame.Models;

namespace Garsonix.TimeGame.Services
{
    public interface ILevelFactory<T>
    {
        Level<T> Next(Level<T> level);

        Level<T> Create(int difficulty);
    }
}