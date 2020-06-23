using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FetchAvatar : MonoBehaviour
{
    public string username;
    private RawImage _rawImage;

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
