
using InControl;
using UnityEngine;

public class PlayerActions : PlayerActionSet
{
	public PlayerAction Jump;
    public PlayerAction Reroll;
    public PlayerAction Ability1;
    public PlayerAction Ability2;

	public PlayerAction Left;
	public PlayerAction Right;
	public PlayerAction Up;
	public PlayerAction Down;
	public PlayerTwoAxisAction Move;

	public PlayerActions()
	{
        Jump = CreatePlayerAction("Jump");
        Reroll = CreatePlayerAction("Reroll");
        Ability1 = CreatePlayerAction("Ability1");
        Ability2 = CreatePlayerAction("Ability2");

		Left = CreatePlayerAction( "Move Left" );
		Right = CreatePlayerAction( "Move Right" );
		Up = CreatePlayerAction( "Move Up" );
		Down = CreatePlayerAction( "Move Down" );
		Move = CreateTwoAxisPlayerAction( Left, Right, Down, Up );
	}
}

