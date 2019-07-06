public static class Camera 
{

    static Vector2i cameraPos;

    /**
        Place camera
     */
    public static void placeCamera(Character mainCharacter)
    {
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
        RB.CameraSet(cameraPos);
    }
}