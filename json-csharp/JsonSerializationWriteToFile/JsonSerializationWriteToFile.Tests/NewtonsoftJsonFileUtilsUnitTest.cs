using Xunit;
using System.IO;
using JsonSerializationWriteToFile.Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace JsonSerializationWriteToFile.Tests;

public class NewtonsoftJsonFileUtilsUnitTest
{
    [Fact]
    public void GivenObject_WhenCallWithSimpleWrite_ThenProducesJsonFile()
    {
        var colleges = SurveyReport.GetColleges();
        var fileName = "Colleges.json";

        JsonFileUtils.SimpleWrite(colleges, fileName);

        var expctedContent = @"[{""Name"":""Juvenile"",""NoOfStudents"":300,""IsPublic"":false},{""Name"":""Cambrian"",""NoOfStudents"":650,""IsPublic"":true},{""Name"":""Mapple Leaf"",""NoOfStudents"":450,""IsPublic"":true}]";

        var actualContent = File.ReadAllText(fileName);
        Assert.Equal(expctedContent, actualContent);
    }

    [Fact]
    public void GivenObject_WhenCallWithPrettyWrite_ThenProducesReadableJsonFile()
    {
        var colleges = SurveyReport.GetColleges();
        var fileName = "Colleges-pretty.json";

        JsonFileUtils.PrettyWrite(colleges, fileName);

        var expctedContent = @"[
  {
    ""Name"": ""Juvenile"",
    ""NoOfStudents"": 300,
    ""IsPublic"": false
  },
  {
    ""Name"": ""Cambrian"",
    ""NoOfStudents"": 650,
    ""IsPublic"": true
  },
  {
    ""Name"": ""Mapple Leaf"",
    ""NoOfStudents"": 450,
    ""IsPublic"": true
  }
]";

        var actualContent = File.ReadAllText(fileName);
        Assert.Equal(expctedContent.ReplaceLineEndings(), actualContent);
    }

    [Fact]
    public void GivenObject_WhenCallWithUtf8BytesWrite_ThenProducesJsonFile()
    {
        var colleges = SurveyReport.GetColleges();
        var fileName = "Colleges-utf8.json";

        JsonFileUtils.Utf8BytesWrite(colleges, fileName);

        var expctedContent = @"[{""Name"":""Juvenile"",""NoOfStudents"":300,""IsPublic"":false},{""Name"":""Cambrian"",""NoOfStudents"":650,""IsPublic"":true},{""Name"":""Mapple Leaf"",""NoOfStudents"":450,""IsPublic"":true}]";

        var actualContent = File.ReadAllText(fileName);
        Assert.Equal(expctedContent, actualContent);
    }

    [Fact]
    public async Task GivenObject_WhenCallWithStreamWriteAsync_ThenProducesJsonFile()
    {
        var colleges = SurveyReport.GetColleges();
        var fileName = "Colleges-stream-async.json";

        await JsonFileUtils.StreamWriteAsync(colleges, fileName);

        var expctedContent = @"[{""Name"":""Juvenile"",""NoOfStudents"":300,""IsPublic"":false},{""Name"":""Cambrian"",""NoOfStudents"":650,""IsPublic"":true},{""Name"":""Mapple Leaf"",""NoOfStudents"":450,""IsPublic"":true}]";

        var actualContent = File.ReadAllText(fileName);
        Assert.Equal(expctedContent, actualContent);
    }

    [Fact]
    public void GivenDynamicJsonObject_WhenCallWithWriteDynamicJsonObject_ThenProducesJsonFile()
    {
        var fileName = "Dynamic-json.json";
        var jsonObj = new JObject
        {
            ["Name"] = "SunnyDale",
            ["NoOfStudents"] = 200,
            ["IsPublic"] = true
        };

        JsonFileUtils.WriteDynamicJsonObject(jsonObj, fileName);

        var expctedContent = @"{""Name"":""SunnyDale"",""NoOfStudents"":200,""IsPublic"":true}";

        var actualContent = File.ReadAllText(fileName);
        Assert.Equal(expctedContent, actualContent);
    }
}