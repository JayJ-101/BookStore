using System.Linq;

namespace BookStore.Models
{
    public static class QueryExtensions
    {
        public static IQueryable<T> PageBy<T>(this IQueryable<T> items,
            int pagenumber, int pagesize)
        {
            return items
                .Skip((pagenumber - 1) * pagesize)
                .Take(pagesize);
        }
    }
}
