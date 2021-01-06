using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkiraBot.Utilities
{
  public static class AkiraConversion
  {
    /// <summary>
    /// Converts a string to a Base64 Encoded string
    /// </summary>
    /// <param name="nMessage">Plain text string</param>
    /// <returns>Base64 Encoded string</returns>
    public static string ConvertToBase64(string nMessage)
    { 
      return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(nMessage));
    }


    /// <summary>
    /// Converts from Base64 back to plain text
    /// </summary>
    /// <param name="nBase64Msg">Base64 Message as a string</param>
    /// <returns>A decrypted base 64 string</returns>
    public static string ConvertFromBase64(string nBase64Msg)
    { 
      return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(nBase64Msg));
    }


    /// <summary>
    /// Conver to a json string
    /// </summary>
    /// <param name="nObj">Object to convert to json</param>
    /// <returns>A json string</returns>
    public static string ConvertToJson<T>(T nObj)
    { 
      return JsonConvert.SerializeObject(nObj);
    }


    /// <summary>
    /// Converts json to an Object
    /// </summary>
    /// <param name="nJson">Json to convert</param>
    /// <returns>An object from the Json</returns>
    public static T ConvertFromJson<T>(string nJson)
    { 
      return JsonConvert.DeserializeObject<T>(nJson);
    }
  }
}
