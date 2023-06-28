using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerSetupMenuController : MonoBehaviour
{
    private int PlayerIndex;
    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private GameObject readyPanel;
    [SerializeField]
    private GameObject menuPanel;
    [SerializeField]
    private Button readyButton;


    private float ignoreInputTime = 1.5f;
    private bool inputEnabled;

    [SerializeField] List<Button> registerKeys = new List<Button>();
    public void SetPlayerIndex(int pi)
    {
        PlayerIndex= pi;
        titleText.SetText("Player " + (pi + 1).ToString());
        ignoreInputTime= Time.time+ignoreInputTime;
    }

    void Update()
    {
        if (Time.time>ignoreInputTime)
        {
            inputEnabled = true;
        }

    }

    public void SetColor(Material color)
    {
        if (!inputEnabled)
        {
            return;
        }

        PlayerConfigManager.Instance.SetPlayerColor(PlayerIndex, color);


        readyPanel.SetActive(true);
        readyButton.Select();
        menuPanel.SetActive(false);
    }


    public void ReadyPlayer()
    {
        if (!inputEnabled)
        {
            return;
        }

        PlayerConfigManager.Instance.ReadyPlayer(PlayerIndex);
        readyButton.gameObject.SetActive(false);
    }

    public void birinci(GameObject prefab)
    {
        PlayerConfigManager.Instance.SetPrefabColor(PlayerIndex, prefab);
    }

    public void ikinci(GameObject prefab)
    {
        PlayerConfigManager.Instance.SetPrefabColor(PlayerIndex, prefab);
    }





}
