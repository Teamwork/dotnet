# Teamwork.Net

## .Net C# Library for Project´s API
Requirements -> .Net 4.5.6 , Newtonsoft.Json 8 or newer

# Usage: 
Init new Client instance:

`var client = TeamworkProjects.Client.GetTeamworkClient(apiKey, Domain)`

Fetch data:

`var AllProjectList = client.Projects.GetAllRecentProjects(anyDate);`



more later
