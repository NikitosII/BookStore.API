namespace BookStore.API.Contracts
{
    public record BookRequest(string Author, string Title, string Description, DateTime CreatAt);

}
