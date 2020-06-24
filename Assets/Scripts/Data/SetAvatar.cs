using UnityEngine;
using UnityEngine.UI;

public class SetAvatar : MonoBehaviour
{
    public string username;
    public Texture userImage;

    private RawImage _rawImage;
    
    void Start()
    {
        _rawImage = GetComponentInChildren<RawImage>();
        name = username;
        _rawImage.texture = userImage;
    }
}
