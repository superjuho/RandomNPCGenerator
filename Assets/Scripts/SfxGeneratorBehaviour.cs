using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxGeneratorBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private WaitForSeconds waitForSeconds = new (15f);

    public AudioClip Vibrate;
    public AudioClip ManCough;
    public AudioClip Sneeze;
    public AudioClip WomanCough;
    
    void Start()
    {
        StartCoroutine(SFX());
    }

    static int RandomInt(int maximum)
    {
        System.Random random = new();
        int randomInt = random.Next(0, maximum);

        return randomInt;
    }
  
    private IEnumerator SFX()
    {
           while(true)
        {
            yield return waitForSeconds;
            
            if (RandomInt(100) > 50)
            {
                Vector3 location = this.transform.GetChild(RandomInt(this.transform.childCount)).position;
                AudioSource.PlayClipAtPoint(Clip(RandomInt(4)), location);
            }

        }
    }

    private AudioClip Clip(int number)
    {
        switch(number)
        {
            case 0:
                return Vibrate;

            case 1:
                return ManCough;

            case 2:
                return WomanCough;

            case 3:
                return Sneeze;

            default:
                Debug.Log("No!");
                return null;
        }

    }
}
