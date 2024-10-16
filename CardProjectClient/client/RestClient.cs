using CardProjectClient.lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CardProjectClient.game;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.VisualBasic.ApplicationServices;
using System.Security.AccessControl;

namespace CardProjectClient.client
{
    /// <summary>
    /// Access the API
    /// </summary>
    static class RestClient
    {
        public static string EndPoint { get; set; }        // The URI of the server


        /// <summary>
        /// Make login request to API
        /// </summary>
        public static async Task<HttpResponseMessage> UserGetRequest(UserGet UserDetails)
        {
            return await ProcessRequest(UserDetails, System.Net.Http.HttpMethod.Get, "UserLogin");
        }


        /// <summary>
        /// Create a user account
        /// </summary>
        /// <returns></returns>
        /// 
        public static async Task<HttpResponseMessage> UserPostRequest(string Forename, string Surname, string Username, string Password, DateOnly DateOfBirth)
        {
            // Check to see if URI is empty
            if (string.IsNullOrWhiteSpace(EndPoint))
                throw new UriIsEmptyException("The URI is empty");

            CheckEndpoint();

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient Client = new HttpClient(clientHandler);

            Client.BaseAddress = new Uri(EndPoint);

            // Create temporary UserPost variable to store properties
            UserPost tUser = new UserPost(Forename, Surname, Username, Password, DateOfBirth.ToDateTime(TimeOnly.Parse("00:00AM")));

            JsonSerializerOptions jOptions = new JsonSerializerOptions();
            jOptions.WriteIndented = true;

            var response = await Client.PostAsJsonAsync("CreateUser", tUser, jOptions);



            return response;

            //Client.PostAsync($"{Forename}¬{Surname}¬{Username}¬{Password}¬{DateOfBirth}");
        }


        public static async Task<HttpResponseMessage> UserDeleteRequest(string Username, string UserID)
        {
            // Check to see if URI is empty
            if (EndPoint == String.Empty)
                throw new UriIsEmptyException("The URI is empty, please make sure you have entered the URI of the server you wish to connect to");

            CheckEndpoint();

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient Client = new HttpClient(clientHandler);

            Client.BaseAddress = new Uri(EndPoint);

            List<string> UserProperties = new List<string>();
            UserProperties.Add(Username);
            UserProperties.Add(UserID);

            string strJson = JsonConvert.SerializeObject(UserProperties);

            HttpRequestMessage HttpRequest = new HttpRequestMessage
            {
                Method = System.Net.Http.HttpMethod.Delete,
                RequestUri = new Uri(EndPoint + "RemoveUser"),
                Content = new StringContent(strJson)
            };

            /// TODO: Check for if server goes down during request
            /// FIXME: At the moment if user is logged in and server goes down the user remains logged in until a server request is made at which point the client will crash

            var response = await Client.SendAsync(HttpRequest);

            return response;
        }

        /// <summary>
        /// Send update user request to API - Put Request
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        /// <exception cref="UriIsEmptyException"></exception>
        public static async Task<HttpResponseMessage> UserUpdateRequest(UserPut tUser, game.User CurrentUser)
        {
            // Check to see if URI is empty
            if (EndPoint == String.Empty)
                throw new UriIsEmptyException("The URI is empty, please make sure you have entered the URI of the server you wish to connect to");

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient Client = new HttpClient(clientHandler);

            Client.BaseAddress = new Uri(EndPoint);

            string strContent = String.Empty;

            UserPut NewCurrentUser = new UserPut
            {
                Forename = CurrentUser.Forename,
                Surname = CurrentUser.Surname,
                Username = CurrentUser.Username,
                Password = CurrentUser.Password,
                DateOfBirth = CurrentUser.DateOfBirth.ToDateTime(TimeOnly.Parse("00:00AM")),
                UserID = CurrentUser.UserID
            };

            List<UserPut> Users = new List<UserPut>();
            Users.Add(tUser);
            Users.Add(NewCurrentUser);

            string strJson = JsonConvert.SerializeObject(Users);

            HttpRequestMessage HttpRequest = new HttpRequestMessage
            {
                Method = System.Net.Http.HttpMethod.Put,
                RequestUri = new Uri(EndPoint + "UpdateUser"),
                Content = new StringContent(strJson)
            };


            /// TODO: Check for if server goes down during request
            /// FIXME: At the moment if user is logged in and server goes down the user remains logged in until a server request is made at which point the client will crash

            var response = await Client.SendAsync(HttpRequest);

            return response;
        }

