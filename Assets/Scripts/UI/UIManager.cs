using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject groupNameObject;
    public Transform userListTransform;
    public GameObject description;

    public GameObject userPrefab;
    
    //Update Information to UI Card
    public void UpdateInfo(GroupDetails details)
    {
        //Update Group Name
        groupNameObject.GetComponent<TMPro.TextMeshProUGUI>().text = details.groupName;

        //Clean previous data    
        for (int i = 0; i < userListTransform.childCount; i++)
        {
            Destroy(userListTransform.GetChild(i).gameObject);
        }

        //Update User List
        foreach (string username in details.usernames)
        {
            GameObject user = Instantiate(userPrefab, userListTransform, false);
            user.GetComponent<FetchAvatar>().username = username;
        }
    }
    
    
}
