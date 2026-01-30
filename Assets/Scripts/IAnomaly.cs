public enum PlayerChoice
{
    Up,
    Down
}

public interface IAnomaly
{
    void Enter();
    void Exit();
    bool IsChoiceCorrect(PlayerChoice playerChoice);
}