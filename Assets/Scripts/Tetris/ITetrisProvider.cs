namespace Tetris
{
    public interface ITetrisProvider
    {
        public event System.Action<char[,]> OnBoardUpdated;
    }
}
