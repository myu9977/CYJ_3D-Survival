using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition health;
    public Condition hunger;
    public Condition stamina;

    void Start()
    {
        // CharacterManager의 Player의 condition에 현재 UICondition을 설정
        CharacterManager.Instance.Player.condition.uICondition = this;
    }
}
