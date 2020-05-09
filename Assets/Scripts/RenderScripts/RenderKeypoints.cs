using UnityEngine;
using UnityEngine.UI;

namespace OpenPose.Example
{
    [RequireComponent(typeof(LineRenderer))]
    public class RenderKeypoints : MonoBehaviour
    {

        // Bone ends
        public RectTransform Joint0, Joint1;

        [SerializeField] bool isSprite;
        [SerializeField] Image spriteAsset;
        [SerializeField] float imageScale;

        private LineRenderer _lr;
        private LineRenderer lineRenderer { get { if (!_lr) _lr = GetComponent<LineRenderer>(); return _lr; } }

        void Update()
        {
            if (Joint0 && Joint1)
            {
                lineRenderer.enabled = Joint0.gameObject.activeInHierarchy && Joint1.gameObject.activeInHierarchy;
                lineRenderer.SetPosition(0, Joint0.localPosition);
                lineRenderer.SetPosition(1, Joint1.localPosition);
            }
        }
    }
}
