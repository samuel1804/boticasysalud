using System.Collections.Generic;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace Pe.ByS.ERP.CrossCutting.Common
{
    public class GenericExcel
    {
        private readonly HSSFWorkbook _workBook;
        private readonly ISheet _sheet;

        public ISheet Sheet
        {
            get { return _sheet; }
        }

        public HSSFWorkbook WorkBook
        {
            get { return _workBook; }
        }

        public GenericExcel(Stream s, string nombreHoja)
        {
            _workBook = new HSSFWorkbook(s);
            _sheet = _workBook.GetSheet(nombreHoja);
        }

        public GenericExcel(string nombreHoja)
        {
            _workBook = new HSSFWorkbook();
            _sheet = _workBook.CreateSheet(nombreHoja);
        }

        #region Métodos Públicos

        public void NewRow(int rowNumber, Dictionary<int, int> cells)
        {
            IRow row = _sheet.CreateRow(rowNumber);
            foreach (var cell in cells)
            {
                row.CreateCell(cell.Key).SetCellValue(cell.Value);
            }
        }

        public void NewRowCellFormula(int rowNumber, int colNumber, string formula)
        {
            IRow row = _sheet.CreateRow(rowNumber);
            row.CreateCell(colNumber).SetCellFormula(formula);
        }

        public void AddCell(int rowNumber, int cellNumber, int cellValue)
        {
            _sheet.GetRow(rowNumber).CreateCell(cellNumber).SetCellValue(cellValue);
        }

        public void AddCell(int rowNumber, int cellNumber, string cellValue)
        {
            _sheet.GetRow(rowNumber).CreateCell(cellNumber).SetCellValue(cellValue);
        }

        public void ChangeCell(int rowNumber, Dictionary<int, string> cells)
        {
            IRow row = _sheet.GetRow(rowNumber);
            foreach (var cell in cells)
            {
                row.GetCell(cell.Key).SetCellValue(cell.Value);
            }
        }

        public void ChangeCell(int rowNumber, Dictionary<int, int> cells)
        {
            IRow row = _sheet.GetRow(rowNumber);
            foreach (var cell in cells)
            {
                row.GetCell(cell.Key).SetCellValue(cell.Value);
            }
        }

        public void ChangeCell(int rowNumber, Dictionary<int, int> cells, IConditionalFormattingRule[] cfRules)
        {
            IRow row = _sheet.GetRow(rowNumber);
            foreach (var cell in cells)
            {
                row.GetCell(cell.Key).SetCellValue(cell.Value);

                ISheetConditionalFormatting sheetCf = _sheet.SheetConditionalFormatting;
                CellRangeAddress[] regions =
                {
                    new CellRangeAddress(rowNumber, rowNumber, cell.Key, cell.Key)
                };

                sheetCf.AddConditionalFormatting(regions, cfRules);
            }
        }

        public void ChangeCell(int rowNumber, int cellNumber, string cellValue)
        {
            _sheet.GetRow(rowNumber).GetCell(cellNumber).SetCellValue(cellValue);
        }

        public void ChangeCell(int rowNumber, int cellNumber, string cellValue, ICellStyle style)
        {
            var cell = _sheet.GetRow(rowNumber).GetCell(cellNumber);
            cell.CellStyle = style;
            cell.SetCellValue(cellValue);
        }

        public void ChangeCell(int rowNumber, int cellNumber, int cellValue, ICellStyle style)
        {
            var cell = _sheet.GetRow(rowNumber).GetCell(cellNumber);
            cell.CellStyle = style;
            cell.SetCellValue(cellValue);
        }

        public void ChangeCell(int rowNumber, int cellNumber, int cellValue)
        {
            _sheet.GetRow(rowNumber).GetCell(cellNumber).SetCellValue(cellValue);
        }

        public void ChangeCell(int rowNumber, int cellNumber, double cellValue)
        {
            _sheet.GetRow(rowNumber).GetCell(cellNumber).SetCellValue(cellValue);
        }

        public void ChangeCellFormula(int rowNumber, int cellNumber, string formula)
        {
            _sheet.GetRow(rowNumber).GetCell(cellNumber).SetCellFormula(formula);
        }

        public void AddConditionalFormatting(int firstRow, int lastRow, int firstCol, int lastCol, IConditionalFormattingRule[] cfRules)
        {
            ISheetConditionalFormatting sheetCf = _sheet.SheetConditionalFormatting;
            CellRangeAddress[] regions =
            {
                new CellRangeAddress(firstRow, lastRow, firstCol, lastCol)
            };

            sheetCf.AddConditionalFormatting(regions, cfRules);
        }

        /// <summary>
        /// Permite insertar una fila nueva basada en una fila inicial hacia una posición destino
        /// </summary>
        /// <param name="sourceRowNum">Fila origen</param>
        /// <param name="destinationRowNum">Fila Destino</param>
        public void CopyRow(int sourceRowNum, int destinationRowNum)
        {
            // Get the source / new row
            IRow newRow = _sheet.GetRow(destinationRowNum);
            IRow sourceRow = _sheet.GetRow(sourceRowNum);

            // If the row exist in destination, push down all rows by 1 else create a new row
            if (newRow != null)
            {
                _sheet.ShiftRows(destinationRowNum, _sheet.LastRowNum, 1);
            }
            else
            {
                newRow = _sheet.CreateRow(destinationRowNum);
            }

            // Loop through source columns to add to new row
            for (int i = 0; i < sourceRow.LastCellNum; i++)
            {
                // Grab a copy of the old/new cell
                ICell oldCell = sourceRow.GetCell(i);
                ICell newCell = newRow.CreateCell(i);

                // If the old cell is null jump to next cell
                if (oldCell == null)
                {
                    continue;
                }

                CopyCell(oldCell, newCell);
            }

            // If there are are any merged regions in the source row, copy to new row
            for (int i = 0; i < _sheet.NumMergedRegions; i++)
            {
                CellRangeAddress cellRangeAddress = _sheet.GetMergedRegion(i);
                if (cellRangeAddress.FirstRow == sourceRow.RowNum)
                {
                    var newCellRangeAddress = new CellRangeAddress(newRow.RowNum,
                            (newRow.RowNum +
                                    (cellRangeAddress.LastRow - cellRangeAddress.FirstRow
                                            )),
                            cellRangeAddress.FirstColumn,
                            cellRangeAddress.LastColumn);
                    _sheet.AddMergedRegion(newCellRangeAddress);
                }
            }
        }

        public void CopyCell(int rowNumber, int sourceCellNum, int destinationCellNum)
        {
            IRow sourceRow = _sheet.GetRow(rowNumber);
            ICell sourceCell = sourceRow.GetCell(sourceCellNum);
            ICell newCell = sourceRow.CreateCell(destinationCellNum);

            CopyCell(sourceCell, newCell);
        }

        public void CopyCell(int rowNumber, int sourceCellNum, int destinationFirstCellNum, int destinationLastCellNum)
        {
            IRow sourceRow = _sheet.GetRow(rowNumber);
            ICell sourceCell = sourceRow.GetCell(sourceCellNum);

            for (int i = destinationFirstCellNum; i <= destinationLastCellNum; i++)
            {
                ICell newCell = sourceRow.CreateCell(i);
                CopyCell(sourceCell, newCell);
            }
        }

        public void RemoveRow(int rowNumber)
        {
            IRow removingRow = _sheet.GetRow(rowNumber);
            if (removingRow != null)
            {
                _sheet.RemoveRow(removingRow);
            }
        }

        public void RemoveCell(int rowNumber, int cellNumber)
        {
            IRow row = _sheet.GetRow(rowNumber);

            if (row != null)
            {
                ICell removingCell = row.GetCell(cellNumber);

                if (removingCell != null)
                    row.RemoveCell(removingCell);
            }
        }

        public void RemoveCells(int rowNumber, int firstCellNumber, int lastCellNumber)
        {
            IRow row = _sheet.GetRow(rowNumber);

            if (row != null)
            {
                for (int i = firstCellNumber; i <= lastCellNumber; i++)
                {
                    ICell removingCell = row.GetCell(i);

                    if (removingCell != null)
                        row.RemoveCell(removingCell);
                }
            }
        }

        public CellReference[] GetCells(string name)
        {
            var iName = _workBook.GetName(name);
            var area = new AreaReference(iName.RefersToFormula);

            return area.GetAllReferencedCells();
        }

        #endregion

        #region Métodos Privados

        private void CopyCell(ICell sourceCell, ICell destinationCell)
        {
            // Copy style from old cell and apply to new cell
            //ICellStyle newCellStyle = _workBook.CreateCellStyle();
            //newCellStyle.CloneStyleFrom(sourceCell.CellStyle);

            destinationCell.CellStyle = sourceCell.CellStyle;

            // If there is a cell comment, copy
            if (sourceCell.CellComment != null)
            {
                destinationCell.CellComment = sourceCell.CellComment;
            }

            // If there is a cell hyperlink, copy
            if (sourceCell.Hyperlink != null)
            {
                destinationCell.Hyperlink = sourceCell.Hyperlink;
            }

            // Set the cell data type
            destinationCell.SetCellType(sourceCell.CellType);

            // Set the cell data value
            switch (sourceCell.CellType)
            {
                case CellType.BLANK:
                    destinationCell.SetCellValue(sourceCell.StringCellValue);
                    break;
                case CellType.BOOLEAN:
                    destinationCell.SetCellValue(sourceCell.BooleanCellValue);
                    break;
                case CellType.ERROR:
                    destinationCell.SetCellErrorValue(sourceCell.ErrorCellValue);
                    break;
                case CellType.FORMULA:
                    destinationCell.SetCellFormula(sourceCell.CellFormula);
                    break;
                case CellType.NUMERIC:
                    destinationCell.SetCellValue(sourceCell.NumericCellValue);
                    break;
                case CellType.STRING:
                    destinationCell.SetCellValue(sourceCell.RichStringCellValue);
                    break;
            }
        }

        #endregion
    }
}