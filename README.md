# Box Agile Dev (BAD)

> BAD is a toolbox for the agile development of .Net Web Api projects under the framework of a workflow.


## Environment

> This library was made in C# .Net framework version 4.

## Installation

- Go to management Nuget Package in your project and searh BAD and install the last versión of `Vickodev.Utility.BAD`.
- Ok, once installed, go to any Class in the project and declare the library for use it, using BoxAgileDev; and ready.

## Tools in package

> `Result`: is a tool for Flow Process Control and return data of your application.

> `SimpleMapper`: is a simple tool for mapping object models with data models.

> `HttpResponseManager`: is a tool for management the Api Controllers and Map Json objects in Object models (PostUtility) into your application.

> `PostUtility`: is a Class into HttpResponseManager with which you can map objects in Json format to object models.


## Example (it's in process)

```c#
using BoxAgileDev;

namespace WebApiTest.Controllers
{
    public class UserController : HttpResponseManager<BMUser>
    {        
        public HttpResponseMessage Get(string email)
        {
            Result result = Instance.Get(email);
            return HandleResult(result, Request);
        }

        public HttpResponseMessage Get()
        {
            Result result = Instance.Get();
            return HandleResult(result, Request);
        }

        public HttpResponseMessage Post(dynamic userObject)
        {
            UserModel newUser = PostUtility.Get<UserModel>(userObject.user);
            Result result = Instance.Create(newUser);
            return HandleResult(result, Request);
        }

        public HttpResponseMessage Delete(dynamic userObject)
        {
            UserModel userDel = PostUtility.Get<UserModel>(userObject.user);
            Result result = Instance.Delete(userDel);
            return HandleResult(result, Request);
        }

        public HttpResponseMessage Put(dynamic userObject)
        {
            UserModel userUpd = PostUtility.Get<UserModel>(userObject.user);
            Result result = Instance.Update(userUpd);
            return HandleResult(result, Request);
        }

    }
}
```

## Usage

