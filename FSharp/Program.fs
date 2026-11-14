namespace Lengko.Datatables.Wpf.Demo.FSharp

open System
open System.Data
open System.Windows
open System.Windows.Controls
open System.Windows.Media
open Lengko.Datatables.Wpf

module Program =

    let createSampleTable () =
        let dt = new DataTable()
        dt.Columns.Add("Name", typeof<string>) |> ignore
        dt.Columns.Add("Position", typeof<string>) |> ignore
        dt.Columns.Add("Office", typeof<string>) |> ignore
        dt.Columns.Add("Age", typeof<int>) |> ignore
        dt.Columns.Add("Start Date", typeof<string>) |> ignore
        dt.Columns.Add("Salary", typeof<string>) |> ignore

        let rows = [|
            ("Tiger Nixon", "System Architect", "Edinburgh", 61, "2011-04-25", "$320,800")
            ("Garrett Winters", "Accountant", "Tokyo", 63, "2011-07-25", "$170,750")
            ("Ashton Cox", "Junior Technical Author", "San Francisco", 66, "2009-01-12", "$86,000")
            ("Cedric Kelly", "Senior Javascript Developer", "Edinburgh", 22, "2012-03-29", "$433,060")
            ("Airi Satou", "Accountant", "Tokyo", 33, "2008-11-28", "$162,700")
            ("Brielle Williamson", "Integration Specialist", "New York", 61, "2012-12-02", "$372,000")
            ("Herrod Chandler", "Sales Assistant", "San Francisco", 59, "2012-08-06", "$137,500")
            ("Rhona Davidson", "Integration Specialist", "Tokyo", 55, "2010-10-14", "$327,900")
            ("Colleen Hurst", "Javascript Developer", "San Francisco", 39, "2009-09-15", "$205,500")
            ("Sonya Frost", "Software Engineer", "Edinburgh", 23, "2008-12-13", "$103,600")
            ("Jena Gaines", "Office Manager", "London", 30, "2008-12-19", "$90,560")
            ("Quinn Flynn", "Support Lead", "Edinburgh", 22, "2013-03-03", "$342,000")
            ("Charde Marshall", "Regional Director", "San Francisco", 36, "2008-10-16", "$470,600")
            ("Haley Kennedy", "Senior Marketing Designer", "London", 43, "2012-12-18", "$313,500")
            ("Tatyana Fitzpatrick", "Regional Director", "London", 19, "2010-03-17", "$385,750")
            ("Michael Silva", "Marketing Designer", "London", 66, "2012-11-27", "$198,500")
            ("Paul Byrd", "Chief Financial Officer (CFO)", "New York", 64, "2010-06-09", "$725,000")
            ("Gloria Little", "Systems Administrator", "New York", 59, "2009-04-10", "$237,500")
            ("Bradley Greer", "Software Engineer", "London", 41, "2012-10-13", "$132,000")
            ("Dai Rios", "Personnel Lead", "Edinburgh", 35, "2012-09-26", "$217,500")
            ("Jenette Caldwell", "Development Lead", "New York", 30, "2011-09-03", "$345,000")
            ("Yuri Berry", "Chief Marketing Officer (CMO)", "New York", 40, "2009-06-25", "$675,000")
            ("Caesar Vance", "Pre-Sales Support", "New York", 21, "2011-12-12", "$106,450")
            ("Doris Wilder", "Sales Assistant", "Sydney", 23, "2010-09-20", "$85,600")
            ("Angelica Ramos", "Chief Executive Officer (CEO)", "London", 47, "2009-10-09", "$1,200,000")
            ("Gavin Joyce", "Developer", "Edinburgh", 42, "2010-12-22", "$92,575")
            ("Jennifer Chang", "Regional Director", "Singapore", 28, "2010-11-14", "$357,650")
            ("Brenden Wagner", "Software Engineer", "San Francisco", 28, "2011-06-07", "$206,850")
            ("Fiona Green", "Chief Operating Officer (COO)", "San Francisco", 48, "2010-03-11", "$850,000")
            ("Shou Itou", "Regional Marketing", "Tokyo", 20, "2011-08-14", "$163,000")
            ("Michelle House", "Integration Specialist", "Sydney", 37, "2011-06-02", "$95,400")
            ("Suki Burks", "Developer", "London", 53, "2009-10-22", "$114,500")
            ("Prescott Bartlett", "Technical Author", "London", 27, "2011-05-07", "$145,000")
            ("Gavin Cortez", "Team Leader", "San Francisco", 22, "2008-10-26", "$235,500")
            ("Martena Mccray", "Post-Sales support", "Edinburgh", 46, "2011-03-09", "$324,050")
            ("Unity Butler", "Marketing Designer", "San Francisco", 47, "2009-12-09", "$85,675")
            ("Howard Hatfield", "Office Manager", "San Francisco", 51, "2008-12-16", "$164,500")
            ("Hope Fuentes", "Secretary", "San Francisco", 41, "2010-02-12", "$109,850")
            ("Vivian Harrell", "Financial Controller", "San Francisco", 62, "2009-02-14", "$452,500")
        |]

        for (name, pos, off, age, dtJoin, sal) in rows do
            dt.Rows.Add(box name, box pos, box off, box age, box dtJoin, box sal) |> ignore

        dt

    let createButton text (bg: Color) onClick =
        let btn = new Button(
            Content = text,
            Background = SolidColorBrush(bg),
            Foreground = Brushes.White,
            FontWeight = FontWeights.SemiBold,
            FontSize = 12.0,
            Padding = Thickness(12.0, 6.0, 12.0, 6.0),
            Margin = Thickness(0.0, 0.0, 8.0, 6.0),
            BorderThickness = Thickness(0.0),
            Cursor = System.Windows.Input.Cursors.Hand
        )
        btn.Click.Add(fun _ -> onClick ())
        btn

    [<STAThread>]
    [<EntryPoint>]
    let main _ =
        let app = new Application()
        let win = new Window(
            Title = "Lengko.Datatables.Wpf — F# Demo",
            Width = 1180.0,
            Height = 800.0,
            MinWidth = 960.0,
            MinHeight = 620.0,
            WindowStartupLocation = WindowStartupLocation.CenterScreen,
            Background = SolidColorBrush(Color.FromRgb(248uy, 250uy, 252uy)),
            FontFamily = FontFamily("Segoe UI"),
            FontSize = 13.0
        )

        let rootGrid = new Grid(Margin = Thickness(16.0))
        rootGrid.RowDefinitions.Add(new RowDefinition(Height = GridLength.Auto))
        rootGrid.RowDefinitions.Add(new RowDefinition(Height = GridLength.Auto))
        rootGrid.RowDefinitions.Add(new RowDefinition(Height = GridLength.Auto))
        rootGrid.RowDefinitions.Add(new RowDefinition(Height = GridLength(1.0, GridUnitType.Star)))
        rootGrid.RowDefinitions.Add(new RowDefinition(Height = GridLength.Auto))

        // 1. Header
        let header = new StackPanel(Margin = Thickness(0.0, 0.0, 0.0, 12.0))
        let txtTitle = new TextBlock(
            Text = "Lengko.Datatables Demo (F# WPF)",
            FontSize = 20.0,
            FontWeight = FontWeights.Bold,
            Foreground = SolidColorBrush(Color.FromRgb(15uy, 23uy, 42uy))
        )
        let txtSubtitle = new TextBlock(
            Text = "Inspired by DataTables.net. Zero external dependencies. Instant search, pagination, export, filters & summaries.",
            FontSize = 13.0,
            Foreground = SolidColorBrush(Color.FromRgb(100uy, 116uy, 139uy)),
            Margin = Thickness(0.0, 2.0, 0.0, 0.0)
        )
        header.Children.Add(txtTitle) |> ignore
        header.Children.Add(txtSubtitle) |> ignore
        Grid.SetRow(header, 0)
        rootGrid.Children.Add(header) |> ignore

        // 4. DataGrid & Table Card (declare early for event wiring)
        let dataGrid = new LengkoDataTableGrid(
            PageLength = 10,
            ZebraStriping = true,
            FilterRowEnabled = true,
            ShowFooterSummary = true
        )
        dataGrid.SetColumnSummary("Salary", DataTableSummaryType.Count)
        dataGrid.SetColumnSummary("Age", DataTableSummaryType.Average)

        dataGrid.ChildRowHeight <- 55.0
        dataGrid.ChildRowTextFactory <- Func<obj, string>(fun row ->
            match box row with
            | :? DataRow as dr ->
                sprintf "👤 %O — %O (%O) | Compensation: %O | Joined: %O" dr["Name"] dr["Position"] dr["Office"] dr["Salary"] dr["Start Date"]
            | _ -> if obj.ReferenceEquals(row, null) then "" else row.ToString())

        let tableLength = new LengkoDataTableLength(Grid = dataGrid)
        let tableButtons = new LengkoDataTableButtons(Grid = dataGrid, ShowColVis = true, ShowResetFilter = true)
        let tableSearch = new LengkoDataTableSearch(Grid = dataGrid, PlaceholderText = "Search employees...")
        let filterChips = new LengkoDataTableFilterChips(Grid = dataGrid, ColumnName = "Office", ShowCounts = true)
        let tableInfo = new LengkoDataTableInfo(Grid = dataGrid, VerticalAlignment = VerticalAlignment.Center)
        let tablePagination = new LengkoDataTablePagination(Grid = dataGrid, HorizontalAlignment = HorizontalAlignment.Right, VerticalAlignment = VerticalAlignment.Center)

        let tableCard = new Border(
            Background = Brushes.White,
            BorderBrush = SolidColorBrush(Color.FromRgb(226uy, 232uy, 240uy)),
            BorderThickness = Thickness(1.0),
            CornerRadius = CornerRadius(6.0),
            Padding = Thickness(12.0)
        )

        // 2. Feature Bar
        let featureBar = new WrapPanel(Margin = Thickness(0.0, 0.0, 0.0, 10.0))

        let mutable isDark = false
        let mutable savedState : string option = None
        let mutable isConditional = false

        let txtChipsLabel = new TextBlock(
            Text = "Office Quick Filter:",
            FontWeight = FontWeights.SemiBold,
            Foreground = SolidColorBrush(Color.FromRgb(51uy, 65uy, 85uy)),
            VerticalAlignment = VerticalAlignment.Center,
            Margin = Thickness(0.0, 0.0, 10.0, 0.0)
        )

        let txtTips = new TextBlock(
            Text = "💡 Tips: Ketik langsung di Filter Row bawah header kolom. Klik header untuk sortir, klik kanan untuk ColVis & Filter unik, atau switch Theme Dark/Light.",
            FontSize = 12.0,
            Foreground = SolidColorBrush(Color.FromRgb(100uy, 116uy, 139uy)),
            Margin = Thickness(2.0, 8.0, 0.0, 0.0)
        )

        let btnTheme = createButton "Theme: Light" (Color.FromRgb(71uy, 85uy, 105uy)) ignore
        btnTheme.Click.Add(fun _ ->
            isDark <- not isDark
            btnTheme.Content <- if isDark then "Theme: Dark" else "Theme: Light"
            let theme = if isDark then LengkoDataTableTheme.Dark else LengkoDataTableTheme.Light
            LengkoDataTableThemeScope.DefaultTheme <- theme
            LengkoDataTableThemeScope.ApplyToTree(win, theme)

            win.Background <- SolidColorBrush(if isDark then Color.FromRgb(15uy, 23uy, 42uy) else Color.FromRgb(248uy, 250uy, 252uy))
            tableCard.Background <- SolidColorBrush(if isDark then Color.FromRgb(30uy, 41uy, 59uy) else Colors.White)
            tableCard.BorderBrush <- SolidColorBrush(if isDark then Color.FromRgb(51uy, 65uy, 85uy) else Color.FromRgb(226uy, 232uy, 240uy))
            txtTitle.Foreground <- SolidColorBrush(if isDark then Colors.White else Color.FromRgb(15uy, 23uy, 42uy))
            txtSubtitle.Foreground <- SolidColorBrush(if isDark then Color.FromRgb(148uy, 163uy, 184uy) else Color.FromRgb(100uy, 116uy, 139uy))
            txtChipsLabel.Foreground <- SolidColorBrush(if isDark then Color.FromRgb(226uy, 232uy, 240uy) else Color.FromRgb(51uy, 65uy, 85uy))
            txtTips.Foreground <- SolidColorBrush(if isDark then Color.FromRgb(148uy, 163uy, 184uy) else Color.FromRgb(100uy, 116uy, 139uy))
        )
        featureBar.Children.Add(btnTheme) |> ignore

        let btnFilterRow = createButton "Filter Row: On" (Color.FromRgb(59uy, 130uy, 246uy)) ignore
        btnFilterRow.Click.Add(fun _ ->
            dataGrid.FilterRowEnabled <- not dataGrid.FilterRowEnabled
            btnFilterRow.Content <- if dataGrid.FilterRowEnabled then "Filter Row: On" else "Filter Row: Off"
        )
        featureBar.Children.Add(btnFilterRow) |> ignore

        let btnMultiSelect = createButton "Multi-Select: Off" (Color.FromRgb(16uy, 185uy, 129uy)) ignore
        btnMultiSelect.Click.Add(fun _ ->
            dataGrid.MultiSelectCheckbox <- not dataGrid.MultiSelectCheckbox
            btnMultiSelect.Content <- if dataGrid.MultiSelectCheckbox then "Multi-Select: On" else "Multi-Select: Off"
        )
        featureBar.Children.Add(btnMultiSelect) |> ignore

        let btnSummary = createButton "Summary: On" (Color.FromRgb(139uy, 92uy, 246uy)) ignore
        btnSummary.Click.Add(fun _ ->
            dataGrid.ShowFooterSummary <- not dataGrid.ShowFooterSummary
            btnSummary.Content <- if dataGrid.ShowFooterSummary then "Summary: On" else "Summary: Off"
        )
        featureBar.Children.Add(btnSummary) |> ignore

        let btnRowGroup = createButton "Group by Office: Off" (Color.FromRgb(245uy, 158uy, 11uy)) ignore
        btnRowGroup.Click.Add(fun _ ->
            dataGrid.RowGroupEnabled <- not dataGrid.RowGroupEnabled
            dataGrid.RowGroupColumnName <- if dataGrid.RowGroupEnabled then "Office" else ""
            btnRowGroup.Content <- if dataGrid.RowGroupEnabled then "Group by Office: On" else "Group by Office: Off"
        )
        featureBar.Children.Add(btnRowGroup) |> ignore

        let btnChildRows = createButton "Child Rows: Off" (Color.FromRgb(5uy, 150uy, 105uy)) ignore
        btnChildRows.Click.Add(fun _ ->
            dataGrid.ChildRowsEnabled <- not dataGrid.ChildRowsEnabled
            btnChildRows.Content <- if dataGrid.ChildRowsEnabled then "Child Rows: On" else "Child Rows: Off"
        )
        featureBar.Children.Add(btnChildRows) |> ignore

        let btnConditional = createButton "Format (Age ≥ 60): Off" (Color.FromRgb(220uy, 38uy, 38uy)) ignore
        btnConditional.Click.Add(fun _ ->
            isConditional <- not isConditional
            btnConditional.Content <- if isConditional then "Format (Age ≥ 60): On" else "Format (Age ≥ 60): Off"
            dataGrid.ConditionalFormats.Clear()
            if isConditional then
                dataGrid.AddConditionalFormat(
                    "Age",
                    Func<obj, bool>(fun valObj ->
                        match valObj with
                        | :? int as age -> age >= 60
                        | _ -> false),
                    Nullable(Color.FromRgb(254uy, 226uy, 226uy)),
                    Nullable(Color.FromRgb(185uy, 28uy, 28uy)),
                    true
                )
            dataGrid.RefreshData()
        )
        featureBar.Children.Add(btnConditional) |> ignore

        let btnSaveState = createButton "Save State" (Color.FromRgb(14uy, 165uy, 233uy)) (fun () ->
            savedState <- Some (dataGrid.SaveStateJson())
            MessageBox.Show("Grid state saved (page, sort, search, filters)!", "State Saved", MessageBoxButton.OK, MessageBoxImage.Information) |> ignore
        )
        featureBar.Children.Add(btnSaveState) |> ignore

        let btnRestoreState = createButton "Restore State" (Color.FromRgb(14uy, 165uy, 233uy)) (fun () ->
            match savedState with
            | Some st ->
                dataGrid.RestoreStateJson(st)
                MessageBox.Show("Grid state berhasil dipulihkan!", "State Restored", MessageBoxButton.OK, MessageBoxImage.Information) |> ignore
            | None ->
                MessageBox.Show("Belum ada state yang disimpan. Klik 'Save State' terlebih dahulu.", "Info", MessageBoxButton.OK, MessageBoxImage.Warning) |> ignore
        )
        featureBar.Children.Add(btnRestoreState) |> ignore

        let btnReset = createButton "Reset Filters" (Color.FromRgb(100uy, 116uy, 139uy)) (fun () ->
            dataGrid.ResetAllFilters()
            tableSearch.SearchText <- ""
            filterChips.SelectChip(null) |> ignore
        )
        featureBar.Children.Add(btnReset) |> ignore

        Grid.SetRow(featureBar, 1)
        rootGrid.Children.Add(featureBar) |> ignore

        // 3. Filter Chips Bar
        let chipsPanel = new StackPanel(
            Orientation = Orientation.Horizontal,
            VerticalAlignment = VerticalAlignment.Center,
            Margin = Thickness(0.0, 0.0, 0.0, 10.0)
        )
        chipsPanel.Children.Add(txtChipsLabel) |> ignore
        chipsPanel.Children.Add(filterChips) |> ignore
        Grid.SetRow(chipsPanel, 2)
        rootGrid.Children.Add(chipsPanel) |> ignore

        // 4. Table Card Layout
        let cardGrid = new Grid()
        cardGrid.RowDefinitions.Add(new RowDefinition(Height = GridLength.Auto))
        cardGrid.RowDefinitions.Add(new RowDefinition(Height = GridLength(1.0, GridUnitType.Star)))
        cardGrid.RowDefinitions.Add(new RowDefinition(Height = GridLength.Auto))

        let topBar = new Grid(Margin = Thickness(0.0, 0.0, 0.0, 10.0))
        topBar.ColumnDefinitions.Add(new ColumnDefinition(Width = GridLength.Auto))
        topBar.ColumnDefinitions.Add(new ColumnDefinition(Width = GridLength.Auto))
        topBar.ColumnDefinitions.Add(new ColumnDefinition(Width = GridLength(1.0, GridUnitType.Star)))
        topBar.ColumnDefinitions.Add(new ColumnDefinition(Width = GridLength(260.0)))

        Grid.SetColumn(tableLength, 0)
        topBar.Children.Add(tableLength) |> ignore

        tableButtons.Margin <- Thickness(12.0, 0.0, 0.0, 0.0)
        Grid.SetColumn(tableButtons, 1)
        topBar.Children.Add(tableButtons) |> ignore

        Grid.SetColumn(tableSearch, 3)
        topBar.Children.Add(tableSearch) |> ignore

        Grid.SetRow(topBar, 0)
        cardGrid.Children.Add(topBar) |> ignore

        Grid.SetRow(dataGrid, 1)
        cardGrid.Children.Add(dataGrid) |> ignore

        let bottomBar = new Grid(Margin = Thickness(0.0, 10.0, 0.0, 0.0))
        bottomBar.ColumnDefinitions.Add(new ColumnDefinition(Width = GridLength.Auto))
        bottomBar.ColumnDefinitions.Add(new ColumnDefinition(Width = GridLength(1.0, GridUnitType.Star)))
        bottomBar.ColumnDefinitions.Add(new ColumnDefinition(Width = GridLength.Auto))

        Grid.SetColumn(tableInfo, 0)
        bottomBar.Children.Add(tableInfo) |> ignore

        Grid.SetColumn(tablePagination, 2)
        bottomBar.Children.Add(tablePagination) |> ignore

        Grid.SetRow(bottomBar, 2)
        cardGrid.Children.Add(bottomBar) |> ignore

        tableCard.Child <- cardGrid
        Grid.SetRow(tableCard, 3)
        rootGrid.Children.Add(tableCard) |> ignore

        // 5. Tips
        Grid.SetRow(txtTips, 4)
        rootGrid.Children.Add(txtTips) |> ignore

        // Load data
        let dt = createSampleTable ()
        dataGrid.DataSource <- dt
        filterChips.AutoPopulate()

        win.Content <- rootGrid
        app.Run(win)
