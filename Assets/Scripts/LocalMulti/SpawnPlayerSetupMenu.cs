using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class SpawnPlayerSetupMenu : MonoBehaviour
{
    public GameObject playerSetUpMenuPrefab;
    public PlayerInput input;

    private void Awake()
    {
        var rootMenu = GameObject.Find("MainLayout");

        if (rootMenu!=null)
        {
            var menu = Instantiate(playerSetUpMenuPrefab, rootMenu.transform);
            input.uiInputModule = menu.GetComponentInChildren<InputSystemUIInputModule>();
            menu.GetComponent<PlayerSetupMenuController>().SetPlayerIndex(input.playerIndex);
        }
    }
}
