# Teamwork.Net

## .Net C# Library for Project´s API
Requirements -> .Net 4.5.6 , Newtonsoft.Json 8 or newer

# Usage: 
Init new Client instance:

`var client = TeamworkProjects.Client.GetTeamworkClient(apiKey, Domain)`

###Fetch data:

`var AllProjectList = client.Projects.GetAllRecentProjects(anyDate);`


###Post Data:

To upload changes just call:<br/>
`client.Projects.UpdateProject(theProjectObject)`<br/>
`client.Projects.UpdateTask(theTask)`<br/>
`client.Projects.UpdateTaskList(theTaskList)`<br/>

alternatively you can call update directly on the object itself: <br/>
`aProjectObject.Update()`<br/>
`aTaskObject.Update()`<br/>
`aMilestoneObject.Update()`<br/>

### Lazy Loading:
By default, if you get a Project you can request all milestones, tasks, tasklists etc and just load the whole project in a single call. If you did not do this, the collection are loaded on first access. E.g. the first time you access the Milestone´s collection of a project, the milestone´s are fetched from the server. 


### Generic .Get call 

The project cotains an extension method that allows you to call .Get on literarily every object you like to. 
As long as the response can be de-serialized to the underlying class you can load any object you want like this:

`MyClass myName = new MyClass();`<br/>
`myName.Get("\endpoint\call.json?param=1","NameOfJsonRootThatContainsTheData","NameOfPropertyForJsonRoot")`



more later
