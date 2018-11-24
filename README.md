# Teamwork.Net
[![Build Status](https://travis-ci.com/Teamwork/dotnet.svg?token=R12oYgGSHPyyQRhqQcMP&branch=master)](https://travis-ci.com/Teamwork/dotnet)

## Legacy SDK
If you are still using or want to use our old legacy SDK, use the (https://github.com/Teamwork/dotnet/tree/legacy)[Legacy Branch]

## Developer Docs
If you are looking for API documentation go (http://developer.teamwork.com)[here]

# Usage: 
Install the SDK

`install-package Teamwork`


Init new Client instance:

`var client = TeamworkProjects.Client.GetTeamworkClient(apiKey, Domain)`

Note, to get the APIKey and domain you need to use our (https://developer.teamwork.com/projects/authentication-questions/how-to-authenticate-via-app-login-flow)[App Loginflow] 



