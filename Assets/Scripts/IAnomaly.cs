public interface IAnomaly
{
    /*
    플레이어의 선택이 올바른지 판정

    플레이어가 선택한 Up / Down
    정답 처리
    오답 처리
    */
    bool IsChoiceCorrect(PlayerChoice choice);
}