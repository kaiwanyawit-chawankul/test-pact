# test-pact
[![consumer test](https://github.com/kaiwanyawit-chawankul/test-pact/actions/workflows/consumer.yml/badge.svg)](https://github.com/kaiwanyawit-chawankul/test-pact/actions/workflows/consumer.yml) [![provider test](https://github.com/kaiwanyawit-chawankul/test-pact/actions/workflows/provider.yml/badge.svg)](https://github.com/kaiwanyawit-chawankul/test-pact/actions/workflows/provider.yml)

# How it works
1. Create provider project+test
create project script
```
dotnet new sln -n Demo.Provider
dotnet new webapi -n Demo.Provider.Api -o provider/Demo.Provider.Api
dotnet new xunit -n Demo.Provider.Tests -o provider/Demo.Provider.Tests
dotnet sln add provider/Demo.Provider.Api
dotnet sln add provider/Demo.Provider.Tests
dotnet add provider/Demo.Provider.Tests reference provider/Demo.Provider.Api
```
add references
```
dotnet add Demo.Provider.Tests package FluentAssertions
dotnet add Demo.Provider.Tests package Microsoft.AspNetCore.Mvc.Testing -v 6
Microsoft.AspNetCore.Mvc.Testing
dotnet add Demo.Provider.Tests package PactNet
```
2. Create consumer project+test
create project
```
dotnet new sln -n Demo.Consumer
dotnet new console -n Demo.Consumer.App -o Demo.Consumer.App
dotnet new xunit -n Demo.Consumer.Tests -o Demo.Consumer.Tests
dotnet sln add Demo.Consumer.App
dotnet sln add Demo.Consumer.Tests
```

add references
```
dotnet add Demo.Consumer.Tests reference Demo.Consumer.App
dotnet add Demo.Consumer.Tests package PactNet
dotnet add Demo.Consumer.Tests package PactNet.Native
```

3. Run provider project => save response
```
dotnet run --project provider/Demo.Provider.Api
```

open swagger url to save response https://localhost:7029/swagger/index.html


4. Generate a pact file
 - Add Pact to Demo.Consumer.Tests
 - Create a test consumers/Demo.Consumer.Tests/PactTest.cs
 - add response from (3) to the test
 - Generate create pact file (need to run consumer)
```
dotnet test --project consumers/Demo.Consumer.Tests
```
 - file will be saved as pacts/ApiClient-WeatherForecastService.json
5. Verify consumer pact against provider
 - Add Pact to Demo.Provider.Tests
 - Create a test provider/Demo.Provider.Tests/PactTest.cs
 - refer to pact file pacts/ApiClient-WeatherForecastService.json
 - Verify consumer pact file (need to run provider)
```
dotnet test --project Provider/Demo.Provider.Tests
```
6. Add workflow to verify provider (unit test)
7. Add workflow to verify consumer (integration test) using docker-compose
```
docker-compose up
```

# More reading
- https://github.com/DiUS/pact-workshop-dotnet-core-v3/
- https://github.com/DiUS/pact-workshop-dotnet-core-v3/#step-2---integration-problems
