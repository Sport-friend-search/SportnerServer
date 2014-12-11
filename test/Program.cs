using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using Sportner.Messages.EventMessages;
using Sportner.Messages.UserMessages;
using Sportner.Models;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("http://sportner.azurewebsites.net");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            Program test = new Program();

            User user = new User
            {
                Username = "Lukas",
                Password = "linijumxxx"
            };

            User updatedUser = new User
            {
                UserId = 32,
                Username = "Lukas",
                Password = "redHubXXX"
            };

            //test.GetAllUsers(client);
            //test.GetUser(client, 17);
            //test.InsertUser(client, user);
            //test.UpdateUser(client, updatedUser);

            test.GetFilteredEvents(client);
        }

        public void GetAllUsers(RestClient client)
        {
            var request = new RestRequest("api/Users", Method.GET);

            // execute the request
            var response = client.Execute(request);
            var content = response.Content; // raw content as string

            JsonDeserializer deserial = new JsonDeserializer();

            var usersList = deserial.Deserialize<GetAllUsersResponse>(response);
        }

        public void GetUser(RestClient client, int userId)
        {
            var request = new RestRequest("api/Users" + userId, Method.GET);

            // execute the request
            var response = client.Execute(request);
            var content = response.Content; // raw content as string

            JsonDeserializer deserial = new JsonDeserializer();

            var user = deserial.Deserialize<GetUserResponse>(response);
        }

        public void InsertUser(RestClient client, User user)
        {
            var request = new RestRequest("api/Users", Method.POST);

            AddUserRequest requestData = new AddUserRequest
            {
                User = user
            };

            var json = JsonConvert.SerializeObject(requestData);
            request.AddParameter("text/json", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            // execute the request
            var resp = client.Execute(request);
            var content = resp.Content;
        }

        public void UpdateUser(RestClient client, User user)
        {
            var request = new RestRequest("api/Users", Method.PUT);

            UpdateUserRequest requestData = new UpdateUserRequest
            {
                User = user
            };

            var json = JsonConvert.SerializeObject(requestData);
            request.AddParameter("text/json", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            var resp = client.Execute(request);
            var content = resp.Content;
        }

        public void GetFilteredEvents(RestClient client)
        {
            var request = new RestRequest("api/GetFilteredEvents", Method.POST);

            GetFilteredEventsRequest requestData = new GetFilteredEventsRequest
            {
                City = "Vilnius"
            };

            var json = JsonConvert.SerializeObject(requestData);
            request.AddParameter("text/json", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            // execute the request
            var response = client.Execute(request);
            var content = response.Content; // raw content as string

            JsonDeserializer deserial = new JsonDeserializer();

            var getFilteredEventsResponse = deserial.Deserialize<GetFilteredEventsResponse>(response);
        }
    }
}
