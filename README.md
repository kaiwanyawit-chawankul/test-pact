# test-pact
[![consumer test](https://github.com/kaiwanyawit-chawankul/test-pact/actions/workflows/consumer.yml/badge.svg)](https://github.com/kaiwanyawit-chawankul/test-pact/actions/workflows/consumer.yml) [![provider test](https://github.com/kaiwanyawit-chawankul/test-pact/actions/workflows/provider.yml/badge.svg)](https://github.com/kaiwanyawit-chawankul/test-pact/actions/workflows/provider.yml)

# How it works
1. Create provider project+test
1. Create consumer project+test
1. Run provider project => save response
1. Add Pact on consumer project with response => create pact file (need to run provider)
1. Add Pact on provider to verify consumer pact


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
    dotnet add Demo.Provider.Tests package PactNet

https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-7.0&viewFallbackFrom=aspnetcore-2.1

https://andrewlock.net/exploring-dotnet-6-part-6-supporting-integration-tests-with-webapplicationfactory-in-dotnet-6/


dotnet new sln -n Demo.Consumer
dotnet new console -n Demo.Consumer.App -o Demo.Consumer.App
dotnet new xunit -n Demo.Consumer.Tests -o Demo.Consumer.Tests
dotnet sln add Demo.Consumer.App
dotnet sln add Demo.Consumer.Tests

dotnet add Demo.Consumer.Tests reference Demo.Consumer.App
dotnet add Demo.Consumer.Tests package PactNet
https://github.com/DiUS/pact-workshop-dotnet-core-v3/
dotnet add Demo.Consumer.Tests package PactNet.Native


https://github.com/DiUS/pact-workshop-dotnet-core-v3/#step-2---integration-problems

docker-compose down
docker-compose build --no-cache
docker-compose up --build --no-start
docker-compose up --build --remove-orphans
