using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCharacterFollow : MonoBehaviour
{
    public Transform character;  // Karakterin Transform'u
    public RectTransform miniMap;  // Harita UI Image bileşeni
    public RectTransform characterIcon;  // Karakter ikonu UI Image bileşeni

    // Haritanın dünya boyutları (inspectordan ayarlanabilir)
    public float worldMapWidth = 1000f;
    public float worldMapHeight = 1000f;

    // Mini-map'in ofset konumunu ayarlamak için (inspectordan ayarlanabilir)
    public Vector2 mapOffset = new Vector2(0f, 0f);

    void Update()
    {
        // Karakterin dünya konumunu al
        Vector3 charPos = character.position;

        // Karakterin dünya konumunu 0-1 arası normalize edin
        float normalizedX = (charPos.x + worldMapWidth * 0.5f) / worldMapWidth;
        float normalizedY = (charPos.z + worldMapHeight * 0.5f) / worldMapHeight;

        // Mini-map'in merkezine göre konum ayarları
        Vector2 miniMapSize = miniMap.sizeDelta;
        Vector2 halfMapSize = miniMapSize * 0.5f;

        // Offset'i dikkate alarak konum ayarlamaları
        float iconPosX = (normalizedX * miniMapSize.x) - halfMapSize.x + mapOffset.x;
        float iconPosY = (normalizedY * miniMapSize.y) - halfMapSize.y + mapOffset.y;

        // Karakter ikonunun mini-map üzerindeki konumunu ayarlayın
        characterIcon.anchoredPosition = new Vector2(iconPosX, iconPosY);
    }
}
