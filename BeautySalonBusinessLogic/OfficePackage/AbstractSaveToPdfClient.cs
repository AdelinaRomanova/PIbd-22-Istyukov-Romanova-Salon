using BeautySalonBusinessLogic.OfficePackage.HelperEnums;
using BeautySalonBusinessLogic.OfficePackage.HelperModels;
using System.Collections.Generic;
using System.Linq;

namespace BeautySalonBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToPdfClient
    {
        public void CreateDoc(PdfInfoClient info)
        {
            CreatePdf(info);
            CreateParagraph(new PdfParagraph
            {
                Text = info.Title,
                Style = "NormalTitle"
            });
            CreateParagraph(new PdfParagraph
            {
                Text = $"с { info.DateFrom.ToShortDateString() } по { info.DateTo.ToShortDateString() }",
                Style = "Normal"
            });
            CreateTable(new List<string> { "3cm", "3cm", "4cm", "3cm", "4cm" });
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "Тип услуги", "Дата оказания услуги", "Процедуры", "Цена", "Клиент" },
                Style = "NormalTitle",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });
            foreach (var procedure in info.Procedures)
            {
                CreateRow(new PdfRowParameters
                {
                    Texts = new List<string> { procedure.TypeOfService, procedure.DateOfService.ToShortDateString(), procedure.ProcedureName, procedure.Price.ToString() },
                    Style = "Normal",
                    ParagraphAlignment = PdfParagraphAlignmentType.Left
                });
            }
            SavePdf(info);
        }

        // Создание doc-файла
        protected abstract void CreatePdf(PdfInfoClient info);

        // Создание параграфа с текстом
        protected abstract void CreateParagraph(PdfParagraph paragraph);

        // Создание таблицы
        protected abstract void CreateTable(List<string> columns);

        /// Создание и заполнение строки
        protected abstract void CreateRow(PdfRowParameters rowParameters);

        /// Сохранение файла
        protected abstract void SavePdf(PdfInfoClient info);
    }
}
