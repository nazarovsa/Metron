Metron
========================
[![Build Status](https://travis-ci.org/InsightAppDev/Metron.svg?branch=master)](https://travis-ci.org/InsightAppDev/Metron)
[![nuget version](https://img.shields.io/nuget/v/Metron)](https://www.nuget.org/packages/Metron/)
[![Nuget](https://img.shields.io/nuget/dt/Metron?color=%2300000)](https://www.nuget.org/packages/Metron/)

Metron is simple metrics library.

Get started
--------------------------
1. Create model which inherits from Model. Model contains Guid Id and DateTimeOffset CreatedAt properties which initialized at parameterless constructor. 
```csharp 
public sealed class UserLoggedIn : Model 
{
  public string Username { get; set; }
}
```
2. Initialize repository which implements IModelRepository<TModel>
```csharp
public sealed class InMemoryRepository : IModelRepository<UserLoggedIn> 
{
  private readonly List<UserLoggedIn> _items;
  
  public InMemoryRepository()
  {
    _items = new List<UserLoggedIn>();
  }
  
  public Task Add(UserLoggedIn model, CancellationToken cancellationToken = default)
  {
    _items.Add(model);
    return Task.CompletedTask;
  }
    
  public Task<IReadOnlyCollection<UserLoggedIn>> Get(CancellationToken cancellationToken = default)
    => Task.FromResult<IReadOnlyCollection<UserLoggedIn>>(_items);
}
```
3. Initialize Metron instance with created repository.
```csharp
var repository = new InMemoryRepository();
var metron = new Metron(repository);
```
4. Use metron instance to write and get metrics.
```csharp
var item = new UserLoggedIn { Username = "root" };
await metron.Add(item);
var items = metron.Get(CancellationToken.None);
```
  
Metron.Extensions
========================
[![nuget version](https://img.shields.io/nuget/v/Metron.Extensions)](https://www.nuget.org/packages/Metron.Extensions/)
[![Nuget](https://img.shields.io/nuget/dt/Metron.Extensions?color=%2300000)](https://www.nuget.org/packages/Metron.Extensions/)

DI extensions for Metron.

Avaliable containers:
- Autofac

Readme in progress

Metron.Repository
========================
[![nuget version](https://img.shields.io/nuget/v/Metron.Repository)](https://www.nuget.org/packages/Metron.Repository/)
[![Nuget](https://img.shields.io/nuget/dt/Metron.Repository?color=%2300000)](https://www.nuget.org/packages/Metron.Repository/)

Repositories for Metron.

Avaliable repositories:
- MongoDb

Readme in progress
