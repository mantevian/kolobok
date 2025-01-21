using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Furnace : MonoBehaviour
{
    [SerializeField]
    public double burnPerSecond = 0.01d;

    [SerializeField]
    public double cooldownPerSecond = 0.01d;

    [SerializeField]
    public GameObject fireStrengthDisplay;

    [SerializeField]
    public GameObject particlesObject;

    public double fireStrength = 0.0d;

    public double readiness = 0.0d;

    public double criticalHeat = 0.0d;

    private bool isCooking = false;

    public bool isOpen = false;

    void Start()
    {
        // TODO THIS IS DEBUG REMOVE LATER
        // vvv
        isCooking = true;
        fireStrength = 0.5d;
        // ^^^
    }

    void Update()
    {
        var particles = particlesObject.GetComponent<ParticleSystem>();
        
        var m = particles.main;

        m.startColor = new Color(1.0f, 0.5f, 0.0f, (float)fireStrength);

        fireStrengthDisplay.GetComponent<Slider>().value = (float)fireStrength;
    }

    void FixedUpdate()
    {
        if (isCooking)
        {
            // если сила меньше 0.3, готовность будет уменьшаться
            readiness += (fireStrength - 0.3d) * burnPerSecond / 60d;
            readiness = Math.Max(readiness, 0.0d);

            // если сила больше 0.7, "критическая шкала" будет увеличиваться
            if (fireStrength > 0.7d)
            {
                criticalHeat += 0.02d / 60d;
            }
            else
            {
                criticalHeat -= 0.01d / 60d;
            }

            fireStrength = Math.Min(fireStrength, 1.0d);
            fireStrength = Math.Max(0.0d, fireStrength - cooldownPerSecond / 60d);

            Debug.Log("fire " + fireStrength + ", readiness " + readiness + ", critical " + criticalHeat);

            // успешно приготовили
            if (readiness >= 1.0d)
            {
                StopCooking();
            }

            // пережарили — колобок вылетает в окно
            if (criticalHeat >= 1.0d)
            {
                StopCooking();
            }
        }
    }

    public void AddWood()
    {
        fireStrength += 0.15d;
    }

    public void StartCooking()
    {
        readiness = 0.0d;
        isCooking = true;
    }

    public void StopCooking()
    {
        readiness = 0.0d;
        isCooking = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        var wood = collider.gameObject.GetComponent<Wood>();

        if (wood != null)
        {
            AddWood();
            Destroy(collider.gameObject);
        }
    }
}
