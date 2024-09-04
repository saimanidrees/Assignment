using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GameData.MyScripts
{
    public class ImageFactory : MonoBehaviour
    {
        public static GameObject CreateImage(string objectName, ImageData imageData, Vector2 size, Vector2 childIconSize)
        {
            var imageObject = new GameObject(objectName);
            var rectTransform = imageObject.AddComponent<RectTransform>();
            rectTransform.sizeDelta = size;
            var image = imageObject.AddComponent<Image>();
            image.sprite = imageData.mainSprite;
            CreateChildIcon(imageObject.transform, imageData.childSprites, childIconSize);
            return imageObject;
        }
        private static void CreateChildIcon(Transform parent, IReadOnlyList<Sprite> childSprites, Vector2 childIconSize)
        {
            var iconObject = new GameObject(Constants.ChildIconString);
            var iconRectTransform = iconObject.AddComponent<RectTransform>();
            iconRectTransform.SetParent(parent);
            var randomIndex = Random.Range(0, childSprites.Count);
            var iconImage = iconObject.AddComponent<Image>();
            iconImage.sprite = childSprites[randomIndex];
            var aspectRatio = iconImage.sprite.rect.width / iconImage.sprite.rect.height;
            iconRectTransform.sizeDelta = childIconSize.x / childIconSize.y > aspectRatio ? new Vector2(childIconSize.y * aspectRatio, childIconSize.y) : 
                new Vector2(childIconSize.x, childIconSize.x / aspectRatio);
            iconRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            iconRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            iconRectTransform.pivot = new Vector2(0.5f, 0.5f);
            iconRectTransform.anchoredPosition = Vector2.zero;
        }
    }
    [System.Serializable]
    public class ImageData
    {
        public Sprite mainSprite; // Main image sprite
        public Sprite[] childSprites; // Array of possible child icon sprites
        public ImageData(Sprite mainSprite, Sprite[] childSprites)
        {
            this.mainSprite = mainSprite;
            this.childSprites = childSprites;
        }
    }
}