using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Written by Andrew Delicata
/// https://github.com/Delie/WebApiJwt
/// </summary>
namespace WebApiJwt.TokenHelpers {
	public class TokenConfig {
		public readonly string Issuer;
		public readonly string Audience;
		public readonly int MinutesUntilExpires;
		public readonly string SecretKey;

		public TokenConfig() {
			Issuer = "TestIssuer";
			Audience = "TestWebsite";
			MinutesUntilExpires = 30;
			SecretKey = GetSecretKey();
		}

		private string GetSecretKey() {
			// IMPORTANT NOTE: in production, this needs to be fetched securely from somewhere safe :)
			// it's up to you how to do that, but for this example - we'll use a hard-coded key to make life easier
			return "this-is-a-test-key-DO-NOT-USE-THIS-IN-PRODUCTION";
		}
	}
}
