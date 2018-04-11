using InControl;
using UnityEngine;

public class PlayerActions : PlayerActionSet {
    public PlayerAction Jump;
    public PlayerAction Glide;
    public PlayerAction Left;
    public PlayerAction Right;
    public PlayerAction Up;
    public PlayerAction Down;
    public PlayerTwoAxisAction Move;

    public PlayerActions() {
        Jump = CreatePlayerAction("Jump");

        Left = CreatePlayerAction("Move Left");
        Right = CreatePlayerAction("Move Right");
        Up = CreatePlayerAction("Move Up");
        Down = CreatePlayerAction("Move Down");

        Glide = CreatePlayerAction("Glide");
        Move = CreateTwoAxisPlayerAction(Left, Right, Down, Up);
    }
}

