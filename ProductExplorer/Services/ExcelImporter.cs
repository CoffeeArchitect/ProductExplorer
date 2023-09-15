using OfficeOpenXml;
using ProductExplorer.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProductExplorer.Services
{
    public class ExcelImporter
    {
        public List<Product> ImportFromExcel(string filePath)
        {
            List<Product> products = new List<Product>();

            try
            {
                FileInfo fileInfo = new FileInfo(filePath);

                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        Product product = new Product
                        {
                            Article = worksheet.Cells[row, 4].Value?.ToString(),
                            Name = worksheet.Cells[row, 1].Value?.ToString(),
                            Price = Convert.ToDecimal(worksheet.Cells[row, 2].Value),
                            Quantity = Convert.ToInt32(worksheet.Cells[row, 3].Value),
                                                                                      
                        };

                        products.Add(product);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при импорте данных из Excel: " + ex.Message);
            }

            return products;
        }
    }
}
