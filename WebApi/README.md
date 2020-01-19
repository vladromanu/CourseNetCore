# Guideless for API Project
[done] 1. Create an Web API Project for your data layer (your domain problem)


2. Add REST endpoints for all entities (at least 3 endpoints)
Create endpoints for 'child' resources

[Route("api/hotels/{hotelId}/rooms")]
[ApiController]
public class RoomsController : ControllerBase

3. Add a global exception handler (log exceptions also)

[done]4. Use middlewares to log the duration of each request (information)
[done]5. Use models, not entireties. Add validations
[done]6. Add swagger UI

7. Put all configurations (db connection string) in the configuration file

8. Create a logger with filtered configuration for minimum log level:

    all logs from System and Microsoft namespace - min level: "Error"
    all logs from your code - min level - "Warning"
    all requests from your middleware (that logs the duration) - "Information"
    default - "Trace"

9. Add security to endpoints

    configure external authentication/authorization (use Identity Server / Auth0 / Other provider) (if
    swagger ui can be configured to set also a auth header: https://ppolyzos.com/2017/10/30/add-jwt-bearer-authorization-to-swagger-and-asp-net-core/

10. Add caching to endpoints

    use memory caching + invalidation (when the resources are updated)
    use distributed caching

11. Add a cancellation token param for all API routes methods
[done]