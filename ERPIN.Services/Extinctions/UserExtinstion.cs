using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ERPIN.Services.Extinctions;
public static class UserExtinction
{
    public static int GetUserId(this HttpContext httpContext)
    {
        if (httpContext == null)
            throw new ArgumentNullException(nameof(httpContext));

        var userIdString = httpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
            throw new InvalidOperationException("User ID claim is missing or invalid.");

        return userId;

    }

}
