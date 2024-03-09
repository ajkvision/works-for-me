namespace WFM.SmokeTests.Domain.Entities;

public class TestPlan
{
    public string TestPlanGuid { get; set; }
    public string TestVersionId { get; set; }
    public string TestPlanName { get; set; }
    public string TestPlanDescription { get; set; }
    public List<TestStep> TestPlanSteps { get; set; }
}