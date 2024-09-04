using UnityEngine;
using UnityEngine.UI;
namespace GameData.MyScripts
{
    public class ImageGrid : MonoBehaviour
    {
        [SerializeField] private ImageData imageData; // Assign the sprite in the Inspector
        [SerializeField] private int rows = 3; // Number of rows in the grid
        [SerializeField] private int columns = 3; // Number of columns in the grid
        [SerializeField] private Vector2 imageSize = new Vector2(100, 100); // Size of each image
        [SerializeField] private Vector2 childIconSize = new Vector2(20, 20); // Size of the child icon (width, height)
        [SerializeField] private float spacing = 10f; // Space between the images
        private ImageFactory _imageFactory;
        private void Start()
        {
            _imageFactory = gameObject.AddComponent<ImageFactory>();
            CreateGridLayout();
        }
        private void CreateGridLayout()
        {
            var gridObject = new GameObject(Constants.ImageGridString);
            gridObject.transform.SetParent(this.transform);
            var gridRectTransform = gridObject.AddComponent<RectTransform>();
            gridRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            gridRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            gridRectTransform.pivot = new Vector2(0.5f, 0.5f);
            gridRectTransform.anchoredPosition = Vector2.zero;
            gridRectTransform.sizeDelta = new Vector2(columns * (imageSize.x + spacing) - spacing, 
                rows * (imageSize.y + spacing) - spacing);
            var gridLayout = gridObject.AddComponent<GridLayoutGroup>();
            gridLayout.cellSize = imageSize;
            gridLayout.spacing = new Vector2(spacing, spacing);
            gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            gridLayout.constraintCount = columns;
            for (var i = 0; i < rows * columns; i++)
            {
                var imageName = Constants.ImageGridString + i;
                var imageObject = ImageFactory.CreateImage(imageName, imageData, imageSize, childIconSize);
                imageObject.transform.SetParent(gridObject.transform, false);
            }
        }
    }
}