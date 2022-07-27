using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaijuManager : MonoBehaviour
{

    public Kaiju leftKaiju, rightKaiju;

    #region KaijuHealth
    public void DamageKaiju(Kaiju k, int amount) {
        k.Damage(amount);
        
    }



    #endregion

}
