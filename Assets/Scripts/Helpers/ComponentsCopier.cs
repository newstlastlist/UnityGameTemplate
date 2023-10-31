using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Helpers
{
#if UNITY_EDITOR
    public class ComponentsCopier
    {
        static Component[] copiedComponents;

        [MenuItem("GameObject/Copy all components %&C")]
        static void Copy()
        {
            if (Selection.activeGameObject == null)
                return;

            copiedComponents = Selection.activeGameObject.GetComponents<Component>();
        }

        [MenuItem("GameObject/Paste all components %&P")]
        static void Paste()
        {
            if (copiedComponents == null)
            {
                Debug.LogError("Nothing is copied!");
                return;
            }

            foreach (var targetGameObject in Selection.gameObjects)
            {
                if (!targetGameObject)
                    continue;

                Undo.RegisterCompleteObjectUndo(targetGameObject,
                    targetGameObject.name + ": Paste All Components"); // sadly does not record PasteComponentValues, i guess

                foreach (var copiedComponent in copiedComponents)
                {
                    if (!copiedComponent)
                        continue;

                    ComponentUtility.CopyComponent(copiedComponent);

                    var targetComponent = targetGameObject.GetComponent(copiedComponent.GetType());

                    if (targetComponent) // if gameObject already contains the component
                    {
                        if (ComponentUtility.PasteComponentValues(targetComponent))
                        {
                            Debug.Log("Successfully pasted: " + copiedComponent.GetType());
                        }
                        else
                        {
                            Debug.LogError("Failed to copy: " + copiedComponent.GetType());
                        }
                    }
                    else // if gameObject does not contain the component
                    {
                        if (ComponentUtility.PasteComponentAsNew(targetGameObject))
                        {
                            Debug.Log("Successfully pasted: " + copiedComponent.GetType());
                        }
                        else
                        {
                            Debug.LogError("Failed to copy: " + copiedComponent.GetType());
                        }
                    }
                }
            }

            copiedComponents = null; // to prevent wrong pastes in future
        }
    }
#endif
}