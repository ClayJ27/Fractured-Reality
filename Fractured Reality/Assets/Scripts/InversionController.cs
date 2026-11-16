using UnityEngine;

public class InversionController : MonoBehaviour
{
    public Material effectMaterial;

    private Renderer rend;
    // might need to be an array if you need to support multiple material indicies on one object
    public Material originalMaterial;
    public bool inverted;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (!inverted)
        {
            rend.sharedMaterial = originalMaterial;
        }
        else
        {
            rend.sharedMaterial = effectMaterial;
        }
    }

}
