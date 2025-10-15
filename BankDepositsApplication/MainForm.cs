using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankDepositsApplication.ActionsData;
using BankDepositsApplication.Models;
using NLog;

namespace BankDepositsApplication
{
    public partial class MainForm : Form
    {
        private Logger loggerMainForm = LogManager.GetCurrentClassLogger();
        private List<CurrencyModel> currencys = new List<CurrencyModel>();
        private List<BankDepModel> bankDeposits = new List<BankDepModel>();
        private CsvWorking csvWorking = new CsvWorking();
        public event Action<List<CurrencyModel>> CurrencyDataReady;
        private int retryCount = 0;
        private const int maxRetryes = 3;
        private bool addDep = false;
        private int indexRow = -1;
        private int colorDep = 0;
        private int countRedDep = 0;

        private readonly string csvDataTablePath =
            Path.Combine(Directory.GetCurrentDirectory(), "InformationTable.csv");

        public MainForm()
        {
            InitializeComponent();
            SettingsDataGrid();
            btnDelDep.Enabled = false;
            loggerMainForm.Info("Приложение запущено.");
        }

        #region Methods

        private void ColomnsDataGridAdded()
        {
            dgvPrintInfo.Columns.Add("Name", "Наименование банка");
            dgvPrintInfo.Columns.Add("Deposit", "Внесенная сумма");
            dgvPrintInfo.Columns.Add("Term", "Срок");
            dgvPrintInfo.Columns.Add("Bid", "Ставка");
            dgvPrintInfo.Columns.Add("TotalDeposit", "Итоговая сумма");
            dgvPrintInfo.Columns.Add("DateOpen", "Дата открытия вклада");
            dgvPrintInfo.Columns.Add("DateClose", "Дата закрытия вклада");
            loggerMainForm.Info($"Заголовки таблицы добавлены.");
        }

        private void SettingsDataGrid()
        {
            dgvPrintInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPrintInfo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPrintInfo.Font = new Font("Times New Roman", 12f);
            dgvPrintInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrintInfo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrintInfo.RowHeadersVisible = false;
            dgvPrintInfo.AllowUserToAddRows = false;
        }

        private void CheckValidateDeposits(int colorDeposit, int countRedDeposits)
        {
            if (countRedDeposits > 0)
            {
                MessageBox.Show($"У вас {countRedDeposits} не закрытых вкладов, срок которых уже истек.",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            /*DialogResult validateDepResult =
                MessageBox.Show($"У вас {countRedDeposits} не закрытых вкладов, срок которых уже истек.",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (validateDepResult == DialogResult.OK)
            {
                this.Focus();
                /*switch (colorDeposit)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default: break;
                }#1#
            }*/
        }

        private void RowsDataGridAdded(bool addDep)
        {
            try
            {
                if (addDep)
                {
                    foreach (var bankDep in bankDeposits)
                    {
                        var cellName = bankDep.Name;
                        var cellDeposit = $"{FormatNumberRows(bankDep.Deposit)} {bankDep.Currency}";
                        var cellTerm = $"{bankDep.Term} мес";
                        var cellBid = $"{bankDep.Bid} %";
                        var cellTotalDeposit = $"{FormatNumberRows(bankDep.TotalDeposit)} руб";
                        var cellDateOpen = bankDep.DateOpen.ToShortDateString();
                        var cellDateClose = bankDep.DateClose.ToShortDateString();
                        int rowIndex = dgvPrintInfo.Rows.Add(cellName, cellDeposit, cellTerm, cellBid, cellTotalDeposit,
                            cellDateOpen, cellDateClose);
                        DateTime targetDate = Convert.ToDateTime(cellDateClose);
                        DateTime dateToday = DateTime.Today;
                        CheckColorRows(targetDate, dateToday, rowIndex);
                    }

                    loggerMainForm.Info($"Строки таблицы добавлены.");
                    SortRowsData();
                    loggerMainForm.Info($"Строки таблицы отсортированы.");
                    csvWorking.Writer(csvDataTablePath, dgvPrintInfo);
                }
                else
                {
                    bankDeposits = csvWorking.Reader(csvDataTablePath, bankDeposits);
                    foreach (var bankDep in bankDeposits)
                    {
                        var cellName = bankDep.Name;
                        var cellDeposit = $"{FormatNumberRows(bankDep.Deposit)} {bankDep.CsvCurrency}";
                        var cellTerm = $"{bankDep.Term} мес";
                        var cellBid = $"{bankDep.Bid} %";
                        var cellTotalDeposit = $"{FormatNumberRows(bankDep.TotalDeposit)} руб";
                        var cellDateOpen = bankDep.DateOpen.ToShortDateString();
                        var cellDateClose = bankDep.DateClose.ToShortDateString();
                        int rowIndex = dgvPrintInfo.Rows.Add(cellName, cellDeposit, cellTerm, cellBid, cellTotalDeposit,
                            cellDateOpen, cellDateClose);
                        switch (bankDep.ColorRows)
                        {
                            case "R":
                                dgvPrintInfo.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                                colorDep = (int)VariableColor.R;
                                countRedDep++;
                                break;
                            case "Y":
                                dgvPrintInfo.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                                colorDep = (int)VariableColor.Y;
                                break;
                            case "G":
                                dgvPrintInfo.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Green;
                                colorDep = (int)VariableColor.G;
                                break;
                            default:
                                dgvPrintInfo.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                                loggerMainForm.Error($"Цвет не задан для строки {bankDep.Name}");
                                break;
                        }
                    }

                    Thread threadWriter = new Thread(() => { csvWorking.Writer(csvDataTablePath, dgvPrintInfo); });
                    threadWriter.Start();
                    SortRowsData();
                }
            }
            catch (Exception ex)
            {
                loggerMainForm.Error($"{ex.Message}");
            }
        }

        private void SortRowsData()
        {
            foreach (DataGridViewRow row in dgvPrintInfo.Rows)
            {
                if (!row.IsNewRow && row.Cells["DateClose"].Value != null)
                {
                    if (DateTime.TryParse(row.Cells["DateClose"].Value.ToString(), out DateTime dateValue))
                    {
                        row.Cells["DateClose"].Value = dateValue;
                    }
                }
            }

            dgvPrintInfo.Columns["DateClose"].DefaultCellStyle.Format = "dd.MM.yyyy";
            dgvPrintInfo.Sort(dgvPrintInfo.Columns["DateClose"], ListSortDirection.Ascending);
        }

        private string FormatNumberRows(double value)
        {
            return value.ToString("N0", CultureInfo.InvariantCulture);
        }

        private void StartParserThread()
        {
            Thread test = new Thread(() =>
            {
                try
                {
                    CentralBankParser cbParser = new CentralBankParser(currencys);
                    var result = cbParser.CB_Parser();
                    CurrencyDataReady?.Invoke(result);
                    retryCount = 0;
                }
                catch (Exception ex)
                {
                    loggerMainForm.Error($"{ex.Message}");
                }
            });
            test.Start();
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                ColomnsDataGridAdded();
                RowsDataGridAdded(addDep);
                addDep = true;
                StartParserThread();
            }
            catch (ThreadStartException tse)
            {
                loggerMainForm.Error($"{tse.Message}");

                if (retryCount < maxRetryes)
                {
                    retryCount++;
                    loggerMainForm.Info($"Повторная попытка {retryCount} из {maxRetryes}");
                    Thread.Sleep(1000);
                    StartParserThread();
                }
                else
                {
                    loggerMainForm.Error("Превышено максимальное количество попыток");
                }
            }
            catch (Exception ex)
            {
                loggerMainForm.Error($"{ex.Message}");
            }
        }

        private void btnAddDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                bankDeposits = new List<BankDepModel>();
                AddDepositForm addDepositForm = new AddDepositForm(this, currencys, bankDeposits);
                addDepositForm.ShowDialog();
                CalculationData calcData = new CalculationData(bankDeposits);
                calcData.GetCalcDeposits();
                RowsDataGridAdded(addDep);
            }
            catch (Exception ex)
            {
                loggerMainForm.Error($"{ex.Message}");
            }
        }

