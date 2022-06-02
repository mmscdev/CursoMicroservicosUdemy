using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNetUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult GetSum(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = Convert.ToDecimal(firstNumber) + Convert.ToDecimal(secondNumber);

            return Ok(sum.ToString());
        }

        return BadRequest("InvalidInput");
    }

    [HttpGet("multiply/{firstNumber}/{secondNumber}")]
    public IActionResult GetMultiply(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = Convert.ToDecimal(firstNumber) * Convert.ToDecimal(secondNumber);

            return Ok(sum.ToString());
        }

        return BadRequest("InvalidInput");
    }

    [HttpGet("subtract/{firstNumber}/{secondNumber}")]
    public IActionResult GetSubtraction(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = Convert.ToDecimal(firstNumber) -  Convert.ToDecimal(secondNumber);

            return Ok(sum.ToString());
        }

        return BadRequest("InvalidInput");
    }

    [HttpGet("mean/{firstNumber}/{secondNumber}")]
    public IActionResult GetMean(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = (Convert.ToDecimal(firstNumber) + Convert.ToDecimal(secondNumber))/2;

            return Ok(sum.ToString());
        }

        return BadRequest("InvalidInput");
    }

    [HttpGet("squareRoot/{number}")]
    public IActionResult GetSquareRoot(string number)
    {
        if (IsNumeric(number))
        {
            var sum = Math.Sqrt(Convert.ToDouble(number));

            return Ok(sum.ToString());
        }

        return BadRequest("InvalidInput");
    }

    [HttpGet("division/{firstNumber}/{secondNumber}")]
    public IActionResult GetDivision(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = (Convert.ToDecimal(firstNumber)/ Convert.ToDecimal(secondNumber));

            return Ok(sum.ToString());
        }

        return BadRequest("InvalidInput");
    }

    private bool IsNumeric(string strNumber)
    {
        double number;

        bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any,
             System.Globalization.NumberFormatInfo.InvariantInfo,
             out number);

        return isNumber;
    }
}
