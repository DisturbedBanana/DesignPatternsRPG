using UnityEngine;

public class WalkingState : IPlayerMovementState
{
    public void HandleInput(Player player, Vector2 input)
    {
        if (input.magnitude < 0.1f)
        {
            player.ChangeState(new IdleState());
        }
        else if (input.magnitude > 0.5f)
        {
            player.ChangeState(new RunningState());
        }
    }

    public void Update(Player player, Vector2 input) // Add input parameter
    {
        // Handle walking behavior
        player.Move(input);
    }
}

