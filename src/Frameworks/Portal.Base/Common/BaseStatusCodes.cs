namespace Portal.Base.Common;
public static class BaseStatusCodes
{
    public static int OK = 200;
    public static int BadRequest = 400;
    public static int ValidateError = BadRequest;
    public static int UnAuthorized = 401;
    public static int NotFound = 404;
    public static int PerformanceMeasurement = 405;
}
