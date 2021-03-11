using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Zorgt ervoor dat sprites op de juiste diepte getekend worden afhankelijk van de y-positie
/// </summary>
public class SpriteOrder : MonoBehaviour
{
    public SpriteRenderer boatSprite;
    public ParticleSystem[] frontParticleSystems;
    
    void Update()
    {
        var y = Mathf.FloorToInt((transform.position.y - 20) * 10);
        boatSprite.sortingOrder = -y;
        foreach (ParticleSystem p in frontParticleSystems)
        {
            p.GetComponent<Renderer>().sortingOrder = -(y - 1);
        }
    }
}
