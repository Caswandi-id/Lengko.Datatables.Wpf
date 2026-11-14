using System;
using System.Data;
using System.Windows;
using System.Windows.Media;
using Lengko.Datatables.Wpf;

namespace Lengko.Datatables.Wpf.Demo.CSharp;

public partial class MainWindow : Window
{
    private bool _isDark = false;
    private string? _savedState = null;
    private bool _isConditionalFormatted = false;

    public MainWindow()
    {
        InitializeComponent();

        // Connect toolbar controls to the grid
        TableLength.Grid = DataGrid;
        TableButtons.Grid = DataGrid;
        TableSearch.Grid = DataGrid;
        FilterChips.Grid = DataGrid;
        TableInfo.Grid = DataGrid;
        TablePagination.Grid = DataGrid;

        // Configure summaries
        DataGrid.SetColumnSummary("Salary", DataTableSummaryType.Count);
        DataGrid.SetColumnSummary("Age", DataTableSummaryType.Average);
        DataGrid.ShowFooterSummary = true;

        // Enable Filter Row by default so users can test live typing immediately
        DataGrid.FilterRowEnabled = true;

        // Configure Child Rows detail expander
        DataGrid.ChildRowHeight = 55;
        DataGrid.ChildRowTextFactory = row =>
        {
            if (row is DataRow dr)
            {
                return $"👤 {dr["Name"]} — {dr["Position"]} ({dr["Office"]}) | Compensation: {dr["Salary"]} | Joined: {dr["Start Date"]}";
            }
            return row?.ToString() ?? string.Empty;
        };

        // Load sample data
        LoadData();
    }

