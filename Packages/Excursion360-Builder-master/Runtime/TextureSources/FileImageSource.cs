﻿using System.IO;
using System.Collections;
using UnityEditor;

#if UNITY_EDITOR
using UnityEngine;
#endif

public class FileImageSource : TextureSource
{
    public Texture texture = null;

    public override SourceType GetSourceType()
    {
        return SourceType.Image;
    }

    public override IEnumerator LoadTexture()
    {
        loadedTexture = texture;
        yield break;
    }

#if UNITY_EDITOR
    public override string Export(string destination, string stateName)
    {
        string path = AssetDatabase.GetAssetPath(texture);
        string filename = stateName + Path.GetExtension(path);

        File.Copy(path, Path.Combine(destination, filename));
        return filename;
    }
#endif
}
