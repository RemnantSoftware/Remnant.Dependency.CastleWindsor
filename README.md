# Remnant.Dependency.CastleWindsor
Castle Windsor dependency injection adapter

# Remnant Dependency Castle Windsor
Castle windsor dependency injection adapter


## Nuget package:

        Install-Package Remnant.Dependency.CastleWindsor -Version 1.0.3

Create container for Castle Windsor
```csharp
var castle = new WindsorContainer();
var container = Container.Create("MyContainer", new CastleAdapter(castle));
```

Get direct access to the internal DI container
```csharp
var castle = Container.Instance.InternalContainer<WindsorContainer>();
```
