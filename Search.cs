using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace Indie.Reveal
{
    public class Search
    {
        // Finds assets by name.
        public static string[] FindAssetsByName(string name)
        {
            // Replace "MyAssetName" with the asset name you're looking for.
            string[] guids = AssetDatabase.FindAssets(name);
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                Debug.Log("Found asset by name at path: " + path);
            }
            return guids;
        }

        // Method to reveal a GameObject in the Hierarchy
        public static bool RevealGameObjectInHierarchy(string name)
        {
            GameObject targetObject = GameObject.Find(name);

            if (targetObject != null)
            {
                Selection.activeGameObject = targetObject;
                EditorGUIUtility.PingObject(targetObject);
                Debug.Log("Revealed GameObject in Hierarchy: " + name);

                return true;
            }
            else
            {
                Debug.LogWarning("GameObject not found in Hierarchy: " + name);

                return false;
            }
        }

        // Method to reveal an asset in the Project view
        public static bool RevealAssetInProject(string name)
        {
            // Searches for assets in the Project by name
            string[] guids = AssetDatabase.FindAssets(name);
            if (guids.Length > 0)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guids[0]);
                Object asset = AssetDatabase.LoadAssetAtPath<Object>(assetPath);

                Selection.activeObject = asset;
                EditorGUIUtility.PingObject(asset);
                Debug.Log("Revealed asset in Project view: " + assetPath);

                return true;
            }
            else
            {
                Debug.LogWarning("Asset not found in Project view: " + name);

                return false;
            }
        }

        // Method to frame a GameObject in the Scene view
        public static bool FrameObjectInSceneView(string name)
        {
            GameObject targetObject = GameObject.Find(name);

            if (targetObject != null)
            {
                Selection.activeGameObject = targetObject;

                // Create a small bounds around the object's position to frame it
                Bounds bounds = new Bounds(targetObject.transform.position, Vector3.one);
                SceneView.lastActiveSceneView.Frame(bounds);
                Debug.Log("Framed GameObject in Scene view: " + name);

                return true;
            }
            else
            {
                Debug.LogWarning("GameObject not found in Scene: " + name);

                return false;
            }
        }

        // Method to select and focus the object in the Scene view and Inspector
        public static string[] SelectAndFocusObject(string name)
        {
            // Replace "MyAssetName" with the asset name you're looking for.
            string[] guids = AssetDatabase.FindAssets(name);
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                Debug.Log("Found asset by name at path: " + path);
            }

            return guids;
        }
    }
}
