using BeautySalonBusinessLogic.OfficePackage.HelperEnums;
using BeautySalonBusinessLogic.OfficePackage.HelperModels;

namespace BeautySalonBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToExcelEmployee
    {
        /// Создание отчета
		public void CreateReport(ExcelInfoEmployee info)
        {
            CreateExcel(info);
            InsertCellInWorksheet(new ExcelCellParameters
            {
                ColumnName = "A",
                RowIndex = 1,
                Text = info.Title,
                StyleInfo = ExcelStyleInfoType.Title
            });
            MergeCells(new ExcelMergeParameters
            {
                CellFromName = "A1",
                CellToName = "C1"
            });
            uint rowIndex = 2;

            foreach (var cosmetic in info.PurchasesCosmetic)
            {
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    ColumnName = "A",
                    RowIndex = rowIndex,
                    Text = cosmetic.Date.ToString(),
                    StyleInfo = ExcelStyleInfoType.TextWithBroder
                });
                rowIndex++;

                foreach (var cosmetics in info.PurchasesCosmetic)
                {
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "B",
                        RowIndex = rowIndex,
                        Text = cosmetics.CosmeticName,
                        StyleInfo = ExcelStyleInfoType.TextWithBroder
                    });

                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "C",
                        RowIndex = rowIndex,
                        Text = cosmetics.Price.ToString(),
                        StyleInfo = ExcelStyleInfoType.TextWithBroder
                    });
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "D",
                        RowIndex = rowIndex,
                        Text = cosmetics.Count.ToString(),
                        StyleInfo = ExcelStyleInfoType.TextWithBroder
                    });
                    rowIndex++;
                }

                InsertCellInWorksheet(new ExcelCellParameters
                {
                    ColumnName = "A",
                    RowIndex = rowIndex,
                    Text = "Итого:",
                    StyleInfo = ExcelStyleInfoType.Text
                });

                InsertCellInWorksheet(new ExcelCellParameters
                {
                    ColumnName = "D",
                    RowIndex = rowIndex,
                    Text = cosmetic.TotalCost.ToString(),
                    StyleInfo = ExcelStyleInfoType.Text
                });
                rowIndex++;
            }
            SaveExcel(info);
        }

        // Создание excel-файла
        protected abstract void CreateExcel(ExcelInfoEmployee info);

        // Добавляем новую ячейку в лист
        protected abstract void InsertCellInWorksheet(ExcelCellParameters excelParams);

        // Объединение ячеек
        protected abstract void MergeCells(ExcelMergeParameters excelParams);

        // Сохранение файла
        protected abstract void SaveExcel(ExcelInfoEmployee info);
    }
}
