using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class BookRatingDTO
    {
        public string AuthorName { get; set; }
        public string BookTitle { get; set; }
        public int Rating { get; set; }
        public List<BookRatingDTO> Get()
        {
            using (Context ctx = new Context())
            {
                var res =  from auth in ctx.Authors
                           join book in ctx.Books on auth.Id 
                           equals book.AuthorId
                           join bookReview in ctx.BookReviews on book.Id 
                           equals bookReview.Book.Id
                           where (book.BookReview != null)
                           select new BookRatingDTO()
                           {
                               AuthorName = auth.Name,
                               BookTitle = book.Title,
                               Rating = bookReview.Rating
                           };
     
                return res.ToList();
            }

        }
    }
}
