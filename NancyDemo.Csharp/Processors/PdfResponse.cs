using System;
using System.IO;
using Nancy;
using NancyDemo.Csharp.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace NancyDemo.Csharp.Processors
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
                    var oDoc = new Document(PageSize.A4);
                    PdfWriter.GetInstance(oDoc, stream);
                    oDoc.Open();
                    foreach (var prop in model.GetType().GetProperties())
                    {
                        oDoc.Add(new Paragraph(prop.Name + ":" + prop.GetValue(model).ToString()));    
                    }
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
}