# Agile Development Box for .Net (BAD Core Infrastructure)

BAD Core is a utility tools for the agile development of applications and APIs in .Net under a Work Flow approach.

## Philosophy

Worry about your business rules and trivial, repetitive things and handle them with BAD Core through the standardization of a workflow.

## Included tools

For a workflow we design the following tools that will help you control the input and output of your use cases.

> `CustomHttpClient`: is a class for manage a single instance of `HttpClient` class for manage your request through the Net Core `IHttpClientFactory` interface.
The advantages offered by this implementation is the optimal management of the HTTP requests avoiding the collapse of the system connection ports and injecting the headers in the HttpRequest messages and not in the client.
