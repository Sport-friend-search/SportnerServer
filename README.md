SportnerServer
==============

<b>Sportner server with RESTAPI</b>

To communicate easily, please use class libraries provided in sportnerServerLibraries.zip, add all .dll's as references to your server client project.

<b>Note!</b> There is test project provided with all example calls to server.

API documentation available: 
http://sportner.azurewebsites.net/swagger/

To start web service locally, ask password to connect to azure db, and add it to connection string, or use your own local database(use your own connection string) and perform code first to new database operations.

Good luck!

Example C# request (made using restSharp): 
```
var client = new RestClient("http://sportner.azurewebsites.net");
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

```
