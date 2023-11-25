# AirTek App Documentation

## Installation

1. Clone this repository:
   ```bash
   git clone https://github.com/GabrielOGabs/AirTekTest.git
   ```
2. Navigate to the project directory:
   ```bash
   cd AirTekTest
   ```
3. Build the project:
   ```bash
   dotnet build
   ```
4. Navigate to the app folder:
   ```bash
   cd AirTek
   ```
   
## Usage
To execute the AirTek app, follow these steps:
1. Open the console or terminal.
2. Run the following command:
   ```bash
   dotnet run "{path_to_json_file}"
   ```
Replace `{path_to_json_file}` with the absolute or relative path to your JSON file.

## Output
Upon successful execution, the app will display the Schedules and Itineraries based on the provided JSON file.

## Example
   ```bash
   dotnet run "path/to/your/file.json"
   ```
## Notes
- Ensure the JSON file follows the expected format to generate accurate Schedules and Itineraries.
- For any issues or inquiries, refer to the project repository or contact the developer.