using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FetchAvatar : MonoBehaviour
{
    public string username;
    private RawImage _rawImage;
    public static readonly String[] Usernames =
    {
        "AbscindFAE",
        "MelenAdroit",
        "Ck1sabaCento",
        "MygielInapt",
        "Delphically",
        "Agrypnia",
        "Abattoir",
        "Landlubber",
        "Circuity",
        "Bibliopoesy ",
        "Centesimal",
        "Opodeldoc",
        "QwertickElapse",
        "KosiusHeresy",
        "Aardwolf",
        "Prelate",
        "Psychognosy",
        "Calathiform",
        "Volerybusch1997",
        "Digerati",
        "Zyriangacy_1",
        "Podexron_j",
        "Agistnic10",
        "Whenasguy9254",
        "Durstg1e362",
        "Gasbagpr0s2x",
        "Dirkton19",
        "Anomalous",
        "Goombah",
        "Ditherroen890",
        "Burnsides",
        "Gibbous",
        "Nomenclature",
        "Gewgawdan001",
        "Adagioviews",
        "Diphthong",
        "Chimpster8",
        "Shenanigan",
        "Pandemonium",
        "Crunging",
        "Boshher404",
        "Convivial"
    };  

    void Start()
    {
        _rawImage = GetComponentInChildren<RawImage>();
        name = username;
        StartCoroutine(GetTexture());
    }
 
    IEnumerator GetTexture() {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://api.adorable.io/avatars/100/"+username);
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            SetTexture(myTexture);
        }
    }

    void SetTexture(Texture texture)
    {
        _rawImage.texture = texture;
    }
}
