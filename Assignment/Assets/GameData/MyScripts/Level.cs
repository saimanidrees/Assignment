using UnityEngine;
namespace GameData.MyScripts
{
    public class Level : MonoBehaviour
    {
        private void Start()
        {
            if (!LevelsHandler.IsPredefinedLevel())
            {
                for (var i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).GetComponent<Card>().SetIsNotClickAble(false);
                } 
                return;
            }
            SetPreviousProgress();
        }
        private void SetPreviousProgress()
        {
            var data = DataManager.Instance.GetData();
            if (data == null)
            {
                for (var i = 0; i < transform.childCount; i++)
                {
                    var card = transform.GetChild(i).GetComponent<Card>();
                    if(!card) continue;
                    card.SetIsNotClickAble(false);
                }
            }
            else
            {
                var count = 0;
                var cardIndex = 0;
                var limit = transform.childCount;
                for (var childIndex = 0; childIndex < limit; childIndex++)
                {
                    var card = transform.GetChild(childIndex).GetComponent<Card>();
                    if (!card) continue;
                    if (data.GetValue(cardIndex))
                    {
                        count++;
                        card.GetComponent<Card>().InvokeDisableCard(0f);
                        if (count == 2)
                        {
                            count = 0;
                            EventsManager.InvokeOnScoreIncreases();
                        }
                    }
                    else
                    {
                        card.SetIsNotClickAble(false);
                    }
                    cardIndex++;
                }
            }
        }
    }
}