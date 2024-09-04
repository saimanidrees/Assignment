using System.Collections.Generic;
using UnityEngine;
namespace GameData.MyScripts
{
    public class RandomIconPlacementStrategy : IIconPlacementStrategy
    {
        public List<IconData> GenerateIconPlacement(IconData[] availableIcons, int totalIcons)
        {
            var selectedIcons = new List<IconData>();
            var halfCount = totalIcons / 2;
            for (var i = 0; i < halfCount; i++)
            {
                var randomIndex = Random.Range(0, availableIcons.Length);
                
                selectedIcons.Add(availableIcons[randomIndex]);
                selectedIcons.Add(availableIcons[randomIndex]);
            }
            for (var i = 0; i < selectedIcons.Count; i++)
            {
                var randomIndex = Random.Range(0, selectedIcons.Count);
                (selectedIcons[i], selectedIcons[randomIndex]) = (selectedIcons[randomIndex], selectedIcons[i]);
            }
            return selectedIcons;
        }
    }
    public interface IIconPlacementStrategy
    {
        List<IconData> GenerateIconPlacement(IconData[] availableIcons, int totalIcons);
    }
}