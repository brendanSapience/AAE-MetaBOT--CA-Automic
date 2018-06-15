using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAutomicLib
{
    public class UsefulMethods
    {
        
        RestUtils rUtils = new RestUtils();
        JsonUtils jUtils = new JsonUtils();

        public String ARA_GetApplications(String ARAHost, int ARAPort, Boolean isHttps, int ARAApiVersion,String ClientLoginDept,String ARAPassword,int MaxResults)
        {
            String ARAUrl = rUtils.FormARAURL(isHttps,ARAHost,ARAPort,ARAApiVersion);
            String ARAUrlFull = ARAUrl + "applications?max_results="+ MaxResults;

            String JsonRes = rUtils.CallRestGETWithBasicAuth(ARAUrlFull, ClientLoginDept, ARAPassword);

            return JsonRes;
        }

        public String ARA_GetDeployments(String ARAHost, int ARAPort, Boolean isHttps, int ARAApiVersion, String ClientLoginDept, String ARAPassword, int MaxResults)
        {
            String ARAUrl = rUtils.FormARAURL(isHttps, ARAHost, ARAPort, ARAApiVersion);
            String ARAUrlFull = ARAUrl + "executions?max_results=" + MaxResults;

            String JsonRes = rUtils.CallRestGETWithBasicAuth(ARAUrlFull, ClientLoginDept, ARAPassword);

            return JsonRes;
        }

        public String ARA_GetPackages(String ARAHost, int ARAPort, Boolean isHttps, int ARAApiVersion, String ClientLoginDept, String ARAPassword, int MaxResults)
        {
            String ARAUrl = rUtils.FormARAURL(isHttps, ARAHost, ARAPort, ARAApiVersion);
            String ARAUrlFull = ARAUrl + "packages?max_results=" + MaxResults;

            String JsonRes = rUtils.CallRestGETWithBasicAuth(ARAUrlFull, ClientLoginDept, ARAPassword);

            return JsonRes;
        }

        public String ARA_GetProfiles(String ARAHost, int ARAPort, Boolean isHttps, int ARAApiVersion, String ClientLoginDept, String ARAPassword, int MaxResults)
        {
            String ARAUrl = rUtils.FormARAURL(isHttps, ARAHost, ARAPort, ARAApiVersion);
            String ARAUrlFull = ARAUrl + "profiles?max_results=" + MaxResults;

            String JsonRes = rUtils.CallRestGETWithBasicAuth(ARAUrlFull, ClientLoginDept, ARAPassword);

            return JsonRes;
        }

        public String ARA_GetEnvironments(String ARAHost, int ARAPort, Boolean isHttps, int ARAApiVersion, String ClientLoginDept, String ARAPassword, int MaxResults)
        {
            String ARAUrl = rUtils.FormARAURL(isHttps, ARAHost, ARAPort, ARAApiVersion);
            String ARAUrlFull = ARAUrl + "environments?max_results=" + MaxResults;

            String JsonRes = rUtils.CallRestGETWithBasicAuth(ARAUrlFull, ClientLoginDept, ARAPassword);

            return JsonRes;
        }

        public String ARA_GetLogins(String ARAHost, int ARAPort, Boolean isHttps, int ARAApiVersion, String ClientLoginDept, String ARAPassword, int MaxResults)
        {
            String ARAUrl = rUtils.FormARAURL(isHttps, ARAHost, ARAPort, ARAApiVersion);
            String ARAUrlFull = ARAUrl + "logins?max_results=" + MaxResults;

            String JsonRes = rUtils.CallRestGETWithBasicAuth(ARAUrlFull, ClientLoginDept, ARAPassword);

            return JsonRes;
        }

        public String ARA_DeployApplication(String ARAHost, int ARAPort, Boolean isHttps, int ARAApiVersion, String ClientLoginDept, String ARAPassword,
            String ApplicationName,String WorkflowName,String PackageName, String DepProfile, Boolean NeedsManualApproval, String InstallMode)
        {
            String ARAUrl = rUtils.FormARAURL(isHttps, ARAHost, ARAPort, ARAApiVersion);
            String ARAUrlFull = ARAUrl + "executions";
            String JSONBody = "{\n  \"application\": \""+ ApplicationName + "\",\n  \"workflow\": \""+ WorkflowName+ "\",\n  \"package\": \""+ PackageName +
                "\",\n  \"deployment_profile\": \""+ DepProfile + "\",\n  \"needs_manual_start\": "+ NeedsManualApproval .ToString().ToLower() + ",\n  \"install_mode\": \""+ InstallMode + "\"\n}";
            String JsonRes = rUtils.CallRestPOSTWithBasicAuth(ARAUrlFull, ClientLoginDept, ARAPassword, JSONBody);

            return JsonRes;
        }

        public String Slack_GetUserListByName(String xAuthToken)
        {
            String URL = "https://slack.com/api/users.list?token="+ xAuthToken;

            String JsonRes = rUtils.CallRestGETNoAuth(URL);
            String ListResp = jUtils.JsonArrayToList(JsonRes,"name");
            return ListResp;
        }

        public String Slack_GetUserListByID(String xAuthToken)
        {
            String URL = "https://slack.com/api/users.list?token=" + xAuthToken;

            String JsonRes = rUtils.CallRestGETNoAuth(URL);
            String ListResp = jUtils.JsonArrayToList(JsonRes,"id");
            return ListResp;
        }

        public String Slack_GetUserListAsCSVArray(String xAuthToken)
        {
            String URL = "https://slack.com/api/users.list?token=" + xAuthToken;
            
            String JsonRes = rUtils.CallRestGETNoAuth(URL);
            String ListResp = jUtils.JsonArrayToCSVArray(JsonRes);
            return ListResp;
        }
        
    }
}
