using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ring : MonoBehaviour{

    private GameManager gm;

    private void Start() {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown() {
        int index = 0;
        for(int i = 0; i < 9; i++){
            if (transform.position == gm.ringSlots[i].position){
                index = i;
            }
        }

        int blok = index/3;
        
        for(int j = blok * 3; j < index; j++){
            if(gm.availableRingSlots[j] == false) return;
        }
        
        if(!gm.isPicked.Flag && gm.availableMoves > 0){
            gm.isPicked.Flag = true;
            gm.isPicked.Ring = this;
            gm.availableRingSlots[index] = true;
            transform.position = gm.ringSlots[9].position;
            transform.localScale *= 1.8f;
        }
    }
    
}
