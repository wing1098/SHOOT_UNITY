using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Net;
using System.Resources;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleSystem : MonoBehaviour
{
    public event EventHandler onBattleStarted;
    public event EventHandler onBattleOver;

    [SerializeField] private DoorAnims lastDoor;
    private enum State
    {
        Idle,
        Active,
        BattleOver,
    }

    [SerializeField] private BattleTrigger battleTrigger;

    [SerializeField] private Wave[] waveArray;

    private State state;

    private void Awake()
    {
        state = State.Idle;
    }

    private void Start()
    {
        battleTrigger.OnPlayerEnterTrigger += BattleTrigger_OnPlayerEnterTrigger;
    }

    private void BattleTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {
        if (state == State.Idle)
        {
            StartBattle();
            battleTrigger.OnPlayerEnterTrigger -= BattleTrigger_OnPlayerEnterTrigger;
        }
    }

    private void StartBattle()
    {
        Debug.Log("Start Battle");

        //enemyTransform.GetComponent<EnemyHealthManger>().Spawn();
        state = State.Active;

        onBattleStarted?.Invoke(this, EventArgs.Empty);
    }

    private void Update()
    {
        switch (state)
        {
            case State.Active:
                foreach (Wave wave in waveArray)
                {
                    wave.Update();
                }

                TestBattleOver();
                break;
        }

    }
    private void TestBattleOver()
    {
        if(state == State.Active)
        {
            if(AreWavesOver())
            {
                //Battle is over
                state = State.BattleOver;
                lastDoor.OpenDoor();
                
                Debug.Log("Battle Over");

                onBattleOver(this, EventArgs.Empty);
            }
        }
    }

    private bool AreWavesOver()
    {
        foreach (Wave wave in waveArray)
        {
            if (wave.IsWaveOver())
            {
                //Wave is over
            }
            else
            {
                //Wave is not over
                return false;
            }
        }
        return true;
    }

    //Represents a single enemy spawn wave
    [System.Serializable]
    private class Wave
    {
        [SerializeField] private EnemyHealthManger[] enemySpawnArrary;
        [SerializeField] private float timer;

        public void Update()
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    SpawnEnemies();
                }
            }
        }

        private void SpawnEnemies()
        {
            foreach (EnemyHealthManger enemySpawn in enemySpawnArrary)
            {
                enemySpawn.Spawn();
            }
        }

        public bool IsWaveOver()
        {
            if(timer < 0)
            {
                //Wave Spawned
                foreach(EnemyHealthManger enemySpawn in enemySpawnArrary)
                {
                    if(enemySpawn.IsAlive())
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                //Enemies have not spawned yet
                return false;
            }
        }
    }
}
