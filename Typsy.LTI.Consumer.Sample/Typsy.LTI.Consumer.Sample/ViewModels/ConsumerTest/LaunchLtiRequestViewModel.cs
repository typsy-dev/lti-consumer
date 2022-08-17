using LtiLibrary.NetCore.Common;
using LtiLibrary.NetCore.Lti.v1;
using static System.Net.WebRequestMethods;

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
            this.LtiRequest = this.GetLtiLaunchRequest();
            this.LtiRequest.Signature = this.LtiRequest.SubstituteCustomVariablesAndGenerateSignature("replace with secret value provided by Typsy");
        }

        // https://github.com/andyfmiller/LtiLibrary1.6/blob/master/LtiLibrary.Core/Lti1/LtiRequest.cs
        public LtiRequest LtiRequest { get; set; }

        private LtiRequest GetLtiLaunchRequest()
        {
            // https://www.edu-apps.org/code.html
            // https://www.imsglobal.org/basic-overview-how-lti-works
            // https://github.com/andyfmiller/LtiSamples
            // https://github.com/andyfmiller/LtiLibrary1.6

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
            ltiRequest.ToolConsumerInfoProductFamilyCode = "MOODLE"; // NOTE: Insert the brand/product name of the LMS Consumer.
            ltiRequest.ToolConsumerInfoVersion = "1.1"; // NOTE: Insert the version of the product name of the LMS Consumer.

            // User
            ltiRequest.LisPersonEmailPrimary = "name@typsy.com";
            ltiRequest.LisPersonNameFamily = "Smith";
            ltiRequest.LisPersonNameGiven = "John";
            ltiRequest.UserId = "1"; // NOTE: This is the unique identifier from the LMS Consumer.  This is used when passing the Outcome back to the LMS to identify the user.

            // Outcomes-1 service (WebApi controller)
            ltiRequest.LisOutcomeServiceUrl = "outcome url goes here";  // NOTE: Test the process by providing a URL from https://webhook.site/
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
