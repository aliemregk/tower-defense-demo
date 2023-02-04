using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standartTurret;
    public TurretBlueprint rocketLauncher;
    public TurretBlueprint radarTower;

    BuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectTurret()
    {
        buildManager.pos = Vector3.zero;
        buildManager.pos.x = -0.655f;
        buildManager.SelectTurretToBuild(standartTurret);
    }
    public void SelectRocketLauncher()
    {
        buildManager.pos = Vector3.zero;
        buildManager.SelectTurretToBuild(rocketLauncher);
    }
    public void SelectRadarTower()
    {
        buildManager.pos = Vector3.zero;
        buildManager.pos.y = 0.44f;
        buildManager.SelectTurretToBuild(radarTower);
    }
}
