using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearblocks : MonoBehaviour
{
    static public int i = 0;

    void Update(){
        if(spawnquize.clear > 1){
            Destroy(this.gameObject);
            i +=1;
            if(i == 9){
                spawnquize.clear = 1;
                i = 0;
            }
            //
            //DestroyImmediate(gameObject,true);
        }
    }
}
