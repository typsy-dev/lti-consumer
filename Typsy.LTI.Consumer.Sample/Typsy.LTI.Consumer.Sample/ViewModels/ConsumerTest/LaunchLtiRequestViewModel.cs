using LtiLibrary.NetCore.Common;
using LtiLibrary.NetCore.Lti.v1;

namespace Typsy.LTI.Consumer.Sample.ViewModels.ConsumerTest
{
    public class LaunchLtiRequestViewModel
    {
        public LaunchLtiRequestViewModel()
        {
            this.LtiRequest = new LtiRequest();
        }


        public void Initialize()
        {
            this.LtiRequest = GetLtiLaunchRequest();
            this.LtiRequest.Signature = this.LtiRequest.SubstituteCustomVariablesAndGenerateSignature("replace with secret value provided by Typsy");

        }

        public LtiRequest LtiRequest { get; set; }


        private LtiRequest GetLtiLaunchRequest()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var ltiRequest = new LtiRequest(LtiConstants.BasicLaunchLtiMessageType)
            {
                ConsumerKey = "replace with consumer key provided by Typsy",
                ResourceLinkId = "launch",
                Url = new Uri("https://lti-staging.typsy.com/moodle/lesson/991")
            };

            // Tool
            ltiRequest.ToolConsumerInfoProductFamilyCode = "LtiLibrary";
            ltiRequest.ToolConsumerInfoVersion = "1.1";

            // Context
            ltiRequest.ContextId = "1";
            ltiRequest.ContextTitle = "Test LTI";
            ltiRequest.ContextType = LtiLibrary.NetCore.Lis.v1.ContextType.Group;

            // Instance
            ltiRequest.ToolConsumerInstanceGuid = "add a guid here";
            ltiRequest.ToolConsumerInstanceName = "Test LTI Launch";
            ltiRequest.ResourceLinkTitle = "Test LTI Launch";
            ltiRequest.ResourceLinkDescription = "Perform a basic LTI 1.1 launch";

            // User
            ltiRequest.LisPersonEmailPrimary = "wilfred@typsy.com";
            ltiRequest.LisPersonNameFamily = "Dsouza";
            ltiRequest.LisPersonNameGiven = "Wilfred";
            ltiRequest.UserId = "1";

            // Outcomes-1 service (WebApi controller)
            ltiRequest.LisOutcomeServiceUrl = "outcome url goes here";
            ltiRequest.LisResultSourcedId = "testId goes here";

            // is a way to test that the correct substitions are happening
            ltiRequest.AddCustomParameter("display_title", "true");
            ltiRequest.AddCustomParameter("display_border", "true");
            ltiRequest.AddCustomParameter("display_description", "true");
            ltiRequest.AddCustomParameter("language", "hin");
            ltiRequest.AddCustomParameter("caption", "hin");

            return ltiRequest;
        }

    }
}
