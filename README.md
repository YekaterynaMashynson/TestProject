# Test Project

## Overview
This project is a simple **Vector Graphic Viewer** that reads graphical data from a **JSON file** and displays it on the screen using a **WPF application**. The viewer supports different graphical primitives such as **lines, circles, and triangles**.

## Features
- **Reads graphical objects from a JSON file**
- **Supports multiple shapes**: Lines, Circles, and Triangles
- **Displays the graphics with correct scaling** to fit the application window
- **Uses ARGB colors** for rendering shapes
- **Handles both filled and non-filled shapes**
- **Automatic proportional scaling** to fit all shapes within the available screen space
- **Extensible architecture** to support future enhancements like new shapes, new input formats (e.g., XML), or shape selection for property inspection

## JSON Input Format
The input file is a JSON file containing an array of objects. Each object represents a shape with specific properties:

### Example JSON File:
```json
[
  {
    "type": "line",
    "a": "-1,5; 3,4",
    "b": "2,2; 5,7",
    "color": "127; 255; 255; 255"
  },
  {
    "type": "circle",
    "center": "0; 0",
    "radius": 15.0,
    "filled": false,
    "color": "127; 255; 0; 0"
  },
  {
    "type": "triangle",
    "a": "-15; -20",
    "b": "15; -20,3",
    "c": "0; 21",
    "filled": true,
    "color": "127; 255; 0; 255"
  }
]
```

## Assumptions
- **Cartesian Coordinate System**: Y-axis points up (as on paper).
- **Virtual Units**: The full picture may exceed screen size and should be proportionally scaled down.
- **Color Format**: Colors are represented as **ARGB** values.
- **Valid Data**: Input data is always valid, and no validation is required.
- **Rendering Rules**:
  - **Filled Shapes**: Rendered with a border and fill.
  - **Non-Filled Shapes**: Rendered with only a border.
  - **Border Width**: Arbitrary (e.g., 1 unit).

### Prerequisites
- .NET SDK installed (version used for the project)
- Visual Studio (recommended)

## Extensibility
The solution is designed to be **easily extensible**:
1. **Adding New Shapes (e.g., Rectangle)**:
   - Implement a new shape class that follows the existing structure.
   - Update the JSON deserialization logic to recognize the new shape.
   - Modify the rendering engine to support drawing the new shape.

2. **Adding New Input Formats (e.g., XML)**:
   - Implement a new **data parser** to handle XML format.
   - Ensure the data structure remains compatible with the existing rendering logic.

3. **Adding Shape Selection & Property Inspection**:
   - Implement shape selection on mouse click.
   - Display shape properties like coordinates, color, and dimensions in an information panel.

## Technologies Used
- **C#** (WPF Application)
- **.NET Core**
- **JSON Serialization** (System.Text.Json / Newtonsoft.Json)
- **MVVM Pattern** (Optional, if implemented)

## Author
- **[Yekateryna Mashynson]**

