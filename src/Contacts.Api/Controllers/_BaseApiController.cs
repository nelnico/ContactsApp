using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Api.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class BaseApiController : ControllerBase
{
}