﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CRMS.Application.Helpers
{
    public class Serialization
    {
        public static string SerializeObj<T>(T modelObject) => JsonSerializer.Serialize(modelObject);
        public static T DeserializeJsonString<T>(string jsonString) => JsonSerializer.Deserialize<T>(jsonString)!;
        public static IList<T> DeserializeJsonStringList<T>(string jsonString) => JsonSerializer.Deserialize<IList<T>>(jsonString)!;
    }
}
