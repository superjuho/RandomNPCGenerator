using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBehaviour : MonoBehaviour
{   
    //shirts
    public Material RedFlannel;
    public Material BlackFlannel;
    public Material FancyFlannel;
    public Material BlueFlannel;

    //pants
    public Material BlackPants;
    public Material BeigePants;
    public Material RedPants;
    public Material BrownPants;

    //skins
    public Material LightSkin;
    public Material TonedSkin;
    public Material DarkSkin;
    public Material BlackSkin;

    public GameObject head;
    public GameObject torso;
    public GameObject legs;

    public float Minimum;
    public float Maximum;



    static float RandomFloat(float min, float max)
    {
        System.Random random = new();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }

    static int RandomInt()
    {
        System.Random random = new();
        int randomInt = random.Next(1, 5);
        
        return randomInt;
    }

    private void RandomHead(int number)
    {
        switch(number)
        {
            case 1:
                head.GetComponent<Renderer>().material = LightSkin;
                break;
            case 2:
                head.GetComponent<Renderer>().material = TonedSkin;
                break;
            case 3:
                head.GetComponent<Renderer>().material = DarkSkin;
                break;
            case 4:
                head.GetComponent<Renderer>().material = BlackSkin;
                break;
            default:
                Debug.Log("Not possible?");
                break;
        }
    }

    private void RandomTorso(int number)
    {
        switch (number)
        {
            case 1:
                legs.GetComponent<Renderer>().material = RedFlannel;
                break;
            case 2:
                legs.GetComponent<Renderer>().material = BlackFlannel;
                break;
            case 3:
                legs.GetComponent<Renderer>().material = FancyFlannel;
                break;
            case 4:
                legs.GetComponent<Renderer>().material = BlueFlannel;
                break;
            default:
                Debug.Log("Not possible?");
                break;
        }
    }

    private void RandomPants(int number)
    {
        switch (number)
        {
            case 1:
                torso.GetComponent<Renderer>().material = RedPants;
                break;
            case 2:
                torso.GetComponent<Renderer>().material = BlackPants;
                break;
            case 3:
                torso.GetComponent<Renderer>().material = BeigePants;
                break;
            case 4:
                torso.GetComponent<Renderer>().material = BrownPants;
                break;
            default:
                Debug.Log("Not possible?");
                break;
        }
    }

    void Start()
    {
        transform.localScale = new Vector3(RandomFloat(Minimum, Maximum), RandomFloat(Minimum, Maximum), 1);
        RandomHead(RandomInt());
        RandomPants(RandomInt());
        RandomTorso(RandomInt());
    }
}
