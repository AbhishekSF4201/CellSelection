using Syncfusion.Maui.Data;
using Syncfusion.Maui.DataGrid;
using System.Collections.ObjectModel;
namespace MauiApp1;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}
    private void picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        if (selectedIndex == 1)
        {
            this.dataGrid.SelectionMode = DataGridSelectionMode.Single;
        }
        else if (selectedIndex == 2)
        {
            this.dataGrid.SelectionMode = DataGridSelectionMode.SingleDeselect;
        }
        else if (selectedIndex == 3)
        {
            this.dataGrid.SelectionMode = DataGridSelectionMode.Multiple;
        }
        else if (selectedIndex == 4)
        {
            dataGrid.GroupColumnDescriptions.Add(new GroupColumnDescription()
            {
                ColumnName = "ShipCity",
            });
            DataGridSummaryRow summaryRow = new DataGridSummaryRow();
            summaryRow.Title = "Total Salary:{TotalSalary} for {ProductCount} members";
            summaryRow.ShowSummaryInRow = true;
            summaryRow.SummaryColumns.Add(new DataGridSummaryColumn()
            {
                Name = "TotalSalary",
                MappingName = "ShipCity",
                Format = "{Sum:c}",
                SummaryType = SummaryType.DoubleAggregate
            });
            summaryRow.SummaryColumns.Add(new DataGridSummaryColumn()
            {
                Name = "ProductCount",
                MappingName = "ShipCity",
                Format = "{Count}",
                SummaryType = SummaryType.CountAggregate
            });
            dataGrid.CaptionSummaryRow = summaryRow;
        }
        else if (selectedIndex == 5)
        {
            dataGrid.GroupColumnDescriptions.Add(new GroupColumnDescription()
            {
                ColumnName = "ShipCity",
            });
            DataGridSummaryRow summaryRow = new DataGridSummaryRow();
            summaryRow.ShowSummaryInRow = false;
            summaryRow.SummaryColumns.Add(new DataGridSummaryColumn()
            {
                Name = "CaptionSummary",
                MappingName = "ShipCity",
                Format = "{Count}",
                SummaryType = SummaryType.CountAggregate
            });
            dataGrid.CaptionSummaryRow = summaryRow;
        }
        else if (selectedIndex == 6)
        {
            dataGrid.GroupColumnDescriptions.Add(new GroupColumnDescription()
            {
                ColumnName = "Salary",
            });
            this.dataGrid.GroupSummaryRows.Add(new DataGridSummaryRow()
            {
                ShowSummaryInRow = true,
                Title = "Total Salary: {Salary} for {customerID} members",
                SummaryColumns = new ObservableCollection<ISummaryColumn>()
                {
                new DataGridSummaryColumn()
                {
                    Name="Salary",
                    MappingName="Salary",
                    SummaryType=SummaryType.DoubleAggregate,
                    Format="{Sum}"
                },
                new DataGridSummaryColumn()
                {
                    Name="customer",
                    MappingName="customer",
                    Format="{Count}",
                    SummaryType=SummaryType.CountAggregate
                }
                }
            });
        }
        else if (selectedIndex == 7)
        {
            dataGrid.GroupColumnDescriptions.Add(new GroupColumnDescription()
            {
                ColumnName = "Salary",
            });
            this.dataGrid.GroupSummaryRows.Add(new DataGridSummaryRow()
            {
                ShowSummaryInRow = false,
                SummaryColumns = new ObservableCollection<ISummaryColumn>()
            {
             new DataGridSummaryColumn()
            {
            Name="Salary",
            MappingName="Salary",
            SummaryType=SummaryType.DoubleAggregate,
            Format="{Sum}"
             },
                }
            });
        }
        else if (selectedIndex == 8)
        {
            DataGridTableSummaryRow summaryRow = new DataGridTableSummaryRow();
            summaryRow.Title = "Total Salary:{TotalSalary} for {ProductCount} members";
            summaryRow.ShowSummaryInRow = true;
            summaryRow.SummaryColumns.Add(new DataGridSummaryColumn()
            {
                Name = "TotalSalary",
                MappingName = "Salary",
                Format = "{Sum:C0}",
                SummaryType = SummaryType.DoubleAggregate
            });
            summaryRow.SummaryColumns.Add(new DataGridSummaryColumn()
            {
                Name = "ProductCount",
                MappingName = "Salary",
                Format = "{Count}",
                SummaryType = SummaryType.CountAggregate
            });
            dataGrid.TableSummaryRows.Add(summaryRow);
        }
        else if(selectedIndex == 9)
        {
            DataGridTableSummaryRow summaryRow = new DataGridTableSummaryRow();
            summaryRow.ShowSummaryInRow = false;
            summaryRow.SummaryColumns.Add(new DataGridSummaryColumn()
            {
                Name = "TableSummary",
                MappingName = "Salary",
                Format = "{Sum:C0}",
                SummaryType = SummaryType.DoubleAggregate
            });
            dataGrid.TableSummaryRows.Add(summaryRow);
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}