
// サブシステム1: PDFを変換するライブラリ
class PdfConverter
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="fileName"></param>
    public void ConvertPdfToText(string fileName)
    
    {
        var reader = new PdfReader();
        var res = reader.Read(fileName);
        Console.WriteLine($"Converting PDF to Text: {fileName}");
        // ここで出力
        Console.WriteLine(res[0]);
    }

    
    // using PdfSharp.Pdf;
    // using PdfSharp.Pdf.IO;
    // 参考： https://zenn.dev/masmgr/articles/f8557ade054b71
    // https://qiita.com/KazTag/items/c8a746baf2792ed47852
    /// <summary>
    ///  PdfConverterがTextを出力するために使用するClass
    /// </summary>
    private class PdfReader
    {
        /// <summary>
        /// PDFを読み込んでtextとbyteで返却する
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// このメソッドはPdfConverterからしか読んでほしくないと仮定して作成している。
        /// PdfReaderをprivateにすることでPdfConverter以外からは見えない。
        /// 外から見ればConvertPdfToTextだけ見えて入れば問題なし。
        public object[] Read(string filePath) {
            // using (var doc= PdfReader.Open(filePath, PdfDocumentOpenMode.ReadOnly)) {
            //     var text = new StringBuilder();
            //     foreach (var page in doc.Pages) {
            //         text.Append(page.ExtractText());
            //     }
            //     
            //     var bytes = new byte[doc.Stream.Length];
            //     return new object[] { text.ToString(), bytes };
            // }
        }
    }
}

// サブシステム2: Excelを変換するライブラリ
class ExcelConverter
{
    public void ConvertExcelToCsv(string fileName)
    {
        Console.WriteLine("Converting Excel to CSV: " + fileName);
    }
}

// Facadeクラス: サブシステムを単純化されたインターフェイスでラップする
class FileConverter
{
    private PdfConverter pdfConverter;
    private ExcelConverter excelConverter;

    public FileConverter()
    {
        pdfConverter = new PdfConverter();
        excelConverter = new ExcelConverter();
    }

    public void ConvertPdfToText(string fileName)
    {
        pdfConverter.ConvertPdfToText(fileName);
    }

    public void ConvertExcelToCsv(string fileName)
    {
        excelConverter.ConvertExcelToCsv(fileName);
    }
}

// クライアトコード: Facadeクラスを使用する
class Program
{
    static void Main(string[] args)
    {
        // fileConverter が APIを2つ公開している状態
        FileConverter fileConverter = new FileConverter();
        fileConverter.ConvertPdfToText("example.pdf");
        fileConverter.ConvertExcelToCsv("example.xlsx");


        // Facadeがない場合, 依存するクラスが増える。
        // PdfConverter pdfConverter = new PdfConverter();
        // FileConverter fileConverter = new FileConverter();
        // pdfConverter.ConvertPdfToText("example.pdf")
        // fileConverter.ConvertExcelToCsv("example.xlsx");
    }
}
