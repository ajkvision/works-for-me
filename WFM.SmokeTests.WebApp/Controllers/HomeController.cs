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
        var mockViewModel = MockDataHelper.GetTestPlansList();
        return View(mockViewModel);
    }
    
    public IActionResult TestReports()
    {
        var mockViewModel = MockDataHelper.GetTestPlansList();
        return View(mockViewModel);
    }

    
    public IActionResult PlanDetail(int id)
    {
        var mockViewModel = MockDataHelper.GetTestPlanData(id);
        return View(mockViewModel);
    }
    
    public IActionResult EditPlan(int id)
    {
        var mockViewModel = MockDataHelper.GetTestPlanData(id);
        return View(mockViewModel);
    }
    
    public IActionResult TestPlanExcecution(int id)
    {
        var mockViewModel = MockDataHelper.GetTestPlanExecutionData(id);
        return View(mockViewModel);
    }
    
   [HttpPost]
    public IActionResult SavePlanExcecution(int id, TestPlanExecutionViewModel testResultsModel)
    {
        testResultsModel.ExecutionTime = DateTime.Now;
        MockDataHelper.SaveTestExecution(id, testResultsModel);
        return RedirectToAction("TestPlans");
    }
    
    public IActionResult CopyTestPlan(int id)
    {
        MockDataHelper.CopyTestPlan(id);
        return RedirectToAction("TestPlans");
    }

    
    public IActionResult DeletePlan(int id)
    {
        MockDataHelper.DelteTestPlan(id);
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