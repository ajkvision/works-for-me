using WFM.SmokeTests.App.Models;

namespace WFM.SmokeTests.App.Helpers;

public static class MockDataHelper
{
    private static List<TestPlanViewModel> testPlansMockData;

    
    static MockDataHelper()
    {
        InitMockData();
    }

    private static void InitMockData()
    {
        testPlansMockData = new List<TestPlanViewModel>();
        
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
        
        testPlansMockData.Add(mockViewModel);
        
        mockViewModel = new TestPlanViewModel();
        mockViewModel.PlanCaption = "My website smoke tests";
        mockViewModel.PlanDescription = "This test plan checks basic func. on forntend";
        mockViewModel.PlanId = 2;
        mockViewModel.PlanSteps = new List<string>()
        {
            "Open home page, check image rendering",
            "Check attachemnets",
            "Check chart rendering"
        };
        
        testPlansMockData.Add(mockViewModel);
    }

    public static TestPlansViewModel GetTestPlansList()
    {
        var mockViewModel = new TestPlansViewModel()
            { Header = "Test plans list", TestPlansList = new List<TestPlanInfo>(){new TestPlanInfo(1, "Smoke tests Admin Panel"),new TestPlanInfo(2, "Smoke tests quick") }};
        return mockViewModel;
    }

    public static TestPlanViewModel GetTestPlanData(int planId)
    {
        return testPlansMockData.First(testPlan => testPlan.PlanId == planId);
    }
}