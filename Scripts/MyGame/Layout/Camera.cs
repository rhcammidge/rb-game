public static class Camera 
{

    static Vector2i cameraPos;

    /**
        Place camera
     */
    public static void placeCamera(Character mainCharacter, Map curMap)
    {
        /*
         * Character drags camera - no bueno?
         * 
        //  Figure out where the camera should be
        if ( mainCharacter.position.x - 16 < cameraPos.x ) {
            cameraPos.x = mainCharacter.position.x - 16;
        }
        if ( mainCharacter.position.x + 32 > cameraPos.x + RB.DisplaySize.width ) {
            cameraPos.x = mainCharacter.position.x - RB.DisplaySize.width + 32;
        }
        if ( mainCharacter.position.y - 16 < cameraPos.y ) {
            cameraPos.y = mainCharacter.position.y - 16;
        }
        if ( mainCharacter.position.y + 32 > cameraPos.y + RB.DisplaySize.height ) {
            cameraPos.y = mainCharacter.position.y - RB.DisplaySize.height + 32;
        }
        */
        cameraPos = mainCharacter.position - RB.DisplaySize / 2 + mainCharacter.size / 2;

        //  Clip camera to map
        if ( cameraPos.x + RB.DisplaySize.width > curMap.mapSize.width )
        {
            cameraPos.x = curMap.mapSize.width - RB.DisplaySize.width;
        }
        if (cameraPos.y + RB.DisplaySize.height > curMap.mapSize.height)
        {
            cameraPos.y = curMap.mapSize.height - RB.DisplaySize.height;
        }
        if (cameraPos.x < 0) cameraPos.x = 0;
        if (cameraPos.y < 0) cameraPos.y = 0;
        RB.CameraSet(cameraPos);
    }
}