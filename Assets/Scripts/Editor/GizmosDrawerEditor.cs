namespace MyEditor
{
    public class GizmosDrawerEditor
    {
        
    }
    // EXAMPLES
    // [CustomEditor(typeof(NPCSpawner))]
    // public class NPCSpawnerEditor : Editor
    // {
    //     [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
    //     public static void RenderCustomGizmo(NPCSpawner spawner, GizmoType gizmp)
    //     {
    //         GizmoHelper.DrawSphere(spawner.transform.position, 0.5f, Color.cyan);
    //     }
    // }
    // [CustomEditor(typeof(AbstractPutOutCargoTrigger))]
    // public class AbstractPutOutCargoTriggerEditor : Editor
    // {
    //     [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
    //     public static void RenderCustomGizmo(AbstractPutOutCargoTrigger putOutCargoTrigger, GizmoType gizmp)
    //     {
    //         GizmoHelper.DrawWireCube(putOutCargoTrigger.transform, putOutCargoTrigger.GetComponent<BoxCollider>(), Color.green);
    //     }
    // }
    // [CustomEditor(typeof(CargoPickUpTrigger))]
    // public class CargoPickUpTriggerEditor : Editor
    // {
    //     [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
    //     public static void RenderCustomGizmo(CargoPickUpTrigger pickUpTrigger, GizmoType gizmp)
    //     {
    //         GizmoHelper.DrawWireCube(pickUpTrigger.transform, pickUpTrigger.GetComponent<BoxCollider>(), Color.green);
    //     }
    // }
}