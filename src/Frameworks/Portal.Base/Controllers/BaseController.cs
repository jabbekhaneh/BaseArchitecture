using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Portal.Base.Controllers;


[Route("api/[controller]")]
[ApiController]
public class BaseController : Controller
{
    protected readonly IMediator Mediator;

    public BaseController(IMediator mediator)
    {
        Mediator = mediator;
    }
}



