using Sift;
using Xunit;


namespace Test.Integration.NetFx48.WorkflowsAPI
{
    public class WorkflowStatuses
    {
        [Fact]
        public void IntegrationTest_WorkflowStatuses()
        {
            var sift = new Client("ccd68efbe25809bc");
            WorkflowStatusRequest workflowStatusRequest = new WorkflowStatusRequest
            {
                ApiKey = "ccd68efbe25809bc",
                AccountId = "5f053f004025ca08a187fad3",
                WorkflowRunId = "6dbq76qbaaaaa"
            };
            WorkflowStatusResponse workFlowStatusResponse = sift.SendAsync(workflowStatusRequest).Result;
            Assert.Equal("OK", workFlowStatusResponse.ErrorMessage);
        }

    }
}
