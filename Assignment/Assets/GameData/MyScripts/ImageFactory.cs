using UnityEngine;
using UnityEngine.UI;
namespace GameData.MyScripts
{
    public class ImageFactory : MonoBehaviour
    {
        public static GameObject CreateCard(string objectName, Sprite bgSprite, IconData iconData, Vector2 size, Vector2 childIconSize)
        {
            var imageObject = new GameObject(objectName);
            var rectTransform = imageObject.AddComponent<RectTransform>();
            rectTransform.sizeDelta = size;
            var image = imageObject.AddComponent<Image>();
            image.sprite = bgSprite;
            var btn = imageObject.AddComponent<Button>();
            var card = imageObject.AddComponent<Card>();
            CreateChildIcon(imageObject.transform, iconData, childIconSize);
            return imageObject;
        }
        private static void CreateChildIcon(Transform parent, IconData iconDataEntry, Vector2 childIconSize)
        {
            var iconObject = new GameObject(Constants.ChildIconString);
            var iconRectTransform = iconObject.AddComponent<RectTransform>();
            iconRectTransform.SetParent(parent);
            var iconImage = iconObject.AddComponent<Image>();
            iconImage.sprite = iconDataEntry.sprite;
            iconRectTransform.sizeDelta = childIconSize;
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
        public RuntimeAnimatorController cardAnimatorController; // Animator for card
        public IconsInventory iconsInventory; // Scriptable object holding icons data
        public ImageData(Sprite mainSprite, IconsInventory iconsInventory)
        {
            this.mainSprite = mainSprite;
            this.iconsInventory = iconsInventory;
        }
    }
}