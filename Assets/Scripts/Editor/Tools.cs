using UnityEditor;
using UnityEngine;

namespace MyEditor
{
  public class Tools 
  {
    [MenuItem("Tools/ClearPrefs")]
    public static void ClearPrefs()
    {
      PlayerPrefs.DeleteAll();
      PlayerPrefs.Save();
    }
  }
}
