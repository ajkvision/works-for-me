using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using WFM.SmokeTests.App.Helpers;
using WFM.SmokeTests.App.Models;

namespace WFM.SmokeTests.App.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult TestPlans()
    {
        var mockViewModel = new TestPlansViewModel()
            { Header = "Test plans list", TestPlansList = new List<TestPlanInfo>(){new TestPlanInfo(1, "Smoke tests Admin Panel"),new TestPlanInfo(2, "Smoke tests quick") }};
        return View(mockViewModel);
    }


    public IActionResult PlanDetail(int id)
    {
        var mockViewModel = MockDataHelper.GetTestPlanData(id);
        return View(mockViewModel);
    }
    
    public IActionResult CopyTestPlan(int id)
    {
        var mockViewModel = MockDataHelper.GetTestPlanData(id);
        return RedirectToAction("TestPlans");
    }

    
    public IActionResult DeletePlan(int id)
    {
        var mockViewModel = MockDataHelper.GetTestPlanData(id);
        return RedirectToAction("TestPlans");
    }


    public IActionResult DownloadPlanDetailJson(int id)
    {
        var mockViewModel = MockDataHelper.GetTestPlanData(id);
        var jsonContent = JsonSerializer.Serialize(mockViewModel);

        var fileName = $"TestPlan_{mockViewModel.PlanId.ToString("000")}_d{DateTime.Now.ToString("yyyymmdd")}.json";
        
        var stream = new MemoryStream(Encoding.Unicode.GetBytes(jsonContent));
        return new FileStreamResult(stream, new MediaTypeHeaderValue("text/json"))
        {
            FileDownloadName = fileName
        };        
    }
    
    public IActionResult DownloadPlanDetailText(int id)
    {
        var mockViewModel = MockDataHelper.GetTestPlanData(id);
        var textContent = new StringBuilder();
        textContent.AppendLine($"Test scenario -> {mockViewModel.PlanCaption}");
        textContent.AppendLine($"Test description -> {mockViewModel.PlanDescription}");
        textContent.AppendLine($"See test steps below: ");
        foreach (var planStep in mockViewModel.PlanSteps)
        {
            textContent.AppendLine($"-> {planStep}");
        }

        textContent.AppendLine("-------------");
        textContent.AppendLine($"Test plan id:{mockViewModel.PlanId},  Generated at:{DateTime.Now.ToString("yyyymmdd")} ");

        var fileName = $"TestPlan_{mockViewModel.PlanId.ToString("000")}_d{DateTime.Now.ToString("yyyymmdd")}.txt";
        
        var stream = new MemoryStream(Encoding.Unicode.GetBytes(textContent.ToString()));
        return new FileStreamResult(stream, new MediaTypeHeaderValue("text/plain"))
        {
            FileDownloadName = fileName
        };        
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}