using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    public Transform[] route1;
    public Transform[] route2;
    public Transform[] slot1;
    public Transform[] slot2;
    public Transform[] slot3;

    public static Route Instance;

    void Awake()
    {
        Instance = this;
    }

    public int CompareDistance(Vector3 pos){

        float dis1 = Vector3.Distance(pos,route1[0].position);
        float dis2 = Vector3.Distance(pos,route2[0].position);
        if(dis1<dis2){
            Debug.Log("route1");
            return 1;
        }
        else{
            Debug.Log("route2");
            return 2;
        }

    }
    public Transform[] GetRoute(int index){
        if(index == 1){
            return route1;
        }
        return route2;
    }
}
