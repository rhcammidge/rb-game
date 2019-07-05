using System;
using System.IO;

/**
    Load Map Resources (Layers and sprite sheets)
 */
public class Map
{   
    
    public static LayerMap[] loadMapFiles(string mapName)
    {
        Vector2i mapDestPos = new Vector2i(0, 0);
        Vector2i sourceChunkPos = new Vector2i(0, 0);
        // Load map
        var map = RB.MapLoadTMX(mapName); 
        string path = "Assets/RetroBlit/Resources/map/map-data.json";

        StreamReader reader = new StreamReader(path); 
        String rawmapdata = reader.ReadToEnd();
        reader.Close();
        // Load json map info and iterate through each object loading the layers from top to bottom //TODO
        LayerMaps layerMaps = Mapper.deserialize<LayerMaps>(rawmapdata);

        foreach(LayerMap m in layerMaps.allMaps)
        {
            RB.MapLoadTMXLayer(map, m.map_layer_name, m.layer);
            RB.SpriteSheetSetup(m.layer, m.sprite_sheet, new Vector2i(32, 32));
            RB.MapLayerSpriteSheetSet(m.layer, m.layer);
        }
        
        
        // You can load a spritesheet here
        RB.SpriteSheetSetup(0, "MyGame/MySprites", new Vector2i(16, 16));
        RB.SpriteSheetSet(0);

        return layerMaps.allMaps;

    }


    public static void drawMap(Vector2i mapDrawPos, LayerMap[] allMaps)
    {
        foreach(LayerMap m in allMaps)
        {
            RB.DrawMapLayer(m.layer, mapDrawPos);
        }
    }
}