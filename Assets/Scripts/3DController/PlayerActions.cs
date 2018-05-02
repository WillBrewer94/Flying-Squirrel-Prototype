using InControl;
using UnityEngine;

public class PlayerActions : PlayerActionSet {
    public PlayerAction Jump;
    public PlayerAction Glide;
    public PlayerAction Dialogue;

    public PlayerAction Left;
    public PlayerAction Right;
    public PlayerAction Up;
    public PlayerAction Down;
    public PlayerAction CamLeft;
    public PlayerAction CamRight;
    public PlayerAction CamUp;
    public PlayerAction CamDown;

    public PlayerTwoAxisAction Move;
    public PlayerTwoAxisAction CamMove;

    public PlayerActions() {
        Jump = CreatePlayerAction("Jump");
        Dialogue = CreatePlayerAction("Dialogue");

        Left = CreatePlayerAction("Move Left");
        Right = CreatePlayerAction("Move Right");
        Up = CreatePlayerAction("Move Up");
        Down = CreatePlayerAction("Move Down");

        CamLeft = CreatePlayerAction("Cam Move Left");
        CamRight = CreatePlayerAction("Cam Move Right");
        CamUp = CreatePlayerAction("Cam Move Up");
        CamDown = CreatePlayerAction("Cam Move Down");

        Glide = CreatePlayerAction("Glide");
        CamMove = CreateTwoAxisPlayerAction(CamLeft, CamRight, CamUp, CamDown);
        Move = CreateTwoAxisPlayerAction(Left, Right, Down, Up);
    }
}

