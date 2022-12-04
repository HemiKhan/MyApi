namespace App_CleanArchitecture.Helpers;

using System.Security.Claims;

public static class Auth
{
  public static long GetOrgId(ClaimsPrincipal claimsPrincipal)
  {
    var temp = claimsPrincipal.Claims?.Where(x => x.Type == "zoneinfo")?.FirstOrDefault()?.Value;
    if (temp is null)
      return 1;
    return long.Parse(temp);
  }

  public static long GetOrgId(HttpContext httpContext)
  {
    var temp = httpContext.User.Claims?.Where(x => x.Type == "zoneinfo")?.FirstOrDefault()?.Value;
    if (temp is null)
      return 1;
    return long.Parse(temp);
  }
}
