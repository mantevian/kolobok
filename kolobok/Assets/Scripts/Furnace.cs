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
    public GameObject readyDisplay;

    [SerializeField]
    public GameObject particlesObject;

    [SerializeField]
    public GameObject pointLight;

    public double fireStrength = 0.0d;

    public double readiness = 0.0d;

    public double criticalHeat = 0.0d;

    private bool isCooking = false;

    public bool isOpen = false;

    void Start()
    {

    }

    void Update()
    {
        var particles = particlesObject.GetComponent<ParticleSystem>();
        var m2 = particles.main;
        m2.startColor = new Color(1.0f, 0.5f, 0.0f, (float)fireStrength);

        var light = pointLight.GetComponent<Light>();
        light.intensity = 5.0f * (float)fireStrength;

        readyDisplay.GetComponent<Slider>().value = (float)readiness;

        var fireSlider = fireStrengthDisplay.GetComponent<Slider>();
        fireSlider.value = (float)fireStrength;

        ColorBlock colors = fireSlider.colors;
        Color c = new Color(0.5f + 0.5f * (float)criticalHeat, 0.5f - 0.5f * (float)criticalHeat, 0.1f);
        colors.normalColor = c;
        colors.highlightedColor = c;
        colors.selectedColor = c;
        colors.pressedColor = c;

        fireSlider.colors = colors;
    }

    void FixedUpdate()
    {
        if (isCooking)
        {
            // если сила меньше 0.3, готовность будет уменьшаться
            readiness += (fireStrength - 0.3d) * burnPerSecond / 60d;
            readiness = Math.Max(readiness, 0.0d);

            // если сила больше 0.7, "критическая шкала" будет увеличиваться
            if (fireStrength > 0.95d)
            {
                criticalHeat += 0.03d / 60d;
            }
            else if (fireStrength > 0.7d)
            {
                criticalHeat += 0.01d / 60d;
            }
            else
            {
                criticalHeat = Math.Max(0.0d, criticalHeat - 0.01d / 60d);
            }

            fireStrength = Math.Min(fireStrength, 1.1d);
            fireStrength = Math.Max(0.0d, fireStrength - cooldownPerSecond / 60d);

            transform.root.GetComponent<Game>().Log("fire " + fireStrength + ", readiness " + readiness + ", critical " + criticalHeat);

            // перегрели, чтобы не бесконечно печка топилась
            if (readiness >= 1.5d)
            {
                StopCooking();
            }

            if (criticalHeat >= 1.0d)
            {
                criticalHeat += 0.01d;
                readiness += 0.01d;
            }

            // пережарили — колобок вылетает в окно
            if (criticalHeat >= 1.5d)
            {
                transform.root.Find("Sound").Find("Explode").gameObject.GetComponent<AudioSource>().Play();
                StopCooking();
                // transform.Find("Container").Find("Kolobok").gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, -1.0f, 0.0f), ForceMode.Impulse);
            }
        }
        else
        {
            fireStrength = Math.Max(0.0d, fireStrength - cooldownPerSecond / 10d);
            criticalHeat = Math.Max(0.0d, criticalHeat - 0.01d / 10d);
        }
    }

    public void AddWood()
    {
        if (!isCooking)
        {
            StartCooking();
        }

        fireStrength += 0.18d;
        transform.root.Find("Sound").Find("Ignite").gameObject.GetComponent<AudioSource>().Play();
    }

    public void StartCooking()
    {
        var game = transform.root.GetComponent<Game>();
        if (game.gameState == GameState.CLOSING_FURNACE)
        {
            game.gameState = GameState.COOKING;
            readiness = 0.0d;
            isCooking = true;

            transform.root.Find("Sound").Find("FireAmbient").gameObject.GetComponent<AudioSource>().Play();
        }
    }

    public void StopCooking()
    {
        isCooking = false;

        transform.root.Find("Sound").Find("FireAmbient").gameObject.GetComponent<AudioSource>().Stop();
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
