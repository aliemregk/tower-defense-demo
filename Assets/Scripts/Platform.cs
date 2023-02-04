using UnityEngine;
using UnityEngine.EventSystems;

public class Platform : MonoBehaviour
{
    public Color platformColor;
    private Renderer rend;
    private Color firstColor;
    public Vector3 pos;

    BuildManager buildManager;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint currentTurretBp;
    [HideInInspector]
    public bool IsUpgraded;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        firstColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetBuildPos()
    {
        return transform.position + pos; 
    }

    private void OnMouseDown()
    {
        if (!buildManager.CanBuild)
            return;
        
        if (turret != null)
        {
            buildManager.SelectPlatform(this);
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());
    }
    public void UpgradeTurret()
    {
        if (PlayerStats.money < currentTurretBp.upgradeCost)
        {
            Debug.Log("Not Enough Money To Upgrade");
            return;
        }

        if (IsUpgraded)
        {
            Debug.Log("Already Upgraded");
            return;
        }

        PlayerStats.money -= currentTurretBp.upgradeCost;
        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(currentTurretBp.upgradedPrefab, turret.transform.position, Quaternion.identity);
        turret = _turret;

        GameObject effect = Instantiate(buildManager.BuildEffect, turret.transform.position, Quaternion.identity);
        Destroy(effect, 5);

        IsUpgraded = true;
    }

    public void SellTurret()
    {
        Destroy(turret);
        turret = null;
        IsUpgraded = false;
        PlayerStats.money += currentTurretBp.sellPrice;

        GameObject effect = Instantiate(buildManager.SellEffect, GetBuildPos(), Quaternion.identity);
        Destroy(effect, 5);
    }

    void BuildTurret(TurretBlueprint turretbp)
    {
        if (PlayerStats.money < turretbp.cost)
        {
            Debug.Log("Not Enough Money");
            return;
        }
        PlayerStats.money -= turretbp.cost;

        GameObject _turret = (GameObject)Instantiate(turretbp.prefab, GetBuildPos() + buildManager.pos, Quaternion.identity);
        turret = _turret;

        currentTurretBp = turretbp;

        GameObject effect = Instantiate(buildManager.BuildEffect, GetBuildPos(), Quaternion.identity);
        Destroy(effect, 5);
    }

    void OnMouseEnter()
    { 
        if (!buildManager.CanBuild)
            return;

        if (buildManager.EnoughMoney || turret != null)
        {
            rend.material.color = Color.red;
            return;
        }

        rend.material.color = platformColor;
    }
    private void OnMouseExit()
    {
        rend.material.color = firstColor;
    }
}
