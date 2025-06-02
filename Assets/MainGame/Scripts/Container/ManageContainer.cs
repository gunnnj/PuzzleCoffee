using System.Collections.Generic;
using UnityEngine;

public class ManageContainer : MonoBehaviour
{
    public static ManageContainer Instance;

    [SerializeField] Color[] listColor;
    [SerializeField] List<Container> listContainer = new List<Container>();
    

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        AddListContainer();
    }

    public Color GetColor(int value){
        return listColor[value];
    }

    public void AddListContainer(){
        for(int i=0; i<transform.childCount; i++){
            Container container = transform.GetChild(i).GetChild(0).gameObject.GetComponent<Container>();
            listContainer.Add(container);
        }
    }
}
