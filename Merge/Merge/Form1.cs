using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OfficeOpenXml;

namespace ExcelFileRenamer
{
    public partial class Form1 : Form
    {
        private string selectedFolderPath;
        private string selectedMergeFolderPath;
        private string selectedReferenceFilePath;

        public Form1()
        {
            InitializeComponent();
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (var folderBrowser = new FolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    selectedFolderPath = folderBrowser.SelectedPath;
                    LoadExcelFiles();
                }
            }
        }

        private void LoadExcelFiles()
        {
            listBoxFiles.Items.Clear();

            var files = Directory.GetFiles(selectedFolderPath, "*.xlsx")
                                 .Select(Path.GetFileName)
                                 .ToList();

            listBoxFiles.Items.AddRange(files.ToArray());
        }

        private void btnRenameFiles_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFolderPath))
            {
                MessageBox.Show("폴더를 먼저 선택해주세요.");
                return;
            }

            var files = Directory.GetFiles(selectedFolderPath, "*.xlsx");

            foreach (var filePath in files)
            {
                var fileName = Path.GetFileName(filePath);
                var newFileName = RenameFile(fileName);

                if (newFileName != fileName)
                {
                    var newFilePath = Path.Combine(selectedFolderPath, newFileName);
                    File.Move(filePath, newFilePath);
                }
            }

            MessageBox.Show("파일명이 성공적으로 변경되었습니다.");
            LoadExcelFiles();
        }

        private string RenameFile(string fileName)
        {
            var extension = Path.GetExtension(fileName);
            var nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);

            var newName = nameWithoutExtension.Replace("+", "");

            var indexOfDash = newName.IndexOf('-');
            if (indexOfDash >= 0)
            {
                newName = newName.Substring(0, indexOfDash);
            }

            return newName.Trim() + extension;
        }

        private void btnSelectFolderForMerge_Click(object sender, EventArgs e)
        {
            using (var folderBrowser = new FolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    selectedMergeFolderPath = folderBrowser.SelectedPath;
                    LoadMergeFiles();
                }
            }
        }

        private void LoadMergeFiles()
        {
            listBoxMergeFiles.Items.Clear();

            var files = Directory.GetFiles(selectedMergeFolderPath, "*.xlsx")
                                 .Select(Path.GetFileName)
                                 .ToList();

            listBoxMergeFiles.Items.AddRange(files.ToArray());
        }

        private void btnSelectReferenceFile_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedReferenceFilePath = openFileDialog.FileName;
                    txtReferenceFile.Text = selectedReferenceFilePath;
                }
            }
        }

        private void btnMergeFiles_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMergeFolderPath))
            {
                MessageBox.Show("폴더를 먼저 선택해주세요.");
                return;
            }

            if (string.IsNullOrEmpty(selectedReferenceFilePath))
            {
                MessageBox.Show("참조 파일을 선택해주세요.");
                return;
            }

            var password = txtPassword.Text;

            var referenceData = LoadReferenceData(selectedReferenceFilePath);
            var files = Directory.GetFiles(selectedMergeFolderPath, "*.xlsx");
            using (var package = new ExcelPackage())
            {
                var sheet1 = package.Workbook.Worksheets.Add("Sheet1");

                sheet1.Cells[1, 1].Value = "라이더로그인ID";
                sheet1.Cells[1, 2].Value = "항목명";
                sheet1.Cells[1, 3].Value = "설명";
                sheet1.Cells[1, 4].Value = "금액";
                sheet1.Cells[1, 5].Value = "적용일자(yyyy-MM-dd)";

                int currentRow = 2;

                foreach (var filePath in files)
                {
                    using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
                    {
                        using (var excelPackage = new ExcelPackage(stream, password))
                        {
                            var sheet = excelPackage.Workbook.Worksheets[0];
                            int rowCount = sheet.Dimension.Rows;

                            for (int row = 2; row <= rowCount; row++)
                            {
                                var colG = sheet.Cells[row, 7].Text;
                                if (colG == "달성")
                                {
                                    var colB = sheet.Cells[row, 2].Text;
                                    var colD = sheet.Cells[row, 4].Text;
                                    var colC = Path.GetFileNameWithoutExtension(filePath).Replace(" ", "");
                                    sheet1.Cells[currentRow, 1].Value = colB;
                                    sheet1.Cells[currentRow, 2].Value = colD;
                                    sheet1.Cells[currentRow, 3].Value = colC;

                                    if (referenceData.ContainsKey(colC))
                                    {
                                        sheet1.Cells[currentRow, 4].Value = referenceData[colC].Item1;
                                        sheet1.Cells[currentRow, 5].Value = referenceData[colC].Item2;
                                    }

                                    currentRow++;
                                }
                            }
                        }
                    }
                }

                var sheet2 = package.Workbook.Worksheets.Add("Sheet2");

                for (int col = 1; col <= 5; col++)
                {
                    sheet2.Cells[1, col].Value = sheet1.Cells[1, col].Value;
                }

                for (int row = 2; row < currentRow; row++)
                {
                    var colE = sheet1.Cells[row, 5].Text;
                    var colD = sheet1.Cells[row, 4].Text;
                    sheet2.Cells[row, 3].Value = $"{colE}_배달미션_{colD}";
                }

                for (int row = 2; row < currentRow; row++)
                {
                    sheet2.Cells[row, 4].Value = sheet1.Cells[row, 2].Value;
                }

                for (int row = 2; row < currentRow; row++)
                {
                    sheet2.Cells[row, 2].Value = "기타-지급성(원천세적용)";
                }

                DateTime today = DateTime.Today;
                DateTime wednesday = today.AddDays(DayOfWeek.Wednesday - today.DayOfWeek);
                if (wednesday < today)
                    wednesday = wednesday.AddDays(7);

                string formattedWednesday = wednesday.ToString("yyyy-MM-dd");

                for (int row = 2; row < currentRow; row++)
                {
                    sheet2.Cells[row, 5].Value = formattedWednesday;
                }

                // Sheet1의 A열 데이터를 Sheet2의 A열로 복사
                for (int row = 1; row < currentRow; row++)
                {
                    sheet2.Cells[row, 1].Value = sheet1.Cells[row, 1].Value;
                }

                // Sheet1 삭제
                package.Workbook.Worksheets.Delete(sheet1);

                // Sheet2의 이름을 Sheet1으로 변경
                sheet2.Name = "Sheet1";

                // D열 데이터를 숫자로 변환하고 1000단위 콤마 형식 적용
                for (int row = 2; row <= sheet2.Dimension.End.Row; row++)
                {
                    if (decimal.TryParse(sheet2.Cells[row, 4].Text, out decimal value))
                    {
                        sheet2.Cells[row, 4].Value = value;
                        sheet2.Cells[row, 4].Style.Numberformat.Format = "#,##0";
                    }
                }

                // 셀 너비 자동 조절
                sheet2.Cells[sheet2.Dimension.Address].AutoFitColumns();

                var outputFilePath = Path.Combine(selectedMergeFolderPath, "정산 업로드.xlsx");
                package.SaveAs(new FileInfo(outputFilePath));
            }

            MessageBox.Show("파일이 성공적으로 합쳐졌습니다.");
        }

        private Dictionary<string, Tuple<string, string>> LoadReferenceData(string referenceFilePath)
        {
            var referenceData = new Dictionary<string, Tuple<string, string>>();

            using (var stream = new FileStream(referenceFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var excelPackage = new ExcelPackage(stream))
                {
                    var sheet = excelPackage.Workbook.Worksheets[0];
                    int rowCount = sheet.Dimension.Rows;

                    for (int row = 1; row <= rowCount; row++)
                    {
                        var key = sheet.Cells[row, 1].Text.Replace(" ", "");
                        var value1 = sheet.Cells[row, 2].Text;
                        var value2 = sheet.Cells[row, 3].Text;
                        if (!string.IsNullOrEmpty(key) && !referenceData.ContainsKey(key))
                        {
                            referenceData.Add(key, new Tuple<string, string>(value1, value2));
                        }
                    }
                }
            }

            return referenceData;
        }
    }
}