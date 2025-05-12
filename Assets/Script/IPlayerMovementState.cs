using UnityEngine;

public interface IPlayerMovementState
{
    void HandleInput(Player player, Vector2 input);
    void Update(Player player, Vector2 input); // Add input parameter
}


