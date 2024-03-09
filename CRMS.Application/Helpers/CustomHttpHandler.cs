using CRMS.Application.DTOs;
using CRMS.Application.Services.Contracts;
using System.Net;

namespace CRMS.Application.Helpers
{
    public class CustomHttpHandler(GetHttpClient getHttpClient, LocalStorageService localStorageService, IUserAccountService accountService) : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage, CancellationToken cancellationToken)
        {
            bool loginUrl = requestMessage.RequestUri!.AbsoluteUri.Contains("login");
            bool registerUrl = requestMessage.RequestUri!.AbsoluteUri.Contains("register");
            bool refreshTokenUrl = requestMessage.RequestUri!.AbsoluteUri.Contains("refresh-token");

            if(loginUrl ||  registerUrl || refreshTokenUrl) 
                return await base.SendAsync(requestMessage, cancellationToken);

            var result = await base.SendAsync(requestMessage,cancellationToken);
            if(result.StatusCode == HttpStatusCode.Unauthorized)
            {
                //Get token from local storage
                var stringToken = await localStorageService.GetToken();
                if (stringToken == null) return result;

                //Check if the header containers token
                string token = string.Empty;
                try
                {
                    token = requestMessage.Headers.Authorization!.Parameter!;
                }
                catch { }

                var deserializedToken = Serialization.DeserializeJsonString<UserSession>(stringToken);
                if(deserializedToken is null) return result;
                if (string.IsNullOrEmpty(token))
                {
                    requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", deserializedToken.Token);
                    return await base.SendAsync(requestMessage, cancellationToken);
                }

                //Call for refresh Token
                var newJwtToken = await GetReshToken(deserializedToken.RefreshToken);
                if(string.IsNullOrEmpty(newJwtToken)) return result;

                requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", deserializedToken.Token);
                return await base.SendAsync(requestMessage, cancellationToken);
            }
            return result;   
        }

        private async Task<string> GetReshToken(string refreshToken)
        {
            var result = await accountService.RefreshTokenAsync(new RefreshToken() { Token = refreshToken });
            string serializedToken = Serialization.SerializeObj(new UserSession()
            { Token = result.Token , RefreshToken = result.RefreshToken});
            await localStorageService.SetToken(serializedToken);
            return result.Token;
        }
    }
}
