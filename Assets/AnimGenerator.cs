using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimGenerator : MonoBehaviour
{

    public RuntimeAnimatorController dance;
    public RuntimeAnimatorController dancedance;
    public RuntimeAnimatorController talkphone;

    static int RandomInt(int min, int max)
    {
        System.Random random = new();
        int randomInt = random.Next(min, max);

        return randomInt;
    }
   
    private RuntimeAnimatorController newController(int number)
    {
        return number switch
        {
            1 => dance,
            2 => dancedance,
            3 => talkphone,
            _ => null,
        };
    }
    void Start()
    {
        Animator animr = gameObject.AddComponent(typeof(Animator)) as Animator;
        animr.runtimeAnimatorController = newController(RandomInt(1, 4));
    }

    // Update is called once per frame
    
}
