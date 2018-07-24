# Auth0 ASP.NET Web API example

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->


- [What is it?](#what-is-it)
- [Stack](#stack)
- [Requirements](#requirements)
- [Set up](#set-up)
  - [Auth0 setup](#auth0-setup)
  - [Local setup](#local-setup)
- [Resources](#resources)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

## What is it?
ASP.NET (OWIN) Web API example project to test use of [Auth0](auth0.com) as 
an Identity Platform / NICE Accounts replacement
  
## Stack
- .NET Framework 4.5.1
- ASP.NET WebApi
- OWIN OpenId Connect

## Requirements
- Visual Studio 2015+

## Set up

### Auth0 setup

- Log into your [Auth0](auth0.com) account and go to the [API section](https://manage.auth0.com/#/apis)

- Create a new API, e.g. `NICE API` with the identifier being the root of your API,
 e.g.: `http://localhost:56573/api` (This is only for identification purposes. 
 Auth0 will not call the API)

- Go into the API `Settings` and make note of the following settings that 
will be used in this this apps' `Web.config`
    - `Identifier` will be used in the `auth0:ApiIdentifier` setting

- Go into the API `Scopes` tab and add a scope named `read:guidance`

- Go into the API `Machine to Machine Appications` tab and make sure the `NICE API (Test Application)`
is authorised. Expand the horizontal tab and select `read:guidance` scope and click `Update`

- Go to the [Applications section](https://manage.auth0.com/#/applications) and select the `NICE API (Test Application)`

- Make note of the following setting that will be used in the
 [API consuming app configuration](https://github.com/nhsevidence/auth0-example-asp/blob/master/Auth0ExampleAsp/Web.config)
    - `Client ID` will be used in the  `auth0:ApiClientId` setting
    - `Client Secret` will be used in the `auth0:ApiClientSecret` setting

- Make note of the following setting that will be used in this apps' `Web.config`
    - `Domain` will be used in the `auth0:Domain`

### Local setup
- Make sure port `56573` is free
- In IIS create an Application Pool (CLR v4) and add a site using `{app_directory}\Auth0ExampleApi` as the content directory
- Configure it to use `localhost` as hostname and `56573` as port
- Open the app in Visual Studio (2015+) and build it
- Go to `http://localhost:56573/api` and see the available endpoints

## Resources

[Auth0 ASP.NET Web API (OWIN): Authorization](https://auth0.com/docs/quickstart/backend/webapi-owin/01-authorization)

[Auth0 ASP.NET Web API (OWIN): Using your API](https://auth0.com/docs/quickstart/backend/webapi-owin/02-using)

[Auth0 ASP.NET Web API (OWIN) code samples](https://github.com/auth0-samples/auth0-aspnet-owin-webapi-samples)