using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Changes the texture of an array of renderers
/// </summary>
public class ChangeShadersTexture : MonoBehaviour
{
    [SerializeField] private string _propertyName;
    [SerializeField] private Texture[] _textures;
    [SerializeField] private Renderer[] _renderers;

    /// <summary>
    /// Changes the textures of the renderers' material
    /// </summary>
    [ContextMenu("Change Textures")]
    public void ChangeTextures(int textureID = 0)
    {
        for (int i = 0; i < _renderers.Length; i++)
            _renderers[i].material.SetTexture(_propertyName, _textures[textureID]);
        
    }
}