        private void btnDelDep_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"Вы дейстительно хотите удалить вклад {dgvPrintInfo.Rows[indexRow].Cells[0].Value} " +
                $"с вкладом {dgvPrintInfo.Rows[indexRow].Cells[1].Value}?", "Предупреждение", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (indexRow >= 0)
                {
                    dgvPrintInfo.Rows.RemoveAt(indexRow);
                    dgvPrintInfo.Refresh();
                    csvWorking.Writer(csvDataTablePath, dgvPrintInfo);
                }

                else
                {
                    MessageBox.Show($"Удаление невозможно, так как строка с индексом {indexRow} не существует.");
                    loggerMainForm.Error($"Удаление невозможно, так как строка с индексом {indexRow} не существует.");
                }
            }
            else
            {
                return;
            }
        }

        private void CheckColorRows(DateTime tDate, DateTime dToday, int rIndex)
        {
            if (tDate >= dToday.AddDays(3))
            {
                dgvPrintInfo.Rows[rIndex].DefaultCellStyle.BackColor = Color.Green;
            }
            else if (tDate < dToday)
            {
                dgvPrintInfo.Rows[rIndex].DefaultCellStyle.BackColor = Color.Red;
            }
            else
            {
                dgvPrintInfo.Rows[rIndex].DefaultCellStyle.BackColor = Color.Yellow;
            }
        }

        private void dgvPrintInfo_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvPrintInfo.CurrentRow != null && dgvPrintInfo.CurrentRow.Index >= 0)
            {
                btnDelDep.Enabled = true;
                indexRow = dgvPrintInfo.CurrentRow.Index;
            }
            else
            {
                btnDelDep.Enabled = false;
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            CheckValidateDeposits(colorDep, countRedDep);
        }

        //такой метод уже есть, надо выносить его отдельно
        private string RemovedCharacters(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return Regex.Replace(value, @"[^\d.]", "");
        }

        private void dgvPrintInfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string bankName = dgvPrintInfo.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            double deposit =
                Convert.ToDouble(
                    RemovedCharacters(dgvPrintInfo.Rows[e.RowIndex].Cells["TotalDeposit"].Value.ToString()));
            int term = Convert.ToInt32(RemovedCharacters(dgvPrintInfo.Rows[e.RowIndex].Cells["Term"].Value.ToString()));
            double bid =
                Convert.ToDouble(RemovedCharacters(dgvPrintInfo.Rows[e.RowIndex].Cells["Bid"].Value.ToString()));
            DateTime dateOpen = Convert.ToDateTime(dgvPrintInfo.Rows[e.RowIndex].Cells["DateOpen"].Value.ToString());
            InformationForm infoForm = new InformationForm(bankName, deposit, term, bid, dateOpen);
            infoForm.ShowDialog();
        }
    }
}