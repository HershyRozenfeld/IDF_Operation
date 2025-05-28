# IDF Operation – First Strike

## Project Overview

**IDF Operation – First Strike** is a console-based C# application simulating a military operation system for the Israel Defense Forces (IDF). The system models intelligence gathering, target selection, and attack execution against a terrorist organization (Hamas). It provides a user-friendly interface to manage intelligence reports, display available weapons, and execute targeted strikes, with a focus on synchronization and resource management.

The project is designed as a proof-of-concept for a command-line military operation simulator, emphasizing modularity, object-oriented design, and clear user feedback through a visually appealing console interface.

## Features

- **Intelligence Management**: Collects and displays intelligence reports on terrorist targets, including their location, weapons, and status.
- **Target Selection**: Automatically selects the highest-priority target based on a weighted algorithm combining terrorist rank and weapon threat level.
- **Weapon System**: Manages a collection of weapons with specific capabilities (e.g., effective areas, ammunition count) and tracks their usage.
- **Attack Execution**: Executes targeted strikes, ensuring proper synchronization by removing eliminated targets and depleting weapon ammunition.
- **User Interface**: Provides a visually enhanced console interface with color-coded outputs, clear formatting, and structured menus for ease of use.
- **Resource Synchronization**: Ensures that eliminated terrorists are removed from active lists and depleted weapons are tracked and optionally removed.

## Architecture

The project follows an object-oriented design with clear separation of concerns. Key entities and their roles are:

1. **IDF (Israel Defense Forces)**:

   - **AMAN (Military Intelligence Directorate)**: Manages intelligence reports (`Intel`) and selects high-priority targets based on a scoring system.
   - **Attack Units**: Handles offensive operations through a collection of `Weapon` objects, each with specific capabilities.
   - **Weapons Systems**: Represented by classes like `F16Fighter`, `Hermes460`, and `M109`, which inherit from an abstract `Weapon` class.

2. **Terrorist Organization (Hamas)**:

   - Manages a list of `Terrorist` objects, tracking their status (alive/dead), weapons, and rank.
   - Maintains separate lists for active and eliminated terrorists.

3. **Interfaces**:

   - `IIDF`: Defines IDF-related components (e.g., AMAN, Attack Units).

## Installation

### Prerequisites

- **.NET SDK**: Version 6.0 or higher.
- **Operating System**: Windows, macOS, or Linux with .NET support.
- **IDE**: Visual Studio, Visual Studio Code, or any C# compatible IDE (optional).

### Steps

1. **Clone the Repository**:

   ```bash
   git clone https://github.com/HershyRozenfeld/IDF_Operation
   cd IDF-Operation-First-Strike
   ```

2. **Restore Dependencies**: The project has no external dependencies beyond the .NET runtime. Ensure the .NET SDK is installed.

3. **Build the Project**:

   ```bash
   dotnet build
   ```

4. **Run the Application**:

   ```bash
   dotnet run
   ```

## Usage

1. Launch the application using `dotnet run`.
2. The main menu displays four options:
   - **1. Display Intelligence Reports**: Shows all active intelligence reports with terrorist details, location, and date.
   - **2. Display Available Weapons**: Lists all available weapons, their boom types, effective areas, and remaining strikes.
   - **3. Execute Attack on Target**: Selects the highest-priority target and executes a strike using a suitable weapon.
   - **4. Exit**: Terminates the application.
3. Select an option by entering a number (1–4) and follow the prompts.
4. After each action, press any key to return to the main menu.

### Example Output

```plaintext
=============================================================
                   IDF OPERATION MENU
=============================================================
1. Display Intelligence Reports
2. Display Available Weapons
3. Execute Attack on Target
4. Exit
=============================================================
Enter your choice (1-4): 3

=== Selected Target ===
│ Target Intel
│ Location: building
│ Date: 07/03/2025 13:49
│ Terrorist Info:
  Terrorist: Nabil
  - Weapons: rocket launcher
  - Rank: 5
  - Status: Alive

SUCCESS: Nabil eliminated by F16 Fighter.
Press any key to continue...
```

## Code Structure

The project is organized into the following key files:

- **Program.cs**: Main entry point, contains the console interface, menu logic, and attack execution.
- **AMAN.cs**: Manages intelligence reports and target selection based on a weighted algorithm.
- **Hamas.cs**: Represents the Hamas organization, managing active and eliminated terrorists.
- **Intel.cs**: Stores intelligence data about a terrorist, including location and date.
- **Terrorist.cs**: Defines a terrorist with attributes like name, weapons, rank, and status.
- **Weapon.cs**: Abstract base class for weapons, with derived classes like `F16Fighter`, `Hermes460`, and `M109`.
- **Attack.cs**: Represents an attack operation with associated intelligence and weapons.
- **IDF.cs**: Static class storing global IDF data, such as establishment date and weapon inventory.
- **Interfaces**:
  - `IIDF`: Interface for IDF components.

### Key Classes and Their Responsibilities

- **Program**: Orchestrates the application flow, including menu display, user input handling, and attack coordination.
- **AMAN**: Maintains a list of `Intel` objects and selects targets based on terrorist rank and weapon threat level.
- **Hamas**: Manages `Terrorist` objects, tracking their status and maintaining separate lists for active and eliminated terrorists.
- **Intel**: Stores data about a terrorist's location and the timestamp of the intelligence report.
- **Terrorist**: Represents an individual terrorist with properties like name, weapons, rank, and status (alive/dead).
- **Weapon**: Abstract class defining weapon properties (name, boom type, effective area, strikes) and behavior (`setStrike`).
- **Attack**: Encapsulates an attack operation, linking intelligence data with available weapons.

## Design Considerations

- **Synchronization**: The system ensures that eliminated terrorists are removed from both the `Hamas` active list and `AMAN` intelligence reports. Depleted weapons are tracked and optionally removed from the inventory.
- **User Interface**: Color-coded outputs (e.g., magenta for headers, green for success, red for failures) and structured formatting (using box-drawing characters) enhance readability.
- **Extensibility**: The use of abstract classes (`Weapon`, `Attack`) and interface (`IIDF`) allows for easy addition of new weapons or organizations.
- **Error Handling**: Invalid user inputs are handled gracefully with clear error messages.

## Future Improvements

- **Advanced Target Selection**: Incorporate additional criteria, such as location proximity or time sensitivity.
- **Weapon Management**: Allow users to select specific weapons for attacks or replenish ammunition.
- **Statistics Dashboard**: Add a menu option to display summary statistics (e.g., total strikes executed, terrorists eliminated).
- **Persistence**: Save the state of the system (e.g., terrorists, weapons) to a file for continuity between sessions.
- **Graphical Interface**: Transition to a GUI-based interface using frameworks like WPF or Blazor for a more modern user experience.