        /// <summary>
        /// Add card to server - only from admin account
        /// </summary>
        /// <param name="CardImage"></param>
        /// <param name="CardName"></param>
        /// <returns></returns>
        /// <exception cref="UriIsEmptyException"></exception>
        public static async Task<HttpResponseMessage> AddNewCard(AddCard NewCard)
        {
            return await ProcessRequest(NewCard, System.Net.Http.HttpMethod.Post, "AddCard");
        }

        /// <summary>
        /// Adds a rarity to the database
        /// </summary>
        /// <param name="Rarity"></param>
        /// <returns></returns>
        /// <exception cref="UriIsEmptyException"></exception>
        public static async Task<HttpResponseMessage> AddNewRarity(string Rarity)
        {
            // Check to see if URI is empty
            if (EndPoint == String.Empty)
                throw new UriIsEmptyException("The URI is empty, please make sure you have entered the URI of the server you wish to connect to");

            CheckEndpoint();

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient Client = new HttpClient(clientHandler);

            Client.BaseAddress = new Uri(EndPoint);

            HttpRequestMessage HttpRequest = new HttpRequestMessage
            {
                Method = System.Net.Http.HttpMethod.Post,
                RequestUri = new Uri(EndPoint + "AddRarity"),
                Content = new StringContent(Rarity)
            };

            var response = await Client.SendAsync(HttpRequest);

            return response;
        }

        /// <summary>
        /// Retrieves all rarities
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UriIsEmptyException"></exception>
        public static async Task<HttpResponseMessage> GetAllRarities()
        {
            // Check to see if URI is empty
            if (EndPoint == String.Empty)
                throw new UriIsEmptyException("The URI is empty, please make sure you have entered the URI of the server you wish to connect to");

            CheckEndpoint();

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient Client = new HttpClient(clientHandler);

            Client.BaseAddress = new Uri(EndPoint);

            HttpRequestMessage HttpRequest = new HttpRequestMessage
            {
                Method = System.Net.Http.HttpMethod.Get,
                RequestUri = new Uri(EndPoint + "GetAllRarities"),
            };

            var response = await Client.SendAsync(HttpRequest);

            return response;
        }

        public static async Task<HttpResponseMessage> AddNewCardFrame(AddFrame NewFrame)
        {
            return await ProcessRequest(NewFrame, System.Net.Http.HttpMethod.Post, "AddFrame");
        }

        public static async Task<HttpResponseMessage> NewCardDrop(UserPut CurrentUser)
        {
            return await ProcessRequest(CurrentUser, System.Net.Http.HttpMethod.Get, "Drop");
        }

        /// <summary>
        /// Gets all collections for a user
        /// </summary>
        /// <param name="CurrentUser"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> GetAllUserCollections(UserPut CurrentUser)
        {


            /// TODO: Check for if server goes down during request
            /// FIXME: At the moment if user is logged in and server goes down the user remains logged in until a server request is made at which point the client will crash

            var response = await ProcessRequest(CurrentUser, System.Net.Http.HttpMethod.Get, "GetCollections");

            return response;
        }

        public static async Task<HttpResponseMessage> GetAllCollectionsWithCard(Card CurrentCard)
        {
            return await ProcessRequest(CurrentCard, System.Net.Http.HttpMethod.Get, "GetAllCollectionsWithCard");
        }

        /// <summary>
        /// Gets all frames for a user
        /// </summary>
        /// <param name="CurrentUser"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> GetAllUserFrames(UserPut CurrentUser)
        {
            return await ProcessRequest(CurrentUser, System.Net.Http.HttpMethod.Get, "GetFrames");
        }

        /// <summary>
        /// Gets a single collection for a user
        /// </summary>
        /// <param name="Collection"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> GetUserCollection(GetCollection Collection)
        {
            return await ProcessRequest(Collection, System.Net.Http.HttpMethod.Get, "GetSingleCollection");
        }

        /// <summary>
        /// Deletes a collection that a user has
        /// </summary>
        /// <param name="CollectionToDelete"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> DeleteCollection(Collection CollectionToDelete)
        {
            return await ProcessRequest(CollectionToDelete, System.Net.Http.HttpMethod.Delete, "DeleteCollection");
        }

