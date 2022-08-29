using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFlashCardsGame
{
    public class TableVisualizer
    {
        public static void ShowTable<T>(List<T> tableData,[AllowNull]string tableName) where T: class
        {
            if(tableName == null)
            {
                tableName = "";
            }

            ConsoleTableBuilder.From(tableData).WithTitle(tableName).ExportAndWriteLine();

        }
    }
}
