using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {
    InputDevice device;
    InputControl control;

    Player player;
    public PlayerActions playerActions;

	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();
        playerActions = CreateWithDefaultBindings();
	}
	
	// Update is called once per frame

	void Update () {
        player.SetDirectionalInput(playerActions.Move);
        player.SetCamDirectionalInput(playerActions.CamMove);
        Camera.main.GetComponent<CameraController>().SetCameraDirectionalInput(playerActions.CamMove);

        // Jump Input
        if (playerActions.Jump.WasPressed) {
            player.OnJumpInputDown();
        }

        if(playerActions.Jump.IsPressed) {
            player.OnJumpInputHold();
        }
        
        if (playerActions.Jump.WasReleased) {
            player.OnJumpInputUp();
        }

        if (playerActions.Dialogue.WasPressed) {
            player.OnDialogueInputDown();
        }
    }

    public void PlayerInputs() {

    }

    PlayerActions CreateWithDefaultBindings() {
        PlayerActions playerActions = new PlayerActions();

        playerActions.Jump.AddDefaultBinding(Key.Space);
        playerActions.Jump.AddDefaultBinding(InputControlType.Action1);

        playerActions.Up.AddDefaultBinding(Key.W);
        playerActions.Down.AddDefaultBinding(Key.S);
        playerActions.Left.AddDefaultBinding(Key.A);
        playerActions.Right.AddDefaultBinding(Key.D);

        playerActions.Dialogue.AddDefaultBinding(Key.E);
        playerActions.Dialogue.AddDefaultBinding(InputControlType.Action2);

        playerActions.Left.AddDefaultBinding(InputControlType.LeftStickLeft);
        playerActions.Right.AddDefaultBinding(InputControlType.LeftStickRight);
        playerActions.Up.AddDefaultBinding(InputControlType.LeftStickUp);
        playerActions.Down.AddDefaultBinding(InputControlType.LeftStickDown);

        playerActions.CamLeft.AddDefaultBinding(InputControlType.RightStickLeft);
        playerActions.CamRight.AddDefaultBinding(InputControlType.RightStickRight);
        playerActions.CamUp.AddDefaultBinding(InputControlType.RightStickUp);
        playerActions.CamDown.AddDefaultBinding(InputControlType.RightStickDown);

        playerActions.CamLeft.AddDefaultBinding(Mouse.NegativeX);
        playerActions.CamRight.AddDefaultBinding(Mouse.PositiveX);
        playerActions.CamUp.AddDefaultBinding(Mouse.PositiveY);
        playerActions.CamDown.AddDefaultBinding(Mouse.NegativeY);

        playerActions.ListenOptions.IncludeUnknownControllers = true;
        playerActions.ListenOptions.MaxAllowedBindings = 4;
        playerActions.ListenOptions.UnsetDuplicateBindingsOnSet = true;

        return playerActions;
    }
}
