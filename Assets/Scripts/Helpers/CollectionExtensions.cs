using System.Collections.Generic;

namespace Helpers
{
    public static class CollectionExtensions
    {
        public static bool AddUnique<T>(this List<T> list, T item)
        {
            if (list.Contains(item))
                return false;
            list.Add(item);
            return true;
        }   

        public static T Random<T>(this List<T> list)
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }
    }
}
