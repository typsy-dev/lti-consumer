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
            this.LtiRequest.Signature = this.LtiRequest.SubstituteCustomVariablesAndGenerateSignature("secret"); // NOTE: ask  Typsy to provide the Secret value.
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
                ConsumerKey = "consumer key", // NOTE: ask Typsy to provide the Consumer Key value.
                ResourceLinkId = "launch",
                Url = new Uri("https://lti.typsy.com/xxx/lesson/1426") // NOTE: ask  Typsy to provide the url of the page to access LTI links for Typsy lessons.
            };

            // Tool
            ltiRequest.ToolConsumerInfoProductFamilyCode = "LtiLibrary";
            ltiRequest.ToolConsumerInfoVersion = "1.1";

            // Context
            ltiRequest.ContextId = "1";
            ltiRequest.ContextTitle = "Test LTI";
            ltiRequest.ContextType = LtiLibrary.NetCore.Lis.v1.ContextType.Group;

            // Instance
            ltiRequest.ToolConsumerInstanceGuid = Guid.NewGuid().ToString(); // NOTE: this value should be unique - insert GUID.
            ltiRequest.ToolConsumerInstanceName = "Test LTI Launch";
            ltiRequest.ResourceLinkTitle = "Test LTI Launch";
            ltiRequest.ResourceLinkDescription = "Perform a basic LTI 1.1 launch";
            ltiRequest.ToolConsumerInfoProductFamilyCode = "insert brand name"; // NOTE: Insert the brand/product name of the LMS Consumer.
            ltiRequest.ToolConsumerInfoVersion = "1.1"; // NOTE: Insert the version of the product name of the LMS Consumer.

            // User - NOTE: replace the values with the information of the user logged into the LMS and launching the Typsy lesson.
            ltiRequest.LisPersonEmailPrimary = "name@typsy.com"; // NOTE: email address.
            ltiRequest.LisPersonNameFamily = "Smith"; // NOTE: last name.
            ltiRequest.LisPersonNameGiven = "John"; // NOTE: first name.
            ltiRequest.UserId = "1"; // NOTE: This is the unique identifier for the user from the LMS Consumer.

            // Outcomes 
            ltiRequest.LisOutcomeServiceUrl = "insert endpoint link to send the outcome / scores";  // NOTE: Test the process by providing a URL from https://webhook.site/. This url is the LMS endpoint to receive the scores sent by Typsy after watching the Typsy lesson.
            ltiRequest.LisResultSourcedId = "insert tracking id"; // NOTE: This is tracking id for the launched lesson.  This is used when passing the Outcome / scores back to the LMS.

           // custom parameters
            ltiRequest.AddCustomParameter("display_title", "true"); // NOTE: display lesson title.
            ltiRequest.AddCustomParameter("display_border", "true");  // NOTE: display border around the lesson.
            ltiRequest.AddCustomParameter("display_description", "true");  // NOTE: display lesson description.
            //ltiRequest.AddCustomParameter("language", "hin");  // NOTE: display title and description in the selected language if a translation for it exists, otherwise display text in english. ISO-639–2 code to be used.
            //ltiRequest.AddCustomParameter("caption", "hin");   // NOTE: display lesson closed caption in the selected language. ISO-639–2 code to be used.

            return ltiRequest;
        }
    }
}
