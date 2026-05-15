using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Rectangle = iTextSharp.text.Rectangle;

namespace EVS
{
    public class RouteDocumentGenerator
    {
        static RouteDocumentGenerator()
        {
            // Регистрируем кодировки Windows (включая windows-1252) для .NET Core/5/6/7/8
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public void ExportToPDF(long requestId, string from, string to, string cargoName,
            string driverName, string truckInfo, string companyName, DateTime deliveryDate,
            string wishes, string receiverOrg, string receiverAddress, string receiverContact)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF файлы (*.pdf)|*.pdf";
                saveDialog.Title = "Сохранить маршрутный лист";
                saveDialog.FileName = $"Marshrutny_list_{requestId}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(saveDialog.FileName, FileMode.Create))
                    {
                        Document doc = new Document(PageSize.A4, 50, 50, 50, 50);
                        PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        // Загружаем шрифт с поддержкой кириллицы
                        iTextSharp.text.pdf.BaseFont baseFont = GetBaseFont();

                        // Создаём шрифты разных размеров (только черный цвет)
                        iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font normalFont = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL);
                        iTextSharp.text.Font boldFont = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font smallFont = new iTextSharp.text.Font(baseFont, 8, iTextSharp.text.Font.NORMAL);

                        // ШАПКА
                        Paragraph company = new Paragraph("ООО \"Столичная Логистика\"", titleFont);
                        company.Alignment = Element.ALIGN_CENTER;
                        doc.Add(company);

                        Paragraph companyInfo = new Paragraph("109431, город Москва, Привольная ул, д. 70 к. 1, помещ. 1/2", smallFont);
                        companyInfo.Alignment = Element.ALIGN_CENTER;
                        doc.Add(companyInfo);
                        doc.Add(new Paragraph(" "));

                        // Декоративная линия
                        Paragraph line = new Paragraph("═══════════════════════════════════════════════════════════════════════════════════════", smallFont);
                        line.Alignment = Element.ALIGN_CENTER;
                        doc.Add(line);
                        doc.Add(new Paragraph(" "));

                        // ЗАГОЛОВОК МАРШРУТНОГО ЛИСТА
                        Paragraph routeTitle = new Paragraph($"МАРШРУТНЫЙ ЛИСТ № {requestId}", headerFont);
                        routeTitle.Alignment = Element.ALIGN_CENTER;
                        doc.Add(routeTitle);

                        Paragraph routeDate = new Paragraph($"от {DateTime.Now:dd.MM.yyyy} г.", normalFont);
                        routeDate.Alignment = Element.ALIGN_CENTER;
                        doc.Add(routeDate);
                        doc.Add(new Paragraph(" "));

                        // ИНФОРМАЦИОННАЯ ТАБЛИЦА (без фона)
                        PdfPTable infoTable = new PdfPTable(2);
                        infoTable.WidthPercentage = 100;
                        infoTable.SetWidths(new float[] { 30f, 70f });

                        AddInfoRow(infoTable, "Компания-заказчик:", companyName, boldFont, normalFont);
                        AddInfoRow(infoTable, "Водитель:", driverName, boldFont, normalFont);
                        AddInfoRow(infoTable, "Транспортное средство:", truckInfo, boldFont, normalFont);
                        AddInfoRow(infoTable, "Дата подачи:", deliveryDate.ToString("dd.MM.yyyy"), boldFont, normalFont);
                        AddInfoRow(infoTable, "Наименование груза:", cargoName, boldFont, normalFont);

                        doc.Add(infoTable);
                        doc.Add(new Paragraph(" "));

                        // ТАБЛИЦА МАРШРУТА (без фона)
                        Paragraph routeHeader = new Paragraph("МАРШРУТ ДВИЖЕНИЯ", boldFont);
                        routeHeader.Alignment = Element.ALIGN_CENTER;
                        doc.Add(routeHeader);
                        doc.Add(new Paragraph(" "));

                        PdfPTable routeTable = new PdfPTable(5);
                        routeTable.WidthPercentage = 100;
                        routeTable.SetWidths(new float[] { 8f, 37f, 30f, 10f, 15f });

                        string[] headers = { "№", "Наименование организации / Адрес", "Цель прибытия", "Время", "Подпись" };
                        foreach (string header in headers)
                        {
                            PdfPCell headerCell = new PdfPCell(new Phrase(header, boldFont));
                            headerCell.Border = Rectangle.BOX;
                            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell.Padding = 8;
                            routeTable.AddCell(headerCell);
                        }

                        // Строка 1 – Погрузка
                        AddRouteRow(routeTable, "1", companyName, from, "Погрузка груза", "", normalFont);

                        // Строка 2 – Выгрузка
                        string receiverName = string.IsNullOrEmpty(receiverOrg) ? "Получатель" : receiverOrg;
                        AddRouteRow(routeTable, "2", receiverName, to, "Выгрузка груза", "", normalFont);

                        // Пустые строки (до 8-й)
                        for (int i = 3; i <= 8; i++)
                        {
                            AddRouteRow(routeTable, i.ToString(), "", "", "", "", normalFont);
                        }

                        doc.Add(routeTable);
                        doc.Add(new Paragraph(" "));

                        // ПОДПИСИ
                        PdfPTable signTable = new PdfPTable(2);
                        signTable.WidthPercentage = 100;
                        signTable.SetWidths(new float[] { 50f, 50f });
                        signTable.SpacingBefore = 20f;

                        PdfPCell dispatcherCell = new PdfPCell();
                        dispatcherCell.Border = Rectangle.NO_BORDER;
                        dispatcherCell.Padding = 5;
                        dispatcherCell.AddElement(new Paragraph("Диспетчер: __________________", normalFont));
                        signTable.AddCell(dispatcherCell);

                        PdfPCell driverCell = new PdfPCell();
                        driverCell.Border = Rectangle.NO_BORDER;
                        driverCell.Padding = 5;
                        driverCell.AddElement(new Paragraph($"Водитель: __________________\n({driverName})", normalFont));
                        signTable.AddCell(driverCell);

                        doc.Add(signTable);
                        doc.Add(new Paragraph(" "));

                        // ДАТА ВЫДАЧИ
                        Paragraph issueDate = new Paragraph($"Маршрутный лист выдан: {DateTime.Now:dd.MM.yyyy} г. в {DateTime.Now:HH:mm} ч.", smallFont);
                        issueDate.Alignment = Element.ALIGN_RIGHT;
                        doc.Add(issueDate);

                        doc.Close();
                    }

