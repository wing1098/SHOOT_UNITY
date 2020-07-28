using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] private DoorAnims entryDoor;
    [SerializeField] private DoorAnims exitDoor;
    [SerializeField] private BattleSystem battleSystem;

    private void Start()
    {
        battleSystem.onBattleStarted += BattleSystem_OnBattleStarted;
        battleSystem.onBattleOver += BattleSystem_onBattleOver;
        entryDoor.OpenDoor();

    }

    private void BattleSystem_onBattleOver(object sender, System.EventArgs e)
    {
        exitDoor.OpenDoor();
    }

    private void BattleSystem_OnBattleStarted(object sender, System.EventArgs e)
    {
        entryDoor.CloseDoor();
    }
}
