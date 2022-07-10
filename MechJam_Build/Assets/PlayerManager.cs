using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    private List<PlayerInput> players = new List<PlayerInput>();
    [SerializeField]
    private List<Transform> startingPoints;
    [SerializeField]
    private List<LayerMask> playerLayers;
    private PlayerInputManager playerInputManager;
    [SerializeField] private GameObject camera;
    private void Awake()
    {
        playerInputManager = FindObjectOfType<PlayerInputManager>();
    }
    private void OnEnable()
    {
        playerInputManager.onPlayerJoined += AddPlayer;
        playerInputManager.onPlayerJoined += toggleCameraOff;
    }
    private void OnDisable()
    {
        playerInputManager.onPlayerJoined -= AddPlayer;
        playerInputManager.onPlayerJoined -= toggleCameraOff;
    }

    public void AddPlayer(PlayerInput player)
    {
        print(player);
        players.Add(player);
        print(player);

       
        
        print(player);
        player.transform.position = startingPoints[players.Count - 1].position;
        int LayerToAdd = (int)Mathf.Log(playerLayers[players.Count - 1].value, 2);
        player.GetComponentInChildren<CinemachineVirtualCamera>().gameObject.layer = LayerToAdd;
        player.GetComponentInChildren<Camera>().cullingMask |= 1 << LayerToAdd;
        //playerParent.GetComponentInChildren<InputHandler>().look = player.actions.FindAction("Look");
    }
    public void toggleCameraOff(PlayerInput player)
    {
        camera.SetActive(false);
    }
}
