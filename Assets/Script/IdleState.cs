using UnityEngine;

public class IdleState : IPlayerMovementState
{
    public void HandleInput(Player player, Vector2 input)
    {
        if (input.magnitude > 0.1f)
        {
            player.ChangeState(new WalkingState());
        }
    }

    public void Update(Player player, Vector2 input)
    {
        //Handle Idle behavior
    }
    
}
