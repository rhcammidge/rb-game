using System;
using UnityEngine;

public class Input
{

    public static Character checkCharacterInput(Character c)
    {
        

        if (RB.KeyDown(KeyCode.W))
        {
            c.position.y -= 1;
        }

        if (RB.KeyDown(KeyCode.A))
        {
            c.position.x -= 1;
        }

        if (RB.KeyDown(KeyCode.S))
        {
            c.position.y += 1;
        }

        if (RB.KeyDown(KeyCode.D))
        {
            c.position.x += 1;
        }

        return c;
    }

    /**
     * Checks System Key Press
     */
    internal static void checkSystemInput()
    {
        if (RB.ButtonPressed(RB.BTN_SYSTEM))
        {
            Application.Quit();
        }
    }
}