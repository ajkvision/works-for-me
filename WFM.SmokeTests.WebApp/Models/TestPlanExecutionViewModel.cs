namespace WFM.SmokeTests.App.Models;

public class TestPlanExecutionViewModel
{
    public int PlanId { get; set; }
    public string PlanCaption { get; set; }
    public string PlanDescription { get; set; }
    public List<PlanSetpResult> PlanStepsResults { get; set; }
}

public class PlanSetpResult
{
    public string StepName { get; set; }
    public bool TestPassed { get; set; }
}