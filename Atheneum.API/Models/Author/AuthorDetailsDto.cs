using Atheneum.API.Models.Book;

namespace Atheneum.API.Models.Author
{
    public class AuthorDetailsDto : AuthorReadDto
    {
        public List<BookReadDto> Books { get; set; }
    }
}
