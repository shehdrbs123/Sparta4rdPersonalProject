using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUI : MonoBehaviour
{
    public void OnClick()
    {
        GameObject obj = GameManager.Instance.UIManager.GetUI("YesOrNoUI");
        obj.GetComponent<YesOrNoUI>().ShowYesOrNoUI("테스트",()=> Debug.Log("Yes"), () => Debug.Log("No"));
    }
}
