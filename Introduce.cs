using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduce : MonoBehaviour
{

    public int windowWidth = 400;
    public int windowHight = 150;

    // private
    Rect windowRect;
    int windowSwitch = 0;
    float alpha = 0;

    void GUIAlphaColor_0_To_1()
    {
        if (alpha < 1)
        {
            alpha += Time.deltaTime;
            GUI.color = new Color(1, 1, 1, alpha);
        }
    }

    // Init
    void Awake()
    {
        windowRect = new Rect(
            (Screen.width - windowWidth) / 2,
            (Screen.height - windowHight) / 2,
            windowWidth,
            windowHight);
    }

    void OnCollisionEnter(Collision other)
    {
        Time.timeScale = 0;
        windowSwitch = 1;
        alpha = 0; // Init Window Alpha Color
    }


    void OnGUI()
    {
        if (windowSwitch == 1)
        {
            GUIAlphaColor_0_To_1();
            windowRect = GUI.Window(0, windowRect, QuitWindow, "Quit Window");
        }
    }

    void QuitWindow(int windowID)
    {
        GUI.Label(new Rect(150, 75, 500, 300), "Space = Jump.\n\nYou can control the character's direction with: Up & Down & Left & Right.\n\nAny CUBE you see must be MONSTER, watch out!\n\nEvery time you touch somethimg in this world, you will get another JUMP opportunity.\n\nBasic to say, CUBE must be MONSTER, SPHERE must be NPC, RotateCUBE must be ITEM");

        if (GUI.Button(new Rect(650, 250, 100, 30), "Cancel"))
        {
            windowSwitch = 0;
            Time.timeScale = 1;
        } 

        GUI.DragWindow();
    }
}