    private void LoadData()
    {
        var dt = new DataTable();
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("Position", typeof(string));
        dt.Columns.Add("Office", typeof(string));
        dt.Columns.Add("Age", typeof(int));
        dt.Columns.Add("Start Date", typeof(string));
        dt.Columns.Add("Salary", typeof(string));

        dt.Rows.Add("Tiger Nixon", "System Architect", "Edinburgh", 61, "2011-04-25", "$320,800");
        dt.Rows.Add("Garrett Winters", "Accountant", "Tokyo", 63, "2011-07-25", "$170,750");
        dt.Rows.Add("Ashton Cox", "Junior Technical Author", "San Francisco", 66, "2009-01-12", "$86,000");
        dt.Rows.Add("Cedric Kelly", "Senior Javascript Developer", "Edinburgh", 22, "2012-03-29", "$433,060");
        dt.Rows.Add("Airi Satou", "Accountant", "Tokyo", 33, "2008-11-28", "$162,700");
        dt.Rows.Add("Brielle Williamson", "Integration Specialist", "New York", 61, "2012-12-02", "$372,000");
        dt.Rows.Add("Herrod Chandler", "Sales Assistant", "San Francisco", 59, "2012-08-06", "$137,500");
        dt.Rows.Add("Rhona Davidson", "Integration Specialist", "Tokyo", 55, "2010-10-14", "$327,900");
        dt.Rows.Add("Colleen Hurst", "Javascript Developer", "San Francisco", 39, "2009-09-15", "$205,500");
        dt.Rows.Add("Sonya Frost", "Software Engineer", "Edinburgh", 23, "2008-12-13", "$103,600");
        dt.Rows.Add("Jena Gaines", "Office Manager", "London", 30, "2008-12-19", "$90,560");
        dt.Rows.Add("Quinn Flynn", "Support Lead", "Edinburgh", 22, "2013-03-03", "$342,000");
        dt.Rows.Add("Charde Marshall", "Regional Director", "San Francisco", 36, "2008-10-16", "$470,600");
        dt.Rows.Add("Haley Kennedy", "Senior Marketing Designer", "London", 43, "2012-12-18", "$313,500");
        dt.Rows.Add("Tatyana Fitzpatrick", "Regional Director", "London", 19, "2010-03-17", "$385,750");
        dt.Rows.Add("Michael Silva", "Marketing Designer", "London", 66, "2012-11-27", "$198,500");
        dt.Rows.Add("Paul Byrd", "Chief Financial Officer (CFO)", "New York", 64, "2010-06-09", "$725,000");
        dt.Rows.Add("Gloria Little", "Systems Administrator", "New York", 59, "2009-04-10", "$237,500");
        dt.Rows.Add("Bradley Greer", "Software Engineer", "London", 41, "2012-10-13", "$132,000");
        dt.Rows.Add("Dai Rios", "Personnel Lead", "Edinburgh", 35, "2012-09-26", "$217,500");
        dt.Rows.Add("Jenette Caldwell", "Development Lead", "New York", 30, "2011-09-03", "$345,000");
        dt.Rows.Add("Yuri Berry", "Chief Marketing Officer (CMO)", "New York", 40, "2009-06-25", "$675,000");
        dt.Rows.Add("Caesar Vance", "Pre-Sales Support", "New York", 21, "2011-12-12", "$106,450");
        dt.Rows.Add("Doris Wilder", "Sales Assistant", "Sydney", 23, "2010-09-20", "$85,600");
        dt.Rows.Add("Angelica Ramos", "Chief Executive Officer (CEO)", "London", 47, "2009-10-09", "$1,200,000");
        dt.Rows.Add("Gavin Joyce", "Developer", "Edinburgh", 42, "2010-12-22", "$92,575");
        dt.Rows.Add("Jennifer Chang", "Regional Director", "Singapore", 28, "2010-11-14", "$357,650");
        dt.Rows.Add("Brenden Wagner", "Software Engineer", "San Francisco", 28, "2011-06-07", "$206,850");
        dt.Rows.Add("Fiona Green", "Chief Operating Officer (COO)", "San Francisco", 48, "2010-03-11", "$850,000");
        dt.Rows.Add("Shou Itou", "Regional Marketing", "Tokyo", 20, "2011-08-14", "$163,000");
        dt.Rows.Add("Michelle House", "Integration Specialist", "Sydney", 37, "2011-06-02", "$95,400");
        dt.Rows.Add("Suki Burks", "Developer", "London", 53, "2009-10-22", "$114,500");
        dt.Rows.Add("Prescott Bartlett", "Technical Author", "London", 27, "2011-05-07", "$145,000");
        dt.Rows.Add("Gavin Cortez", "Team Leader", "San Francisco", 22, "2008-10-26", "$235,500");
        dt.Rows.Add("Martena Mccray", "Post-Sales support", "Edinburgh", 46, "2011-03-09", "$324,050");
        dt.Rows.Add("Unity Butler", "Marketing Designer", "San Francisco", 47, "2009-12-09", "$85,675");
        dt.Rows.Add("Howard Hatfield", "Office Manager", "San Francisco", 51, "2008-12-16", "$164,500");
        dt.Rows.Add("Hope Fuentes", "Secretary", "San Francisco", 41, "2010-02-12", "$109,850");
        dt.Rows.Add("Vivian Harrell", "Financial Controller", "San Francisco", 62, "2009-02-14", "$452,500");

        DataGrid.DataSource = dt;
        FilterChips.AutoPopulate();
    }

    private void BtnTheme_Click(object sender, RoutedEventArgs e)
    {
        _isDark = !_isDark;
        BtnTheme.Content = _isDark ? "Theme: Dark" : "Theme: Light";
        var theme = _isDark ? LengkoDataTableTheme.Dark : LengkoDataTableTheme.Light;
        LengkoDataTableThemeScope.DefaultTheme = theme;
        LengkoDataTableThemeScope.ApplyToTree(this, theme);

        BtnGridStyle.Content = $"Grid Style: {DataGrid.GridStyle}";

        Background = new SolidColorBrush(_isDark ? Color.FromRgb(15, 23, 42) : Color.FromRgb(248, 250, 252));
        TableCard.Background = new SolidColorBrush(_isDark ? Color.FromRgb(30, 41, 59) : Colors.White);
        TableCard.BorderBrush = new SolidColorBrush(_isDark ? Color.FromRgb(51, 65, 85) : Color.FromRgb(226, 232, 240));
        TxtTitle.Foreground = new SolidColorBrush(_isDark ? Colors.White : Color.FromRgb(15, 23, 42));
        TxtSubtitle.Foreground = new SolidColorBrush(_isDark ? Color.FromRgb(148, 163, 184) : Color.FromRgb(100, 116, 139));
        TxtChipsLabel.Foreground = new SolidColorBrush(_isDark ? Color.FromRgb(226, 232, 240) : Color.FromRgb(51, 65, 85));
        TxtTips.Foreground = new SolidColorBrush(_isDark ? Color.FromRgb(148, 163, 184) : Color.FromRgb(100, 116, 139));
    }

