namespace WFM.SmokeTests.App.Models;

public class TestPlansViewModel
{
    public string Header { get; set; }
    
    public List<TestPlanInfo> TestPlansList { get; set;}
}

public record TestPlanInfo(int PlanId, string PlanName);