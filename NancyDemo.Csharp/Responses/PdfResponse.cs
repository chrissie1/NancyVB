using System;
using System.IO;
using Nancy;
using ServiceStack.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace NancyDemo.Csharp.Responses
{
    public class PdfResponse<TModel> : Response
    {
        public PdfResponse(TModel model)
        {
            this.Contents = GetPdfContents(model);
            this.ContentType = "application/pdf";
            this.StatusCode = HttpStatusCode.OK;
        }

        protected virtual Action<Stream> GetPdfContents(TModel model)
        {
            return stream =>
                {
                    var oDoc = new Document(PageSize.A4,36,36,50,50);
                    var writer = PdfWriter.GetInstance(oDoc, stream);
                    writer.PageEvent = new MyPageEventHandler2();
                    oDoc.Open();
                    oDoc.Add(new Paragraph(model.Dump()));
                    oDoc.Close();
                    
                };
        }
    }

    public class PdfResponse : PdfResponse<object>
    {
        public PdfResponse(object model)
            : base(model)
        {
        }
    }

    public class MyPageEventHandler2 : PdfPageEventHelper
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
            _cb.SetFontAndSize(_bf, 8);
            _cb.SetRGBColorFill(100, 100, 100);
            _cb.SetTextMatrix(pageSize.GetLeft(40), pageSize.GetTop(30));
            _cb.ShowText("pdf created by nancy.");
            _cb.EndText();

            _cb.SetRGBColorStroke(100, 100, 100);
            _cb.SetLineWidth(0.1f);
            _cb.MoveTo(pageSize.GetLeft(40), pageSize.GetTop(document.TopMargin));
            _cb.LineTo(pageSize.GetRight(40), pageSize.GetTop(document.TopMargin));
            _cb.Stroke();
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

            _cb.SetRGBColorStroke(100, 100, 100);

            _cb.MoveTo(pageSize.GetLeft(40), document.BottomMargin);
            _cb.LineTo(pageSize.GetRight(40), document.BottomMargin);
            _cb.Stroke();
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