# WebApiJwt
.NET Core 1.0 Web API starter project with JWT authentication of HTTP Headers

Just use [Authorize] on your web api methods, and .net will check that the JWT is valid automatically.  Configure options

This is NOT production-ready.  You will need to
1.  Add some user login / validation to the TokenController.Post method.
2. Use a proper password for the TokenConfig.SecretKey.  Ideally the password will be stored somewhere secure, outside of the project entirely. 

You're free to use as you please.  

Andrew Delicata 
Freelance .NET and JavaScript programmer based in Salisbury, UK
http://www.sarumcreative.com