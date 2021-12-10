using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Configuration;

namespace Base
{
    public static class staticStringReader
    {
        public static JsonData staticdata;

        public static JsonData StaticData
        {
            get
            {
                if (staticdata == null)
                {
                    string _Testdatapath = Directory.GetParent(Directory.GetCurrentDirectory()).ToString().Replace("bin", "") + "StaticData\\staticData.json";
                    staticdata = JsonConvert.DeserializeObject<JsonData>(File.ReadAllText(_Testdatapath));
                }
                return staticdata;
            }
        }
    }

    public class JsonData
    {
        public string masterUsername { get; set; }
        public string masterPassword { get; set; }
        public string validation_FirstName { get; set; }
        public string validation_LastName { get; set; }
        public string validation_Email { get; set; }
        public string validation_Password { get; set; }
        public string validation_WrongEmail { get; set; }
        public string validation_PasswordLength { get; set; }
        public string validation_ConfirmPassword { get; set; }

    }
    
}
