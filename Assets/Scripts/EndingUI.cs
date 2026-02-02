using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndingUI : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(GoToCreditRoutine());
    }

    private IEnumerator GoToCreditRoutine()
    {
        yield return new WaitForSeconds(2f);

        SceneFlowManager.Instance.LoadCredit();
    }
}