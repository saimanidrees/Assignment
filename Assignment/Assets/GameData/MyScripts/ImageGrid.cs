using UnityEngine;
using UnityEngine.UI;
namespace GameData.MyScripts
{
    public class ImageGrid : MonoBehaviour
    {
        [SerializeField] private LevelData currentLevel; // Choose grid or level setting in inspector
        [SerializeField] private ImageData imageData; // Assign the data in the Inspector
        public void CreateGridLayout(LevelData levelData)
        {
            currentLevel = levelData;
            var gridObject = new GameObject(Constants.CardsGridString);
            gridObject.transform.SetParent(this.transform);
            var gridRectTransform = gridObject.AddComponent<RectTransform>();
            gridRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            gridRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            gridRectTransform.pivot = new Vector2(0.5f, 0.5f);
            gridRectTransform.anchoredPosition = Vector2.zero;
            gridRectTransform.sizeDelta = new Vector2(currentLevel.columns * (currentLevel.imageSize.x + currentLevel.spacing) - currentLevel.spacing, 
                currentLevel.rows * (currentLevel.imageSize.y + currentLevel.spacing) - currentLevel.spacing);
            var gridLayout = gridObject.AddComponent<GridLayoutGroup>();
            gridLayout.cellSize = currentLevel.imageSize;
            gridLayout.spacing = new Vector2(currentLevel.spacing, currentLevel.spacing);
            gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            gridLayout.constraintCount = currentLevel.columns;
            IIconPlacementStrategy strategy = new RandomIconPlacementStrategy();
            var totalElements = currentLevel.rows * currentLevel.columns;
            var selectedIcons = strategy.GenerateIconPlacement(imageData.iconsInventory.iconsData, totalElements);
            for (var i = 0; i < totalElements; i++)
            {
                var imageName = Constants.CardImageString + i;
                var imageObject = ImageFactory.CreateCard(imageName, imageData.mainSprite, imageData.cardAnimatorController, selectedIcons[i], 
                    currentLevel.imageSize, currentLevel.childIconSize);
                imageObject.transform.SetParent(gridObject.transform, false);
            }
            gridObject.AddComponent<Level>();
        }
    }
}