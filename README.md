SportnerServer
==============

Sportner server with RESTAPI

To communicate easily, please use class librarys provided in sportnerServerLibraries.zip, add all .dll's as references to your server client project.

Note! There is test project provided with all example calls to server!
API documentation available: http://sportner.azurewebsites.net/swagger/

Example request (made using restSharp): 
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
