using UnityEngine;

public class RunningState : IPlayerMovementState
{
    public void HandleInput(Player player, Vector2 input)
    {
        if (input.magnitude < 0.1f)
        {
            player.ChangeState(new IdleState());
        }
        else if (input.magnitude < 0.5f)
        {
            player.ChangeState(new WalkingState());
        }
    }

    public void Update(Player player, Vector2 input) // Add input parameter
    {
        // Handle running behavior
        player.Move(input * 2f); // Run faster
    }
}


