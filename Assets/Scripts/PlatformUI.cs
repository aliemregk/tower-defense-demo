using UnityEngine;
using UnityEngine.UI;

public class PlatformUI : MonoBehaviour
{
    private Platform target;
    public GameObject UI;

    public Text UpgradeCost;
    public Text SellPrice;
    public Button UpgradeButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetTarget(Platform _target)
    {
        this.target = _target;
        transform.position = target.GetBuildPos();

        if (!target.IsUpgraded)
        {
            UpgradeCost.text = "Upgrade -" + target.currentTurretBp.upgradeCost.ToString() + "$";
            UpgradeButton.interactable = true;
        }
        else
        {
            UpgradeCost.text = "Upgraded";
            UpgradeButton.interactable = false;
        }

        SellPrice.text = "Sell +" + target.currentTurretBp.sellPrice.ToString() + "$";

        UI.SetActive(true);
    }
    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.Deselect();
    }
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.Deselect();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10);
    }
}
