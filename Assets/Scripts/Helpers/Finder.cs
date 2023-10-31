using UnityEngine;

namespace Helpers
{
    public static class Finder
    {
        public static Transform FindChildTransformRecursively(Transform parentTransform, string childName)
        {
            foreach (Transform childTransform in parentTransform)
            {
                if (childTransform.name == childName)
                {
                    return childTransform;
                }

                Transform result = FindChildTransformRecursively(childTransform, childName);
                if (result != null)
                {
                    return result;
                }
            }
            
            return null;
        }
    }
}