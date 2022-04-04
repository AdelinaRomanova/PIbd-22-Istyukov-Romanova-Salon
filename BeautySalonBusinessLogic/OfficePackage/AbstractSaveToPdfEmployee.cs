using BeautySalonBusinessLogic.OfficePackage.HelperEnums;
using BeautySalonBusinessLogic.OfficePackage.HelperModels;
using System.Collections.Generic;
using System.Linq;

namespace BeautySalonBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToPdfEmployee
    {
        public void CreateDoc(PdfInfoEmployee info)
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
                Texts = new List<string> { "Дата выдачи косметики", "Косметика", "Количество", "Поручитель" },
                Style = "NormalTitle",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });
            foreach (var cosmetic in info.Cosmetics)
            {
                CreateRow(new PdfRowParameters
                {
                    Texts = new List<string> { cosmetic.DateOfService.ToShortDateString(), cosmetic.CosmeticName, cosmetic.Count.ToString(), cosmetic.TypeOfService },
                    Style = "Normal",
                    ParagraphAlignment = PdfParagraphAlignmentType.Left
                });
            }
            SavePdf(info);
        }

        // Создание doc-файла
        protected abstract void CreatePdf(PdfInfoEmployee info);

        // Создание параграфа с текстом
        protected abstract void CreateParagraph(PdfParagraph paragraph);

        // Создание таблицы
        protected abstract void CreateTable(List<string> columns);

        /// Создание и заполнение строки
        protected abstract void CreateRow(PdfRowParameters rowParameters);

        /// Сохранение файла
        protected abstract void SavePdf(PdfInfoEmployee info);
    }
}
