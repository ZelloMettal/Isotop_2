namespace Isotop2.Data
{
    //Класс строки в таблице на печать
    public class TableRows
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public TableRows(int row, int columns)
        {
            Rows = row;
            Columns = columns;
        }
    }
}
