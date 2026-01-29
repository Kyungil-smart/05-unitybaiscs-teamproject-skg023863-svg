public interface IAnomaly
{
    // 이변 발생 시 호출 (정상 물체 끄기, 소리 재생 등)
    void ActivateAnomaly();

    // 이변 정리 시 호출 (정상 물체 복구, 상태 초기화)
    void DeactivateAnomaly();

    // 정답 판정
    bool IsChoiceCorrect(PlayerChoice choice);
}