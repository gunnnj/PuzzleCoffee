using UnityEngine;
using UnityEngine.AI;

public class MoveToPoint : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform posToMove;
    public Transform[] posRoute;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void SetRoute(int index){
        posRoute = Route.Instance.GetRoute(index);
        CalculateDistance();


        // posToMove = posRoute[0];
        // navMeshAgent.SetDestination(posToMove.position);
    }
    public void CalculateDistance(){
        if (posRoute == null || posRoute.Length < 2)
        {
            Debug.LogError("PosRoute is null or does not have enough points.");
            return;
        }

        int closestIndex1 = -1;
        int closestIndex2 = -1;
        float closestDistance1 = float.MaxValue;
        float closestDistance2 = float.MaxValue;

        for (int i = 0; i < posRoute.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, posRoute[i].position);

            // Kiểm tra và cập nhật điểm gần nhất
            if (distance < closestDistance1)
            {
                closestDistance2 = closestDistance1;
                closestIndex2 = closestIndex1;

                closestDistance1 = distance;
                closestIndex1 = i;
            }
            else if (distance < closestDistance2)
            {
                closestDistance2 = distance;
                closestIndex2 = i;
            }
        }
        if(closestIndex1>closestDistance2){
            Debug.Log("index " +closestIndex1);
        }
        else{
            Debug.Log("index " +closestIndex2);
        }
    }
}
