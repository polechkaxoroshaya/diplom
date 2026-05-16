using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Rectangle = iTextSharp.text.Rectangle;

namespace EVS
{
    public class OrderPrintGenerator
    {
        static OrderPrintGenerator()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public void ExportOrderToPDF(long requestId, string from, string to, string cargoName,
            string driverName, string truckInfo, string companyName, DateTime deliveryDate,
            string wishes, string receiverOrg, string receiverAddress, string receiverContact,
            string contactPerson, string contactPhone, string weight, string volume,
            string places, string transportType, string payer,
            bool rearLoading, bool sideLoading, bool topLoading,
            bool mozhd, bool ttk, bool sadovoe)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF файлы (*.pdf)|*.pdf";
                saveDialog.Title = "Сохранить поручение экспедитору";
                saveDialog.FileName = $"Poruchenie_{requestId}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(saveDialog.FileName, FileMode.Create))
                    {
                        Document doc = new Document(PageSize.A4, 35, 35, 35, 35);
                        PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        iTextSharp.text.pdf.BaseFont baseFont = GetBaseFont();
                        // ВСЕ ШРИФТЫ ОБЫЧНЫЕ, БЕЗ BOLD
                        iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL);
                        iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL);
                        iTextSharp.text.Font normalFont = new iTextSharp.text.Font(baseFont, 9, iTextSharp.text.Font.NORMAL);
                        iTextSharp.text.Font smallFont = new iTextSharp.text.Font(baseFont, 7, iTextSharp.text.Font.NORMAL);

                        // ЗАГОЛОВОК
                        Paragraph docTitle = new Paragraph("ПОРУЧЕНИЕ ЭКСПЕДИТОРУ (Заявка)", titleFont);
                        docTitle.Alignment = Element.ALIGN_CENTER;
                        doc.Add(docTitle);
                        doc.Add(new Paragraph(" "));

                        // ШАПКА КОМПАНИИ
                        Paragraph company = new Paragraph("ООО \"Столичная Логистика\"", headerFont);
                        company.Alignment = Element.ALIGN_CENTER;
                        doc.Add(company);

                        Paragraph companyInfo = new Paragraph("109145, г. Москва, ул. Привольная, д.2, к.5 | Тел.: +7(495)740-40-80, +7(495)740-40-89", smallFont);
                        companyInfo.Alignment = Element.ALIGN_CENTER;
                        doc.Add(companyInfo);
                        doc.Add(new Paragraph(" "));

                        // Линия
                        Paragraph line = new Paragraph(new string('─', 85), smallFont);
                        line.Alignment = Element.ALIGN_CENTER;
                        doc.Add(line);
                        doc.Add(new Paragraph(" "));

                        // ========== ДАТА И ВРЕМЯ ДОСТАВКИ ИЗ ЗАЯВКИ ==========
                        PdfPTable dateTable = new PdfPTable(2);
                        dateTable.WidthPercentage = 100;
                        dateTable.SetWidths(new float[] { 25f, 25f });

                        AddDateCell(dateTable, "Дата доставки:", deliveryDate.ToString("dd.MM.yyyy"), normalFont, normalFont);
                        AddDateCell(dateTable, "Время доставки:", deliveryDate.ToString("HH:mm"), normalFont, normalFont);
                        doc.Add(dateTable);
                        doc.Add(new Paragraph(" "));

                        // ОТПРАВИТЕЛЬ
                        Paragraph senderTitle = new Paragraph("Отправитель:", normalFont);
                        doc.Add(senderTitle);

                        PdfPTable senderTable = new PdfPTable(2);
                        senderTable.WidthPercentage = 100;
                        senderTable.SetWidths(new float[] { 22f, 78f });

                        AddInfoRow(senderTable, "Организация:", companyName, normalFont, normalFont);
                        AddInfoRow(senderTable, "Адрес отправления:", from, normalFont, normalFont);
                        AddInfoRow(senderTable, "Контактное лицо:", contactPerson, normalFont, normalFont);
                        AddInfoRow(senderTable, "Телефон:", contactPhone, normalFont, normalFont);
                        AddInfoRow(senderTable, "Склад/Терминал:", from, normalFont, normalFont);

                        doc.Add(senderTable);
                        doc.Add(new Paragraph(" "));

