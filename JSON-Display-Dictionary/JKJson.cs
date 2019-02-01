using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JKJsonDecode
{
    class JKJson
    {
        public static List<dynamic> ListOut(object des)
        {
            return JArray.FromObject(des).ToObject<List<dynamic>>();
        }

        public static Dictionary<string, dynamic> DictOut(object des)
        {
            return JObject.FromObject(des).ToObject<Dictionary<string, dynamic>>();
        }

        public static object Deserialized(string url)
        {
            using (WebClient w = new WebClient())
            {
                object d = null;

                try
                {
                    string json_data = w.DownloadString(url);
                    dynamic json = JsonConvert.DeserializeObject<dynamic>(json_data);

                    switch (json.GetType().ToString())
                    {
                        case "Newtonsoft.Json.Linq.JObject":
                            d = JObject.FromObject(json);
                            break;
                        case "Newtonsoft.Json.Linq.JArray":
                            d = JArray.FromObject(json);
                            break;
                    }
                }
                catch (Exception e)
                {
                    return e.Message;
                }

                return d;
            }
        }
    }
}
