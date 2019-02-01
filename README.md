# Teamwork.Net
[![Build Status](https://travis-ci.com/Teamwork/dotnet.svg?token=R12oYgGSHPyyQRhqQcMP&branch=master)](https://travis-ci.com/Teamwork/dotnet)

## Legacy SDK
If you are still using or want to use our old legacy SDK, use the [Legacy Branch](https://github.com/Teamwork/dotnet/tree/legacy)
Please note that we are not updating the old sdk any more and feature are only added to the new sdk. Its highly recommended to not start new projects with the legacy sdk. 

## Developer Docs
If you are looking for API documentation go [here](http://developer.teamwork.com)

# Usage: 
Install the SDK

`install-package Teamwork -IncludePrerelease`

## Authentication
Note, to get the Token and domain you need to use our [App Loginflow](https://developer.teamwork.com/projects/authentication-questions/how-to-authenticate-via-app-login-flow)

When using the SDK you only need to handle the first step yourself, once you got a code back from our system you can use our helper to retrieve the final access token along with user data:

            var response = await GetLoginDataAsync(code);

With that you can get an instance of the client itself:

            var client = Teamwork.Client.GetTeamworkClient(
            response.TokenData.Installation.Url,
            response.TokenData.AccessToken, true);

If you are using our legacy api key (deprecated and not recomended to use)

            var client = TeamworkProjects.Client.GetTeamworkClient(apiKey, Domain,false)





## Fetching Data
Fetching data is really simple, just like this:

            var myProjects = client.Projects.Projects.GetAllAsync()
            var taskOfAProjects = client.Projects.Tasks.GetAllAsync(projectid, optional: tasklistid)

## Manipulating data
You can also create or update items using the sdk, done like this:

To create a new task to a project

            var myNewTask = new TodoItem() {
                Description = "My Task Description",
                Content = "My Task Title"
            };
            var result = client.Projects.Projects.AddTodoItem(myNewTask);

To update an existing task

            // Add all fields you want to update, need the task id
            var myUpdatedTask = new TodoItem() {
                id = "myTaskID",
                Description = "My Task Description",
                Content = "My Task Title"
            };

            result = client.Projects.Tasks.UpdateTask(myNewTask);
            
## Support and feedback
if you have any question, need support or have any feedback please send us a message to [api@teamwork.com](mailto:api@teamwork.com)

