using Word = Microsoft.Office.Interop.Word;

namespace Isotop2.Data
{
    internal class TableConstructor
    {
        Dictionary<Word.Table, TableRows> _rowList = new Dictionary<Word.Table, TableRows>(); //Словарь строк и их структуры
        //Добавление строки в список
        public void AddRow(Word.Table table, TableRows rows)
        {
            _rowList.Add(table, rows);
        }
        //Получение количества ячеек в таблице
        public int GetCountCells()
        {
            int cells = 0;
            foreach (var item in _rowList)
                cells += item.Value.Columns * item.Value.Rows;            
            return cells;
        }
        //Получение списка строк
        public Dictionary<Word.Table, TableRows> GetRowList()
        {
            return _rowList;
        }
    }
}

