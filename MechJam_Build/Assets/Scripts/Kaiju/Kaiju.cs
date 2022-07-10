using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaiju : MonoBehaviour
{
    //stats
    [SerializeField] private float m_health, m_damage, m_speed, m_attackSpeed;

    private void Awake() {
        m_speed = m_speed / 10;
        m_attackSpeed = m_attackSpeed / 10;
    }
    private void Start() {
        StartCoroutine(ApproachMech());
    }
    IEnumerator ApproachMech() {

        var i = 0f;
        while(i < 1f) {
            i += Time.deltaTime * m_speed;
            yield return null;
        }

        //when you have reached the mech...
        Debug.LogError("Kaiju has approached the mech!");
        StartCoroutine(AttackMech());
        
    }

    IEnumerator AttackMech() {
        var i = 0f;
        while(i < 1f) {
            i += Time.deltaTime * m_attackSpeed;
            yield return null;
        }
        //shoot mech
        ShootMech();

        StartCoroutine(AttackMech());

    }

    private void ShootMech() {
        Debug.Log("Shots fired!");
        GameManager.instance.Manager_Mech.DamageMech((int)m_damage);
    }


    public void SetKaijuHealth(int healthAmount) {
        m_health = healthAmount;
    }

    public int GetKaijuHealth() {
        return (int)m_health;
    }
    public void Damage(int amount) {
        int val = GetKaijuHealth() - amount;

        SetKaijuHealth(val);
        if (val <= 0) {
            //this kaiju has been defeated!
        }

    }
}
