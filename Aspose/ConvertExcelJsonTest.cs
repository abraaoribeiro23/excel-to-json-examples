using Aspose.Cells;
using Aspose.Extensions;
using Aspose.Models;
using Newtonsoft.Json;
using Xunit;

namespace Aspose;

public class ConvertExcelJsonTest
{
    private const string JsonSavedFile = "temp.json";

    [Fact]
    public void Converter()
    {
        var workbook = new Workbook("Xlsx\\products.xlsx");
        workbook.Save($"Xlsx\\{JsonSavedFile}");

        var reader = new StreamReader($"Xlsx\\{JsonSavedFile}");
        var jsonString = reader.ReadToEnd();

        var entitie = JsonConvert.DeserializeObject<TableData>(jsonString);

        reader.Dispose();

        Assert.NotNull(entitie);
        Assert.NotNull(entitie.Products);
        Assert.NotNull(entitie.Materials);
        Assert.NotNull(entitie.Optionals);

        var deliveryResult = ExtractProductsResult(entitie);

        var resultObj = new
        {
            products = deliveryResult
        };

        var resultObjJson = JsonConvert.SerializeObject(resultObj);

        Assert.NotNull(resultObjJson);

        //File.WriteAllText(@"D:\products.json", resultObjJson);
    }
    
    private static IDictionary<string, IEnumerable<Result>> ExtractProductsResult(TableData tableData)
    {
        var resultMap = new Dictionary<string, IEnumerable<Result>>();

        foreach (var product in tableData.Products.DistinctBy(p => p.Id))
        {
            var materials = tableData.Materials
                .MapResultBySetId(product.Id);

            var optionals = tableData.Optionals
                .MapResultBySetId(product.Id);
            
            
            var resultPersonalizes = Result.CreateMaterial(materials);
            var resultExtras = Result.CreateOptional(optionals);

            var results = new List<Result> {resultPersonalizes, resultExtras };

            resultMap.Add(product.Id, results);
        }

        return resultMap;
    }
}
