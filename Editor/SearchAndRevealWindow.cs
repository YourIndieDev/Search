using UnityEditor;
using UnityEngine;

namespace Indie.Reveal
{
    public class ObjectFocusRevealWindow : EditorWindow
    {
        private string objectName = "Enter Object Name";
        private bool searchInAssets = false; // Toggle to search in assets or hierarchy

        [MenuItem("Tools/Indie/Search/Object Focus & Reveal Tool")]
        public static void ShowWindow()
        {
            GetWindow<ObjectFocusRevealWindow>("Focus & Reveal Tool");
        }

        private void OnGUI()
        {
            GUILayout.Label("Focus & Reveal Options", EditorStyles.boldLabel);

            // Toggle to select searching in Assets or Hierarchy
            searchInAssets = EditorGUILayout.Toggle("Search in Assets", searchInAssets);

            // Text field for entering the name of the object or asset
            objectName = EditorGUILayout.TextField("Object/Asset Name:", objectName);

            // Button to search and reveal the object
            if (GUILayout.Button("Reveal in Editor"))
            {
                if (searchInAssets)
                    Search.RevealAssetInProject(objectName); // Call from Search class
                else
                    Search.RevealGameObjectInHierarchy(objectName); // Call from Search class
            }

            // Button to frame the found object in Scene view
            if (GUILayout.Button("Frame in Scene View"))
            {
                Search.FrameObjectInSceneView(objectName); // Call from Search class
            }

            // Button to both select and focus the object
            if (GUILayout.Button("Select and Focus"))
            {
                Search.SelectAndFocusObject(objectName); // Call from Search class
            }
        }
    }
}
