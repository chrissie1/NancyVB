using System;
using System.IO;
using Nancy;
using NancyDemo.Csharp.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace NancyDemo.Csharp.Responses
{
    public class TreeModelPdfResponse : Response
    {
        public TreeModelPdfResponse(TreeModel model)
        {
            this.Contents = GetPdfContents(model);
            this.ContentType = "application/pdf";
            this.StatusCode = HttpStatusCode.OK;
        }

        private Action<Stream> GetPdfContents(TreeModel model)
        {
            return stream =>
                {
                    using (var oDoc = new Document(PageSize.A4))
                    {
                        using (var writer = PdfWriter.GetInstance(oDoc, stream))
                        {
                            writer.PageEvent = new MyPageEventHandler();
                            oDoc.Open();
                            oDoc.Add(new Paragraph("This a Tree"));
                            oDoc.Add(new Paragraph("Id: " + model.Id));
                            oDoc.Add(new Paragraph("Genus: " + model.Genus));
                        }
                    }
                };
        }
    }

    class MyPageEventHandler : PdfPageEventHelper
    {

            PdfContentByte _cb;
            PdfTemplate _template;
            BaseFont _bf = null;
            DateTime _printTime = DateTime.Now;

            public override void OnOpenDocument(PdfWriter writer, Document document)
            {
                try
                {
                    _printTime = DateTime.Now;
                    _bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    _cb = writer.DirectContent;
                    _template = _cb.CreateTemplate(50, 50);
                }
                catch (DocumentException de)
                {
                }
                catch (System.IO.IOException ioe)
                {
                }
            }

            public override void OnStartPage(PdfWriter writer, Document document)
            {
                base.OnStartPage(writer, document);

                Rectangle pageSize = document.PageSize;

                _cb.BeginText();
                _cb.SetFontAndSize(_bf, 15);
                _cb.SetRGBColorFill(50, 50, 200);
                _cb.SetTextMatrix(pageSize.GetLeft(40), pageSize.GetTop(40));
                _cb.ShowText("Title");
                _cb.EndText();
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnEndPage(writer, document);

                int pageN = writer.PageNumber;
                String text = "Page " + pageN + " of ";
                float len = _bf.GetWidthPoint(text, 8);

                Rectangle pageSize = document.PageSize;

                _cb.SetRGBColorFill(100, 100, 100);

                _cb.BeginText();
                _cb.SetFontAndSize(_bf, 8);
                _cb.SetTextMatrix(pageSize.GetLeft(40), pageSize.GetBottom(30));
                _cb.ShowText(text);
                _cb.EndText();

                _cb.AddTemplate(_template, pageSize.GetLeft(40) + len, pageSize.GetBottom(30));

                _cb.BeginText();
                _cb.SetFontAndSize(_bf, 8);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT,
                    "Printed On " + _printTime.ToString(),
                    pageSize.GetRight(40),
                    pageSize.GetBottom(30), 0);
                _cb.EndText();
            }

            public override void OnCloseDocument(PdfWriter writer, Document document)
            {
                base.OnCloseDocument(writer, document);

                _template.BeginText();
                _template.SetFontAndSize(_bf, 8);
                _template.SetTextMatrix(0, 0);
                _template.ShowText("" + (writer.PageNumber - 1));
                _template.EndText();
            }

        }
}