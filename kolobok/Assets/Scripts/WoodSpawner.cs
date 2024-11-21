using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSpawner : MonoBehaviour
{
	[SerializeField]
	public GameObject woodPrefab;

	private GameObject currentWood;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void TakeWood()
	{
		currentWood.SetActive(true);

		var newWood = Instantiate(woodPrefab);

		currentWood = newWood;
	}
}
