using System.Collections.Generic;
using System.Linq;
using Assets.Plugins.Helpers;
using UnityEngine;

namespace Assets.Scripts.Grid
{
    public class EntityGrid
    {
        private GridItem[,] _items;
        private int _columnsCount;
        private int _rowsCount;

        public EntityGrid(int columnsCount, int rowsCount)
        {
            _columnsCount = columnsCount;
            _rowsCount = rowsCount;
            _items=new GridItem[columnsCount,rowsCount];
        }

        public void SetGridItem(int columnIndex,int rowIndex,GridItem item)
        {
            _items[columnIndex, rowIndex] = item;
        }

        public GridItem GetRandomElementByState(GridItemState state)
        {
            var gridItems = GetGridItemsByState(state);
            if (gridItems.Any())
            {
               return GetRandomElementFromCollection(gridItems);
            }
            return null;
        }

        private IEnumerable<GridItem> GetGridItemsByState(GridItemState state)
        {
			return ArrayExtensions.ToEnumerable<GridItem> (_items).Where(x => x.State== state);
        }

        private GridItem GetRandomElementFromCollection(IEnumerable<GridItem> items)
        {
            int randomPrefabPositionIndex = (int)Random.Range(0, items.Count());
            return items.ElementAt(randomPrefabPositionIndex);
        }

        public int ColumnsCount
        {
            get { return _columnsCount; }
        }

        public int RowsCount
        {
            get { return _rowsCount; }
        }
    }
}
