using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int time = 30;

    public int difficulty =1;
    private void Awake() {
        if(Instance == null){
            Instance = this;
        }
    }

    private void Start() {
        StartCoroutine(countDownRoutine());
    }
    IEnumerator countDownRoutine(){
        while (time>0)
        {
            yield return new WaitForSeconds(1);
            time--;
        }
    }

}