        public static async Task<HttpResponseMessage> GetAllUserCards(UserPut CurrentUser)
        {
            // Check to see if URI is empty
            if (EndPoint == String.Empty)
                throw new UriIsEmptyException("The URI is empty, please make sure you have entered the URI of the server you wish to connect to");

            CheckEndpoint();

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient Client = new HttpClient(clientHandler);

            Client.BaseAddress = new Uri(EndPoint);

            string StringContent = JsonConvert.SerializeObject(CurrentUser);

            HttpRequestMessage HttpRequest = new HttpRequestMessage
            {
                Method = System.Net.Http.HttpMethod.Get,
                RequestUri = new Uri(EndPoint + "GetAllCards"),
                Content = new StringContent(StringContent)
            };

            /// TODO: Check for if server goes down during request
            /// FIXME: At the moment if user is logged in and server goes down the user remains logged in until a server request is made at which point the client will crash

            var response = await Client.SendAsync(HttpRequest);

            return response;
        }

        /// <summary>
        /// Gets user that is creating the trade tradable cards - i.e. cards not being used in another trade
        /// </summary>
        /// <param name="UserFrom"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> GetUserFromTradeCards(UserPut UserFrom)
        {
            return await ProcessRequest(UserFrom, System.Net.Http.HttpMethod.Get, "GetUserFromTradeCards");
        }

        public static async Task<HttpResponseMessage> GetAllTradeUserCards(UserPut TradeUser)
        {
            return await ProcessRequest(TradeUser, System.Net.Http.HttpMethod.Get, "GetAllTradeUserCards");
        }

        public static async Task<HttpResponseMessage> GetThreeCardImages(List<Card> CardNames)
        {
            // Check to see if URI is empty
            if (EndPoint == String.Empty)
                throw new UriIsEmptyException("The URI is empty, please make sure you have entered the URI of the server you wish to connect to");

            CheckEndpoint();

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient Client = new HttpClient(clientHandler);

            Client.BaseAddress = new Uri(EndPoint);

            string[] StringCardNames = new string[3];

            for (int i = 0; i < 3; i++)
            {
                StringCardNames[i] = CardNames[i].CardName;
            }

            string StringContent = JsonConvert.SerializeObject(StringCardNames);

            HttpRequestMessage HttpRequest = new HttpRequestMessage
            {
                Method = System.Net.Http.HttpMethod.Get,
                RequestUri = new Uri(EndPoint + "GetThreeCardImages"),
                Content = new StringContent(StringContent)
            };

            /// TODO: Check for if server goes down during request
            /// FIXME: At the moment if user is logged in and server goes down the user remains logged in until a server request is made at which point the client will crash

            var response = await Client.SendAsync(HttpRequest);

            return response;
        }

        public static async Task<HttpResponseMessage> GetSingleCardImage(string CardName)
        {
            // Check to see if URI is empty
            if (EndPoint == String.Empty)
                throw new UriIsEmptyException("The URI is empty, please make sure you have entered the URI of the server you wish to connect to");

            CheckEndpoint();

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient Client = new HttpClient(clientHandler);

            Client.BaseAddress = new Uri(EndPoint);

            string StringContent = JsonConvert.SerializeObject(CardName);

            HttpRequestMessage HttpRequest = new HttpRequestMessage
            {
                Method = System.Net.Http.HttpMethod.Get,
                RequestUri = new Uri(EndPoint + "GetSingleCardImage"),
                Content = new StringContent(StringContent)
            };

            /// TODO: Check for if server goes down during request
            /// FIXME: At the moment if user is logged in and server goes down the user remains logged in until a server request is made at which point the client will crash

            var response = await Client.SendAsync(HttpRequest);

            return response;
        }

        /// <summary>
        /// Gets the frame of a card
        /// </summary>
        /// <param name="FrameName"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> GetSingleCardFrame(string FrameName)
        {
            return await ProcessRequest(FrameName, System.Net.Http.HttpMethod.Get, "GetSingleFrameImage");
        }

        /// <summary>
        /// Creates a new collection
        /// </summary>
        /// <param name="NewCollection"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> CreateCollection (Collection NewCollection)
        {


            /// TODO: Check for if server goes down during request
            /// FIXME: At the moment if user is logged in and server goes down the user remains logged in until a server request is made at which point the client will crash

            var response = await ProcessRequest(NewCollection, System.Net.Http.HttpMethod.Post, "CreateCollection");

            return response;
        }

