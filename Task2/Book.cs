namespace Task2
{
    class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int AuthorId { get; set; }
        public BookReview BookReview { get; set; }
    }
}
