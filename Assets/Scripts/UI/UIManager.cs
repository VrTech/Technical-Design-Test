using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI groupNameObject;
    public Transform userListTransform;
    public TextMeshProUGUI descriptionText;
    public GameObject buttons;
    public ToggleMovement toggleMovement;
    
    [Header("Prefab")]
    public GameObject userPrefab;
    
    //Update Information to UI Card
    public void UpdateUserInfo(GroupDetails details)
    {
        //Update Group Name
        groupNameObject.text = details.groupName;

        //Clean previous data    
        for (int i = 0; i < userListTransform.childCount; i++)
        {
            Destroy(userListTransform.GetChild(i).gameObject);
        }

        //Update User List
        foreach (username user in details.usernames)
        {
            SetAvatar newUser = Instantiate(userPrefab, userListTransform, false).GetComponent<SetAvatar>();
            newUser.username = user.name;
            newUser.userImage = user.image;
        }
    }
    
    //Show/Hide Description
    public void ToggleDescription()
    {
        toggleMovement.isToggled = !toggleMovement.isToggled;
        buttons.SetActive(toggleMovement.isToggled);
    }
    
    //Update card description
    public void UpdateDescription(string text)
    {
        descriptionText.text = text;
    }

    //Clear card description
    public void ClearDescription()
    {
        descriptionText.text = "Click to see more...";
    }
}
