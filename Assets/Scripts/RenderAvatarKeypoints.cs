using UnityEngine;
using UnityEngine.UI;

namespace OpenPose.Example
{
    [RequireComponent(typeof(LineRenderer))]
    public class RenderAvatarKeypoints : MonoBehaviour
    {

        // Bone ends
        public RectTransform Joint0, Joint1;

        [SerializeField] Image spriteAsset;
        [SerializeField] float imageLocationScale = 0;
        [SerializeField] float imageScale = 1;
        [SerializeField] float imageScaleX = 1;
        [SerializeField] float imageScaleY = 1;

        private LineRenderer _lr;
        private LineRenderer lineRenderer { get { if (!_lr) _lr = GetComponent<LineRenderer>(); return _lr; } }

        // Update is called once per frame
        void Update()
        {
            if (Joint0 && Joint1)
            {
                    spriteAsset.enabled = Joint0.gameObject.activeInHierarchy && Joint1.gameObject.activeInHierarchy;
                    gameObject.transform.position = Vector3.Lerp(Joint0.transform.position, Joint1.transform.position, imageLocationScale) ;

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
                //scale.x = Vector3.Distance(Joint0.transform.position, Joint1.transform.position) / spriteSize;
                scale.x *= imageScaleX;
                scale.y *= imageScaleY;

                    transform.localScale = scale;
            }
        }
    }
}
