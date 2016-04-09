using System.Collections.Generic;
using System.Linq;

namespace Nancy.Model
{
    public static class NextIdHelper
    {
        public static int NextId<T>(this IList<T> list) where T : IEntity
        {
            return list.Any() ? list.Max(x => x.Id) + 1 : 0;
        }
    }
}