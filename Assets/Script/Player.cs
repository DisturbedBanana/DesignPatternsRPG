using UnityEngine;

public class Player : MonoBehaviour
{
    private IPlayerMovementState currentState;
    private Vector2 input;

    void Start()
    {
        currentState = new IdleState();
    }

    void Update()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        currentState.HandleInput(this, input);
        currentState.Update(this, input); // Pass input to the Update method
    }

    public void Move(Vector2 movement)
    {
        transform.Translate(movement * Time.deltaTime);
    }

    public void ChangeState(IPlayerMovementState newState)
    {
        currentState = newState;
    }
}