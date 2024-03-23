using Microsoft.AspNetCore.Mvc;

namespace xo.Controllers
{
  [ApiController]
  [Route("api/users")]
  public class UserController : ControllerBase
  {


    public UserController()
    {

    }

    [HttpGet]
    public int[] GetAll()
    {
      return [1, 2, 3];
    }

    [HttpGet("{id}")]
    public string GetById(string id)
    {
      return id;
    }
  }
}
