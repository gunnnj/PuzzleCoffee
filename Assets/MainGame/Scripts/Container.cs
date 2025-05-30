using UnityEngine;

public class Container : MonoBehaviour
{
    public int amoutSlot;
    public float moveSpeed;
    public LayerMask layerContainer;
    public bool isMove = false;
    Vector3 targetPosition;
    void Start()
    {
        targetPosition = transform.position + transform.forward * 10f;
    }

    void Update()
    {
        // CheckContainer();
        if(isMove){
            MoveForward();
        }
    }

    public void MoveContainNer(){
        CheckContainer();
    }

    public void CheckContainer(){
        RaycastHit hit;
        Debug.DrawLine(transform.position, transform.position + transform.forward, Color.red, 5f);
        if(Physics.Raycast(transform.position,transform.forward,out hit,5f, layerContainer)){
            Debug.Log(gameObject.name+" Don't move");
        }
        else{
            isMove = true;
        }
        
    }
    public void MoveForward(){
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

}
