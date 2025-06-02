using UnityEngine;

public class Container : MonoBehaviour
{
    public int ID;
    public float rangeRaycast;
    public int amoutSlot;
    public float moveSpeed;
    public float distanceMove;
    public LayerMask layerContainer;
    public LayerMask layerWall;
    public bool isMove = false;
    public Transform transformParent;
    public Vector3 targetPosition;
    private MoveToPoint moveToPoint;
    public int indexRoute;
    Material material;
    void Start()
    {
        moveToPoint = GetComponentInParent<MoveToPoint>();
        material = GetComponent<MeshRenderer>().material;
        targetPosition = transformParent.position + transform.forward * distanceMove;

        ScaleWithSlot();
        ChangeColor();
    }

    void Update()
    {
        if(isMove){
            MoveForward();
            // MoveContainNer();
        }
    }
    public void ScaleWithSlot(){
        if(amoutSlot==4){
            transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y, 1.2f);
        }
        else if(amoutSlot == 6){
            transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y, 1.4f);
        }
        else if(amoutSlot == 8){
            transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y, 1.6f);
        }
    }
    public void ChangeColor(){
        material.color = ManageContainer.Instance.GetColor(ID);
    }

    public void MoveContainNer(){
        CheckContainer();
    }

    public void CheckContainer(){
        RaycastHit hit;
        Debug.DrawLine(transform.position, transform.position + transform.forward, Color.red);
        if(Physics.Raycast(transform.position,transform.forward,out hit,rangeRaycast, layerContainer)){
            Debug.Log(gameObject.name+" Don't move");
        }
        else{
            
            isMove = true;
            
        }
        
    }
    public void MoveForward(){
        RaycastHit hit;
        Debug.DrawLine(transform.position, transform.position + transform.forward * 1f, Color.green);
        if (!Physics.Raycast(transform.position,transform.forward,out hit,1f, layerWall))
        {
            transformParent.position = Vector3.MoveTowards(transformParent.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            Debug.Log("Stop");
            isMove = false;
            indexRoute = Route.Instance.CompareDistance(transform.position);
            moveToPoint.SetRoute(indexRoute);
            // moveToPoint.SetDestination();
        }
    }


}
