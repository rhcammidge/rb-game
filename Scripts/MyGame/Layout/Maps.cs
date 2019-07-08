using System;
using System.IO;

public class LayerMaps
{
    public LayerMap[] allMaps;

    
}

public class LayerMap
{    
    public string map_layer_name;
    public int layer;
    public string sprite_sheet;
}

public class Map
{
    private string mapName;
    public Vector2i mapSize;

    LayerMap[] mapLayers;

    public Map(string mapName)
    {
        this.mapName = mapName;
        loadMapFiles(mapName);
    }

    public void loadMapFiles(string mapName)
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

        foreach (LayerMap m in layerMaps.allMaps)
        {
            RB.MapLoadTMXLayer(map, m.map_layer_name, m.layer);
            RB.SpriteSheetSetup(m.layer, m.sprite_sheet, new Vector2i(32, 32));
            RB.MapLayerSpriteSheetSet(m.layer, m.layer);
        }


        // You can load a spritesheet here
        RB.SpriteSheetSetup(0, "MyGame/MySprites", new Vector2i(16, 16));
        RB.SpriteSheetSet(0);

        mapLayers = layerMaps.allMaps;
        mapSize = map.size * 32;
    }


    public void drawMap(Vector2i mapDrawPos)
    {
        foreach (LayerMap m in mapLayers)
        {
            RB.DrawMapLayer(m.layer, mapDrawPos);
        }
    }

    public bool isPointBlocked(Vector2i tilePos)
    {
        if (tilePos.x < 0 || tilePos.y < 0) return true;
        if (tilePos.x >= mapSize.width || tilePos.y >= mapSize.height) return true;
        tilePos /= 32;
        foreach (LayerMap m in mapLayers)
        {

            var tileProps = RB.MapDataGet<TMXProperties>(m.layer, tilePos);
            if (tileProps != null && tileProps.GetBool("blocked"))
            {
                return true;
            }
        }

        return false;
    }

    public bool isTileBlocked(Vector2i characterPos, Vector2i characterSize)
    {
        //  TL
        if (isPointBlocked(characterPos)) return true;
        //  TR
        if (isPointBlocked(new Vector2i(characterPos.x + characterSize.width, characterPos.y))) return true;
        //  BL
        if (isPointBlocked(new Vector2i(characterPos.x, characterPos.y + characterSize.height))) return true;
        //  BR
        if (isPointBlocked(new Vector2i(characterPos.x + characterSize.width, characterPos.y + characterSize.height))) return true;

        return false;
    }
}