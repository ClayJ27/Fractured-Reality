using UnityEngine;

public class FlipController : MonoBehaviour
{
    public bool flipped;
    private bool originalPosition;
    private bool mirroredPosition;

    private void Update()
    {
        if (!flipped) //Changes the selected material depending on if the player is in the inverted world or not
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
            transform.Rotate(new Vector2(0, 0));
            originalPosition = true;
            mirroredPosition = false;
        }
    }

    private void mirroredFlip()
    {
        if (!mirroredPosition)
        {
            transform.Rotate(new Vector2(0, 180));
            originalPosition = false;
            mirroredPosition = true;
        }
    }
}