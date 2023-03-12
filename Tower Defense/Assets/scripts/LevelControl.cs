using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;

public class LevelControl : MonoBehaviour
{
    public GameObject[] Forts;
    public int FireMode;
    public float FireDelay;
    public float FireBreak;
    public int cycles;

    private bool Active = false;
    private float Timer;
    private List<GameObject> Units = new List<GameObject>();
    private int CurrentUnit;
    private int cycle = 0;

    void Start()
    {
        CurrentUnit = 0;
        foreach (GameObject fort in Forts)
        {
            foreach (GameObject enemy in fort.GetComponent<FortEnemiesArray>().Enemies)
            {
                Units.Add(enemy);
            }
        }
    }

    void Update()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            //reset timer
            Timer = FireDelay;

            //send attack event to units
            bool fired = false;
            while (fired == false && CurrentUnit < Units.Count && Active)
            {
                if (Units[CurrentUnit].transform.parent.gameObject.activeSelf)
                {
                    fired = true;
                }
                CustomEvent.Trigger(Units[CurrentUnit], "attack");
                CurrentUnit++;
            }
            if (CurrentUnit == Units.Count)
            {
                CurrentUnit = 0;
                cycle++;
            }

            if (cycle == cycles)
            {
                //reset timer
                Timer += (FireBreak * Random.Range(0.8f, 1.2f));
                cycle = 0;
            }


        }

    }

    public void Enable(bool mode)
    {
        Active = mode;
    }
}
