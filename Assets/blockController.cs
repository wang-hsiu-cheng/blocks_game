using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockController : MonoBehaviour
{
    private int x, y;
    static public int correct = 0;
    // Start is called before the first frame update
    void Start()
    {
        x = (int)transform.position.x+1;
        y = -1*(int)transform.position.y+1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseUp(){
        //correct = 0;
        x = (int)transform.position.x+1;
        y = -1*(int)transform.position.y+1;
        if(spawnquize.array_youcanmove[y, x+1] == ""){
            transform.Translate( 1, 0, 0 );
            spawnquize.array_youcanmove[y, x+1] = spawnquize.array_youcanmove[y, x];
            spawnquize.array_youcanmove[y, x] = "";
        }
        else if(spawnquize.array_youcanmove[y, x-1] == ""){
            transform.Translate( -1, 0, 0 );
            spawnquize.array_youcanmove[y, x-1] = spawnquize.array_youcanmove[y, x];
            spawnquize.array_youcanmove[y, x] = "";
        }
        else if(spawnquize.array_youcanmove[y-1, x] == ""){
            transform.Translate( 0, 1, 0 );
            spawnquize.array_youcanmove[y-1, x] = spawnquize.array_youcanmove[y, x];
            spawnquize.array_youcanmove[y, x] = "";
        }
        else if(spawnquize.array_youcanmove[y+1, x] == ""){
            transform.Translate( 0, -1, 0 );
            spawnquize.array_youcanmove[y+1, x] = spawnquize.array_youcanmove[y, x];
            spawnquize.array_youcanmove[y, x] = "";
        }
        for(int i=0; i<3; i++){
            for(int j=0; j<3; j++){
                if(spawnquize.array_youcanmove[i+2, j+2] == spawnquize.array_answer[i, j]+" 1"){
                    correct += 1;
                }
            }
        }
    }
}
