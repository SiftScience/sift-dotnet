using Sift;
using Test.Integration.Net7.Uitlities;
using Xunit;


namespace Test.Integration.Net7.WorkflowsAPI
{
    public class WorkflowStatuses
    {
        private readonly EnvironmentVariable environmentVariable = new();
        private readonly string ApiKey;
        private readonly string AccountId;
        private readonly string WorkflowRunId;
        public WorkflowStatuses()
        {
            ApiKey = environmentVariable.ApiKey;
            AccountId = environmentVariable.AccountId;
            WorkflowRunId = environmentVariable.WorkflowRunId;
        }

        [Fact]
        public void WorkflowStatusesTest()
        {
            var sift = new Client(ApiKey);
            WorkflowStatusRequest workflowStatusRequest = new WorkflowStatusRequest
            {
                ApiKey = ApiKey,
                AccountId = AccountId,
                WorkflowRunId = WorkflowRunId
            };
            WorkflowStatusResponse workFlowStatusResponse = sift.SendAsync(workflowStatusRequest).Result;
            Assert.Equal("OK", workFlowStatusResponse.ErrorMessage);
        }

    }
}
