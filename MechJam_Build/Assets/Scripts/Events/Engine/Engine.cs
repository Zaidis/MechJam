using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : Event
{
    public int m_countdownTimer;

    [SerializeField] private float i;
    private void Start() {
        BeginEvent();
    }
    public override void BeginEvent() {
        //UI popup  + red siren lighting + siren sounds go here


        StartCoroutine(Countdown());
    }

    public override void EndEvent() {
        StopAllCoroutines();
    }


    IEnumerator Countdown() {

        i = 0f;

        while(i < 1f) {
            i += Time.deltaTime / m_countdownTimer;
            yield return null;
        }

        //if it reaches this, game over
        Debug.LogError("Engine has overheated!");
    }
}
