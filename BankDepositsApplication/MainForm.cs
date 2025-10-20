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
using BankDepositsApplication.MethodsForms;
using BankDepositsApplication.Models;
using NLog;

namespace BankDepositsApplication
{
    public partial class MainForm : Form
    {
        #region Fields

        private Logger loggerMainForm = LogManager.GetCurrentClassLogger();
        private List<CurrencyModel> currencys = new List<CurrencyModel>();
        private List<BankDepModel> bankDeposits = new List<BankDepModel>();
        private CsvWorking csvWorking = new CsvWorking();
        private GeneralsMethods genMethods = new GeneralsMethods();
        public event Action<List<CurrencyModel>> CurrencyDataReady;
        private int retryCount = 0;
        private const int maxRetryes = 3;
        private bool addDep = false;
        private int indexRow = -1;
        private int colorDep = 0;
        private int countRedDep = 0;
        private bool capitalize = false;
        private int rowIndexAdded = 0;
        private static readonly SemaphoreSlim writeLock = new SemaphoreSlim(1, 1);

        private readonly string csvDataTablePath =
            Path.Combine(Directory.GetCurrentDirectory(), "InformationTable.csv");

        #endregion

        #region Constructors

        public MainForm()
        {
            InitializeComponent();
            DataGridSettings();
            btnDelDep.Enabled = false;
            loggerMainForm.Info("Приложение запущено.");
        }

        #endregion

        #region Settings Form

        private void DataGridSettings()
        {
            dgvPrintInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPrintInfo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPrintInfo.Font = new Font("Times New Roman", 12f);
            dgvPrintInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrintInfo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrintInfo.RowHeadersVisible = false;
            dgvPrintInfo.AllowUserToAddRows = false;
        }

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

