using CameraLogic;
using UnityEngine;
using Zenject;

namespace SceneContext
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camera;
        public override void InstallBindings()
        {
            CameraInstall();
        }

        private void CameraInstall()
        {
            Container
                .Bind<Camera>()
                .FromInstance(_camera)
                .AsSingle();

            CameraFollow cameraFollow = _camera.transform.GetComponent<CameraFollow>();
            
            Container
                .Bind<CameraFollow>()
                .FromInstance(cameraFollow)
                .AsSingle();
            
        }
    }
}