        /// <summary>
        /// Updates a collection - changing the name, whether its public or not, removing cards from it
        /// </summary>
        /// <param name="UpdateUserCollection"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> UpdateCollection (UpdateCollection UpdateUserCollection)
        {
            return await ProcessRequest(UpdateUserCollection, System.Net.Http.HttpMethod.Put, "UpdateCollection");
        }

        /// <summary>
        /// Carries out a search 
        /// </summary>
        /// <param name="NewObjectSearch"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> SearchObject(NewSearch NewObjectSearch)
        {
            return await ProcessRequest(NewObjectSearch, System.Net.Http.HttpMethod.Get, "SearchRequest");
        }

        /// <summary>
        /// Updates a card, adding/ changing a nickname or adding a frame
        /// </summary>
        /// <param name="NewCardUpdate"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> UpdateCard(UpdateCard NewCardUpdate)
        {
            return await ProcessRequest(NewCardUpdate, System.Net.Http.HttpMethod.Put, "UpdateCard");
        }

        /// <summary>
        /// Creates a new trade request
        /// </summary>
        /// <param name="NewTrade"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> CreateNewTradeRequest(Trade NewTrade)
        {
            return await ProcessRequest(NewTrade, System.Net.Http.HttpMethod.Post, "NewTradeRequest");
        }

        public static async Task<HttpResponseMessage> GetUserCardsInSentTrade(TradeSearch CurrentTradeSearch)
        {
            return await ProcessRequest(CurrentTradeSearch, System.Net.Http.HttpMethod.Get, "GetTradeSentCards");
        }

#if false
        // Dead Code
        public async Task<HttpResponseMessage> GetUserCardsInIncomingTrade(TradeSearch CurrentTradeSearch)
        {
            return await ProcessRequest(CurrentTradeSearch, System.Net.Http.HttpMethod.Get, "GetTradeIncomingCards");
        }
#endif

        public static async Task<HttpResponseMessage> DeleteTradeRequest(TradeSearch CurrentTradeSearch)
        {
            return await ProcessRequest(CurrentTradeSearch, System.Net.Http.HttpMethod.Delete, "DeleteTradeRequest");
        }

        public static async Task<HttpResponseMessage> AcceptDenyTradeRequest(TradeAcceptDeny CurrentTradeAcceptDeny)
        {
            return await ProcessRequest(CurrentTradeAcceptDeny, System.Net.Http.HttpMethod.Put, "AcceptDenyTradeRequest");
        }

        public static async Task<HttpResponseMessage> CreateNewsPost(News NewsPost)
        {
            return await ProcessRequest(NewsPost, System.Net.Http.HttpMethod.Post, "CreateNewsPost");
        }

        public static async Task<HttpResponseMessage> GetNews(int NewsPage)
        {
            // Check to see if URI is empty
            if (EndPoint == String.Empty)
                throw new UriIsEmptyException("The URI is empty, please make sure you have entered the URI of the server you wish to connect to");

            CheckEndpoint();

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient Client = new HttpClient(clientHandler);

            Client.BaseAddress = new Uri(EndPoint);
            return await Client.GetAsync($"GetNewsPost/{NewsPage}");            
        }

        public static async Task<HttpResponseMessage> GetMostRecentCard(UserPut CurrentUserPut)
        {
            return await ProcessRequest(CurrentUserPut, System.Net.Http.HttpMethod.Get, "GetMostRecentCard");
        }

#region Helper Functions

        public static async Task<HttpResponseMessage> ProcessRequest<T>(T ObjectToSerialize, HttpMethod CallMethod, string ApiEndPoint)
        {
            // Check to see if URI is empty
            if (EndPoint == String.Empty)
                throw new UriIsEmptyException("The URI is empty, please make sure you have entered the URI of the server you wish to connect to");

            CheckEndpoint();

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient Client = new HttpClient(clientHandler);

            Client.BaseAddress = new Uri(EndPoint);

            string StringContent = System.Text.Json.JsonSerializer.Serialize(ObjectToSerialize);

            HttpRequestMessage HttpRequest = new HttpRequestMessage
            {
                Method = CallMethod,
                RequestUri = new Uri(EndPoint + ApiEndPoint),
                Content = new StringContent(StringContent)
            };

            /// TODO: Check for if server goes down during request
            /// FIXME: At the moment if user is logged in and server goes down the user remains logged in until a server request is made at which point the client will crash

            return await Client.SendAsync(HttpRequest);
        }

        private static void CheckEndpoint()
        {
            if (!EndPoint.EndsWith('/'))
                EndPoint += '/';
        }

#endregion
    }
}
