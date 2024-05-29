using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uICondition;

    Condition health { get { return uICondition.health; } }
    Condition hunger { get { return uICondition.hunger; } }
    Condition stamina { get { return uICondition.stamina; } }

    public float noHungerHealthDecay; // ��Ⱑ 0�� �� ü���� �����ϴ� �ӵ�

    void Update()
    {
        hunger.Subtract(hunger.passiveValue * Time.deltaTime); // ��⸦ �нú� ����ŭ ����
        stamina.Add(stamina.passiveValue * Time.deltaTime); // ���¹̳��� �нú� ����ŭ ����

        if (hunger.curValue <= 0f) // ��Ⱑ 0 �����̸� ü�� ����
        {
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }

        if (health.curValue <= 0f) // ü���� 0 �����̸� ��� ó��
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
        Debug.Log("����");
    }
}
