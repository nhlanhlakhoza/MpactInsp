using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace MpactInsp.Components.Pages
{
    public class LoginBase : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; }
        [Inject] public NavigationManager Navigation { get; set; }
        [Inject] public IJSRuntime JS { get; set; }

        protected LoginModel loginModel = new();
        protected string errorMessage = "";

        protected async Task HandleLogin()
        {
            errorMessage = "";

            Console.WriteLine($"EMAIL ENTERED = {loginModel.Email}");
            Console.WriteLine($"PASSWORD ENTERED = {loginModel.Password}");

            var response = await Http.PostAsJsonAsync(
                "https://localhost:7272/api/users/login", loginModel);

            var rawResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine("RAW API RESPONSE: " + rawResponse);

            if (!response.IsSuccessStatusCode)
            {
                var backendError = System.Text.Json.JsonSerializer
                    .Deserialize<LoginResponse>(rawResponse);

                errorMessage = backendError?.message ?? "Login failed";
                return;
            }

            var result = System.Text.Json.JsonSerializer
                .Deserialize<LoginResponse>(rawResponse);

            if (string.IsNullOrEmpty(result?.token))
            {
                errorMessage = "Login failed: No token received";
                return;
            }

            await JS.InvokeVoidAsync("localStorage.setItem", "jwtToken", result.token);
            Navigation.NavigateTo("/dashboard");
        }

        public class LoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class LoginResponse
        {
            public string token { get; set; }
            public string message { get; set; }
        }
    }
}