        private void PanelSettings()
        {
            btnAddDeposit.Location = new Point(panelButtons.Width - btnAddDeposit.Width - 10, 10);
            btnAddDeposit.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            btnDelDep.Location = new Point(panelButtons.Width - btnDelDep.Width - btnAddDeposit.Width - 10, 10);
            btnDelDep.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            dgvPrintInfo.Location = new Point(panelDataGrid.Width - dgvPrintInfo.Width);
            dgvPrintInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        #endregion

        #region Methods

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
                        var cellDeposit = $"{genMethods.FormatNumberRows(bankDep.Deposit)} {bankDep.Currency}";
                        var cellTerm = $"{bankDep.Term} мес";
                        var cellBid = $"{bankDep.Bid} %";
                        var cellTotalDeposit = $"{genMethods.FormatNumberRows(bankDep.TotalDeposit)} руб";
                        var cellDateOpen = bankDep.DateOpen.ToShortDateString();
                        var cellDateClose = bankDep.DateClose.ToShortDateString();
                        capitalize = bankDep.Capitalization ? true : false;
                        rowIndexAdded = dgvPrintInfo.Rows.Add(cellName, cellDeposit, cellTerm, cellBid,
                            cellTotalDeposit,
                            cellDateOpen, cellDateClose);
                        DateTime targetDate = Convert.ToDateTime(cellDateClose);
                        DateTime dateToday = DateTime.Today;
                        CheckColorRows(targetDate, dateToday, rowIndexAdded);
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
                        var cellDeposit = $"{genMethods.FormatNumberRows(bankDep.Deposit)} {bankDep.CsvCurrency}";
                        var cellTerm = $"{bankDep.Term} мес";
                        var cellBid = $"{bankDep.Bid} %";
                        var cellTotalDeposit = $"{genMethods.FormatNumberRows(bankDep.TotalDeposit)} руб";
                        var cellDateOpen = bankDep.DateOpen.ToShortDateString();
                        var cellDateClose = bankDep.DateClose.ToShortDateString();
                        capitalize = bankDep.Capitalization ? true : false;
                        rowIndexAdded = dgvPrintInfo.Rows.Add(cellName, cellDeposit, cellTerm, cellBid,
                            cellTotalDeposit,
                            cellDateOpen, cellDateClose);
                        switch (bankDep.ColorRows)
                        {
                            case "R":
                                dgvPrintInfo.Rows[rowIndexAdded].DefaultCellStyle.BackColor = Color.Red;
                                colorDep = (int)VariableColor.R;
                                countRedDep++;
                                break;
                            case "Y":
                                dgvPrintInfo.Rows[rowIndexAdded].DefaultCellStyle.BackColor = Color.Yellow;
                                colorDep = (int)VariableColor.Y;
                                break;
                            case "G":
                                dgvPrintInfo.Rows[rowIndexAdded].DefaultCellStyle.BackColor = Color.Green;
                                colorDep = (int)VariableColor.G;
                                break;
                            default:
                                dgvPrintInfo.Rows[rowIndexAdded].DefaultCellStyle.BackColor = Color.White;
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

        private void UpdateDataGridRow(int rowIndex, DepositUpdatedEventArgs updatedData)
        {
            try
            {
                dgvPrintInfo.Rows[rowIndex].Cells["Name"].Value = updatedData.BankName;
                dgvPrintInfo.Rows[rowIndex].Cells["Deposit"].Value =
                    $"{genMethods.FormatNumberRows(updatedData.Deposit)} {updatedData.Currency}";
                dgvPrintInfo.Rows[rowIndex].Cells["Term"].Value = $"{updatedData.Term} мес";
                dgvPrintInfo.Rows[rowIndex].Cells["Bid"].Value = $"{updatedData.Bid} %";
                string calcTotalDep = genMethods.FormatNumberRows(genMethods.CalculationTotalDeposit(
                    updatedData.Deposit,
                    updatedData.Rate, updatedData.Bid, updatedData.Term, updatedData.Capitalization));
                dgvPrintInfo.Rows[rowIndex].Cells["TotalDeposit"].Value =
                    $"{calcTotalDep} руб";
                dgvPrintInfo.Rows[rowIndex].Cells["DateOpen"].Value = updatedData.DateOpen.ToShortDateString();
                dgvPrintInfo.Rows[rowIndex].Cells["DateClose"].Value = updatedData.DateClose;
                dgvPrintInfo.Rows[rowIndex].DefaultCellStyle.BackColor = updatedData.ColorRow;
            }
            catch (Exception ex)
            {
                loggerMainForm.Error($"{ex.Message}");
            }
        }

        private async Task WriterChangeDataDeposit()
        {
            await writeLock.WaitAsync();

            try
            {
                await Task.Run(() => { csvWorking.Writer(csvDataTablePath, dgvPrintInfo); });
            }
            finally
            {
                writeLock.Release();
            }
        }

        #endregion

        #region Buttons Action

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

        #endregion

        #region Elements Handlers

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                ColomnsDataGridAdded();
                RowsDataGridAdded(addDep);
                dgvPrintInfo.Refresh();
                dgvPrintInfo.PerformLayout();
                PanelSettings();
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

        private void MainForm_Shown(object sender, EventArgs e)
        {
            CheckValidateDeposits(colorDep, countRedDep);
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

        private void dgvPrintInfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int currentRowIndex = e.RowIndex;
            if (currentRowIndex < 0)
            {
                return;
            }

            Color color = dgvPrintInfo.Rows[e.RowIndex].DefaultCellStyle.BackColor;
            string bankName;
            double deposit;
            int term;
            double bid;
            DateTime dateOpen;
            string currency;
            if (color.Name == "Red")
            {
                bankName = dgvPrintInfo.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                deposit = Convert.ToDouble(
                    genMethods.RemovedCharacters(dgvPrintInfo.Rows[currentRowIndex].Cells["TotalDeposit"].Value
                        .ToString()));
                term = Convert.ToInt32(
                    genMethods.RemovedCharacters(dgvPrintInfo.Rows[currentRowIndex].Cells["Term"].Value.ToString()));
                bid = Convert.ToDouble(
                    genMethods.RemovedCharacters(dgvPrintInfo.Rows[currentRowIndex].Cells["Bid"].Value
                        .ToString())); // это можно поменять на реальный процент
                dateOpen = Convert.ToDateTime(dgvPrintInfo.Rows[currentRowIndex].Cells["DateClose"].Value.ToString());
                currency = genMethods.RemovedNumbers(dgvPrintInfo.Rows[currentRowIndex].Cells["TotalDeposit"].Value
                    .ToString());
                
            }
            else
            {
                bankName = dgvPrintInfo.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                deposit = Convert.ToDouble(
                    genMethods.RemovedCharacters(dgvPrintInfo.Rows[e.RowIndex].Cells["Deposit"].Value.ToString()));
                term = Convert.ToInt32(
                    genMethods.RemovedCharacters(dgvPrintInfo.Rows[e.RowIndex].Cells["Term"].Value.ToString()));
                bid = Convert.ToDouble(
                    genMethods.RemovedCharacters(dgvPrintInfo.Rows[e.RowIndex].Cells["Bid"].Value.ToString()));
                dateOpen = Convert.ToDateTime(dgvPrintInfo.Rows[e.RowIndex].Cells["DateOpen"].Value.ToString());
                currency = genMethods.RemovedNumbers(dgvPrintInfo.Rows[e.RowIndex].Cells["Deposit"].Value
                    .ToString());
            }

            foreach (var dep in bankDeposits.Where(dep => rowIndexAdded == currentRowIndex))
            {
                capitalize = dep.Capitalization;
            }

            InformationForm infoForm =
                new InformationForm(bankName, deposit, term, bid, dateOpen, currency, capitalize, currencys);
            infoForm.DepositUpdated += (s, args) => { UpdateDataGridRow(currentRowIndex, args); };
            infoForm.FormClosed += async (s, args) => { await WriterChangeDataDeposit(); };
            infoForm.ShowDialog();
        }

        #endregion
    }
}