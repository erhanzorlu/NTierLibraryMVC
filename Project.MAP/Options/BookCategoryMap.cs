using Project.ENTITIES.Models;

namespace Project.MAP.Options
{
    public class BookCategoryMap:BaseMap<BookCategory>
    {
        public BookCategoryMap()
        {
            Ignore(x => x.ID);
            HasKey(x => new
            {
                x.BookID,
                x.CategoryID
            });
        }
    }
}
