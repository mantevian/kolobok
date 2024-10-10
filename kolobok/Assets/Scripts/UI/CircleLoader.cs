using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class CircleLoader : MonoBehaviour
{
    public Image loadingImage;

    [Range(0, 1)]
    public float loadingProgress = 0;

    [SerializeField]
    public int duration = 5;

    [SerializeField]
    public CircleLoaderTrigger trigger;



    // Update is called once per frame
    void Update()
    {
        if(trigger.entered.Count == 2 && loadingProgress < 1)
            loadingProgress += Time.deltaTime/duration;
        else 
            loadingProgress = 0;
        
        if (loadingProgress >=1 )
            Done();
        
        loadingImage.fillAmount = loadingProgress;
    }

    void Done(){
        Debug.Log("Win!");
    }
}