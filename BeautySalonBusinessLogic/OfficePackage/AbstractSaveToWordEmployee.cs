using BeautySalonBusinessLogic.OfficePackage.HelperEnums;
using BeautySalonBusinessLogic.OfficePackage.HelperModels;
using System.Collections.Generic;
using System.Linq;

namespace BeautySalonBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToWordEmployee
    {
        // Создание документа
        public void CreateDoc(WordInfoEmployee info)
        {
            CreateWord(info);
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24", }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });
            foreach (var cosmetic in info.PurchasesCosmetic)
            {
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> { ("Дата покупки " + cosmetic.Date.ToString(), new WordTextProperties {Bold = true, Size = "24"}),
                        ("Название косметики" + cosmetic.CosmeticName, new WordTextProperties {Bold = false, Size = "24"}),
                        ("Стоимость " + cosmetic.Price.ToString(), new WordTextProperties {Bold = false, Size = "24"}),
                        ("Количество " + cosmetic.Count.ToString(), new WordTextProperties { Bold = false, Size = "24" })},
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationType = WordJustificationType.Both
                    }
                });
            }
            SaveWord(info);
        }

        // Создание doc-файла
        protected abstract void CreateWord(WordInfoEmployee info);

        // Создание абзаца с текстом
        protected abstract void CreateParagraph(WordParagraph paragraph);

        // Сохранение файла
        protected abstract void SaveWord(WordInfoEmployee info);
    }
}
