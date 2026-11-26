using UnityEngine;

public class XPPickup : MonoBehaviour
{

    public float XPSpeed = 5f;
    public float XPRadius = 5;
    public float XPPickupRadius = 1;
    public int XPValue;
    public int TotalXP;
    public int XPToLevelUP;
    public int Level;
    public LayerMask Collectible;
    [SerializeField] XPLevelHUD XPLevelHUDScript;
    [SerializeField] GameObject LevelHUD;
    [SerializeField] GameObject LevelUpUI;

    // Update is called once per frame
    void Update()
    {
        CollectiblePickup();
    }

    public void CollectiblePickup()
    {
        Collider2D[] Collectibles = Physics2D.OverlapCircleAll(transform.position, XPRadius, Collectible); 

        for (int i = 0, length = Collectibles.Length; i < length; i++)
        {
            if (Collectibles[i] == null)
                continue; 
            Collectibles[i].transform.position = Vector2.MoveTowards(Collectibles[i].transform.position, transform.position, XPSpeed * Time.deltaTime);
        }

        Collider2D[] PickupColliders = Physics2D.OverlapCircleAll(transform.position, XPPickupRadius, Collectible); 
        for (int i = 0, length = PickupColliders.Length; i < length; i++)
        {
            if (PickupColliders[i] == null)
                continue; 
            if (PickupColliders[i].CompareTag("XP")) 
            {
                TotalXP = TotalXP + XPValue; 
                XPLevelHUDScript.UpdateXP(); 


                if (TotalXP >= XPToLevelUP)
                {
                    LevelUP();
                }
            }

            Destroy(PickupColliders[i].gameObject); 
        }
    }

    public void LevelUP()
    {
        if (TotalXP >= XPToLevelUP)
        {
            Level++;
            TotalXP = TotalXP - XPToLevelUP;
            XPToLevelUP = Mathf.CeilToInt(Level + 3) * Mathf.CeilToInt(Level + 3); 
            XPLevelHUDScript.UpdateXP(); 
            // UpgradeManager.LevelUp(); This is to be added
        }
    }

}
