using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigManager : MonoBehaviour
{
    private List<PlayerConfig> playerConfigs;
    [SerializeField]
    private int MaxPlayers = 2;

    public static PlayerConfigManager Instance { get; private set; }

    private void Awake()
    {

        if (Instance != null)
        {
            Debug.Log("Instance oluþturmaya çalýþ");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfigs = new List<PlayerConfig>();
        }

    }

    public List<PlayerConfig> GetPlayerConfigs()
    {
        return playerConfigs;
    }

    public void SetPlayerColor(int index, Material color)
    {
        playerConfigs[index].PlayerMaterial = color;
    }

    public void SetPrefabColor(int index, GameObject Playerprefab)
    {
        playerConfigs[index].PlayerPrefab = Playerprefab;
    }


    public void ReadyPlayer(int index)
    {
        playerConfigs[index].IsReady = true;
        if (playerConfigs.Count == MaxPlayers && playerConfigs.All(p => p.IsReady == true))
        {
            SceneManager.LoadScene("FirstLevel");
        }
    }

    public void HandlePlayerJoin(PlayerInput pi)
    {
        Debug.Log("Oyuncu Katýldý" + pi.playerIndex);

        if (!playerConfigs.Any(p => p.PlayerIndex == pi.playerIndex))
        {
            playerConfigs.Add(new PlayerConfig(pi));
            pi.transform.SetParent(transform);

        }
    }
}

public class PlayerConfig
{
    public PlayerConfig(PlayerInput pi)
    {
        PlayerIndex = pi.playerIndex;
        Input = pi;
    }

    public GameObject PlayerPrefab { get; set; }

    public PlayerInput Input { get; set; }
    public int PlayerIndex { get; set; }
    public bool IsReady { get; set; }
    public Material PlayerMaterial { get; set; }
  
}
