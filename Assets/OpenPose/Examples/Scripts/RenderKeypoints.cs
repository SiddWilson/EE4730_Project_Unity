using UnityEngine;
using UnityEngine.UI;

namespace OpenPose.Example
{
    /*
     * Visualize human data 2D for body, hand and face keypoints
     */
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

        // Update is called once per frame
        void Update()
        {
            if (Joint0 && Joint1)
            {
                if (isSprite)
                {
                    spriteAsset.enabled = Joint0.gameObject.activeInHierarchy && Joint1.gameObject.activeInHierarchy;
                    gameObject.transform.position = Joint0.transform.position;

                    gameObject.transform.rotation = Quaternion.FromToRotation(Joint0.transform.position, Joint1.transform.position);
                    //Vector3 scale = transform.localScale;
                    float spriteSize = spriteAsset.sprite.rect.width * imageScale / spriteAsset.sprite.pixelsPerUnit;
                    //scale.y = (Joint1.transform.localPosition.y - Joint0.transform.localPosition.y) / spriteSize;
                    //scale.z = (Joint1.transform.localPosition.z - Joint0.transform.localPosition.z) / spriteSize;
                    //transform.localScale = scale;

                    //float distance = Vector3.Distance(Joint0.transform.position, Joint1.transform.position);
                    //spriteAsset.rectTransform.sizeDelta = new Vector2(distance, distance);

                    Vector3 direction = (Joint1.transform.localPosition - Joint0.transform.localPosition).normalized;
                    transform.right = direction;
                    Vector3 scale = new Vector3(1, 1, 1);
                    //scale.y = Vector3.Distance(Joint0.transform.position, Joint1.transform.position) / spriteSize;
                    //scale.x = -Vector3.Distance(Joint0.transform.position, Joint1.transform.position) / spriteSize;

                    transform.localScale = scale;
                }
                else
                {
                    lineRenderer.enabled = Joint0.gameObject.activeInHierarchy && Joint1.gameObject.activeInHierarchy;
                    lineRenderer.SetPosition(0, Joint0.localPosition);
                    lineRenderer.SetPosition(1, Joint1.localPosition);
                }

            }
        }
    }
}
