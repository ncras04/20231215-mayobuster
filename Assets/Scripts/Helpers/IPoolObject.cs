namespace Helpers
{
    public interface IPoolObject
    {
        public void Acquire();
        public void Reclaim();
    }
}
