using UnityEngine;
using System.Collections;

public class sample : MonoBehaviour //滑鼠拖曳物體
{    
    Vector3 offset;
    void Update()
    {
        /*我原本以為的方法(不行原因:滑鼠座標是畫素座標，但相機是世界座標)
        if(Input.GetMouseButton(0)){
            transform.position = new Vector3( Input.mousePosition.x, Input.mousePosition.y, 0);
        }*/

        /*網路上的簡單版本(不行原因:z座標會與相機一致，所以看不到)
        if(Input.GetMouseButton(0)){
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition.x, Input.mousePosition.y);
        }*/
        
        /*網路解法1(看不懂，也動不了)
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray , out hit))
            {
                Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
                hit.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
            }
        }*/
    }
    //網路解法2
    void OnMouseDown(){
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    }

    void OnMouseDrag(){
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }
}