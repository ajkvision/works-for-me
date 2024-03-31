using WFM.SmokeTests.App.Models;

namespace WFM.SmokeTests.App.Helpers;

public static class MockDataHelper
{

    List<
    public static MockDataHelper()
    {
        InitMockData();
    }

    private static void InitMockData()
    {
        throw new NotImplementedException();
    }

    public static TestPlansViewModel GetTestPlansList()
    {
        var mockViewModel = new TestPlansViewModel()
            { Header = "Test plans list", TestPlansList = new List<TestPlanInfo>(){new TestPlanInfo(1, "Smoke tests Admin Panel"),new TestPlanInfo(2, "Smoke tests quick") }};
        return mockViewModel;
    }

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