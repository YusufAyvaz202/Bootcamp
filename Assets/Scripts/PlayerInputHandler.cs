using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.PlayerLoop;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfig playerConfig;
    private Mover mover;


    [SerializeField]
    private MeshRenderer playerMesh;

    private PlayerControls controls;
    private bool jumped = false;

    private void Awake()
    {
        mover = GetComponent<Mover>();
        controls = new PlayerControls();
    }

    public void InitializePlayer(PlayerConfig pc)
    {
        playerConfig = pc;
        //playerMesh.material = pc.PlayerMaterial;
        playerConfig.PlayerPrefab = pc.PlayerPrefab;
        playerConfig.Input.onActionTriggered += Input_onActionTriggered;
    }

    private void Input_onActionTriggered(CallbackContext obj)
    {
        if (obj.action.name == controls.Player.Movement.name)
        {
            OnMove(obj);
        }

        if (obj.action.name==controls.Player.Jump.name)
        {
            OnJump(obj);
        }
    }

    public void OnMove(CallbackContext context)
    {
        mover.SetInputVector(context.ReadValue<Vector2>());
    }
    public void OnJump(CallbackContext context)
    {
        mover.IsJump(context.action.triggered);
    }

}
