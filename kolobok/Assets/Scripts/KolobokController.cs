using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KolobokController : MonoBehaviour
{


    [SerializeField]
    Mesh LessMesh;
    
    [SerializeField]
    Mesh GoodMesh;
    
    [SerializeField]
    Mesh MoreMesh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init(int flour, int egg, int butter) // Меньше нуля -- мало, ноль -- равно, больше нуля -- много
    {   
        if (flour == 0){
            transform.localScale = new Vector3(6.9f,6.9f,6.9f);
        } else if (flour < 0){
            transform.localScale = new Vector3(5f,5f,5f);
        } else {
            transform.localScale = new Vector3(8f,8f,8f);
        }

        Mesh meshToSet;
        if (egg == 0){
            meshToSet = GoodMesh;
        } else if (egg < 0){
            meshToSet = LessMesh;
        } else {
            meshToSet = MoreMesh;
        }
        GetComponent<MeshCollider>().sharedMesh = meshToSet;
        GetComponent<MeshFilter>().sharedMesh = meshToSet;

        Renderer rend = GetComponent<Renderer>();
        rend.material.EnableKeyword("_BumpScale");
        if (butter == 0){
            rend.material.SetFloat("_BumpScale", 2);
        } else if (butter < 0){
            rend.material.SetFloat("_BumpScale", 0.5f);
        } else {
            rend.material.SetFloat("_BumpScale", 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
