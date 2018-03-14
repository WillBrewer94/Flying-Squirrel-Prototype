using UnityEngine;
using InControl;
using System.Collections;

[RequireComponent(typeof(Player))]
public class SplitPlayerInput : MonoBehaviour {
    InputDevice device;
    InputControl control;

    Player player;
    public PlayerActions playerActions;

    void Awake() {
        player = GetComponent<Player>();
    }

    void Update() {
        player.SetDirectionalInput(playerActions.Move);

        // Jump Input
        if(playerActions.Jump.WasPressed) {
            player.OnJumpInputDown();
        }

        if(playerActions.Jump.WasReleased) {
            player.OnJumpInputUp();
        }

        // Abilities
        if(playerActions.Ability1.WasPressed) {
            player.OnAbility1InputDown();
        }

        if(playerActions.Ability1.WasReleased) {
            player.OnAbility1InputUp();
        }

        if(playerActions.Ability2.WasPressed) {
            player.OnAbility2InputDown();
        }

        if(playerActions.Ability2.WasReleased) {
            player.OnAbility2InputUp();
        }
    }

    //=========================
    //        Bindings 
    //=========================

    //Split Character One
    public void CreateWithSplitOneBindings() {
        PlayerActions playerOneActions = new PlayerActions();
        playerOneActions.Left.AddDefaultBinding(InputControlType.LeftStickLeft);
        playerOneActions.Right.AddDefaultBinding(InputControlType.LeftStickRight);
        playerOneActions.Up.AddDefaultBinding(InputControlType.LeftStickUp);
        playerOneActions.Down.AddDefaultBinding(InputControlType.LeftStickDown);

        playerOneActions.Up.AddDefaultBinding(Key.W);
        playerOneActions.Down.AddDefaultBinding(Key.S);
        playerOneActions.Left.AddDefaultBinding(Key.A);
        playerOneActions.Right.AddDefaultBinding(Key.D);

        playerOneActions.Jump.AddDefaultBinding(Key.Space);
        playerOneActions.Jump.AddDefaultBinding(InputControlType.Action1);

        playerOneActions.Ability1.AddDefaultBinding(Key.LeftShift);
        playerOneActions.Ability1.AddDefaultBinding(InputControlType.Action2);

        playerActions = playerOneActions;
    }

    //Split Character Two
    public void CreateWithSplitTwoBindings() {
        PlayerActions playerTwoActions = new PlayerActions();

        playerTwoActions.Left.AddDefaultBinding(InputControlType.RightStickLeft);
        playerTwoActions.Right.AddDefaultBinding(InputControlType.RightStickRight);
        playerTwoActions.Up.AddDefaultBinding(InputControlType.RightStickUp);
        playerTwoActions.Down.AddDefaultBinding(InputControlType.RightStickDown);

        playerTwoActions.Up.AddDefaultBinding(Key.UpArrow);
        playerTwoActions.Down.AddDefaultBinding(Key.DownArrow);
        playerTwoActions.Left.AddDefaultBinding(Key.LeftArrow);
        playerTwoActions.Right.AddDefaultBinding(Key.RightArrow);

        playerTwoActions.Jump.AddDefaultBinding(Key.Space);
        playerTwoActions.Jump.AddDefaultBinding(InputControlType.Action1);

        playerTwoActions.Ability1.AddDefaultBinding(Key.LeftShift);
        playerTwoActions.Ability1.AddDefaultBinding(InputControlType.Action2);

        playerActions = playerTwoActions;
    }
}