namespace BookStore.Core.Models
{
    public class Book
    {
        public const int Max_Length_Title = 100;
        public Guid Id { get; init; }
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public string Author { get; init; } = string.Empty;
        public DateTime CreatAt { get; init; } = DateTime.Now;

        private Book(Guid Id, string Author, string Title, string Description, DateTime CreatAt)
        {
            this.Id = Id;
            this.Title = Title;
            this.Description = Description;
            this.Author = Author;
            this.CreatAt = CreatAt;
        }

        public static (Book book, string Error) Creator(Guid Id, string Author, string Title, string Description, DateTime CreatAt)
        {
            var error = string.Empty;
            if (string.IsNullOrEmpty(Title) || Title.Length > Max_Length_Title)
            {
                error = "Error: The title of the book can't be empty or more than 100 characters long.";

            }
            var book = new Book(Id, Author, Title, Description, CreatAt);
            return (book, error);
        }

    }
}
