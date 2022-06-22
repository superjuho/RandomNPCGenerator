using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRandomizer : MonoBehaviour
{
    public Material lightSkin;
    public Material tonedSkin;
    public Material darkSkin;
    public Material blackSkin;

    GameObject Head;
    GameObject Torso;
    GameObject Legs;

    Material[] torsoMaterials;
    Material[] legsMaterials;
    Material headMaterial;

    Color shirtColor;
    Material skinColor;
    Color pantsColor;
    Color randomColor;


    public MeshGenerator mG;
    private bool isDone = false;

    static int RandomInt(int min, int max)
    {
        System.Random random = new();
        int randomInt = random.Next(min, max);

        return randomInt;
    }

    private Color NewShirtColor()
    {
        return Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
    private Material NewSkinColor(int number)
    {
        return number switch {
            1 => lightSkin,
            2 => tonedSkin,
            3 => darkSkin,
            4 => blackSkin,
            _ => null,
        };
        
    }

    private Color NewPantsColor()
    {
        return Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    void Update()
    {
        if(isDone == false)
        {
             if (mG.isDone)
             {
                for(int i = 0; i < this.transform.childCount; i++)
                {
                    switch(this.transform.GetChild(i).tag)
                    {
                        case "Head":
                            Head = this.transform.GetChild(i).gameObject;
                            break;
                        case "Torso":
                            Torso = this.transform.GetChild(i).gameObject;
                            break;
                        case "Legs":
                            Legs = this.transform.GetChild(i).gameObject;
                            break;
                        default:
                            break;
                    }
                }

                headMaterial = Head.GetComponent<Renderer>().material;
                torsoMaterials = Torso.GetComponent<Renderer>().materials;
                legsMaterials = Legs.GetComponent<Renderer>().materials;
            
                skinColor = NewSkinColor(RandomInt(1, 5));
                pantsColor = NewPantsColor();
                shirtColor = NewShirtColor();

                headMaterial.color = skinColor.color;

                for (int i = 0; i < torsoMaterials.Length; i++)
                {
                    if(torsoMaterials[i].name.Contains("Skin"))
                    {
                        torsoMaterials[i].color = skinColor.color;
                    } else
                    {
                        torsoMaterials[i].color = NewShirtColor();
                    }
                }

                for(int i = 0; i < legsMaterials.Length; i++)
                {
                    legsMaterials[i].color = pantsColor;
                }
                
                
                isDone = true;
             }
        } else if (isDone)
        {
            Destroy(this.GetComponent<ColorRandomizer>());
            Destroy(this.GetComponent<MeshGenerator>());
        }
       
    }



    // Update is called once per frame

}
