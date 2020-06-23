using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupDetails : MonoBehaviour
{
    public Color worldColor;
    public string groupName;
    public string[] usernames;

    private void Start()
    {
        //Change World Color
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Material newMaterial = new Material(meshRenderer.material);
        newMaterial.color = worldColor;
        meshRenderer.material = newMaterial;
    }
}
