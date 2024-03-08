namespace WFM.SmokeTests.Domain.Entities;

public class TestStepExecution
{
    public string Guid { get; set; }
    public DateTime ExecutionTime { get; set; }
    public string ExecutionUserName { get; set; }
    public string ExecutionComments { get; set; }
    public StepExecutionResult StepResult { get; set; }
}

public enum StepExecutionResult
{
    Success,
    Fail,
    SucessWithComments,
    Skipped
}