                    MessageBox.Show($"Маршрутный лист №{requestId} успешно сохранен!",
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
            // Пытаемся найти системный шрифт, поддерживающий кириллицу
            string[] possibleFonts = {
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arialuni.ttf"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "cour.ttf"),
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

            // Если ни одного шрифта не найдено, используем стандартный (лат.)
            return iTextSharp.text.pdf.BaseFont.CreateFont(
                iTextSharp.text.pdf.BaseFont.HELVETICA,
                iTextSharp.text.pdf.BaseFont.IDENTITY_H,
                iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);
        }

        private void AddInfoRow(PdfPTable table, string label, string value, iTextSharp.text.Font labelFont, iTextSharp.text.Font valueFont)
        {
            PdfPCell labelCell = new PdfPCell(new Phrase(label, labelFont));
            labelCell.Border = Rectangle.NO_BORDER;
            labelCell.Padding = 6;
            table.AddCell(labelCell);

            PdfPCell valueCell = new PdfPCell(new Phrase(value ?? "", valueFont));
            valueCell.Border = Rectangle.NO_BORDER;
            valueCell.Padding = 6;
            table.AddCell(valueCell);
        }

        private void AddInfoRowNoBg(PdfPTable table, string label, string value, iTextSharp.text.Font labelFont, iTextSharp.text.Font valueFont)
        {
            PdfPCell labelCell = new PdfPCell(new Phrase(label, labelFont));
            labelCell.Border = Rectangle.NO_BORDER;
            labelCell.Padding = 6;
            table.AddCell(labelCell);

            PdfPCell valueCell = new PdfPCell(new Phrase(value ?? "", valueFont));
            valueCell.Border = Rectangle.NO_BORDER;
            valueCell.Padding = 6;
            table.AddCell(valueCell);
        }

        private void AddRouteRow(PdfPTable table, string num, string orgName, string address,
            string purpose, string time, iTextSharp.text.Font font)
        {
            PdfPCell cellNum = new PdfPCell(new Phrase(num, font));
            cellNum.HorizontalAlignment = Element.ALIGN_CENTER;
            cellNum.Border = Rectangle.BOX;
            cellNum.Padding = 8;
            table.AddCell(cellNum);

            string text = "";
            if (!string.IsNullOrEmpty(orgName) && !string.IsNullOrEmpty(address))
                text = $"{orgName}\n{address}";
            else if (!string.IsNullOrEmpty(orgName))
                text = orgName;
            else if (!string.IsNullOrEmpty(address))
                text = address;
            else
                text = "_____________________________";

            PdfPCell cellOrg = new PdfPCell(new Phrase(text, font));
            cellOrg.Border = Rectangle.BOX;
            cellOrg.Padding = 8;
            table.AddCell(cellOrg);

            PdfPCell cellPurpose = new PdfPCell(new Phrase(purpose ?? "", font));
            cellPurpose.Border = Rectangle.BOX;
            cellPurpose.Padding = 8;
            table.AddCell(cellPurpose);

            PdfPCell cellTime = new PdfPCell(new Phrase(time ?? "", font));
            cellTime.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTime.Border = Rectangle.BOX;
            cellTime.Padding = 8;
            table.AddCell(cellTime);

            PdfPCell cellSign = new PdfPCell(new Phrase("_____________", font));
            cellSign.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSign.Border = Rectangle.BOX;
            cellSign.Padding = 8;
            table.AddCell(cellSign);
        }
    }
}