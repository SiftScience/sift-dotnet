using Sift;
using Test.Integration.Net7.Uitlities;
using Xunit;


namespace Test.Integration.Net7.WorkflowsAPI
{
    public class WorkflowStatuses
    {
        private readonly EnvironmentVariable environmentVariable = new();

        [Fact]
        public void WorkflowStatusesTest()
        {
            var sift = new Client(environmentVariable.ApiKey);
            WorkflowStatusRequest workflowStatusRequest = new WorkflowStatusRequest
            {
                ApiKey = environmentVariable.ApiKey,
                AccountId = environmentVariable.AccountId,
                WorkflowRunId = environmentVariable.WorkflowRunId
            };
            WorkflowStatusResponse workFlowStatusResponse = sift.SendAsync(workflowStatusRequest).Result;
            Assert.Equal("OK", workFlowStatusResponse.ErrorMessage);
        }

    }
}
