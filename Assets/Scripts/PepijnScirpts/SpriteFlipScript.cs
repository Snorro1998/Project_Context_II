using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipScript : MonoBehaviour
{
    Vector2 currentPosition = new Vector2();
    Vector2 lastPosition = new Vector2();
    Vector3 transformScale = new Vector3();
    Vector3 transformRight = new Vector2();
    Vector3 transformLeft = new Vector2();

    // Update is called once per frame
    private void Start()
    {
        //Last position setten zodat het niet bugged op de eerste frame.
        lastPosition = Vector2.zero;

        //De transformscale vinden en alvast de scales bepalen voor als ik de sprite wil flippen.
        transformScale = transform.localScale;
        transformLeft = transformScale;
        transformLeft.x = (transformScale.x * -1);
        transformRight = transformScale;
    }
    void Update()
    {
        //Currentposition setten.
        currentPosition = transform.position;

        //Check of hij niet stil staat.

        if (currentPosition != lastPosition)
        {
            //Check of hij naar rechts gaat.
            if (currentPosition.x < lastPosition.x)
            {
                transform.localScale = transformRight;
            }
            //Check of hij naar links gaat.
            else if(currentPosition.x > lastPosition.x)
            {
                transform.localScale = transformLeft;
            }
        }
        lastPosition = transform.position;
    }
}
