﻿using DinkToPdf;
using DinkToPdf.Contracts;

namespace Employeedetails.Services
{
    public class PdfGenerator
    {
        private readonly IConverter _converter;
        public PdfGenerator(IConverter converter)
        {
            _converter = converter;
        }

        public byte[] GeneratorPdf(string htmlContent)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,   
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 30, Bottom = 20, Left = 5, Right = 5 },
                //DocumentTitle = "Generate PDF"
            };

            var objectSettings = new ObjectSettings
            {
                //PagesCount = true,
                HtmlContent = htmlContent,
                WebSettings = { DefaultEncoding = "utf-8" },
                //HeaderSettings = { FontSize = 12, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 },
                //FooterSettings = { FontSize = 12, Line = true, Right = "@" + DateTime.Now.Year }
            };

            var document = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            return _converter.Convert(document);
        }
    }
}
