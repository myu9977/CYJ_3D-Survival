using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uICondition;

    Condition health { get { return uICondition.health; } }
    Condition hunger { get { return uICondition.hunger; } }
    Condition stamina { get { return uICondition.stamina; } }

    public float noHungerHealthDecay; // 허기가 0일 때 체력이 감소하는 속도

    void Update()
    {
        hunger.Subtract(hunger.passiveValue * Time.deltaTime); // 허기를 패시브 값만큼 감소
        stamina.Add(stamina.passiveValue * Time.deltaTime); // 스태미나를 패시브 값만큼 증가

        if (hunger.curValue <= 0f) // 허기가 0 이하이면 체력 감소
        {
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }

        if (health.curValue <= 0f) // 체력이 0 이하이면 사망 처리
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Eat(float amount)
    {
        hunger.Add(amount);
    }

    public void Die()
    {
        Debug.Log("죽음");
    }
}
