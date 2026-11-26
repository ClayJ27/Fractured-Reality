using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XPLevelHUD : MonoBehaviour
{

    [SerializeField] XPPickup XPPickup;

    int XPLevel;
    [SerializeField] TextMeshProUGUI LevelText;
    [SerializeField] Image XPBar;
    float XPBarFillAmount;
    [SerializeField] float XPBarSpeed;
    int TotalXP;
    int XPToLevelUp;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateXP();
    }

    // Update is called once per frame
    void Update()
    {
        XPBar.fillAmount = Mathf.Lerp(XPBar.fillAmount, XPBarFillAmount, XPBarSpeed * Time.deltaTime);
    }

    // Updates the XP UI when XP is collected in the XPPickup Script
    public void UpdateXP()
    {
        TotalXP = XPPickup.TotalXP; 
        XPToLevelUp = XPPickup.XPToLevelUP; 
        XPLevel = XPPickup.Level; 
        XPBarFillAmount = (float)TotalXP / XPToLevelUp; 
        LevelText.text = "Level: " + XPLevel.ToString();
    }
}
