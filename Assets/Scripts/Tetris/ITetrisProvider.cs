namespace Tetris
{
    public interface ITetrisProvider
    {
        public event System.Action<char[,]> OnBoardUpdated;

        public int Width { get; }
        public int Height { get; }  
    }
}
