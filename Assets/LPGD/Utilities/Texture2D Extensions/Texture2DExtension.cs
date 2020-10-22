using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Texture2DExtension
{
    static System.Text.StringBuilder m_StringBuilder = new System.Text.StringBuilder();
    static readonly char m_WindowsPathSeparator = '\\';

    public static Texture2D CreateAssetOutOfThisTexture(this Texture2D texture, string absolutePathToFolder, string name)
    {
#if UNITY_EDITOR
            m_StringBuilder.Clear();
            m_StringBuilder.Append(absolutePathToFolder);
            if (m_StringBuilder[m_StringBuilder.Length - 1] != m_WindowsPathSeparator)
                m_StringBuilder.Append(m_WindowsPathSeparator);
            m_StringBuilder.Append(name);
            m_StringBuilder.Append(".png");

            string path = m_StringBuilder.ToString();

            byte[] bytes = texture.EncodeToPNG();

            System.IO.FileStream stream = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
            System.IO.BinaryWriter writer = new System.IO.BinaryWriter(stream);
            for (int i = 0; i < bytes.Length; i++)
            {
                writer.Write(bytes[i]);
            }
            writer.Close();
            stream.Close();

            UnityEditor.AssetDatabase.Refresh();

            string relativePath = string.Empty;
            if (path.StartsWith(Application.dataPath))
            {
                relativePath = "Assets" + path.Substring(Application.dataPath.Length);
            }

            UnityEditor.AssetDatabase.ImportAsset(relativePath);
            var tex = (UnityEditor.TextureImporter)UnityEditor.TextureImporter.GetAtPath(relativePath);
            tex.isReadable = true;
            tex.SaveAndReimport();
            UnityEditor.AssetDatabase.Refresh();

            var textureAsset = UnityEditor.AssetDatabase.LoadAssetAtPath<Texture2D>(path);
            return textureAsset;
#endif
        Debug.LogWarning("Calling create texture asset not in the editor! Check the callstack an remove this call.");
        return texture;
    }
}