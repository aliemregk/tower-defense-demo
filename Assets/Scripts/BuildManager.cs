using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private TurretBlueprint turretToBuild;
    private Platform selectedPlatform;
    public GameObject Turret;
    public GameObject Launcher;
    public GameObject Radar;
    public GameObject BuildEffect;
    public GameObject SellEffect;
    public Vector3 pos;

    public PlatformUI platformUI;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is more than one BuildManager.");
            return;
        }
        instance = this;
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        Deselect();
    }
    public void SelectPlatform(Platform platform)
    {
        if (selectedPlatform == platform)
        {
            Deselect();
            return;
        }

        selectedPlatform = platform;
        platformUI.SetTarget(platform);
    }
    public void Deselect()
    {
        selectedPlatform = null;
        platformUI.Hide();
    }
    public void DeselectTurret()
    {
        turretToBuild = null;
    }

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool EnoughMoney { get { return PlayerStats.money < turretToBuild.cost; } }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
} 