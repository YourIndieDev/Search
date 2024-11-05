using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace Indie.Reveal
{
    public static class Search
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
        public static GameObject RevealGameObjectInHierarchy(string name)
        {
            GameObject targetObject = GameObject.Find(name);

            if (targetObject != null)
            {
                Selection.activeGameObject = targetObject;
                EditorGUIUtility.PingObject(targetObject);
                Debug.Log("Revealed GameObject in Hierarchy: " + name);

                return targetObject;
            }
            else
            {
                Debug.LogWarning("GameObject not found in Hierarchy: " + name);

                return null;
            }
        }

        // Method to reveal an asset in the Project view
        public static string[] RevealAssetInProject(string name)
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

                return guids;
            }
            else
            {
                Debug.LogWarning("Asset not found in Project view: " + name);

                return null;
            }
        }

        // Method to frame a GameObject in the Scene view
        public static GameObject FrameObjectInSceneView(string name)
        {
            GameObject targetObject = GameObject.Find(name);

            if (targetObject != null)
            {
                Selection.activeGameObject = targetObject;

                // Create a small bounds around the object's position to frame it
                Bounds bounds = new Bounds(targetObject.transform.position, Vector3.one);
                SceneView.lastActiveSceneView.Frame(bounds);
                Debug.Log("Framed GameObject in Scene view: " + name);

                return targetObject;
            }
            else
            {
                Debug.LogWarning("GameObject not found in Scene: " + name);

                return null;
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
