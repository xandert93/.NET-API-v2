using Microsoft.AspNetCore.Mvc;
using xo.Data;
using xo.Models;

namespace xo.Controllers
{
  [ApiController]
  [Route("api/users")]
  public class UserController : ControllerBase
  {

    private readonly DbContext _db;

    public UserController(IConfiguration config)
    {
      _db = new DbContext(config);
    }

    [HttpGet]
    public IEnumerable<User> GetAll()
    {
      return _db.Find<User>("SELECT * FROM MyApp.users");
    }

    [HttpGet("{id}")]
    public User GetById(string id)
    {
      return _db.FindOne<User>("SELECT * FROM MyApp.users WHERE id = " + id);
    }
  }
}
