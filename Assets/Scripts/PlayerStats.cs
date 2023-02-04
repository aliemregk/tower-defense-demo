using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 400;

    public static int live;
    public int startLive = 5;

    // Start is called before the first frame update
    void Start()
    {
        money = startMoney;
        live = startLive;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
