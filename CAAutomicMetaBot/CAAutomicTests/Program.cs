using System;
using CAAutomicLib;

namespace CAAutomicTests
{
    class Program
    {
        static void Main(string[] args)
        {
            
            UsefulMethods uMethods = new UsefulMethods();
            String IPADR = "";
            String SlackAuthToken = "xoxp-291425943108-291393414370-7";
            //String JsonResp = uMethods.GetARAApps(IPADR,80,false,1,"100/ARA/ARA","ARA",1000);

            //String JsonResp = uMethods.ARA_GetDeployments(IPADR, 80, false, 1, "100/ARA/ARA", "ARA", 1000);
            //String jsonBody = "{\n  \"application\": \"POSApp\",\n  \"workflow\": \"DeployToPOS\",\n  \"package\": \"v1.0\",\n  \"deployment_profile\": \"v_8.0.14\",\n  \"needs_manual_start\": false,\n  \"install_mode\": \"overwriteExisting\"\n}";
            //String JsonResp = uMethods.ARA_DeployApplication(IPADR, 80, false, 1, "100/ARA/ARA", "ARA","POSApp","DeployToPOS","V1.0","v_8.0.14",false,"overwriteExisting");
            // String JsonResp = uMethods.ARA_GetPackages(IPADR, 80, false, 1, "100/ARA/ARA", "ARA", 1000);
            // String JsonResp = uMethods.Slack_GetUserListByID(SlackAuthToken);
            String JsonResp = uMethods.Slack_GetUserListAsCSVArray(SlackAuthToken);

            Console.WriteLine("Response:"+ JsonResp);
            Console.ReadKey();
        }
    }
}
