using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
1. 스크립트 작성 시 : AnomalyBase 상속
2. 인스펙터 'Target Normal Object'에 사라져야 할 정상 물체 연결 (없으면 비워둠)
*/
public class AnomalyBase : MonoBehaviour, IAnomaly
{
    [SerializeField, Tooltip("이상현상이 켜질때 꺼져야 할 정상 오브젝트")]
    protected GameObject _targetNormalObject;

    public virtual void ActivateAnomaly()
    {
        // 타겟이 있으면 끄고(액자 사라짐 등), 없으면 그냥 둠
        if (_targetNormalObject != null)
            _targetNormalObject.SetActive(false);
    }

    public virtual void DeactivateAnomaly()
    {
        // 다시 정상으로 복구
        if (_targetNormalObject != null)
            _targetNormalObject.SetActive(true);

        gameObject.SetActive(false);
    }

    // 기본적으로 이변이 존재하면 Up이 정답
    public virtual bool IsChoiceCorrect(PlayerChoice choice)
    {
        return choice == PlayerChoice.Up;
    }
}