using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class JumpBehaviour : MonoBehaviour
{
    private WaitForSeconds waitForSeconds;
    public Vector3 jump;
    public float jumpForce = 2.0f;

    Rigidbody rb;

    static float RandomFloat(float min, float max)
    {
        System.Random random = new();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }

    // Start is called before the first frame update
    void Start()
    {
        waitForSeconds = new(RandomFloat(3f, 8f));
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0f, 2f, 0f);

        StartCoroutine(JUMP());
    }

   private IEnumerator JUMP()
    {
        while(true)
        {
            yield return waitForSeconds;

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }
    }
}
