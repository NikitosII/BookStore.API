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
            var error = new List<string>();
            if (string.IsNullOrEmpty(Title) || Title.Length > Max_Length_Title)
            {
                error.Add($"Error: The title of the book can't be empty or more than {Max_Length_Title} characters long.");

            }
            if (string.IsNullOrEmpty(Author) || Author.Length > Max_Length_Author)
            {
                error.Add($"Error: the Author field can't be empty or more than {Max_Length_Author} characters long.");

            }
            if (Description.Length > Max_Length_Description)
            {
                error.Add($"Error: the Description field can't be more than {Max_Length_Description} characters long.");
            }
            if (CreatAt > DateTime.Now)
            {
                error.Add("Creation date cannot be in the future.");
            }

            var book = new Book(Id, Author, Title, Description, CreatAt);
            return (book, string.Empty);
        }

    }
}
