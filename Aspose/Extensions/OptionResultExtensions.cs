using Aspose.Models;

namespace Aspose.Extensions;

public static class OptionResultExtensions
{
    public static IEnumerable<OptionResult> MapResultBySetId(this IEnumerable<ProductOption> options, string setId)
    {
        return options
            .Where(option => option.SetId == setId)
            .Select(extra => new OptionResult
            {
                id = extra.Id,
                amount = extra.Amount,
                label = extra.Label
            });
    }
}