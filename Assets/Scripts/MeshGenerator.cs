using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    public GameObject head;
    public GameObject head2;
    public GameObject head3;
    public GameObject torso;
    public GameObject torso2;
    public GameObject torso3;
    public GameObject legs;
    public GameObject legs2;
    public GameObject legs3;

    public GameObject ownHead;
    public GameObject ownTorso;
    public GameObject ownLegs;

    private float Minimum = 0.8f;
    private float Maximum = 1.3f;

    public bool isDone = false;

    static float RandomFloat(float min, float max)
    {
        System.Random random = new();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }
    static int RandomInt(int min, int max)
    {
        System.Random random = new();
        int randomInt = random.Next(min, max);

        return randomInt;
    }
    private GameObject NewHead(int number)
    {
        return number switch
        {
            1 => head,
            2 => head2,
            3 => head3,
            _ => null,
        };
    }
    private GameObject NewTorso(int number)
    {
        return number switch
        {
            1 => torso,
            2 => torso2,
            3 => torso3,
            _ => null,
        };
    }
    private GameObject NewLegs(int number)
    {
        return number switch
        {
            1 => legs,
            2 => legs2,
            3 => legs3,
            _ => null,
        };
    }
    void Start()
    {
       Vector3 headPosition = ownHead.transform.position;
       Vector3 torsoPosition = ownTorso.transform.position;
       Vector3 legsPosition = ownLegs.transform.position;

       Quaternion headRotation = ownHead.transform.rotation;
       Quaternion torsoRotation = ownTorso.transform.rotation;
       Quaternion legsRotation = ownLegs.transform.rotation;

        if(headPosition != null && torsoPosition != null && legsPosition != null)
        {
            

            var newHead = Instantiate(NewHead(RandomInt(1, 4)), headPosition, headRotation);
            var newTorso = Instantiate(NewTorso(RandomInt(1, 4)), torsoPosition, torsoRotation);
            var newLegs = Instantiate(NewLegs(RandomInt(1, 4)), legsPosition, legsRotation);

            newHead.transform.parent = this.transform;
            newTorso.transform.parent = this.transform;
            newLegs.transform.parent = this.transform;

            transform.localScale = new Vector3(RandomFloat(Minimum, Maximum), RandomFloat(Minimum, Maximum), 1);

            if (newHead != null && newTorso != null && newLegs != null)
            {
                Destroy(ownHead);
                Destroy(ownTorso);
                Destroy(ownLegs);
                isDone = true;
            }
        }
    }

}
