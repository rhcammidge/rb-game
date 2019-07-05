using System;
using UnityEngine;

public class Input
{

    public static Character checkCharacterInput(Character c)
    {
        

        if (RB.KeyDown(KeyCode.W))
        {
            c.positionY -= 1;
        }

        if (RB.KeyDown(KeyCode.A))
        {
            c.positionX -= 1;
        }

        if (RB.KeyDown(KeyCode.S))
        {
            c.positionY += 1;
        }

        if (RB.KeyDown(KeyCode.D))
        {
            c.positionX += 1;
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