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
        // CharacterManager�� Player�� condition�� ���� UICondition�� ����
        CharacterManager.Instance.Player.condition.uICondition = this;
    }
}
