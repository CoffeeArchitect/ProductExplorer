
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using ProductExplorer.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProductExplorer.Services
{
    /// <summary>
    /// Класс хелпер для импорта данных из Excel
    /// </summary>
    public class ExcelImporter
    {
        /// <summary>
        /// Импортировать данные из Excel
        /// </summary>
        /// <param name="filePath">Путь до файла</param>
        /// <returns></returns>
        public List<Product> ImportFromExcel(string filePath)
        {
            List<Product> products = new List<Product>();

            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook workbook;
                    
                    if (Path.GetExtension(filePath) == ".xlsx")
                    {
                        workbook = new XSSFWorkbook(fs);
                    }
                    else
                    {
                        throw new Exception("Неподдерживаемый формат файла Excel.");
                    }

                    ISheet sheet = workbook.GetSheetAt(0);

                    for (int row = 1; row <= sheet.LastRowNum; row++)
                    {
                        IRow excelRow = sheet.GetRow(row);
                        if (excelRow != null)
                        {
                            Product product = new Product
                            {
                                Article = excelRow.GetCell(0)?.StringCellValue,
                                Name = excelRow.GetCell(1)?.StringCellValue,
                                Price = Convert.ToDecimal(excelRow.GetCell(2).NumericCellValue),
                                Quantity = Convert.ToInt32(excelRow.GetCell(3).NumericCellValue)
                            };

                            products.Add(product);
                        }
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
