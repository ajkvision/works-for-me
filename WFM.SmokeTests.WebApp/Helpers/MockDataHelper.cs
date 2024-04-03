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
        mockViewModel.PlanCaption = "Admin panel smoke tests";
        mockViewModel.PlanDescription = "This test plan checks basic func. of admin panel";
        mockViewModel.PlanId = 2;
        mockViewModel.PlanSteps = new List<string>()
        {
            "Open home page, login as admin",
            "Check menu, settings options should be visible",
            "Try edit item"
        };
        
        testPlansMockData.Add(mockViewModel);
    }

    public static TestPlansViewModel GetTestPlansList()
    {
        var testPlansList = new List<TestPlanInfo>();
        if (testPlansMockData.Any())
        {
            testPlansMockData.ForEach(
                tp => testPlansList.Add(new TestPlanInfo(tp.PlanId, tp.PlanCaption))
                );
        }
        
        var mockViewModel = new TestPlansViewModel()
            { Header = "Test plans list", TestPlansList = testPlansList};
        return mockViewModel;
    }

    public static TestPlanViewModel GetTestPlanData(int planId)
    {
        return testPlansMockData.First(testPlan => testPlan.PlanId == planId);
    }
    
    public static void DelteTestPlan(int planId)
    {
        testPlansMockData.RemoveAll(testPlan => testPlan.PlanId == planId);
    }
    
    public static void CopyTestPlan(int planId)
    {
        var testPlan = testPlansMockData.First(testPlan => testPlan.PlanId == planId);
        var newtestPlan = new TestPlanViewModel();
        newtestPlan.PlanDescription = testPlan.PlanDescription;
        newtestPlan.PlanCaption = testPlan.PlanCaption;
        newtestPlan.PlanId = testPlansMockData.Max(tp => tp.PlanId) + 1;
        newtestPlan.PlanSteps = new List<string>();
        testPlan.PlanSteps.ForEach(ps => newtestPlan.PlanSteps.Add(ps));
        
        testPlansMockData.Add(newtestPlan);
    }
}