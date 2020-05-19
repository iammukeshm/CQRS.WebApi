# CQRS.WebApi
Here is an implementation of CQRS with MediatR in ASP.NET Core 3.1. Read the step by step guide in my blog post.
https://www.codewithmukesh.com/blog/cqrs-in-asp-dot-net-core-3-1/

# Summary
CQRS, Command Query Responsibility Segregation is a design pattern that separates the read and write operations of a data source. Here Command refers to a Database Command, which can be either an Insert / Update or Delete Operation, whereas Query stands for Querying data from a source. It essentially separates the concerns in terms of reading and writing, which makes quite a lot of sense. 
