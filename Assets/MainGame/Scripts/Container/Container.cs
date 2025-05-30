using UnityEngine;

public class Container : MonoBehaviour
{
    public int ID;
    public int amoutSlot;
    public float moveSpeed;
    public LayerMask layerContainer;
    public bool isMove = false;
    public Transform transformParent;
    Vector3 targetPosition;
    Material material;
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        targetPosition = transformParent.position + transform.forward * 10f;

        ScaleWithSlot();
        ChangeColor();
    }

    void Update()
    {
        if(isMove){
            MoveForward();
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
        Debug.DrawLine(transform.position, transform.position + transform.forward, Color.red, 5f);
        if(Physics.Raycast(transform.position,transform.forward,out hit,5f, layerContainer)){
            Debug.Log(gameObject.name+" Don't move");
        }
        else{
            isMove = true;
        }
        
    }
    public void MoveForward(){
        transformParent.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }


}
