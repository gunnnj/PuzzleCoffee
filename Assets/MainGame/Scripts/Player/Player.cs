using UnityEngine;

public class Player : MonoBehaviour
{
    public LayerMask layerContainer;
    private Container container;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray ray;
            if (Input.touchCount > 0)
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            }
            else
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            }

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerContainer))
            {
                container = hit.collider.gameObject.GetComponent<Container>();
                container.MoveContainNer();
            }
            else{
                Debug.Log("0");
            }

        }
    }

}
