using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Butts : MonoBehaviour{

    private GameManager gm;
    public List<Button> Butt = new List<Button>();
    
    private void Start() {
        gm = FindObjectOfType<GameManager>();

        for (int i = 0; i < Butt.Count; i++)
        {
            int index = i;
            Butt[i].onClick.AddListener(() => OnButtonClicked(index));
        }
    }
    
    void OnButtonClicked(int index){ 
        int i = 0;
        if(gm.isPicked.Flag == true){
            for(int j = index * 3 + 2; j >= index * 3; j--){
                if(gm.availableRingSlots[j] == true){
                    gm.isPicked.Flag = false;
                    gm.isPicked.Ring.transform.position = gm.ringSlots[j].position;
                    gm.isPicked.Ring.transform.localScale /= 1.8f;
                    gm.availableRingSlots[j] = false;
                    break;
                }
                else i+=1;
            }
            if (i != 3)
            gm.isLevelCompleted();
        }
    }
}
