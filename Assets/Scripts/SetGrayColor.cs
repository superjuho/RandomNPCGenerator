using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGrayColor : MonoBehaviour
{
    

    List<Material> startMaterials = new List<Material>();
    List<Color> startColors = new List<Color>();
    private bool materialsChanged = false;
    private bool materialsSaved = false;
    private bool colorisGray = false;
    private int grayCounter;
    
    IEnumerator WaitTwoSeconds()
    {
        var wait = new WaitForSeconds(2f);

        yield return wait;
        materialsChanged = true;
    }

    IEnumerator TickCounter()
    {
        var wait = new WaitForSeconds(1f);

        while (true)
        {
            yield return wait;
            grayCounter++;
            Debug.Log(grayCounter);
        }
        
    }

    void Start()
    {
        grayCounter = 0;
        StartCoroutine(WaitTwoSeconds());
        StartCoroutine(TickCounter());
    }
    void SaveMaterials()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            for (int l = 0; l < this.transform.GetChild(i).transform.childCount; l++)
            {
                Material[] childMaterials = this.transform.GetChild(i).transform.GetChild(l).GetComponent<Renderer>().materials;

                for (int m = 0; m < childMaterials.Length; m++)
                {
                    startMaterials.Add(childMaterials[m]);
                }
            }
        }

        Material[] materialArray = startMaterials.ToArray();
        
        for(int i = 0; i < materialArray.Length; i++)
        {
            startColors.Add(materialArray[i].color);
        }

        Color[] colorArray = startColors.ToArray();

        Debug.Log(materialArray[0].color);
        Debug.Log(colorArray[0]);
        
        materialsSaved = true;
    }

    void Update()
    {
       

       if(materialsChanged && !materialsSaved)
        {
            StopCoroutine(WaitTwoSeconds());
            SaveMaterials();
        }

       if(grayCounter > 5 && !colorisGray)
        {
            Debug.Log(grayCounter);
        }
    }
}
