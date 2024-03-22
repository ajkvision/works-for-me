using WFM.SmokeTests.App.Models;

namespace WFM.SmokeTests.App.Helpers;

public static class MockDataHelper
{
    public static TestPlanViewModel GetTestPlanData(int planId)
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
}