# Agile Development Box for .Net (BAD Core)

BAD Core is a utility tool for the agile development of applications and APIs in .Net under a Work Flow approach.

1. [Philosophy 🧘🏽](#philosophy)
1. [Included tools 🧰](#included-tools)

## Philosophy

Worry about your business rules and trivial, repetitive things and handle them with BAD Core through the standardization of a workflow.

## Included tools

For a workflow we design the following tools that will help you control the input and output of your use cases.

> `BaseResult`: is a class for flow business control and set the response data for request of your application.

> `CommonResponse`: is a class for management the response througt `IActionResult` interface of each request into called Controller method.

> `SimpleMapper`: is a simple tool for mapping object models with data models (Simple objects or collections, not work for mixtures for the moment).

> `ControllerManager`: is a class based in `ControllerBase` class for  for management the Controller methods and deserialize/serialize Json objects in object models (JsonUtil) into your application and get a method (HanlderResponse) for manage the result for current request.

> `JsonUtil`: is a tool class into `ControllerManager` with which you can deserialize/serialize objects in Json format to object models and viceversa.

> `CustomHttpClient`: is a class for manage a single instance of `HttpClient` class for manage your request through the Net Core `IHttpClientFactory` interface.
The advantages offered by this implementation is the optimal management of the HTTP requests avoiding the collapse of the system connection ports and injecting the headers in the HttpRequest messages and not in the client.

