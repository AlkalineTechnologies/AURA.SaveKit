using System;
using System.Security.Cryptography;
using System.Text;

namespace AFSM;

/// <summary>
/// DataProfile Script.
/// </summary>
[Serializable]
public class DataProfile
{

    /// <summary>
    /// The file extension used for saved files.
    /// </summary>
    /// 
    public virtual string GetComponentName()
    {
        return "DataProfile";
    }
    
    /// <summary>
    /// Generates a SHA256 hash of the current DataProfile.
    /// </summary>
    public String GenerateHash()
    {
        String json = FlaxEngine.Json.JsonSerializer.Serialize(this);

        using (var sha256 = SHA256.Create())
        {
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(json));
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
    }
}