namespace WFM.SmokeTests.Domain.Entities;

public class TestStep
{
    public string StepGuid { get; set; }
    public string StepName { get; set; } = default;
    public string StepDescription { get; set; }
    public string ExpectedResult { get; set; }
    public string NavigationLink { set; get; }
    public string ImageUrl { get; set; }
}