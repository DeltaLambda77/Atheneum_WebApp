using AtheneumApp.Blazor.Server.UI.Services.Base;

namespace AtheneumApp.Blazor.Server.UI.Services
{
    public interface IBookService
    {
        Task<Response<List<BookReadDto>>> Get();

        Task<Response<BookDetailsDto>> Get(int id);

        Task<Response<BookUpdateDto>> GetForUpdate(int id);
        Task<Response<int>> Create(BookCreateDto author);

        Task<Response<int>> Edit(int id, BookUpdateDto author);

        Task<Response<int>> Delete(int id);

    }
}