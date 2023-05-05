# test-pact
# How it works

Create api project for provider
dotnet new sln -n Demo.Provider
dotnet new webapi -n Demo.Provider.Api -o provider/Demo.Provider.Api
dotnet new xunit -n Demo.Provider.Tests -o provider/Demo.Provider.Tests
dotnet sln add provider/Demo.Provider.Api
dotnet sln add provider/Demo.Provider.Tests
dotnet add provider/Demo.Provider.Tests reference provider/Demo.Provider.Api
dotnet add provider/Demo.Provider.Tests package FluentAssertions
dotnet add Demo.Provider.Tests package Microsoft.AspNetCore.Mvc.Testing -v 6
Microsoft.AspNetCore.Mvc.Testing
    dotnet new sln -n DemoMounteBank
    dotnet new xunit -n DemoMounteBank.Test -o test/DemoMounteBank.Test
    dotnet add test/DemoMounteBank.Test package FluentAssertions
    dotnet sln add test/DemoMounteBank.Test
    dotnet test

https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-7.0&viewFallbackFrom=aspnetcore-2.1

https://andrewlock.net/exploring-dotnet-6-part-6-supporting-integration-tests-with-webapplicationfactory-in-dotnet-6/