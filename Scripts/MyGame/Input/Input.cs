using System;
using UnityEngine;

public class Input
{

    public static Character checkCharacterInput(Map curMap, Character c)
    {
        Vector2i newPos = c.position;

        if (RB.KeyDown(KeyCode.W))
        {
            newPos.y -= 1;
        }

        if (RB.KeyDown(KeyCode.A))
        {
            newPos.x -= 1;
        }

        if (RB.KeyDown(KeyCode.S))
        {
            newPos.y += 1;
        }

        if (RB.KeyDown(KeyCode.D))
        {
            newPos.x += 1;
        }

        if (!curMap.isTileBlocked(newPos))
        {
            c.position = newPos;
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