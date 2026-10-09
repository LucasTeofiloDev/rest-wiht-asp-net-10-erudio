using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestLogsController : ControllerBase
    {
        private readonly ILogger<TestLogsController> _logger;

        public TestLogsController(ILogger<TestLogsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult LosTest()
        {
            _logger.LogInformation("Fetching all test logs");
            _logger.LogWarning("This is a warning log for test logs");
            _logger.LogError("This is an error log for test logs");
            _logger.LogCritical("This is a critical log for test logs");
            _logger.LogDebug("This is a debug log for test logs");
            _logger.LogTrace("This is a trace log for test logs");

            return Ok(new { Message = "Test logs fetched successfully" });
        }
    }
}
