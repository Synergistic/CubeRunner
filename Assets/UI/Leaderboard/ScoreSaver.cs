using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.game;
using AssemblyCSharp;

public class ScoreSaver : MonoBehaviour
{
    ServiceAPI sp = null;
    ScoreBoardService scoreBoardService = null; // Initializing ScoreBoard Service.
    ScoreboardSetter callBack = new ScoreboardSetter();

#if UNITY_EDITOR
    public static bool Validator(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
    { return true; }
#endif
    void Start()
    {
#if UNITY_EDITOR
        ServicePointManager.ServerCertificateValidationCallback = Validator;
#endif
        sp = new ServiceAPI("4a2e534eefa10daa614156dc12babcc73a5510cbd498d4f8c5372d6d804ff0f2", "fdcefae18555d7e2fd0d45c485c814f4bc7f5ccf4d2c61c8083c9d0f71297056");
    }

    public void SaveScore(string userName, double score)
    {
        scoreBoardService = sp.BuildScoreBoardService(); // Initializing ScoreBoard Service.
        scoreBoardService.SaveUserScore("CubeRunner", userName, score, callBack);
    }

}
