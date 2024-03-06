namespace WFM.SmokeTests.App.Models;

public class TestPlanViewModel
{
    public int PlanId { get; set; }
    public string PlanCaption { get; set; }
    public string PlanDescription { get; set; }
    public List<string> PlanSteps { get; set; }
}