                        // ========== ОПИСАНИЕ ГРУЗА (3 столбца: Наименование, Вес, Объём) ==========
                        Paragraph cargoTitle = new Paragraph("Описание груза", normalFont);
                        doc.Add(cargoTitle);
                        doc.Add(new Paragraph(" "));

                        // ИСПРАВЛЕНО: теперь 3 столбца вместо 4
                        PdfPTable cargoTable = new PdfPTable(3);
                        cargoTable.WidthPercentage = 100;
                        cargoTable.SetWidths(new float[] { 50f, 25f, 25f }); // Наименование шире, вес и объем по 25%

                        string[] cargoHeaders = { "Наименование груза", "Вес (кг)", "Объём (м³)" };
                        foreach (string header in cargoHeaders)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(header, normalFont));
                            cell.Border = Rectangle.BOX;
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.Padding = 4;
                            cargoTable.AddCell(cell);
                        }

                        // Добавляем данные (3 ячейки вместо 4)
                        cargoTable.AddCell(new PdfPCell(new Phrase(cargoName, normalFont)) { Border = Rectangle.BOX, Padding = 4 });
                        cargoTable.AddCell(new PdfPCell(new Phrase(weight ?? "0", normalFont)) { Border = Rectangle.BOX, Padding = 4, HorizontalAlignment = Element.ALIGN_CENTER });
                        cargoTable.AddCell(new PdfPCell(new Phrase(volume ?? "0", normalFont)) { Border = Rectangle.BOX, Padding = 4, HorizontalAlignment = Element.ALIGN_CENTER });

                        doc.Add(cargoTable);
                        doc.Add(new Paragraph(" "));

                        // ПАРАМЕТРЫ ГРУЗА
                        PdfPTable paramsTable = new PdfPTable(2);
                        paramsTable.WidthPercentage = 100;
                        paramsTable.SetWidths(new float[] { 50f, 50f });

                        PdfPCell leftCell = new PdfPCell();
                        leftCell.Border = Rectangle.NO_BORDER;
                        leftCell.Padding = 3;

                        // Создаем фразу с переносом строки
                        Phrase sizePhrase = new Phrase();
                        sizePhrase.Add(new Chunk("Размеры груза (м):\n", normalFont));  // \n - перенос строки
                        sizePhrase.Add(new Chunk("длина _____   ширина _____   высота _____", normalFont));

                        leftCell.AddElement(new Paragraph(sizePhrase));
                        leftCell.AddElement(new Paragraph(" ", normalFont)); // отступ

                        leftCell.AddElement(new Paragraph("Жесткой упаковки: да ( )   нет ( )", normalFont));
                        leftCell.AddElement(new Paragraph("Страховая стоимость (руб.): _______________", normalFont));
                        leftCell.AddElement(new Paragraph(" ", normalFont));
                        leftCell.AddElement(new Paragraph("Пожелания:", normalFont));
                        leftCell.AddElement(new Paragraph(wishes ?? "", normalFont));

                        string rearMark = rearLoading ? "(X)" : "( )";
                        string sideMark = sideLoading ? "(X)" : "( )";
                        string topMark = topLoading ? "(X)" : "( )";

                        string mozhdMark = mozhd ? "(X)" : "( )";
                        string ttkMark = ttk ? "(X)" : "( )";
                        string sadovoeMark = sadovoe ? "(X)" : "( )";

                        PdfPCell rightCell = new PdfPCell();
                        rightCell.Border = Rectangle.NO_BORDER;
                        rightCell.Padding = 3;
                        rightCell.AddElement(new Paragraph("Требуемый транспорт: " + (transportType ?? truckInfo), normalFont));
                        rightCell.AddElement(new Paragraph($"Тип загрузки: Задняя {rearMark}   Боковая {sideMark}   Верхняя {topMark}", normalFont));
                        rightCell.AddElement(new Paragraph($"Пропуска: МОЖД {mozhdMark}   ТТК {ttkMark}   Садовое кольцо {sadovoeMark}", normalFont));

                        paramsTable.AddCell(leftCell);
                        paramsTable.AddCell(rightCell);
                        doc.Add(paramsTable);
                        doc.Add(new Paragraph(" "));

                        // ПОЛУЧАТЕЛЬ
                        Paragraph receiverTitle = new Paragraph("Получатель", normalFont);
                        doc.Add(receiverTitle);
                        doc.Add(new Paragraph(" "));

                        PdfPTable receiverTable = new PdfPTable(2);
                        receiverTable.WidthPercentage = 100;
                        receiverTable.SetWidths(new float[] { 22f, 78f });

                        AddInfoRow(receiverTable, "Организация:", receiverOrg, normalFont, normalFont);
                        AddInfoRow(receiverTable, "Адрес доставки:", receiverAddress, normalFont, normalFont);
                        AddInfoRow(receiverTable, "Контактное лицо:", receiverContact, normalFont, normalFont);
                        AddInfoRow(receiverTable, "Телефон:", contactPhone, normalFont, normalFont);

                        doc.Add(receiverTable);
                        doc.Add(new Paragraph(" "));

                        // ПЛАТЕЛЬЩИК
                        Paragraph payerTitle = new Paragraph("Плательщик по данной заявке", normalFont);
                        doc.Add(payerTitle);
                        doc.Add(new Paragraph(" "));

                        PdfPTable payerTable = new PdfPTable(2);
                        payerTable.WidthPercentage = 100;
                        payerTable.SetWidths(new float[] { 22f, 78f });

                        AddInfoRow(payerTable, "Наименование юр. лица:", payer ?? companyName, normalFont, normalFont);

                        doc.Add(payerTable);
                        doc.Add(new Paragraph(" "));

                        // ПОДПИСИ
                        PdfPTable signTable = new PdfPTable(2);
                        signTable.WidthPercentage = 100;
                        signTable.SetWidths(new float[] { 50f, 50f });
                        signTable.SpacingBefore = 10f;

                        AddSignCell(signTable, "Отправитель:", "__________________", normalFont);
                        AddSignCell(signTable, "Экспедитор:", "__________________", normalFont);

                        doc.Add(signTable);
                        doc.Add(new Paragraph(" "));

                        // ДАТА ОФОРМЛЕНИЯ
                        Paragraph dateFooter = new Paragraph($"Дата оформления: {DateTime.Now:dd.MM.yyyy} г.", smallFont);
                        dateFooter.Alignment = Element.ALIGN_RIGHT;
                        doc.Add(dateFooter);

                        doc.Close();
                    }

                    MessageBox.Show($"Поручение экспедитору №{requestId} успешно сохранено!",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private iTextSharp.text.pdf.BaseFont GetBaseFont()
        {
            string[] possibleFonts = {
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "calibri.ttf")
            };

            foreach (string path in possibleFonts)
            {
                if (File.Exists(path))
                {
                    return iTextSharp.text.pdf.BaseFont.CreateFont(path,
                        iTextSharp.text.pdf.BaseFont.IDENTITY_H,
                        iTextSharp.text.pdf.BaseFont.EMBEDDED);
                }
            }

            return iTextSharp.text.pdf.BaseFont.CreateFont(
                iTextSharp.text.pdf.BaseFont.HELVETICA,
                iTextSharp.text.pdf.BaseFont.IDENTITY_H,
                iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);
        }

        private void AddInfoRow(PdfPTable table, string label, string value, iTextSharp.text.Font labelFont, iTextSharp.text.Font valueFont)
        {
            PdfPCell labelCell = new PdfPCell(new Phrase(label, labelFont));
            labelCell.Border = Rectangle.NO_BORDER;
            labelCell.Padding = 3;
            table.AddCell(labelCell);

            PdfPCell valueCell = new PdfPCell(new Phrase(value ?? "", valueFont));
            valueCell.Border = Rectangle.NO_BORDER;
            valueCell.Padding = 3;
            table.AddCell(valueCell);
        }

        private void AddDateCell(PdfPTable table, string label, string value, iTextSharp.text.Font labelFont, iTextSharp.text.Font valueFont)
        {
            PdfPCell labelCell = new PdfPCell(new Phrase(label, labelFont));
            labelCell.Border = Rectangle.NO_BORDER;
            labelCell.Padding = 3;
            table.AddCell(labelCell);

            PdfPCell valueCell = new PdfPCell(new Phrase(value, valueFont));
            valueCell.Border = Rectangle.NO_BORDER;
            valueCell.Padding = 3;
            table.AddCell(valueCell);
        }

        private void AddSignCell(PdfPTable table, string label, string sign, iTextSharp.text.Font font)
        {
            PdfPCell cell = new PdfPCell();
            cell.Border = Rectangle.NO_BORDER;
            cell.Padding = 5;
            cell.AddElement(new Paragraph($"{label} {sign}", font));
            table.AddCell(cell);
        }
    }
}