    private int _gridStyleIndex = 0;
    private readonly DataTableGridStyle[] _gridStyles = (DataTableGridStyle[])Enum.GetValues(typeof(DataTableGridStyle));

    private void BtnGridStyle_Click(object sender, RoutedEventArgs e)
    {
        _gridStyleIndex = (_gridStyleIndex + 1) % _gridStyles.Length;
        var style = _gridStyles[_gridStyleIndex];
        DataGrid.GridStyle = style;
        BtnGridStyle.Content = $"Grid Style: {style}";
    }

    private void BtnFilterRow_Click(object sender, RoutedEventArgs e)
    {
        DataGrid.FilterRowEnabled = !DataGrid.FilterRowEnabled;
        BtnFilterRow.Content = DataGrid.FilterRowEnabled ? "Filter Row: On" : "Filter Row: Off";
    }

    private void BtnMultiSelect_Click(object sender, RoutedEventArgs e)
    {
        DataGrid.MultiSelectCheckbox = !DataGrid.MultiSelectCheckbox;
        BtnMultiSelect.Content = DataGrid.MultiSelectCheckbox ? "Multi-Select: On" : "Multi-Select: Off";
    }

    private void BtnSummary_Click(object sender, RoutedEventArgs e)
    {
        DataGrid.ShowFooterSummary = !DataGrid.ShowFooterSummary;
        BtnSummary.Content = DataGrid.ShowFooterSummary ? "Summary: On" : "Summary: Off";
    }

    private void BtnRowGroup_Click(object sender, RoutedEventArgs e)
    {
        DataGrid.RowGroupEnabled = !DataGrid.RowGroupEnabled;
        DataGrid.RowGroupColumnName = DataGrid.RowGroupEnabled ? "Office" : "";
        BtnRowGroup.Content = DataGrid.RowGroupEnabled ? "Group by Office: On" : "Group by Office: Off";
    }

    private void BtnChildRows_Click(object sender, RoutedEventArgs e)
    {
        DataGrid.ChildRowsEnabled = !DataGrid.ChildRowsEnabled;
        BtnChildRows.Content = DataGrid.ChildRowsEnabled ? "Child Rows: On" : "Child Rows: Off";
    }

    private void BtnConditional_Click(object sender, RoutedEventArgs e)
    {
        _isConditionalFormatted = !_isConditionalFormatted;
        BtnConditional.Content = _isConditionalFormatted ? "Format (Age ≥ 60): On" : "Format (Age ≥ 60): Off";

        DataGrid.ConditionalFormats.Clear();
        if (_isConditionalFormatted)
        {
            DataGrid.AddConditionalFormat(
                "Age",
                val => val is int age && age >= 60,
                backColor: Color.FromRgb(254, 226, 226),
                foreColor: Color.FromRgb(185, 28, 28),
                bold: true);
        }
        DataGrid.RefreshData();
    }

    private void BtnSaveState_Click(object sender, RoutedEventArgs e)
    {
        _savedState = DataGrid.SaveStateJson();
        MessageBox.Show("Grid state saved (page, sort, search, filters)!", "State Saved", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void BtnRestoreState_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(_savedState))
        {
            MessageBox.Show("Belum ada state yang disimpan. Klik 'Save State' terlebih dahulu.", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }
        DataGrid.RestoreStateJson(_savedState);
        MessageBox.Show("Grid state berhasil dipulihkan!", "State Restored", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void BtnReset_Click(object sender, RoutedEventArgs e)
    {
        DataGrid.ResetAllFilters();
        TableSearch.SearchText = string.Empty;
        FilterChips.SelectChip(null);
    }
}
