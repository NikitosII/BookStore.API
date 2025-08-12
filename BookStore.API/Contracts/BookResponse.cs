namespace BookStore.API.Contracts
{
    public record BookResponse(Guid Id, string Author, string Title, string Description, DateTime CreatAt);

}