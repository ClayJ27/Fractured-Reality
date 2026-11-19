using UnityEngine;

public class ObjectFlip : MonoBehaviour
{
    public bool flipped;
    private bool originalPosition;
    private bool mirroredPosition;
    public SpriteRenderer sprite;


    private void Update()
    {
        if (!flipped) //Flips the sprite direction when in the inverted world
        {
            originalFlip();
        }
        else
        {
            mirroredFlip();
        }
    }

    private void originalFlip()
    {
        if (!originalPosition)
        {
            sprite.flipX = false;
            originalPosition = true;
            mirroredPosition = false;
        }
    }

    private void mirroredFlip()
    {
        if (!mirroredPosition)
        {
            sprite.flipX = true;
            originalPosition = false;
            mirroredPosition = true;
        }
    }
}