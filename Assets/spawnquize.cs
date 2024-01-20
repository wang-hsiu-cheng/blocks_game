using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnquize : MonoBehaviour{

    [SerializeField] GameObject[] colorblocks;
    static public int clear = 0;
    private int[] array_randomnumber = new int[6] {0,0,0,0,0,0};
    static public string[,] array_answer = new string[3,3];
    static public string[,] array_youcanmove = new string[7,7] {{"0","0","0","0","0","0","0"},
                                                                {"0","","","","","","0"},
                                                                {"0","","","","","","0"},
                                                                {"0","","","","","","0"},
                                                                {"0","","","","","","0"},
                                                                {"0","","","","","","0"},
                                                                {"0","0","0","0","0","0","0"}};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            blockController.correct = 9;
        }
        if(Input.GetKeyDown(KeyCode.X)){
            for(int i=2; i<5; i++){
                for(int j=2; j<5; j++){
                    print(i+","+j+"="+array_youcanmove[i, j]);
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.S)){
            print("correct=" + blockController.correct);
        }
    }

    public void Onspawnquizeclick(){
        clear += 1;
        for(int i=-1; i>-4; i--){
            for(int j=-7; j<-4; j++){
                int randomnumber = Random.Range(0, 6);
                if(array_randomnumber[randomnumber] > 4){
                    int falsenumber = randomnumber;
                    while(falsenumber == randomnumber){
                        randomnumber = Random.Range(0, 6);
                    }
                }
                GameObject block = Instantiate(colorblocks[randomnumber], new Vector3(j,i,0), Quaternion.Euler (0, 0, 0));
                array_answer[-i-1,j+7] = colorblocks[randomnumber].ToString();
                array_answer[-i-1,j+7] += " 1"; /*array_answer[-i-1,j+7]+'1';*/
                array_randomnumber[randomnumber] +=1;
            }
        }
        for(int i=0; i<3; i++){
            for(int j=0; j<3; j++){
                print(i+","+j+"="+array_answer[i, j]);
            }
        }
        if(clear <= 1){
            spawnmovething();
            spawnmovething();
            spawnmovething();
            spawnmovething();
        }
        for(int i=2; i<5; i++){
            for(int j=2; j<5; j++){
                print(i+","+j+"="+array_youcanmove[i, j]);
            }
        }
        Timer.time_basic = 0;
        Timer.time_wsec = 0;
        Timer.time_sec = 0;
        Timer.time_min = 0;
        Timer.countining = true;
    }

    void spawnmovething(){
        for(int i=6; i<12; i++){
            //int x = Random.Range(0, 5);
            //int y = Random.Range(0, -5);
            Vector3 position = new Vector3(Random.Range(0, 5), Random.Range(0, -5), 0);
            while(array_youcanmove[-1*(int)position.y+1, (int)position.x+1] != ""){
                position = new Vector3(Random.Range(0, 5), Random.Range(0, -5), 0);
            }
            GameObject youcanmove = Instantiate(colorblocks[i], position, Quaternion.Euler (0, 0, 0));
            array_youcanmove[-1*(int)position.y+1, (int)position.x+1] = colorblocks[i].ToString();
        }
    }

}
