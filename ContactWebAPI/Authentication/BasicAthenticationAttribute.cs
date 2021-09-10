
using Microsoft.AspNetCore.Authorization;

namespace ContactWebAPI.Authentication
{
	public class BasicAuthorizationAttribute : AuthorizeAttribute
	{
		public BasicAuthorizationAttribute()
		{
			Policy = "BasicAuthentication";
		}
	}
}