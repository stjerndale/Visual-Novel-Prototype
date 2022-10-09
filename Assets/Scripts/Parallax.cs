using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float startpos;
    private float startposy;
    public float parallaxEffect;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        startposy = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 mouse = cam.ScreenToWorldPoint(Input.mousePosition);

        mouse.x = Bounding(mouse.x, 3);
        mouse.y = Bounding(mouse.y, 1);

        float dist = -mouse.x * parallaxEffect;
        float disty = -mouse.y * parallaxEffect * 0.5f;

        transform.position = new Vector3(startpos + dist, startposy + disty, transform.position.z);
    }

    float Bounding(float input, float bound)
    {
        float output;
        output = input;
        if (input < -bound)
            output = -bound;
        else if (input > bound)
            output = bound;

        return output;
    }
}
