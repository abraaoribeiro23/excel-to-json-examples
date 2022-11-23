namespace Aspose.Models;

public class Result
{
    public string title { get; set; }
    public IEnumerable<OptionResult> options { get; set; }

    public static Result CreateMaterial(IEnumerable<OptionResult> optionResults)
    {
        return new Result
        {
            title = "Material",
            options = optionResults
        };
    }
    public static Result CreateOptional(IEnumerable<OptionResult> optionResults)
    {
        return new Result
        {
            title = "Optional",
            options = optionResults
        };
    }
}

public class OptionResult
{
    public string id { get; set; }
    public string label { get; set; }
    public string amount { get; set; }
}