using Blazored.LocalStorage;

namespace AtheneumApp.Blazor.Server.UI.Services.Base
{
    public class BaseHttpService
    {
        private readonly IClient client;
        private readonly ILocalStorageService localStorage;

        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            this.client = client;
            this.localStorage = localStorage;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException apiException)
        {
            if (apiException.StatusCode == 400) 
            {
                return new Response<Guid>()
                {
                    Message = "Validation errors have occurred.",
                    ValidationErrors = apiException.Response,
                    Success = false
                };
            }
            if (apiException.StatusCode == 404)
            {
                return new Response<Guid>()
                {
                    Message = "The requested item could not be found.",
                    ValidationErrors = apiException.Response,
                    Success = false
                };
            }

            if(apiException.StatusCode >= 200 && apiException.StatusCode <= 299)
            {
                return new Response<Guid>()
                {
                    Message = "Operation successful",
                    Success = true
                };
            }

            return new Response<Guid>()
            {
                Message = "Something went wrong, please try again.",
                Success = false
            };
        }

        protected async Task GetBearerToken()
        {
            var token = await localStorage.GetItemAsync<string>("accessToken");
            if (token != null)
            {
                client.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);
            }
        }
    }
}
