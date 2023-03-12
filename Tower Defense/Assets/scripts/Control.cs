using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;

public class Control : MonoBehaviour
{

    public GameObject player;
    public int level = 0;
    public bool camLocked = false;
    public GameObject UI;
    public GameObject[] levelmarkers;
    public GameObject[] levels;
    private Animator ani;

    //define list of pixel fonts
    public Font[] fonts;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        UI.SetActive(true);

        //fix fonts to make it sharp
        for (int i = 0; i < fonts.Length; i++)
        {
            fonts[i].material.mainTexture.filterMode = FilterMode.Point;
        }


        ani.SetInteger("Level", level);
        ani.SetBool("CamLocked", camLocked);
    }

    // Update is called once per frame
    void Update()
    {
        if (level < levelmarkers.GetLength(0) && level < levels.GetLength(0))
        {
            if (player.transform.position.x > levelmarkers[level].transform.position.x)
            {
                camLocked = true;
                ani.SetBool("CamLocked", camLocked);

                levels[level].SetActive(true);

                levels[level].GetComponent<LevelControl>().Enable(true);
            }

            bool FortsAlive = false;

            foreach (GameObject fort in levels[level].GetComponent<LevelControl>().Forts)
            {
                if (fort.activeSelf)
                {
                    FortsAlive = true;
                }
            }



            if (FortsAlive == false && camLocked == true)
            {
                level += 1;
                camLocked = false;

                ani.SetInteger("Level", level);
                ani.SetBool("CamLocked", camLocked);
            }
        }
        else
        {
            Variables.ActiveScene.Get<GameObject>("UICanvas").GetComponent<Animator>().SetTrigger("FadeOutVictory");
        }
    }
}
