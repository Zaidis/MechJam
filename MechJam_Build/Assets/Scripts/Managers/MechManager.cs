using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechManager : MonoBehaviour
{

    private int m_health;
    private int m_shield;

    #region Mech Health
    public void SetMechHealth(int amount) {
        m_health = amount;
    }
    public int GetMechHealth() {
        return m_health;
    }

    public void DamageMechHealth(int damageAmount) {
        int val = m_health - damageAmount;
        SetMechHealth(val);

        if(val <= 0) {
            //game ends
        }
    }

    #endregion
    #region Mech Shield

    public void SetMechShield(int amount) {
        m_shield = amount;
    }

    public int GetMechShield() {
        return m_shield;
    }

    public void DamageMechShield(int damageAmount) {
        int val = m_shield - damageAmount;

        

        int difference = val * -1;
        
        if(difference >= 0) {
            //this means that the shield was depleated and there was extra damage
            //which means we need to reduce the health value as well. 

            DamageMechHealth(difference);
        }
    }

    public void FixMechShield(int healAmount) {
        int val = m_shield + healAmount;
        SetMechShield(val);
    }

    #endregion
}
