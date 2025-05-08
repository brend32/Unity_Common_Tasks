using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ObjectPresenterGrid : MonoBehaviour
{
    public ObjectPresenter Presenter;
    public TextMeshProUGUI NumberPrefab;
    public VerticalLayoutGroup YAxis;
    public HorizontalLayoutGroup XAxis;
    public GridLayoutGroup Grid;
    
    public void Present(ObjectType[,] objects)
    {
        Grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        
        YAxis.spacing = Grid.spacing.y;
        XAxis.spacing = Grid.spacing.x;

        var amountX = objects.GetLength(0);
        var amountY = objects.GetLength(1);

        Grid.constraintCount = amountX;
        
        var rect = Grid.GetComponent<RectTransform>().rect;
        var cellSize = (rect.size - Grid.spacing * new Vector2(amountX - 1, amountY - 1)) / new Vector2(amountX, amountY);
        var min = Mathf.Min(cellSize.x, cellSize.y);
        Grid.cellSize = new Vector2(min, min);

        SpawnText(amountX, XAxis.transform, min, RectTransform.Axis.Horizontal);
        SpawnText(amountY, YAxis.transform, min, RectTransform.Axis.Vertical);

        var list = new List<ObjectType>();
        for (int y = 0; y < amountY; y++)
        {
            for (int x = 0; x < amountX; x++)
            {
                list.Add(objects[x, y]);
            }
        }

        Presenter.Present(list);
    }

    private void SpawnText(int amount, Transform container, float size, RectTransform.Axis axis)
    {
        Clear(container);
        
        for (int i = 0; i < amount; i++)
        {
            var text = Instantiate(NumberPrefab, container);
            text.text = i.ToString();
            var layoutElement = text.GetComponent<LayoutElement>();
            if (axis == RectTransform.Axis.Horizontal)
            {
                layoutElement.preferredWidth = size;
            }
            else
            {
                layoutElement.preferredHeight = size;
            }
        }
    }

    private void Clear(Transform container)
    {
        for (int i = 0; i < container.childCount; i++)
        {
            Destroy(container.GetChild(i).gameObject);
        }
    }
}
