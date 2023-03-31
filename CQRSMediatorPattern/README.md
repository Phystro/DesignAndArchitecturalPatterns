# CQRS

Use it in an application that has more reads than writes to DB or it's part of a large scalable micro-service architecture.

CQRS helps to decouple operations and make the application more scalable and flexible on large scale.

We can use Command Query Responsibility Segregation when the application is huge and access the same data in parallel. CQRS helps reduce merge conflicts while performing multiple operations with data.

In DDD terminology, if the domain data model is complex and needs to perform many operations on priority like validations and executing some business logic so in that case, we need the consistency that we will by using CQRS.

MediatR pattern helps to reduce direct dependency between multiple objects and make them collaborative through MediatR.

In .NET Core MediatR provides classes that help to communicate with multiple objects efficiently in a loosely coupled manner.
