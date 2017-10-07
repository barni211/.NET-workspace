using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace cwiczenie1_fabryka
{
    public class BasicTable<T> : ICloneable, ITable<T>
    {
        private static RangeType rangeType;
        private static TableType tableType;
        private static ITable<T> table;
        private static int start;
        private static int stop;
        private static BasicTable<T> basicTable = new BasicTable<T>();

        protected BasicTable()
        {

        }

        public static BasicTable<T> GetInstance()
        {
            return basicTable;
        }
        
        public void SetSource(TableType value)
        {
            tableType = value;
        }

        public object Clone()
        {
            return this;
        }

        public void CreateTableFromBegin(int size)
        {
            start = 0;
            stop = size - 1;
            rangeType = RangeType.FromBegin;
            CreateTable(size);
        }

        public void CreateTableFromRange(int begin, int end)
        {
            start = begin;
            stop = end;
            rangeType = RangeType.FromRange;
            CreateTable(end);
        }

        private void CreateTable(int size)
        {
            switch(tableType)
            {
                case TableType.ArrayTable:
                    table = new ArrayTable<T>(size);
                    break;
                case TableType.ListTable:
                    table = new ListTable<T>();
                    break;
            }
        }

        public void AddElement(T elem, int index)
        {
            if (ValidateRange(index))
            {
                table.AddElement(elem, index);
            }
            else
            {
                Debug.Print("Indeks wyszedł poza zakres struktury");
            }
        }
        public void RemoveElement(int index)
        {
            if (ValidateRange(index))
            {
                table.RemoveElement(index);
            }
            else
            {
                Debug.Print("Indeks wyszedł poza zakres struktury");
            }
        }

        private Boolean ValidateRange(int index)
        {
            if(rangeType == RangeType.FromBegin && index <= stop)
            {
                return true;
            }
            else if(rangeType == RangeType.FromRange && index <= stop && index >= start)
            {
                return true;
            }
            return false;
        }

        public void ShowElements()
        {
            table.ShowElements();
        }
    }
}
