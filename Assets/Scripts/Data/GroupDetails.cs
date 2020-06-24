using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct username
{
    public string name;
    public Texture image;
}

public class GroupDetails : MonoBehaviour
{
    public Color worldColor;
    public string groupName;
    public string groupDescription;
    public username[] usernames;

    private void Start()
    {
        //Change World Color
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Material newMaterial = new Material(meshRenderer.material);
        newMaterial.color = worldColor;
        meshRenderer.material = newMaterial;
    }
}
