# WebApiJwt
.NET Core 1.0 Web API with JWT authentication of HTTP Headers

Incredibly basic starter project to help get started with .NET and JWT.

Just use [Authorize] on your web api methods, and .net will check that the JWT is valid automatically.  

**Initial routes to test with:**
- /api/token - send username and password, receive token
- /api/values/testguestroute - tests guest web method (no JWT token needed)
- /api/values/testauthroute - tests [Authorized] web method (you will need to send a JWT!)

You can practice sending/receiving tokens by using a tool such as Postman or Telerik Fiddler.

## This is **NOT production-ready**

You will need to:

 1. Add some user login / validation code to the TokenController.Post
    method.

 2. Use a proper password for the TokenConfig.SecretKey.  Ideally the password will be stored somewhere secure, outside of the project entirely.

You're free to use as you please!

Cheers,

Andy  
Freelance .NET and JavaScript programmer based in Salisbury, UK  
https://github.com/Delie/WebApiJwt
