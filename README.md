<p align="center">
  <img src="logo.png" alt="Lengko Datatables WPF Logo" width="140" />
</p>

# Lengko.Datatables.Wpf — Demos & Samples

High-performance, feature-packed data table for **WPF (Windows Presentation Foundation)** inspired by DataTables.net. Zero external dependencies, pure WPF hardware-accelerated rendering.

[![Platform](https://img.shields.io/badge/Platform-WPF-brightgreen.svg)]()
[![Languages](https://img.shields.io/badge/Languages-C%23%20%7C%20VB.NET%20%7C%20F%23-blue.svg)]()
[![Target](https://img.shields.io/badge/.NET-8.0--windows-512BD4.svg)]()
[![License](https://img.shields.io/badge/License-Freeware-orange.svg)](LICENSE.txt)

---

## Projects in this Folder

| Language | Project File | Description |
|---|---|---|
| **C#** | `CSharp/Lengko.Datatables.Wpf.Demo.CSharp.csproj` | Comprehensive C# WPF showcase with search, pagination, multi-select, filter row, summary rows, row grouping, child rows, conditional formatting, and state persistence. |
| **VB.NET** | `VB/Lengko.Datatables.Wpf.Demo.VB.vbproj` | Full VB.NET WPF demo implementing toolbar controls, theme toggling, and data binding. |
| **F#** | `FSharp/Lengko.Datatables.Wpf.Demo.FSharp.fsproj` | Functional F# WPF demo with pure code UI composition, full control coverage, and data export. |

Dedicated solution: **`Lengko.Datatables.Wpf.sln`** (builds all 3 demos alongside the library).

---

## Controls & Components Demonstrated

- `LengkoDataTableGrid`: Core data table with sorting, row grouping, zebra striping, multi-select checkboxes, child rows, summary footer.
- `LengkoDataTableSearch`: Real-time search filter with debounce and clear button.
- `LengkoDataTableLength`: Page length selector dropdown (10, 25, 50, 100).
- `LengkoDataTablePagination`: Page navigation buttons with smart ellipsis.
- `LengkoDataTableInfo`: Real-time record summary counter ("Showing 1 to 10 of 39 entries").
- `LengkoDataTableFilterChips`: Active filter tag chips with quick-remove buttons.
- `LengkoDataTableButtons`: Dropdown toolbar for column visibility toggles and export commands.
- `LengkoDataTableThemeScope`: Global theme provider for Light and Dark modes.
- `LengkoDataExporter`: Built-in CSV data export engine.

---

## Quick Start / How to Run

### Via Visual Studio
Open `Lengko.Datatables.Wpf.sln`, select any demo project as Startup Project, and press `F5`.

### Via .NET CLI

```powershell
# Run C# Demo
dotnet run --project CSharp/Lengko.Datatables.Wpf.Demo.CSharp.csproj

# Run VB.NET Demo
dotnet run --project VB/Lengko.Datatables.Wpf.Demo.VB.vbproj

# Run F# Demo
dotnet run --project FSharp/Lengko.Datatables.Wpf.Demo.FSharp.fsproj
```

---

## Code Examples

### C# (XAML)
```xml
<Window xmlns:dt="clr-namespace:Lengko.Datatables.Wpf;assembly=Lengko.Datatables.Wpf">
    <Grid>
        <dt:LengkoDataTableLength x:Name="TableLength" Grid = "DataGrid" />
        <dt:LengkoDataTableSearch x:Name="TableSearch" Grid = "DataGrid" />
        <dt:LengkoDataTableGrid x:Name="DataGrid" PageLength="10" ZebraStriping="True" />
        <dt:LengkoDataTablePagination x:Name="TablePagination" Grid = "DataGrid" />
    </Grid>
</Window>
```

### VB.NET (Code-Behind)
```vb
Imports Lengko.Datatables.Wpf

TableLength.Grid = DataGrid
TableButtons.Grid = DataGrid
TableSearch.Grid = DataGrid
FilterChips.Grid = DataGrid
TableInfo.Grid = DataGrid
TablePagination.Grid = DataGrid

DataGrid.DataSource = dt
```

### F# (Code UI)
```fsharp
open Lengko.Datatables.Wpf

let dataGrid = new LengkoDataTableGrid(PageLength = 10, ZebraStriping = true)
let tableLength = new LengkoDataTableLength(Grid = dataGrid)
let tableSearch = new LengkoDataTableSearch(Grid = dataGrid)
let tablePagination = new LengkoDataTablePagination(Grid = dataGrid)

dataGrid.DataSource <- dt
```

<img width="1378" height="519" alt="image" src="https://github.com/user-attachments/assets/56f07df2-de15-4e81-b9b2-66d53e60e840" />


---

## License
Proprietary Freeware License (PFL). Free for personal, educational, and commercial use. See [LICENSE.txt](LICENSE.txt).
