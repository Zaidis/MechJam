using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechManager : MonoBehaviour
{

    [SerializeField]private int m_health;
    [SerializeField]private int m_shield;


    /// <summary>
    /// Always call this function when Kaiju damages the Mech. 
    /// </summary>
    /// <param name="damageAmount"></param>
    public void DamageMech(int damageAmount) {
        if (GetMechShield() > 0) DamageMechShield(damageAmount);
        else DamageMechHealth(damageAmount);
    }

    #region Mech Health
    public void SetMechHealth(int amount) {
        m_health = amount;
        Debug.Log("Health amount = " +  m_health);
    }
    public int GetMechHealth() {
        return m_health;
    }

    private void DamageMechHealth(int damageAmount) {
        int val = GetMechHealth() - damageAmount;
        SetMechHealth(val);

        if(val <= 0) {
            //game ends
        }
    }

    #endregion
    #region Mech Shield

    public void SetMechShield(int amount) {

        m_shield = amount;
        Debug.Log("Shield amount = " + m_shield);
    }

    public int GetMechShield() {
        return m_shield;
    }

   
    private void DamageMechShield(int damageAmount) {
        int val = GetMechShield() - damageAmount;

        

        int difference = val * -1;
        
        if(difference >= 0) {
            SetMechShield(0);
            //this means that the shield was depleated and there was extra damage
            //which means we need to reduce the health value as well. 

            DamageMechHealth(difference);
            return;
        } 

        //only if the shield is still above 0
        SetMechShield(val);
    }

    public void FixMechShield(int healAmount) {
        int val = GetMechShield() + healAmount;
        SetMechShield(val);
    }

    #endregion
}
