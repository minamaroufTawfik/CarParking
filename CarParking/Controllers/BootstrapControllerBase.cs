using Microsoft.AspNetCore.Mvc;
using CarParking.Helpers;

namespace CarParking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootstrapControllerBase : ControllerBase
    {
        private JsonUtility _jsonUtility;
        protected JsonUtility JsonUtility => _jsonUtility ??= new JsonUtility();
    }
}
