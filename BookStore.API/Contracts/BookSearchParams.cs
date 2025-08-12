using Microsoft.AspNetCore.Mvc;

namespace Library.API.Contracts
{
    public record BookSearchParams(string search, string sortitem, string sortBy);

}
