/*
이상현상 판정을 위한 인터페이스

- 모든 이상현상 프리팹은 반드시 이 인터페이스를 구현해야 함
- AnomalyManager는 이 인터페이스만 알고 판정을 위임함
- 개별 이상현상 로직은 서로 몰라도 됨 (확장성 확보)
*/
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