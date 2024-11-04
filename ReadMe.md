The `Search` class in the `Indie.Reveal` namespace is a utility class designed to help developers programmatically locate, reveal, and focus on assets and GameObjects within the Unity Editor. This class simplifies the process of finding specific objects or assets by name and allows users to quickly bring them into view in the appropriate Unity editor window (Hierarchy, Project, or Scene view).

### Functions of the `Search` Class

The `Search` class contains several static methods, each with a specific purpose:

1. **`FindAssetsByName(string name)`**:
   - **Purpose**: Searches for assets in the Project window by their name.
   - **Functionality**: Uses `AssetDatabase.FindAssets` to locate all assets that match the specified name. For each found asset, it logs its path in the console.
   - **Use Case**: Allows developers to locate assets by name, which is useful for searching resources, textures, prefabs, or any other Unity assets in the Project view.

2. **`RevealGameObjectInHierarchy(string name)`**:
   - **Purpose**: Finds and highlights a GameObject in the Hierarchy view by name.
   - **Functionality**: Uses `GameObject.Find` to locate a GameObject with the specified name in the current scene. If found, it sets it as the active object in the `Selection`, which highlights it in the Hierarchy, and pings it to draw attention.
   - **Use Case**: Useful for quickly locating and focusing on specific GameObjects in the scene, making it easier to edit or review them.

3. **`RevealAssetInProject(string name)`**:
   - **Purpose**: Finds and highlights an asset in the Project view by name.
   - **Functionality**: Searches the Project window for assets that match the specified name using `AssetDatabase.FindAssets`. When an asset is found, it selects and pings it to bring it into focus in the Project view.
   - **Use Case**: Helps developers locate specific assets in the Project view without manually searching through folders, which is useful for assets with complex directory structures.

4. **`FrameObjectInSceneView(string name)`**:
   - **Purpose**: Frames a GameObject in the Scene view by name.
   - **Functionality**: Finds a GameObject with the specified name in the scene and uses `SceneView.Frame` to center and zoom in on it in the Scene view. It creates a small `Bounds` around the object’s position to achieve the framing.
   - **Use Case**: Helpful for quickly navigating the Scene view to a specific GameObject, especially in large scenes where locating objects manually can be time-consuming.

5. **`SelectAndFocusObject(string name)`**:
   - **Purpose**: Finds and focuses on an object or asset by name, allowing for selection in the Project or Hierarchy views.
   - **Functionality**: Similar to `FindAssetsByName`, this method retrieves all assets that match the specified name and logs their paths. It can be used to reveal objects within the editor, but it doesn’t include specific focus functionality in the current form (this might need additional functionality based on usage).
   - **Use Case**: Acts as a helper method to find and log the location of assets by name and can be extended to integrate with other methods for selection or framing.

### How to Use the `Search` Class

In the context of the **Object Focus & Reveal Tool** (`ObjectFocusRevealWindow`), the `Search` class functions serve as the core logic for revealing and focusing on assets and GameObjects. Here’s how each method would typically be used within this tool:

- **Revealing Assets in the Project or Hierarchy**: 
   - When a user enters an asset name and clicks the "Reveal in Editor" button, the `RevealAssetInProject` or `RevealGameObjectInHierarchy` method is called (depending on whether the user is searching in the Project or Hierarchy).
   - This immediately brings the specified asset or GameObject into focus, simplifying navigation.

- **Framing Objects in the Scene View**:
   - If the user wants to focus on a specific GameObject in the Scene, the "Frame in Scene View" button calls `FrameObjectInSceneView`. This zooms in on the GameObject, providing a centered view, which is particularly helpful in complex scenes.

- **Combined Selection and Focus**:
   - The "Select and Focus" button allows for combined functionality, where `SelectAndFocusObject` could be extended to select and bring an object into view, integrating features from `RevealAssetInProject` and `FrameObjectInSceneView` as needed.

### Summary

The `Search` class is a utility to streamline object and asset management in Unity, providing tools to locate, reveal, and focus on elements in the editor. By encapsulating this functionality, it enables a smooth and efficient workflow for tasks like asset management, scene navigation, and debugging. Using the `ObjectFocusRevealWindow`, developers can harness these features to improve productivity, especially in larger projects.
