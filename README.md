
# Blazor WebAssembly N-Tier Architecture
# Project Tracker Demo application

A small demo .NET 8 application looking at structuring a Blazor Wasm solution according to the requirements of an n-tier architecture, appropiate for deploying to Azure Static Web Apps.

The application demonstrates the use of Identity on ASP.NET Core with JWT authentication.
The ASP.NET Core Identity documentaion can be found here:
https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-8.0&tabs=visual-studio

and a nice video looking at standard cookie authentication v jwt token authentication can be found here:
https://youtu.be/Cet54urCj70?si=6fvqzl8PKCy2nXmC


The app also showcases full CRUD activity with EF core 
https://learn.microsoft.com/en-us/ef/core/

and showcases some useful plugins available for Blazor WebAssembly.

# Requirements
Visual Studio 2022

Sql Server Management Studio (Tested against 18.11.1)

# Technologies covered
ASP.NET Core Web API
ASP.NET Core Blazor WebAssembly
EF Core
ASP.NET Core Identity
JWT

## Run Locally

1. Clone the project
2. Check connection string in the api appsettings.json points to an appropiate server.
3. Rename the databse as required.
4. Run the app. databse should be created authomatically and a couple of users seeded.

5. Two Users created:
    admin@example.com
    Admin123!

    user@example.com
    User123!

    Two Roles created:
    Admin
    User

    And users mapped accordingly.

    Admin user can see Users / Projects / Tasks tabs
    User can see just the Tasks tab.

    Admin user must first create projects then admin users and regular users can assign tasks against these projects.

6. The Swagger UI can be used to create additional users (or use the Register user dialog)
    https://localhost:xxxx/api/Account
    

    And then assign them additional roles if reqd.
    https://localhost:xxxx/api/Account/role

7. Pages are protected through the Authorize attribute
    @attribute [Authorize(Roles = "Admin")]

8. The supporting APIs ProjectTask and Project illustrate how an api may be secured through jwt      token authentication

    The LoginController.Login() method checks the supplied credentials against the Identity credentials held in the database. 
    A Loginresponse object is returned by the controller containing and indication of success and generated jwt token if appropiate.
    The client side auth service then writes the token to local storage (using a handy Blazored.LocalStorage plugin).

9.  You can decode your jwt token here 
    https://jwt.io/


10. Of other interest, the app demonstrates a few other useful plugins. User feedback is handled by 
https://github.com/Blazored/Toast

Also the menu bar / header demonstrate Radzen components 
https://blazor.radzen.com/
a collection of nice free components which appear play nice with bootstrap.



