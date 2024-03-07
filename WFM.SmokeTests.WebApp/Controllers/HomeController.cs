using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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

    private TestPlanViewModel getTestPlanData(int planId)
    {
        var mockViewModel = new TestPlanViewModel();
        mockViewModel.PlanCaption = "My website smoke tests";
        mockViewModel.PlanDescription = "This test plan checks basic func. on forntend";
        mockViewModel.PlanId = 1;
        mockViewModel.PlanSteps = new List<string>()
        {
            "Open home page, check image rendering",
            "Check attachemnets",
            "Check chart rendering"
        };
        return mockViewModel;
    }
    public IActionResult PlanDetail(int id)
    {
        var mockViewModel = getTestPlanData(id);
        return View(mockViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}