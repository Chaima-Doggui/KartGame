using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurboUI : MonoBehaviour
{
    [SerializeField] RectTransform TurboFillAmount;
    private void setTurboAmount(float _amount)
    {
        TurboFillAmount.localScale = new Vector3(1f, _amount, 1f);
    }

    void Update()
    {
        setTurboAmount(GetComponent<Movement>().getTurboAmount());
    }
}
