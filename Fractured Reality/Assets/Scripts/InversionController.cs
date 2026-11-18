using UnityEngine;

public class InversionController : MonoBehaviour
{
    public Material originalMaterial;
    public Material invertedMaterial;
    public bool inverted;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (!inverted) //Changes the selected material depending on if the player is in the inverted world or not
        {
            rend.sharedMaterial = originalMaterial;
        }
        else
        {
            rend.sharedMaterial = invertedMaterial;
        }
    }

}
