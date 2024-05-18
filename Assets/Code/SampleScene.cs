namespace Assets.Code
{
    internal class SampleScene : UnityEngine.MonoBehaviour
    {
        private void Awake()
        {
            UnityEngine.QualitySettings.vSyncCount = 0;
            UnityEngine.Application.targetFrameRate = 30;

            
        }

        private void Update()
        {
            doProcess();
        }

        private void doProcess()
        {

        }
    }
}