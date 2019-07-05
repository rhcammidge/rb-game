using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// Your game! You can of course rename this class to whatever you'd like.
/// </summary>
public class MyGame : RB.IRetroBlitGame
{
    
    /// <summary>
    /// Query hardware. Here you initialize your retro game hardware.
    /// </summary>
    /// <returns>Hardware settings</returns>
    public RB.HardwareSettings QueryHardware()
    {
        var hw = new RB.HardwareSettings();

        // Set your display size
        hw.DisplaySize = new Vector2i(320, 180);

        // Set tilemap maximum size, default is 256, 256. Keep this close to your minimum required size to save on memory
        //// hw.MapSize = new Vector2i(256, 256);

        // Set tilemap maximum layers, default is 8. Keep this close to your minimum required size to save on memory
        //// hw.MapLayers = 8;

        return hw;
    }

    LayerMap[] mapLayers;
    
    public const string mapName = "map/testmap";
    /// <summary>
    /// Initialize your game here.
    /// </summary>
    /// <returns>Return true if successful</returns>
    public bool Initialize()
    {
        mapLayers = Map.loadMapFiles(mapName);        
        return true;
    }

    Character mainCharacter = new Character(0, 0);

    /// <summary>
    /// Update, your game logic should live here. Update is called at a fixed interval of 60 times per second.
    /// </summary>
    public void Update()
    {
        Input.checkSystemInput();
        Input.checkCharacterInput(mainCharacter);
    }

    /// <summary>
    /// Render, your drawing code should go here.
    /// </summary>
    public void Render()
    {
        RB.Clear(new Color32(127, 213, 221, 255));

        Vector2i mapDrawPos = new Vector2i();
        mapDrawPos.x = (int) (-(mainCharacter.positionX));
        mapDrawPos.y = (int) (-(mainCharacter.positionY));
        Map.drawMap(mapDrawPos, mapLayers);
 
        // Draw character
        var position = new Vector2i(mainCharacter.positionX - (RB.SpriteSize().width / 2), mainCharacter.positionY - (RB.SpriteSize().height/2));
        int spriteIndex = ((int)RB.Ticks / 20) % 2;

        // Draw character shadow
        //RB.DrawEllipseFill(position + new Vector2i(RB.SpriteSize().width / 2, RB.SpriteSize().height - 1), new Vector2i(6 + spriteIndex, 2), new Color32(54, 150, 104, 255));

        // Draw a sprite just below
        RB.DrawSprite(spriteIndex, position);
 
        // Print some more text
        /**RB.Print(
            new Rect2i(0, (RB.DisplaySize.height / 2) + 12, RB.DisplaySize.width, 64),
            new Color32(35, 101, 71, 255),
            RB.ALIGN_H_CENTER | RB.TEXT_OVERFLOW_WRAP,
            "Now it's @ffffff@w165your@w000@- time to shine!\n\nPlease enjoy@- @ffffffRetroBlit@-! I sincerely hope it inspires, and enables you\nto create the next great retro game!\n" +
            "\nIf you enjoyed @ffffffRetroBlit@-, and would like to continue supporting its development then please share your review on the @ffffffUnity Asset Store@-!" +
            "\n\nThank you!"); **/
    }
}
