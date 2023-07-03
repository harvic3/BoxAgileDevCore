# Agile Development Box for .Net (BAD Core Adapters)

BAD Core is a utility tools for the agile development of applications and APIs in .Net under a Work Flow approach.

## Philosophy

Worry about your business rules and trivial, repetitive things and handle them with BAD Core through the standardization of a workflow.

## Included tools

For a workflow we design the following tools that will help you control the input and output of your use cases.

> `HttpSatusMapping`: is a class to manage application status and it contains de correspondig HttpStatusCode for an AplicationStatusCode.

> `ControllerExtension`: is a class to manage the response througt `IActionResult` interface or througt a simple BaseResult.

> `ProducesApplicationResponseTypeAttribute`: is a simple Attributte controller to help us to mapping ApplicationStatusCode to HttpStatusCode.

> `JsonUtil`: is a tool class with which you can deserialize/serialize objects in Json format to object models and viceversa.
