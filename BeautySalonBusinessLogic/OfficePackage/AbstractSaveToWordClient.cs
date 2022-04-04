using BeautySalonBusinessLogic.OfficePackage.HelperEnums;
using BeautySalonBusinessLogic.OfficePackage.HelperModels;
using System.Collections.Generic;
using System.Linq;

namespace BeautySalonBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToWordClient
    {
        // Создание документа
        public void CreateDoc(WordInfoClient info)
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
            foreach (var procedure in info.DistributionProcedure)
            {
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> { ("Дата посещения " + procedure.Date.ToString(), new WordTextProperties {Bold = true, Size = "24"}),
                        ("Название процедуры" + procedure.ProcedureName, new WordTextProperties {Bold = false, Size = "24"}),
                        ("Стоимость " + procedure.Price.ToString(), new WordTextProperties {Bold = false, Size = "24"})},
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
        protected abstract void CreateWord(WordInfoClient info);
        
        // Создание абзаца с текстом
        protected abstract void CreateParagraph(WordParagraph paragraph);
        
        // Сохранение файла
        protected abstract void SaveWord(WordInfoClient info);
    }
}
