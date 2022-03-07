# Remnant.Dependency.CastleWindsor
Castle Windsor dependency injection adapter

# Remnant Dependency Castle Windsor
Castle windsor dependency injection adapter


## Nuget package:

        Install-Package Remnant.Dependency.CastleWindsor -Version 1.0.3
        
```csharp
var castle = new WindsorContainer();
var container = Container.Create("MyContainer", new CastleAdapter(castle));
```

