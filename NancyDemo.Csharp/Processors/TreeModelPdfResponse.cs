using System;
using System.IO;
using Nancy;
using NancyDemo.Csharp.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace NancyDemo.Csharp.Processors
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
                    var oDoc = new Document(PageSize.A4);
                    PdfWriter.GetInstance(oDoc, stream);
                    oDoc.Open();
                    oDoc.Add(new Paragraph("This a Tree"));
                    oDoc.Add(new Paragraph("Id: " + model.Id));
                    oDoc.Add(new Paragraph("Genus: " + model.Genus));
                    oDoc.Close();
                };
        }
    }
}