using Contract;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]


public class WeatherForecastController : ControllerBase
{
    private readonly ILoggerManager _logger;
    private IRepositoryWrapper _repository;

    public WeatherForecastController(ILoggerManager logger, IRepositoryWrapper repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    public IEnumerable<string> Get()
    {
        _logger.LogInfo("Here is info message from the controller.");
        _logger.LogDebug("Here is debug message from the controller.");
        _logger.LogWarn("Here is warn message from the controller.");
        _logger.LogError("Here is error message from the controller.");

        var domesticAccounts = _repository.Account.FindByCondition(x => x.AccountType.Equals("Domestic"));
        var owners = _repository.Owner.FindAll();

        return new string[] { "info", "value2" };
    }
}