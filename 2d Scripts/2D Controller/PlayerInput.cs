using UnityEngine;
using InControl;
using System.Collections;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {
    public enum PlayerType {
        DEFAULT,
        SPLIT_ONE,
        SPLIT_TWO
    }

    InputDevice device;
    InputControl control;

    Player player;
    PlayerType playerType;
    public PlayerActions playerActions;

	void Start() {
        player = GetComponent<Player>();
        playerActions = CreateWithDefaultBindings();
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
    PlayerActions CreateWithDefaultBindings() {
        PlayerActions playerActions = new PlayerActions();

        playerActions.Jump.AddDefaultBinding(Key.Space);
        playerActions.Jump.AddDefaultBinding(InputControlType.Action1);

        playerActions.Reroll.AddDefaultBinding(Key.V);
        playerActions.Reroll.AddDefaultBinding(InputControlType.Action4);

        playerActions.Ability1.AddDefaultBinding(Key.LeftShift);
        playerActions.Ability1.AddDefaultBinding(InputControlType.Action2);

        playerActions.Ability2.AddDefaultBinding(Key.X);
        playerActions.Ability2.AddDefaultBinding(InputControlType.Action3);

        playerActions.Up.AddDefaultBinding(Key.UpArrow);
        playerActions.Down.AddDefaultBinding(Key.DownArrow);
        playerActions.Left.AddDefaultBinding(Key.LeftArrow);
        playerActions.Right.AddDefaultBinding(Key.RightArrow);

        playerActions.Left.AddDefaultBinding(InputControlType.LeftStickLeft);
        playerActions.Right.AddDefaultBinding(InputControlType.LeftStickRight);
        playerActions.Up.AddDefaultBinding(InputControlType.LeftStickUp);
        playerActions.Down.AddDefaultBinding(InputControlType.LeftStickDown);

        playerActions.ListenOptions.IncludeUnknownControllers = true;
        playerActions.ListenOptions.MaxAllowedBindings = 4;
        playerActions.ListenOptions.UnsetDuplicateBindingsOnSet = true;

        playerType = PlayerType.DEFAULT;

        return playerActions;
    }
    
    //Split Character One
    public void CreateWithSplitOneBindings() {
        playerActions.Left.AddDefaultBinding(InputControlType.LeftStickLeft);
        playerActions.Right.AddDefaultBinding(InputControlType.LeftStickRight);
        playerActions.Up.AddDefaultBinding(InputControlType.LeftStickUp);
        playerActions.Down.AddDefaultBinding(InputControlType.LeftStickDown);

        playerActions.Up.AddDefaultBinding(Key.W);
        playerActions.Down.AddDefaultBinding(Key.S);
        playerActions.Left.AddDefaultBinding(Key.A);
        playerActions.Right.AddDefaultBinding(Key.D);

        playerActions.Jump.AddDefaultBinding(Key.Space);
        playerActions.Jump.AddDefaultBinding(InputControlType.Action1);

        playerActions.Ability2.AddDefaultBinding(Key.LeftShift);
        playerActions.Ability2.AddDefaultBinding(InputControlType.Action1);

        playerType = PlayerType.SPLIT_ONE;
    }

    //Split Character Two
    public void CreateWithSplitTwoBindings() {
        playerActions.Left.AddDefaultBinding(InputControlType.RightStickLeft);
        playerActions.Right.AddDefaultBinding(InputControlType.RightStickRight);
        playerActions.Up.AddDefaultBinding(InputControlType.RightStickUp);
        playerActions.Down.AddDefaultBinding(InputControlType.RightStickDown);

        playerActions.Up.AddDefaultBinding(Key.UpArrow);
        playerActions.Down.AddDefaultBinding(Key.DownArrow);
        playerActions.Left.AddDefaultBinding(Key.LeftArrow);
        playerActions.Right.AddDefaultBinding(Key.RightArrow);

        playerActions.Jump.AddDefaultBinding(Key.Space);
        playerActions.Jump.AddDefaultBinding(InputControlType.Action1);

        playerActions.Ability2.AddDefaultBinding(Key.LeftShift);
        playerActions.Ability2.AddDefaultBinding(InputControlType.Action1);

        playerType = PlayerType.SPLIT_TWO;
    }

    public PlayerType GetPlayerType() {
        return playerType;
    }
}
