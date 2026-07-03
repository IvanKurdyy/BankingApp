using ScottPlot;
using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
namespace Banking
{
    public partial class Diagram : Form
    {
        private readonly BankingMain mainform;
        private FormsPlot pieChart;
        public Diagram(BankingMain mainform)
        {
            InitializeComponent();
            this.mainform = mainform;
            this.Text = "Диаграмма средств";
            // 2. Создайте элемент управления программно и настройте его
            this.pieChart = new FormsPlot
            {
                Dock = DockStyle.Fill // График будет растягиваться на всю панель
            };

            // 3. Добавьте созданный график на вашу панель
            // Вместо "panel1" укажите имя вашей панели
            panel1.Controls.Add(pieChart);

            // 4. Теперь можно строить графики
            UpdatePieChart();
        }

        // Ваш метод для обновления круговой диаграммы
        private void UpdatePieChart()
        {
            pieChart.Plot.Clear();

            // 1. Подготовка данных
            var values = mainform.banks.Select(bank => (double)bank.GetAllBalance().Sum()).ToArray();
            var bankNames = mainform.banks.Select(bank => bank.GetBankName()).ToArray();

            // 2. Создаем список "ломтиков" (слайсов) для диаграммы
            var slices = new List<PieSlice>();
            for (int i = 0; i < values.Length; i++)
            {
                // Пропускаем банки с нулевым балансом, чтобы не было пустых кусков
                if (values[i] > 0)
                {
                    slices.Add(new PieSlice
                    {
                        Value = values[i],
                        Label = bankNames[i], // Имя банка будет надписью на секторе
                        FillColor = GenerateColor(i) // Если нужны цвета - добавьте логику
                    });
                }
            }

            // 3. Передаем список ломтиков в метод Add.Pie
            var pie = pieChart.Plot.Add.Pie(slices);

            // 4. Настройки внешнего вида (актуальные для ScottPlot 5)         // Показать подписи (имена из Label)
            pie.SliceLabelDistance = 1.2;   // Немного отодвинуть подписи от центра, чтобы не налезали
                                            // pie.ExplodeFraction = 0.1;   // Опционально: "выдвинуть" сектора

            // Совет: В SP5 пока нет простого ShowPercentages как в SP4, 
            // но можно настроить формат вывода текста, если нужно.
            // pie.SliceLabelFormat = "{0}: {1:P1}"; // Имя и процент

            // Спрятать лишние оси
            pieChart.Plot.Axes.Frameless();
            pieChart.Plot.HideGrid();

            pieChart.Refresh();
        }

        // Простой генератор цветов для примера
        private ScottPlot.Color GenerateColor(int index)
        {
            var colors = new[] { Colors.Red, Colors.Blue, Colors.Green, Colors.Orange, Colors.Purple };
            return colors[index % colors.Length];
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
