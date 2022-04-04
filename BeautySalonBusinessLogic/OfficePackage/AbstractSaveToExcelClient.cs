using BeautySalonBusinessLogic.OfficePackage.HelperEnums;
using BeautySalonBusinessLogic.OfficePackage.HelperModels;

namespace BeautySalonBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToExcelClient
    {
		/// Создание отчета
		public void CreateReport(ExcelInfoClient info)
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

            foreach (var procedure in info.DistributionProcedure)
            {
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    ColumnName = "A",
                    RowIndex = rowIndex,
                    Text = procedure.Date.ToString(),
                    StyleInfo = ExcelStyleInfoType.TextWithBroder
                });
                rowIndex++;

                foreach (var procedures in info.DistributionProcedure)
                {
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "B",
                        RowIndex = rowIndex,
                        Text = procedures.ProcedureName,
                        StyleInfo = ExcelStyleInfoType.TextWithBroder
                    });

                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "C",
                        RowIndex = rowIndex,
                        Text = procedures.Price.ToString(),
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
                    ColumnName = "C",
                    RowIndex = rowIndex,
                    Text = procedure.TotalCost.ToString(),
                    StyleInfo = ExcelStyleInfoType.Text
                });
                rowIndex++;
            }
            SaveExcel(info);
		}

		// Создание excel-файла
		protected abstract void CreateExcel(ExcelInfoClient info);
		
		// Добавляем новую ячейку в лист
		protected abstract void InsertCellInWorksheet(ExcelCellParameters excelParams);
		
		// Объединение ячеек
		protected abstract void MergeCells(ExcelMergeParameters excelParams);
		
		// Сохранение файла
		protected abstract void SaveExcel(ExcelInfoClient info);
	}
}
