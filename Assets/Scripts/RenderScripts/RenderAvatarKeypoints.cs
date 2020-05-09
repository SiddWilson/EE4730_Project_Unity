using UnityEngine;
using UnityEngine.UI;

namespace OpenPose.Example
{
    public class RenderAvatarKeypoints : MonoBehaviour
    {
        // Bone ends
        public RectTransform Joint0, Joint1;

        [SerializeField] Image spriteAsset;
        [SerializeField] float imageLocationScale = 0;
        [SerializeField] float imageScale = 1;
        [SerializeField] float imageScaleX = 1;
        [SerializeField] float imageScaleY = 1;

        void Update()
        {
            if (Joint0 && Joint1)
            {
                    spriteAsset.enabled = Joint0.gameObject.activeInHierarchy && Joint1.gameObject.activeInHierarchy;
                    gameObject.transform.position = Vector3.Lerp(Joint0.transform.position, Joint1.transform.position, imageLocationScale) ;

                    gameObject.transform.rotation = Quaternion.FromToRotation(Joint0.transform.position, Joint1.transform.position);
                    float spriteSize = spriteAsset.sprite.rect.width * imageScale / spriteAsset.sprite.pixelsPerUnit;

                    Vector3 direction = (Joint1.transform.localPosition - Joint0.transform.localPosition).normalized;
                    transform.right = direction;
                    Vector3 scale = new Vector3(1, 1, 1);
                    scale.x *= imageScaleX;
                    scale.y *= imageScaleY;
                    transform.localScale = scale;
            }
        }
    }
}
