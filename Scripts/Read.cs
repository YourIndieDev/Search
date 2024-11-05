using System.IO;
using UnityEditor;
using UnityEngine;

namespace Indie.Reveal
{
    public static class Read
    {
        /// <summary>
        /// Reads the content of a file by path within the Unity Project.
        /// </summary>
        /// <param name="filePath">The relative path of the file within the Assets folder (e.g., "Assets/Path/To/File.txt").</param>
        /// <returns>The content of the file as a string, or null if the file type is not supported or the file does not exist.</returns>
        public static string ReadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Debug.LogWarning($"File not found: {filePath}");
                return null;
            }

            string extension = Path.GetExtension(filePath).ToLower();

            // Ensure the file type is supported
            if (extension == ".cs" || extension == ".txt" || extension == ".json" || extension == ".md" ||  extension == ".xml" || extension == ".uss" || extension == ".css" || extension == ".py" || extension == ".html")
            {
                try
                {
                    return File.ReadAllText(filePath);
                }
                catch (IOException e)
                {
                    Debug.LogError($"Failed to read file at {filePath}. Error: {e.Message}");
                    return null;
                }
            }
            else
            {
                Debug.LogWarning($"Unsupported file extension: {extension}. Supports .cs, .txt, .json, .md, .xml, .uss, .css, .py, .html");
                return null;
            }
        }

        /// <summary>
        /// Finds and reads the content of the first file matching the provided name and extension in the Unity Project.
        /// </summary>
        /// <param name="fileName">The name of the file to search for (without extension).</param>
        /// <param name="extension">The extension of the file to search for (e.g., ".cs", ".txt").</param>
        /// <returns>The content of the file as a string, or null if the file is not found or the extension is unsupported.</returns>
        public static string ReadFilesByName(string fileName)
        {
            // Use AssetDatabase to locate the file in the project
            string[] guids = AssetDatabase.FindAssets($"{fileName} t:TextAsset");

            string content = "";
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                content += "\n\n" + ReadFile(path);
            }

            return content;
        }
    }
}
