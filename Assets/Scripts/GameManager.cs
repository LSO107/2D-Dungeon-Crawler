// Lee (1720076)

using Combat;
using Enemies.Definitions;
using EquipmentSystem;
using ItemSystem.Inventory;
using Player;
using UI.Coins;
using UI.InventoryUI;
using UnityEngine;
using UnityEngine.SceneManagement;

internal sealed class GameManager : MonoBehaviour
{
    public PlayerController Player;
    public GameObject RespawnLocation;
    public PlayerInventory PlayerInventory => Player.PlayerInventory;
    public PlayerCoins PlayerCoins;
    public PlayerStats PlayerStats;
    public InventoryUI InventoryUI;
    public EquipmentUI EquipmentUI;

    public static GameManager instance;

    public void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        Screen.SetResolution(1024, 768, true);
    }

    /// <summary>
    /// Get the scene by the name, and set all of the
    /// parent gameObjects in the opposite scene
    /// to deactivated 
    /// </summary>
    public void ChangeScene(string sceneName)
    {
        var newScene = SceneManager.GetSceneByName(sceneName);

        var mainScene = SceneManager.GetActiveScene();
        var roots = mainScene.GetRootGameObjects();

        foreach (var root in roots)
        {
            root.SetActive(false);
        }

        SceneManager.SetActiveScene(newScene);

        var combatScene = SceneManager.GetActiveScene();
        roots = combatScene.GetRootGameObjects();

        foreach (var root in roots)
        {
            root.SetActive(true);
        }
    }
}