using AtheneumApp.Blazor.Server.UI.Services.Base;

namespace AtheneumApp.Blazor.Server.UI.Services
{
    public interface IAuthorService
    {
        Task<Response<List<AuthorReadDto>>> Get();

        Task<Response<AuthorDetailsDto>> Get(int id);

        Task<Response<AuthorUpdateDto>> GetForUpdate(int id);
        Task<Response<int>> Create(AuthorCreateDto author);

        Task<Response<int>> Edit(int id, AuthorUpdateDto author);

        Task<Response<int>> Delete(int id);

    }
}