using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CAAutomicLib
{
    public class JsonUtils
    {
        public String RowSeparator = ";;";
        public String ColumnSeparator = ",,";

        public String JsonArrayToList(String JsonResp, String AttrName)
        {
            RestSharp.RestResponse response = new RestSharp.RestResponse();

            response.Content = JsonResp;

            RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();

            AllSlackUsers x = deserial.Deserialize<AllSlackUsers>(response);
            String Resp = "";
            foreach (var Member in x.members)
            {
                String AttrToAdd = "";
                if (AttrName.Equals("name")) { AttrToAdd = Member.name; }
                if (AttrName.Equals("id")) { AttrToAdd = Member.id; }
                if (Resp.Equals("")) { Resp = AttrToAdd; }
                else { Resp = Resp + "," + AttrToAdd; }
            }

            return Resp;
        }

        public String JsonArrayToCSVArray(String JsonResp)
        {
            RestSharp.RestResponse response = new RestSharp.RestResponse();

            response.Content = JsonResp;

            RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();

            AllSlackUsers x = deserial.Deserialize<AllSlackUsers>(response);
            String Resp = "id"+ColumnSeparator+ "name" + ColumnSeparator + "team_id" + ColumnSeparator + "deleted" + ColumnSeparator + "real_name" + ColumnSeparator + "tz" +
                ColumnSeparator + "tz_label" + ColumnSeparator + "is_admin" + ColumnSeparator + "is_owner" + ColumnSeparator + "is_bot" + RowSeparator;
            foreach (var Member in x.members)
            {
                Resp = Resp + Member.id + ColumnSeparator + Member.name + ColumnSeparator + Member.team_id + ColumnSeparator + Member.deleted + ColumnSeparator + Member.real_name + ColumnSeparator + Member.tz + ColumnSeparator + Member.tz_label + ColumnSeparator + Member.is_admin +
                    ColumnSeparator + Member.is_owner + ColumnSeparator + Member.is_bot + RowSeparator;
            }

            return Resp;
        }
    }
    public class Profile
    {
        public string title { get; set; }
        public string phone { get; set; }
        public string skype { get; set; }
        public string real_name { get; set; }
        public string real_name_normalized { get; set; }
        public string display_name { get; set; }
        public string display_name_normalized { get; set; }
        public string status_text { get; set; }
        public string status_emoji { get; set; }
        public int status_expiration { get; set; }
        public string avatar_hash { get; set; }
        public string bot_id { get; set; }
        public string api_app_id { get; set; }
        public bool always_active { get; set; }
        public string image_original { get; set; }
        public string image_24 { get; set; }
        public string image_32 { get; set; }
        public string image_48 { get; set; }
        public string image_72 { get; set; }
        public string image_192 { get; set; }
        public string image_512 { get; set; }
        public string image_1024 { get; set; }
        public string status_text_canonical { get; set; }
        public string team { get; set; }
        public bool is_custom_image { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public object fields { get; set; }
    }

    public class Member
    {
        public string id { get; set; }
        public string team_id { get; set; }
        public string name { get; set; }
        public bool deleted { get; set; }
        public string color { get; set; }
        public string real_name { get; set; }
        public string tz { get; set; }
        public string tz_label { get; set; }
        public int tz_offset { get; set; }
        public Profile profile { get; set; }
        public bool is_admin { get; set; }
        public bool is_owner { get; set; }
        public bool is_primary_owner { get; set; }
        public bool is_restricted { get; set; }
        public bool is_ultra_restricted { get; set; }
        public bool is_bot { get; set; }
        public int updated { get; set; }
        public bool is_app_user { get; set; }
        public bool? has_2fa { get; set; }
    }

    public class AllSlackUsers
    {
        public bool ok { get; set; }
        public List<Member> members { get; set; }
        public int cache_ts { get; set; }
    }
}
